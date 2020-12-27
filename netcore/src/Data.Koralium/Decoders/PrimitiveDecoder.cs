using Apache.Arrow;
using System;

namespace Data.Koralium.Decoders
{
    internal class PrimitiveDecoder<T> : ColumnDecoder
        where T : struct
    {
        private protected PrimitiveArray<T> Array { get; private set; }

        public override string GetDataTypeName()
        {
            return typeof(T).Name;
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            if(arrowArray is PrimitiveArray<T> primitiveArray)
            {
                Array = primitiveArray;
            }
            else
            {
                throw new ArgumentException("Expected primitive array", nameof(arrowArray));
            }
        }

        public override bool IsDbNull(in int index)
        {
            return Array.IsNull(index);
        }

        public override Type GetFieldType()
        {
            return typeof(T);
        }

        public override object GetValue(in int index)
        {
            return Array.Values[index];
        }

        public override TType GetFieldValue<TType>(in int index)
        {
            var value = Array.Values[index];

            if (value is TType toTypeValue)
            {
                return toTypeValue;
            }

            return (TType)Convert.ChangeType(Array.Values[index], typeof(T));
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if(Equals(type, typeof(T)))
            {
                return GetValue(index);
            }
            var nullableInnerType = Nullable.GetUnderlyingType(type);

            if(nullableInnerType == null)
            {
                return Convert.ChangeType(GetValue(index), type);
            }

            if(Equals(nullableInnerType, typeof(T)))
            {
                return GetValue(index);
            }
            else
            {
                return Convert.ChangeType(GetValue(index), nullableInnerType);
            }
        }
    }
}
