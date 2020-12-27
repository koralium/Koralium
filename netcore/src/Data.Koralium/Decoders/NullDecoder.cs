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

namespace Data.Koralium.Decoders
{
    /// <summary>
    /// Decoder that performs null checks
    /// Only used if a column is nullable.
    /// </summary>
    internal class NullDecoder : ColumnDecoder
    {
        private readonly ColumnDecoder _decoder;
        private readonly Type _type;

        public NullDecoder(ColumnDecoder decoder)
        {
            _decoder = decoder;

            _type = _decoder.GetFieldType();

            if(_type.IsPrimitive || _type.IsValueType)
            {
                //If it is a primitive, add nullable
                _type = typeof(Nullable<>).MakeGenericType(_type);
            }
        }

        public override string GetDataTypeName()
        {
            return _decoder.GetDataTypeName();
        }

        public override Type GetFieldType()
        {
            return _type;
        }

        private void ThrowErrorIfNull(in int index)
        {
            if (_decoder.IsDbNull(index))
            {
                throw new InvalidOperationException("No data exists for the row/column.");
            }
        }

        public override bool GetBoolean(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetBoolean(index);
        }

        public override byte GetByte(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetByte(index);
        }

        public override long GetBytes(in int index, in long dataOffset, in byte[] buffer, in int bufferOffset, in int length)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetBytes(index, dataOffset, buffer, bufferOffset, length);
        }

        public override char GetChar(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetChar(index);
        }

        public override object GetValue(in int index)
        {
            if(_decoder.IsDbNull(index))
            {
                return null;
            }
            return _decoder.GetValue(index);
        }

        public override DateTime GetDateTime(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetDateTime(index);
        }

        public override decimal GetDecimal(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetDecimal(index);
        }

        public override float GetFloat(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetFloat(index);
        }

        public override double GetDouble(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetDouble(index);
        }

        public override short GetInt16(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetInt16(index);
        }

        public override int GetInt32(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetInt32(index);
        }

        public override long GetInt64(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetInt64(index);
        }

        public override string GetString(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetString(index);
        }

        public override Guid GetGuid(in int index)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetGuid(index);
        }

        public override bool IsDbNull(in int index)
        {
            return _decoder.IsDbNull(index);
        }

        public override long GetChars(in int index, in long dataOffset, in char[] buffer, in int bufferOffset, in int length)
        {
            ThrowErrorIfNull(index);
            return _decoder.GetChars(index, dataOffset, buffer, bufferOffset, length);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if (_decoder.IsDbNull(index))
            {
                return null;
            }
            return _decoder.GetFieldValue(index, type);
        }

        public override T GetFieldValue<T>(in int index)
        {
            if (_decoder.IsDbNull(index))
            {
                return default;
            }
            return _decoder.GetFieldValue<T>(index);
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            _decoder.NewBatch(arrowArray);
        }
    }
}
