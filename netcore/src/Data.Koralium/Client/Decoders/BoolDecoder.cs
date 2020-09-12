using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Client.Decoders
{
    public class BoolDecoder : ColumnDecoder
    {
        public BoolDecoder(int ordinal)
            : base(ordinal)
        {
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Bools.Values;

            Decode(nulls, values, setter, numberOfRows);
        }

        public override string GetDataTypeName()
        {
            return "bool";
        }

        public override Type GetFieldType()
        {
            return typeof(bool);
        }

        public override void ReadBlock(Block block, KoraliumRow[] rows)
        {
            Decode(block, (index, val) =>
            {
                rows[index].SetData(ordinal, val);
            });
        }

        public override bool GetBoolean(KoraliumRow row)
        {
            return (bool)row.GetData(ordinal);
        }
    }
}
