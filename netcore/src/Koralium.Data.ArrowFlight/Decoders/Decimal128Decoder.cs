using Apache.Arrow;
using Koralium.Data.ArrowFlight.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Data.ArrowFlight.Decoders
{
    class Decimal128Decoder : ColumnDecoder
    {
        private Decimal128Array _array;

        public override string GetDataTypeName()
        {
            return "decimal";
        }

        public override Type GetFieldType()
        {
            return typeof(decimal);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if (Equals(type, typeof(decimal)))
            {
                return GetValue(index);
            }
            var nullableInnerType = Nullable.GetUnderlyingType(type);

            if (nullableInnerType == null)
            {
                return Convert.ChangeType(GetValue(index), type);
            }

            if (Equals(nullableInnerType, typeof(decimal)))
            {
                return GetValue(index);
            }
            else
            {
                return Convert.ChangeType(GetValue(index), nullableInnerType);
            }
        }

        public override object GetValue(in int index)
        {
            return _array.GetValue(index);
        }

        public override bool IsDbNull(in int index)
        {
            return _array.IsNull(index);
        }

        public override decimal GetDecimal(in int index)
        {
            return _array.GetValue(index).Value;
        }

        

        internal override void NewBatch(IArrowArray arrowArray)
        {
            if (arrowArray is Decimal128Array decimalArray)
            {
                _array = decimalArray;
            }
            else
            {
                throw new ArgumentException(Resources.ExpectedDecimalArray, nameof(arrowArray));
            }
        }
    }
}
