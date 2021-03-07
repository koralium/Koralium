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
