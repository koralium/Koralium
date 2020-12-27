using Apache.Arrow;
using System;

namespace Data.Koralium.Decoders
{
    internal class BoolDecoder : ColumnDecoder
    {
        private BooleanArray _array;
        public override bool GetBoolean(in int index)
        {
            return _array.GetBoolean(index);
        }

        public override string GetDataTypeName()
        {
            return "bool";
        }

        public override Type GetFieldType()
        {
            return typeof(bool);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if (Equals(type, typeof(bool)))
            {
                return GetValue(index);
            }
            return Convert.ChangeType(GetValue(index), type);
        }

        public override object GetValue(in int index)
        {
            return GetBoolean(index);
        }

        public override long GetInt64(in int index)
        {
            return GetBoolean(index) ? 1 : 0;
        }

        public override bool IsDbNull(in int index)
        {
            return _array.IsNull(index);
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            if (arrowArray is BooleanArray booleanArray)
            {
                _array = booleanArray;
            }
            else
            {
                throw new ArgumentException("Expected boolean array", nameof(arrowArray));
            }
        }
    }
}
