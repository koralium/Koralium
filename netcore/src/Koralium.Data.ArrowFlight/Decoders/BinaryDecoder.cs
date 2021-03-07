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
using Koralium.Data.ArrowFlight.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Data.ArrowFlight.Decoders
{
    internal class BinaryDecoder : ColumnDecoder
    {
        private BinaryArray _array;

        public override string GetDataTypeName()
        {
            return "binary";
        }

        public override long GetBytes(in int index, in long dataOffset, in byte[] buffer, in int bufferOffset, in int length)
        {
            if (buffer.Length < (bufferOffset + length))
            {
                throw new InvalidOperationException(Resources.BufferSmallerThanLength);
            }

            var span = _array.GetBytes(index);

            int maxIndex = (int)(span.Length - dataOffset);

            int i = 0;
            
            for (; i < length && i < maxIndex; i++)
            {
                buffer[bufferOffset + i] = span[(int)(i + dataOffset)];
            }

            return i;
        }

        public override Type GetFieldType()
        {
            return typeof(byte[]);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if(Equals(type, typeof(byte[])))
            {
                return GetValue(index);
            }
            throw new InvalidOperationException($"Cannot cast byte[] to {type.FullName}");
        }

        public override object GetValue(in int index)
        {
            return _array.GetBytes(index).ToArray();
        }

        public override bool IsDbNull(in int index)
        {
            return _array.IsNull(index);
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            if (arrowArray is BinaryArray binaryArray)
            {
                _array = binaryArray;
            }
            else
            {
                throw new ArgumentException(Resources.ExpectedBinaryArray, nameof(arrowArray));
            }
        }
    }
}
