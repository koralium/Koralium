using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Data.ArrowFlight.Decoders
{
    class UInt8Decoder : PrimitiveDecoder<byte>
    {
        public override int GetInt32(in int index)
        {
            return Array.Values[index];
        }

        public override short GetInt16(in int index)
        {
            return Array.Values[index];
        }

        public override long GetInt64(in int index)
        {
            return Array.Values[index];
        }

        public override byte GetByte(in int index)
        {
            return Array.Values[index];
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
