using Google.Protobuf.WellKnownTypes;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Client.Decoders
{
    public class TimestampDecoder : ColumnDecoder
    {
        public TimestampDecoder(int ordinal) : base(ordinal)
        {
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Timestamps.Values;

            Decode(nulls, values, (index, value) =>
            {
                var timestamp = value as Timestamp;
                setter(index, timestamp.ToDateTime());
            }, numberOfRows);
        }

        public override string GetDataTypeName()
        {
            return "timestamp";
        }

        public override System.Type GetFieldType()
        {
            return typeof(DateTime);
        }

        public override void ReadBlock(Block block, KoraliumRow[] rows)
        {
            Decode(block, (index, val) =>
            {
                rows[index].SetData(ordinal, val);
            });
        }

        public override DateTime GetDateTime(KoraliumRow row)
        {
            return (DateTime)row.GetData(ordinal);
        }
    }
}
