using Koralium.Grpc;
using Koralium.Transport.LegacyGrpc.Interfaces;
using Koralium.Transport.LegacyGrpc.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.Transport.LegacyGrpc.Encoders
{
    class ArrayEncoder : IEncoder
    {
        private readonly IReadOnlyList<Column> _children;
        private readonly IEncoder encoder;

        public ArrayEncoder()
        {

        }

        public ArrayEncoder(IReadOnlyList<Column> children, ColumnMetadata metadata)
        {
            _children = children;
            var child = this._children.FirstOrDefault();
            encoder = EncoderHelper.GetEncoder(child.Type, metadata.SubColumns.FirstOrDefault(), child.Children);
        }

        public Block CreateBlock(Page page)
        {
            var block = new Block()
            {
                Arrays = new ArrayBlock()
            };

            block.Arrays.Values = encoder.CreateBlock(page);

            return block;
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            var list = value as IList;

            block.Arrays.Size.Add((uint)list.Count);

            uint size = 4;

            var insideBlock = block.Arrays.Values;
            for (int i = 0; i < list.Count; i++)
            {
                size += encoder.Encode(list[i], insideBlock, in rowNumber);
            }

            return size;
        }

        public void Finish()
        {
            encoder.Finish();
        }
    }
}
