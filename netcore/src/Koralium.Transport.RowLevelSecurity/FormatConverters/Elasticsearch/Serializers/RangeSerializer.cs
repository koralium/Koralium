using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Serializers
{
    class RangeSerializer : JsonConverter<Models.Range>
    {
        private static JsonEncodedText _rangeText = JsonEncodedText.Encode("range");
        private static JsonEncodedText _ltText = JsonEncodedText.Encode("lt");
        private static JsonEncodedText _gtText = JsonEncodedText.Encode("gt");
        private static JsonEncodedText _gteText = JsonEncodedText.Encode("gte");
        private static JsonEncodedText _lteText = JsonEncodedText.Encode("lte");

        public override Models.Range Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Models.Range value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteStartObject(_rangeText);
            writer.WriteStartObject(value.FieldName);

            if (value.GreaterThan != null)
            {
                writer.WritePropertyName(_gtText);
                JsonSerializer.Serialize(writer, value.GreaterThan, options);
            }
            if (value.GreaterThanEqual != null)
            {
                writer.WritePropertyName(_gteText);
                JsonSerializer.Serialize(writer, value.GreaterThanEqual, options);
            }
            if (value.LessThan != null)
            {
                writer.WritePropertyName(_ltText);
                JsonSerializer.Serialize(writer, value.LessThan, options);
            }
            if (value.LessThanEqual != null)
            {
                writer.WritePropertyName(_lteText);
                JsonSerializer.Serialize(writer, value.LessThanEqual, options);
            }

            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
