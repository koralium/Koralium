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
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    public class ListEncoder : IJsonEncoder
    {
        private readonly Func<object, object> _getFunc;
        private readonly IJsonEncoder _childEncoder;

        public ListEncoder(Column column)
        {
            _getFunc = column.GetFunction;

            Debug.Assert(column.Children.Count == 1);

            var child = column.Children.First();

            _childEncoder = EncoderHelper.GetEncoder(child);
        }

        Func<object, object> IJsonEncoder.GetValueFunc => _getFunc;

        public void Encode(in Utf8JsonWriter utf8JsonWriter, in object row)
        {
            var val = _getFunc(row);

            if(val == null)
            {
                utf8JsonWriter.WriteNullValue();
            }
            else
            {
                var enumerable = val as IEnumerable;

                utf8JsonWriter.WriteStartArray();

                foreach(var o in enumerable)
                {
                    _childEncoder.Encode(in utf8JsonWriter, o);
                }

                utf8JsonWriter.WriteEndArray();
            }
        }
    }
}
