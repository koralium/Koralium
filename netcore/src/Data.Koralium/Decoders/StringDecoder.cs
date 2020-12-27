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
            if(Equals(type, typeof(string)))
            {
                return GetString(index);
            }
            return Convert.ChangeType(GetString(index), type);
        }
    }
}
