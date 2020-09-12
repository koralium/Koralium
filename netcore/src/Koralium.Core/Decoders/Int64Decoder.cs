using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Decoders
{
    public class Int64Decoder : BaseDecoder
    {
        public override IDecoder Create(int columnId, TableColumn column)
        {
            return new Int64Decoder();
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Longs.Values;

            Decode(nulls, values, setter, numberOfRows);
        }
    }
}
