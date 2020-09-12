using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Koralium.Core.Encoders;
using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Grpc;
using Koralium.SqlToExpression.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium.Core.Services
{
    public class KoraliumGrpcService : KoraliumService.KoraliumServiceBase
    {

        private readonly GrpcExecutor _koraliumExecutor;
        private readonly MetadataStore _metadataStore;
        private readonly IServiceProvider _serviceProvider;

        public KoraliumGrpcService(
            GrpcExecutor koraliumExecutor,
            MetadataStore metadataStore,
            IServiceProvider serviceProvider)
        {
            _koraliumExecutor = koraliumExecutor;
            _metadataStore = metadataStore;
            _serviceProvider = serviceProvider;
        }

        public override Task<TableMetadataResponse> GetTables(Empty request, ServerCallContext context)
        {
            return Task.FromResult(_metadataStore.GetMetadataResponse());
        }

        public override async Task Query(QueryRequest request, IServerStreamWriter<Page> responseStream, ServerCallContext context)
        {
            try
            {
                Channel<Page> channel = System.Threading.Channels.Channel.CreateUnbounded<Page>();

                var getDataTask = Task.Run(async () =>
                {
                    try
                    {
                        await _koraliumExecutor.Execute(request, context.GetHttpContext(), channel.Writer);
                    }
                    catch (Exception e)
                    {
                        channel.Writer.Complete(e);
                    }
                });

                await channel.Reader.WaitToReadAsync();

                while (!channel.Reader.Completion.IsCompleted || getDataTask.IsFaulted)
                {
                    await channel.Reader.WaitToReadAsync();
                    if (channel.Reader.TryRead(out var batch))
                    {
                        await responseStream.WriteAsync(batch);
                    }
                }

                await getDataTask;
            }
            catch (SqlErrorException sqlException)
            {
                throw new RpcException(new Status(StatusCode.Cancelled, sqlException.Message));
            }
        }

        public override async Task<Scalar> QueryScalar(QueryRequest request, ServerCallContext context)
        {
            var result = await _koraliumExecutor.ExecuteScalar(request, context.GetHttpContext());
            return ScalarEncoder.EncodeScalarResult(result);
        }

        public override async Task GetIndex(IndexRequest request, IServerStreamWriter<Page> responseStream, ServerCallContext context)
        {
            var table = _metadataStore.GetTable(request.TableId);

            var index = table.Indices.FirstOrDefault(x => x.IndexId == request.IndexId);

            if (index == null)
            {
                throw new Exception("Index not found");
                //throw new IndexNotFoundException(request.IndexId, table.TableMetadata.SchemaTableName.TableName);
            }

            var resolver = (IIndexResolver)_serviceProvider.GetService(index.Resolver);

            Channel<Page> channel = System.Threading.Channels.Channel.CreateUnbounded<Page>();

            var getDataTask = Task.Run(async () =>
            {
                try
                {
                    await resolver.GetData(request, table, index, context, channel);
                }
                catch (Exception e)
                {
                    channel.Writer.Complete(e);
                }
            });

            await channel.Reader.WaitToReadAsync();
            while (!channel.Reader.Completion.IsCompleted || getDataTask.IsFaulted)
            {
                if (channel.Reader.TryRead(out var batch))
                {
                    await responseStream.WriteAsync(batch);
                }
            }

            await getDataTask;
        }
    }
}
