//using Google.Protobuf.WellKnownTypes;
//using Grpc.Core;
//using Koralium.Core;
//using Koralium.Core.Metadata;
//using Koralium.Grpc.Executors;
//using Koralium.Grpc.Models;
//using Koralium.SqlToExpression.Exceptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Channels;
//using System.Threading.Tasks;

//namespace Koralium.Grpc.Services
//{
//    public class KoraliumGrpcService : KoraliumService.KoraliumServiceBase
//    {
//        private readonly KoraliumGrpcStore _grpcStore;
//        private readonly GrpcExecutor _koraliumExecutor;
//        private readonly MetadataStore _metadataStore;
//        public KoraliumGrpcService(
//            KoraliumGrpcStore grpcStore,
//            GrpcExecutor koraliumExecutor,
//            MetadataStore metadataStore)
//        {
//            _grpcStore = grpcStore;
//            _koraliumExecutor = koraliumExecutor;
//            _metadataStore = metadataStore;
//        }

//        public override Task<TableMetadataResponse> GetTables(Empty request, ServerCallContext context)
//        {
//            return Task.FromResult(_grpcStore.TableMetadataResponse);
//        }

//        public override async Task Query(QueryRequest request, IServerStreamWriter<Page> responseStream, ServerCallContext context)
//        {
//            try
//            {
//                Channel<Page> channel = Channel.CreateUnbounded<Page>();

//                var getDataTask = Task.Run(async () =>
//                {
//                    try
//                    {
//                        await _koraliumExecutor.Execute(request, context.GetHttpContext(), channel.Writer);
//                    }
//                    catch (Exception e)
//                    {
//                        channel.Writer.Complete(e);
//                    }
//                });

//                await channel.Reader.WaitToReadAsync();

//                while (!channel.Reader.Completion.IsCompleted || getDataTask.IsFaulted)
//                {
//                    await channel.Reader.WaitToReadAsync();
//                    if (channel.Reader.TryRead(out var batch))
//                    {
//                        await responseStream.WriteAsync(batch);
//                    }
//                }

//                await getDataTask;
//            }
//            catch (SqlErrorException sqlException)
//            {
//                throw new RpcException(new Status(StatusCode.Cancelled, sqlException.Message));
//            }
//        }

//        public override Task GetIndex(IndexRequest request, IServerStreamWriter<Page> responseStream, ServerCallContext context)
//        {
//            var table = _metadataStore.GetTable(request.TableId);

//            var index = table.Indices.FirstOrDefault(x => x.IndexId == request.IndexId);

//            if (index == null)
//            {
//                //throw new IndexNotFoundException(request.IndexId, table.TableMetadata.SchemaTableName.TableName);
//            }

            

//            return base.GetIndex(request, responseStream, context);
//        }
//    }
//}
