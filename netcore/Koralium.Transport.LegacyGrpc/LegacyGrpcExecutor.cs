using Grpc.Core;
using Koralium.Decoders;
using Koralium.Grpc;
using Koralium.Services;
using Koralium.SqlToExpression;
using Koralium.Transport.LegacyGrpc.Encoders;
using Koralium.Transport.LegacyGrpc.Interfaces;
using Koralium.Transport.LegacyGrpc.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium.Transport.LegacyGrpc
{
    public class LegacyGrpcExecutor
    {
        private readonly ILogger<LegacyGrpcExecutor> _logger;
        private readonly IKoraliumExecutor _koraliumExecutor;
        public LegacyGrpcExecutor(ILogger<LegacyGrpcExecutor> logger, IKoraliumExecutor koraliumExecutor)
        {
            _logger = logger;
            _koraliumExecutor = koraliumExecutor;
        }

        private Grpc.ColumnMetadata ToMetadata(ref int index, Column column)
        {
            Grpc.ColumnMetadata columnMetadata = new Grpc.ColumnMetadata()
            {
                Type = MetadataHelper.GetKoraliumType(column.Type),
                ColumnId = index++,
                Name = column.Name
            };
            foreach (var child in column.Children)
            {
                columnMetadata.SubColumns.Add(ToMetadata(ref index, child));
            }
            return columnMetadata;
        }

        public async Task Query(QueryRequest request, ChannelWriter<Page> channelWriter, ServerCallContext context)
        {
            var parameters = ParameterDecoder.DecodeParameters(request.Parameters);
            var queryResult = await _koraliumExecutor.Execute(request.Query, parameters, context.GetHttpContext());

            var enumerator = queryResult.Result.GetEnumerator();

            Page page = new Page()
            {
                Metadata = new QueryMetadata()
            };

            foreach (var metadata in queryResult.Metadata)
            {
                page.Metadata.CustomMetadata.Add(new KeyValue() { Name = metadata.Key, Value = ScalarEncoder.EncodeScalarResult(metadata.Value) });
            }

            IEncoder[] encoders = new IEncoder[queryResult.Columns.Count];
            Func<object, object>[] propertyGetters = new Func<object, object>[encoders.Length];

            int indexCounter = 0;
            for (int i = 0; i < queryResult.Columns.Count; i++)
            {
                var column = queryResult.Columns[i];

                var columnMetadata = ToMetadata(ref indexCounter, column);

                encoders[i] = EncoderHelper.GetEncoder(column.Type, columnMetadata, column.Children);
                propertyGetters[i] = column.GetFunction;
                page.Metadata.Columns.Add(columnMetadata);
            }

            await EncoderHelper.ReadData(_logger, page, encoders, propertyGetters, enumerator, request.MaxBatchSize, channelWriter);
        }

        public ValueTask<object> ExecuteScalar(QueryRequest queryRequest, ServerCallContext context)
        {
            var sqlParameters = ParameterDecoder.DecodeParameters(queryRequest.Parameters);

            Dictionary<string, object> extraDatas = new Dictionary<string, object>();
            foreach (var extraData in queryRequest.ExtraData)
            {
                extraDatas.Add(extraData.Name, ScalarDecoder.DecodeScalar(extraData.Value));
            }

            return _koraliumExecutor.ExecuteScalar(queryRequest.Query, sqlParameters, context.GetHttpContext());
        }
    }
}
