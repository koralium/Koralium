using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models
{
    class Bool : BoolOperation
    {
        [JsonPropertyName("must")]
        public List<BoolOperation> Must { get; set; }

        [JsonPropertyName("should")]
        public List<BoolOperation> Should { get; set; }

        [JsonPropertyName("must_not")]
        public List<BoolOperation> MustNot { get; set; }
    }
}
