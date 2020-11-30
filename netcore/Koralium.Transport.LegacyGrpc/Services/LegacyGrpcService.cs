using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Koralium.Grpc;
using Koralium.Shared;
using Koralium.Transport.LegacyGrpc.Encoders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium.Transport.LegacyGrpc.Services
{
    public class LegacyGrpcService : KoraliumService.KoraliumServiceBase
    {
        private LegacyGrpcExecutor _executor;
        public LegacyGrpcService(LegacyGrpcExecutor executor)
        {
            _executor = executor;
        }

        public override async Task<Scalar> QueryScalar(QueryRequest request, ServerCallContext context)
        {
            var result = await _executor.ExecuteScalar(request, context);
            return ScalarEncoder.EncodeScalarResult(result);
        }

        public override Task<TableMetadataResponse> GetTables(Empty request, ServerCallContext context)
        {
            return Task.FromResult(_executor.GetTables(context));
        }

        public override async Task Query(QueryRequest request, IServerStreamWriter<Page> responseStream, ServerCallContext context)
        {
            try
            {
                if(request.MaxBatchSize == 0)
                {
                    request.MaxBatchSize = 10000000;
                }

                Channel<Page> channel = System.Threading.Channels.Channel.CreateUnbounded<Page>();

                var getDataTask = Task.Run(async () =>
                {
                    try
                    {
                        await _executor.Query(request, channel.Writer, context);
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
    }
}
