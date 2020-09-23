/*
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
using Koralium.Decoders;
using Koralium.Interfaces;
using Koralium.Metadata;
using Koralium.Utils;
using Koralium.Grpc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using Koralium.Encoders;

namespace Koralium
{
    public class GrpcExecutor
    {
        private readonly KoraliumExecutor _koraliumExecutor;
        private readonly MetadataStore _metadataStore;
        private readonly ILogger<GrpcExecutor> _logger;
        public GrpcExecutor(
            KoraliumExecutor koraliumExecutor,
            MetadataStore metadataStore,
            ILogger<GrpcExecutor> logger)
        {
            _koraliumExecutor = koraliumExecutor;
            _metadataStore = metadataStore;
            _logger = logger;
        }

        public ValueTask<object> ExecuteScalar(QueryRequest queryRequest, HttpContext httpContext)
        {
            var sqlParameters = ParameterDecoder.DecodeParameters(queryRequest.Parameters);

            Dictionary<string, object> extraDatas = new Dictionary<string, object>();
            foreach (var extraData in queryRequest.ExtraData)
            {
                extraDatas.Add(extraData.Name, ScalarDecoder.DecodeScalar(extraData.Value));
            }

            CustomMetadataStore customMetadataStore = new CustomMetadataStore();

            return _koraliumExecutor.ExecuteScalar(queryRequest.Query, sqlParameters, httpContext, extraDatas, customMetadataStore);
        }

        public async Task Execute(QueryRequest queryRequest, HttpContext httpContext, ChannelWriter<Page> channelWriter)
        {
            _logger.LogTrace("Parsing parameters");
            System.Diagnostics.Stopwatch parametersStopwatch = new System.Diagnostics.Stopwatch();
            parametersStopwatch.Start();
            var sqlParameters = ParameterDecoder.DecodeParameters(queryRequest.Parameters);
            parametersStopwatch.Stop();
            _logger.LogTrace($"Parsing parameters took: {parametersStopwatch.ElapsedMilliseconds} ms");


            Dictionary<string, object> extraDatas = new Dictionary<string, object>();
            foreach (var extraData in queryRequest.ExtraData)
            {
                extraDatas.Add(extraData.Name, ScalarDecoder.DecodeScalar(extraData.Value));
            }

            //Create the custom metadata store
            CustomMetadataStore customMetadataStore = new CustomMetadataStore();

            _logger.LogTrace($"Executing query: {queryRequest.Query}");
            System.Diagnostics.Stopwatch executeStopwatch = new System.Diagnostics.Stopwatch();
            executeStopwatch.Start();
            var result = await _koraliumExecutor.Execute(queryRequest.Query, sqlParameters, httpContext, extraDatas, customMetadataStore);
            var enumerator = result.Result.GetEnumerator();
            executeStopwatch.Stop();
            _logger.LogTrace($"Execute query took {executeStopwatch.ElapsedMilliseconds} ms");

            IEncoder[] encoders = new IEncoder[result.Columns.Count];
            Func<object, object>[] propertyGetters = new Func<object, object>[encoders.Length];
            Page page = new Page()
            {
                Metadata = new QueryMetadata()
            };

            //Add the custom metadata
            foreach(var customMetadata in customMetadataStore.GetMetadataValues())
            {
                page.Metadata.CustomMetadata.Add(new KeyValue() { Name = customMetadata.Key, Value = ScalarEncoder.EncodeScalarResult(customMetadata.Value) });
            }

            //Build up metadata and encoders
            int indexCounter = 0;
            for (int i = 0; i < result.Columns.Count; i++)
            {
                var column = result.Columns[i];
                ColumnMetadata columnMetadata = new ColumnMetadata()
                {
                    Type = MetadataHelper.GetKoraliumType(column.Type),
                    ColumnId = indexCounter++,
                    Name = column.Name
                };

                if (!_metadataStore.TryGetTypeColumns(column.Type, out var columns))
                {
                    columns = new List<TableColumn>();
                }

                foreach (var child in columns)
                {
                    columnMetadata.SubColumns.Add(child.ToColumnMetadata(ref indexCounter));
                }

                encoders[i] = EncoderHelper.GetEncoder(column.Type, columnMetadata, columns);
                propertyGetters[i] = column.GetFunction;
                page.Metadata.Columns.Add(columnMetadata);
            }

            //Encode all results
            _logger.LogTrace("Starting to write data");
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            await EncoderHelper.ReadData(_logger, page, encoders, propertyGetters, enumerator, queryRequest.MaxBatchSize, channelWriter);
            stopwatch.Stop();
            _logger.LogTrace($"Writing data took: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
