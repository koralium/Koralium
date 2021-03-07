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
