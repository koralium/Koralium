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
using System;
using System.Collections.Generic;

namespace Koralium.Encoders
{
    public class ObjectEncoder : IEncoder
    {
        private const uint MaxSize = 100000;
        private readonly IReadOnlyList<TableColumn> _children;
        private readonly int columnId;
        private readonly IEncoder[] encoders;
        private readonly Func<object, object>[] propertyGetters;
        private readonly Dictionary<object, uint> _lookup = new Dictionary<object, uint>();
        private uint currentSize = 0;
        private uint counter = 0;
        private uint currentBlockCount = 0;
        private ObjectColumn _objectColumn;

        public ObjectEncoder()
        {

        }

        public ObjectEncoder(IReadOnlyList<TableColumn> children, Grpc.ColumnMetadata metadata)
        {
            this.columnId = metadata.ColumnId;
            _children = children;

            encoders = new IEncoder[children.Count];
            propertyGetters = new Func<object, object>[children.Count];
            for(int i = 0; i < children.Count; i++)
            {
                encoders[i] = EncoderHelper.GetEncoder(children[i].ColumnType, metadata.SubColumns[i], children[i].Children);
                propertyGetters[i] = children[i].PropertyAccessor;
            }
        }

        private Columns CreateColumns(Page page)
        {
            Columns columns = new Columns();
            foreach (var encoder in encoders)
            {
                columns.Blocks.Add(encoder.CreateBlock(page));
            }
            return columns;
        }

        public Block CreateBlock(Page page)
        {
            //Reset current block size every time
            currentBlockCount = 0;

            var block = new Block()
            {
                Objects = new ObjectRefBlock()//new Columns()
            };

            _objectColumn = new ObjectColumn()
            {
                ColumnId = (uint)columnId
            };

            _objectColumn.Objects = CreateColumns(page);

            //Went over the cache limit
            if (currentSize > MaxSize)
            {
                //Clear the current size
                currentSize = 0;
                //Start the counter from 0 again
                counter = 0;
                //Clear the cache
                _lookup.Clear();
                //Set so that the previous cache should be forgotten
                _objectColumn.ClearPrevious = true;
            }

            page.Objects.Add(_objectColumn);

            return block;
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            uint count = 4;
            var blocks = _objectColumn.Objects.Blocks;
            //Check if the object has already been added
            if (!_lookup.TryGetValue(value, out var index))
            {
                index = counter++;
                for (int i = 0; i < encoders.Length; i++)
                {
                    var encoder = encoders[i];
                    var getter = propertyGetters[i];

                    var data = getter(value);

                    if (data == null)
                    {
                        blocks[i].Nulls.Add((uint)rowNumber);
                        continue;
                    }

                    count += encoder.Encode(data, blocks[i], in rowNumber);
                }
                _lookup.Add(value, index);
                currentSize += count;
                currentBlockCount++;
            }
            block.Objects.Values.Add(index);
            return count;
        }

        public void Finish()
        {
            foreach (var encoder in encoders)
            {
                encoder.Finish();
            }
            _objectColumn.Count = currentBlockCount;
        }
    }
}
