using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Core.Utils;
using Koralium.Grpc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium.Core
{
    public class GrpcExecutor
    {
        private readonly KoraliumExecutor _koraliumExecutor;
        private readonly MetadataStore _metadataStore;
        public GrpcExecutor(
            KoraliumExecutor koraliumExecutor,
            MetadataStore metadataStore)
        {
            _koraliumExecutor = koraliumExecutor;
            _metadataStore = metadataStore;
        }

        public async Task Execute(QueryRequest queryRequest, HttpContext httpContext, ChannelWriter<Page> channelWriter)
        {
            var result = await _koraliumExecutor.Execute(queryRequest.Query, null, httpContext);

            IEncoder[] encoders = new IEncoder[result.Columns.Count];
            Func<object, object>[] propertyGetters = new Func<object, object>[encoders.Length];
            Page page = new Page();

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
                page.Metadata.Add(columnMetadata);
            }

            //Encode all results
            await EncoderHelper.ReadData(page, encoders, propertyGetters, result.Result.GetEnumerator(), queryRequest.MaxBatchSize, channelWriter);
        }
    }
}
