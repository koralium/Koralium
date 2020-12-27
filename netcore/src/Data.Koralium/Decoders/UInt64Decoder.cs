using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Decoders
{
    class UInt64Decoder : PrimitiveDecoder<ulong>
    {
        public override int GetInt32(in int index)
        {
            var value = GetInt64(index);

            //Check bounds
            if (value > int.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a int32 from a uint32 value and the value is larger than int32 MaxValue");
            }

            return (int)value;
        }

        public override short GetInt16(in int index)
        {
            var value = GetInt64(index);

            //Check bounds
            if (value > short.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a int16 from a uint32 value and the value is larger than int16 MaxValue");
            }

            return (short)value;
        }

        public override long GetInt64(in int index)
        {
            var value = Array.Values[index];

            if(value > long.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a int64 from a uint64 value and the value is larger than int64 MaxValue");
            }

            return (long)value;
        }

        public override byte GetByte(in int index)
        {
            var value = Array.Values[index];

            //Check bounds
            if (value > byte.MaxValue)
            {
                throw new InvalidOperationException("Trying to get a byte from a uint64 value and the value is larger than byte MaxValue");
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
