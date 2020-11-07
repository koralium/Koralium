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
using Koralium.Grpc;
using System.Collections.Generic;

namespace Koralium.Encoders
{
    public class StringEncoder : IEncoder
    {
        private readonly uint columnId;
        private const uint MaxSize = 100000;
        private StringColumn _stringColumn;
        private uint currentSize = 0;
        private uint counter = 0;
        private readonly Dictionary<string, uint> _lookup = new Dictionary<string, uint>();

        public StringEncoder()
        {

        }

        public StringEncoder(uint columnId)
        {
            this.columnId = columnId;
        }

        public Block CreateBlock(Page page)
        {
            _stringColumn = new StringColumn()
            {
                ColumnId = columnId
            };

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
                _stringColumn.ClearPrevious = true;
            }

            page.Strings.Add(_stringColumn);

            return new Block()
            {
                Strings = new StringRefBlock()
            };
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            uint count = 4;

            if (!_lookup.TryGetValue(value as string, out var index))
            {
                string val = value as string;
                index = counter++;
                _lookup.Add(val, index);
                _stringColumn.Strings.Add(val);
                count += (uint)val.Length;
                currentSize += (uint)val.Length;
            }

            block.Strings.StringId.Add(index);

            return count;
        }

        public void Finish()
        {
            //No operation needed
        }
    }
}
