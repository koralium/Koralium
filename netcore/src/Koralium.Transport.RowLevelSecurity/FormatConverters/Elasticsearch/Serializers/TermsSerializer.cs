using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Serializers
{
    internal class TermsSerializer : JsonConverter<Terms>
    {
        private static readonly JsonEncodedText _termsText = JsonEncodedText.Encode("terms");

        public override Terms Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Terms value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteStartObject(_termsText);
            writer.WritePropertyName(JsonEncodedText.Encode(value.FieldName));
            JsonSerializer.Serialize(writer, value.Values, options);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
