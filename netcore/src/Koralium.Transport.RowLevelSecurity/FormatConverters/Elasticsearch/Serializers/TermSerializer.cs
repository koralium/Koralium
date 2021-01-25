using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Serializers
{
    class TermSerializer : JsonConverter<Term>
    {
        private static JsonEncodedText _termText = JsonEncodedText.Encode("term");

        public override Term Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Term value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteStartObject(_termText);
            writer.WritePropertyName(JsonEncodedText.Encode(value.FieldName));
            JsonSerializer.Serialize(writer, value.Value, options);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
