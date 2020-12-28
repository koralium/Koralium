using Apache.Arrow;
using Data.Koralium.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Decoders
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
