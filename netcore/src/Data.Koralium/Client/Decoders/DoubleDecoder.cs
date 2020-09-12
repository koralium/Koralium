using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Client.Decoders
{
    public class DoubleDecoder : ColumnDecoder
    {
        public DoubleDecoder(int ordinal) : base(ordinal)
        {
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Doubles.Values;

            Decode(nulls, values, setter, numberOfRows);
        }

        public override string GetDataTypeName()
        {
            return "double";
        }

        public override Type GetFieldType()
        {
            return typeof(double);
        }

        public override void ReadBlock(Block block, KoraliumRow[] rows)
        {
            Decode(block, (index, val) =>
            {
                rows[index].SetData(ordinal, val);
            });
        }

        public override double GetDouble(KoraliumRow row)
        {
            return (double)row.GetData(ordinal);
        }

        public override float GetFloat(KoraliumRow row)
        {
            return (float)Convert.ChangeType(GetDouble(row), typeof(float));
        }

        public override decimal GetDecimal(KoraliumRow row)
        {
            return (decimal)Convert.ChangeType(GetDouble(row), typeof(decimal));
        }
    }
}
