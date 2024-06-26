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
using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models;
using System;
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
