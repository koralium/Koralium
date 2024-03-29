﻿/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Grpc.Core;
using Koralium.Grpc;
using Koralium.Shared;
using Koralium.Transport.Exceptions;
using Koralium.Transport.Extensions;
using Koralium.Transport.LegacyGrpc.Decoders;
using Koralium.Transport.LegacyGrpc.Encoders;
using Koralium.Transport.LegacyGrpc.Interfaces;
using Koralium.Transport.LegacyGrpc.Utils;
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
        private readonly IKoraliumTransportService _koraliumExecutor;
        public LegacyGrpcExecutor(ILogger<LegacyGrpcExecutor> logger, IKoraliumTransportService koraliumExecutor)
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

        public TableMetadataResponse GetTables(ServerCallContext context)
        {
            var tables = _koraliumExecutor.GetTables();
            var httpContext = context.GetHttpContext();

            TableMetadataResponse tableMetadataResponse = new TableMetadataResponse();

            int tableId = 0;
            var parameters = new SqlParameters();
            foreach (var table in tables)
            {
                var columns = _koraliumExecutor.GetSchema(table.SelectAllColumnsStatement(), parameters, httpContext);

                var tableMetadata = new TableMetadata()
                {
                    Name = table.Name,
                    TableId = tableId++
                };

                int columnRef = 0;
                foreach(var column in columns)
                {
                    tableMetadata.Columns.Add(ToMetadata(ref columnRef, column));
                }
                tableMetadataResponse.Tables.Add(tableMetadata);
            }

            return tableMetadataResponse;
        }

        public async Task Query(QueryRequest request, ChannelWriter<Page> channelWriter, ServerCallContext context)
        {
            var parameters = ParameterDecoder.DecodeParameters(request.Parameters);

            QueryResult queryResult;
            try
            {
                queryResult = await _koraliumExecutor.Execute(request.Query, parameters, context.GetHttpContext());
            }
            catch (AuthorizationFailedException authFailed)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, authFailed.Message));
            }

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
            System.Diagnostics.Stopwatch encodeWatch = new System.Diagnostics.Stopwatch();
            encodeWatch.Start();
            await EncoderHelper.ReadData(_logger, page, encoders, propertyGetters, enumerator, request.MaxBatchSize, channelWriter);
            encodeWatch.Stop();
            _logger.LogTrace($"Encode time: {encodeWatch.ElapsedMilliseconds} ms");
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
