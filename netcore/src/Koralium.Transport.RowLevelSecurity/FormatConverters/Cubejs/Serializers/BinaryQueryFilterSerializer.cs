using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Serializers
{
    class BinaryQueryFilterSerializer : JsonConverter<BinaryQueryFilter>
    {
        private static JsonEncodedText _andText = JsonEncodedText.Encode("and");
        private static JsonEncodedText _orText = JsonEncodedText.Encode("or");

        public override BinaryQueryFilter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, BinaryQueryFilter value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            
            if (value.And != null)
            {
                writer.WriteStartArray(_andText);
                foreach(var val in value.And)
                {
                    BaseQueryFilterSerializer.baseSerializer.Write(writer, val, options);
                }
                writer.WriteEndArray();
            }
            else if(value.Or != null)
            {
                writer.WriteStartArray(_orText);
                foreach(var val in value.Or)
                {
                    BaseQueryFilterSerializer.baseSerializer.Write(writer, val, options);
                }
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
