using Koralium.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Grpc.Extensions
{
    public static class MetadataStoreExtensions
    {
        public static TableMetadataResponse ToTableMetadataResponse(this MetadataStore metadataStore)
        {
            var response = new TableMetadataResponse();

            foreach(var table in metadataStore.Tables)
            {
                response.Tables.Add(table.ToTableMetadata());
            }
            return response;
        }
    }
}
