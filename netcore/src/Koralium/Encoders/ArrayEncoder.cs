/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.Interfaces;
using Koralium.Metadata;
using Koralium.Utils;
using Koralium.Grpc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.Encoders
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
