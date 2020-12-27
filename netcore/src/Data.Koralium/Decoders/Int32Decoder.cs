using Apache.Arrow;
using System;

namespace Data.Koralium.Decoders
{
    internal class Int32Decoder : PrimitiveDecoder<int>
    {
        public override int GetInt32(in int index)
        {
            return Array.Values[index];
        }

        public override short GetInt16(in int index)
        {
            var value = Array.Values[index];

            //Check bounds
            if(value > short.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a int32 value and the value is larger than int16 MaxValue");
            }
            if (value < short.MinValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a int32 value and the value is smaller than int16 MinValue");
            }

            return (short)value;
        }

        public override long GetInt64(in int index)
        {
            return Array.Values[index];
        }

        public override byte GetByte(in int index)
        {
            var value = Array.Values[index];

            //Check bounds
            if (value > byte.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a int32 value and the value is larger than byte MaxValue");
            }
            if (value < byte.MinValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a int32 value and the value is smaller than byte MinValue");
            }

            return (byte)value;
        }

        public override float GetFloat(in int index)
        {
            return Array.Values[index];
        }

        public override double GetDouble(in int index)
        {
            return Array.Values[index];
        }

        public override decimal GetDecimal(in int index)
        {
            return Array.Values[index];
        }
    }
}
