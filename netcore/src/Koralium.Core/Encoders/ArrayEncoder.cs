using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Core.Utils;
using Koralium.Grpc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.Core.Encoders
{
    public class ArrayEncoder : IEncoder
    {
        private readonly IReadOnlyList<TableColumn> _children;
        private readonly IEncoder encoder;

        public ArrayEncoder()
        {

        }

        public ArrayEncoder(IReadOnlyList<TableColumn> children, ColumnMetadata metadata)
        {
            _children = children;
            var child = this._children.FirstOrDefault();
            encoder = EncoderHelper.GetEncoder(child.ColumnType, metadata.SubColumns.FirstOrDefault(), child.Children);
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
