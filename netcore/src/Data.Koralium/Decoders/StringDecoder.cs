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
using Data.Koralium.Properties;
using System;

namespace Data.Koralium.Decoders
{
    internal class StringDecoder : ColumnDecoder
    {
        private StringArray _array;

        public override string GetDataTypeName()
        {
            return "string";
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            if (arrowArray is StringArray stringArray)
            {
                _array = stringArray;
            }
            else
            {
                throw new ArgumentException(Resources.ExpectedStringArray, nameof(arrowArray));
            }
        }

        public override string GetString(in int index)
        {
            return _array.GetString(index);
        }

        public override char GetChar(in int index)
        {
            var value = GetString(index);

            if(value.Length == 1)
            {
                return value[0];
            }
            else if(value.Length > 1)
            {
                throw new InvalidOperationException(Resources.StringContainsMultipleCharacters);
            }
            else
            {
                throw new InvalidOperationException(Resources.NoCharactersInString);
            }
        }

        public override long GetChars(in int index, in long dataOffset, in char[] buffer, in int bufferOffset, in int length)
        {
            //Check so no out of bounds on buffer
            if(buffer.Length < (bufferOffset + length))
            {
                throw new InvalidOperationException(Resources.BufferSmallerThanLength);
            }

            var value = GetString(index);

            //Calculate the max value that the string can go to
            int maxStringIndex = (int)(value.Length - dataOffset);

            int i = 0;
            for (; i < length && i < maxStringIndex; i++)
            {
                buffer[bufferOffset + i] = value[(int)(i + dataOffset)];
            }

            return i;
        }

        public override Guid GetGuid(in int index)
        {
            var value = GetString(index);

            if(!Guid.TryParse(value, out var guid))
            {
                throw new InvalidOperationException(Resources.NotAValidGuid(value));
            }

            return guid;
        }

        public override Type GetFieldType()
        {
            return typeof(string);
        }

        public override object GetValue(in int index)
        {
            return GetString(index);
        }

        public override bool IsDbNull(in int index)
        {
            return _array.IsNull(index);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            var val = GetString(index);
            if (type.IsEnum && Enum.TryParse(type, val, out var enumValue))
            {
                return enumValue;
            }
            if (Equals(type, typeof(string)))
            {
                return val;
            }
            return Convert.ChangeType(val, type);
        }
    }
}
