using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Client.Decoders
{
    public class Int32Decoder : ColumnDecoder
    {
        public Int32Decoder(int ordinal) : base(ordinal)
        {
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Ints.Values;

            Decode(nulls, values, setter, numberOfRows);
        }

        public override string GetDataTypeName()
        {
            return "int";
        }

        public override Type GetFieldType()
        {
            return typeof(int);
        }

        public override void ReadBlock(Block block, KoraliumRow[] rows)
        {
            Decode(block, (index, val) =>
            {
                rows[index].SetData(ordinal, val);
            });
        }

        public override long GetInt64(KoraliumRow row)
        {
            return (long)Convert.ChangeType(GetInt32(row), typeof(long));
        }

        public override byte GetByte(KoraliumRow row)
        {
            return (byte)Convert.ChangeType(GetInt32(row), typeof(byte));
        }

        public override short GetInt16(KoraliumRow row)
        {
            return (short)Convert.ChangeType(GetInt32(row), typeof(short));
        }

        public override int GetInt32(KoraliumRow row)
        {
            return (int)row.GetData(ordinal);
        }

        public override double GetDouble(KoraliumRow row)
        {
            return (double)Convert.ChangeType(GetInt32(row), typeof(double));
        }

        public override float GetFloat(KoraliumRow row)
        {
            return (float)Convert.ChangeType(GetInt32(row), typeof(float));
        }

        public override decimal GetDecimal(KoraliumRow row)
        {
            return (decimal)Convert.ChangeType(GetInt32(row), typeof(decimal));
        }
    }
}
