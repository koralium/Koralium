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
using Apache.Arrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    class EnumEncoder : IArrowEncoder
    {
        private readonly Type _enumType;
        private StringArray.Builder _builder;
        private readonly Func<object, object> _getFunc;
        private readonly bool _nullable;

        private long _size;
        public EnumEncoder(Column column)
        {
            _getFunc = column.GetFunction;
            _nullable = column.IsNullable;
            _enumType = column.Type;
        }

        public IArrowArray BuildArray()
        {
            return _builder.Build();
        }

        public void NewBatch()
        {
            _size = 0;
            _builder = new StringArray.Builder();
        }

        public void Encode(object row)
        {
            var val = _getFunc(row);

            if (_nullable && val == null)
            {
                _builder.AppendNull();
            }
            else
            {
                var stringVal = Enum.GetName(_enumType, val);
                _size += stringVal.Length;
                _builder.Append(stringVal);
            }
        }

        public long Size()
        {
            return _size;
        }

        public void Pad(int length)
        {
            if (_nullable)
            {
                for (int i = 0; i < length; i++)
                {
                    _builder.AppendNull();
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    _builder.Append(string.Empty);
                }
            }
        }
    }
}
