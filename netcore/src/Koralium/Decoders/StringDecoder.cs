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
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.Decoders
{
    public class StringDecoder : BaseDecoder
    {
        private readonly int columnId;
        private readonly List<string> cache;

        public StringDecoder()
        {
            columnId = -1;
        }

        public StringDecoder(int columnId)
        {
            this.columnId = columnId;
            cache = new List<string>();
        }

        public override IDecoder Create(int columnId, TableColumn column)
        {
            return new StringDecoder(columnId);
        }

        private void BuildCache(Page page)
        {
            var stringColumn = page.Strings.FirstOrDefault(x => x.ColumnId == columnId);

            if (stringColumn == null)
            {
                //TODO
                throw new Exception();
                //throw new ColumnNotFoundException($"No column with id: {columnId} was found.");
            }

            if (stringColumn.ClearPrevious)
            {
                cache.Clear();
            }

            //Add all the strings to the cache
            cache.AddRange(stringColumn.Strings);
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Strings.StringId;

            Decode(nulls, values, (index, value) =>
            {
                setter(index, cache[Convert.ToInt32(value)]);
            }, numberOfRows);
        }

        public override void NewPage(Page page)
        {
            BuildCache(page);
            base.NewPage(page);
        }
    }
}
