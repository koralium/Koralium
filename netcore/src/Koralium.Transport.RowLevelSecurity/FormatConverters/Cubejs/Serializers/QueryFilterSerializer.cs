using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Serializers
{
    class QueryFilterSerializer : JsonConverter<QueryFilter>
    {
        private static JsonEncodedText _memberText = JsonEncodedText.Encode("member");
        private static JsonEncodedText _operatorText = JsonEncodedText.Encode("operator");
        private static JsonEncodedText _valuesText = JsonEncodedText.Encode("values");

        private static readonly JsonEncodedText[] operators = new JsonEncodedText[]
        {
            JsonEncodedText.Encode("equals"), //0
            JsonEncodedText.Encode("notEquals"), //1
            JsonEncodedText.Encode("contains"), //2
            JsonEncodedText.Encode("notContains"), //3
            JsonEncodedText.Encode("gt"), //4
            JsonEncodedText.Encode("gte"), //5
            JsonEncodedText.Encode("lt"), //6
            JsonEncodedText.Encode("lte"), //7
            JsonEncodedText.Encode("set"), //8
            JsonEncodedText.Encode("notSet"), //9
            JsonEncodedText.Encode("inDateRange"), //10
            JsonEncodedText.Encode("notInDateRange"), //11
            JsonEncodedText.Encode("beforeDate"), //12
            JsonEncodedText.Encode("afterDate") //13
        };

        public override QueryFilter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, QueryFilter value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString(_memberText, value.Member);
            writer.WriteString(_operatorText, operators[(int)value.Operator]);

            writer.WriteStartArray(_valuesText);

            foreach(var val in value.Values)
            {
                writer.WriteStringValue(val);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }
    }
}
