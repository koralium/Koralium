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
using System.Collections.Generic;
using System.Text.Json;

namespace Koralium.Transport.Json.Encoders
{
    public class ObjectEncoder : IJsonEncoder
    {
        private readonly Func<object, object> _getFunc;
        private readonly IJsonEncoder[] _childEncoders;
        private readonly JsonEncodedText[] _names;
        public ObjectEncoder(Column column)
        {
            _getFunc = column.GetFunction;

            _childEncoders = new IJsonEncoder[column.Children.Count];
            _names = new JsonEncodedText[column.Children.Count];

            for(int i = 0; i < column.Children.Count; i++)
            {
                _childEncoders[i] = EncoderHelper.GetEncoder(column.Children[i]);
                _names[i] = JsonEncodedText.Encode(column.Children[i].Name);
            }
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
                utf8JsonWriter.WriteStartObject();

                for(int i = 0; i < _childEncoders.Length; i++)
                {
                    utf8JsonWriter.WritePropertyName(_names[i]);
                    _childEncoders[i].Encode(in utf8JsonWriter, val);
                }

                utf8JsonWriter.WriteEndObject();
            }
        }
    }
}
