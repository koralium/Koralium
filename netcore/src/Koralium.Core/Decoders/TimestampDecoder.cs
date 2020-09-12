using Google.Protobuf.WellKnownTypes;
using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Decoders
{
    public class TimestampDecoder : BaseDecoder
    {
        public override IDecoder Create(int columnId, TableColumn column)
        {
            return new TimestampDecoder();
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
    }
}
