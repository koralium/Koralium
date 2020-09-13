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
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Koralium.Client.Decoders
{
    public class StringDecoder : ColumnDecoder
    {
        private readonly List<string> cache;
        private readonly int _columnId;

        public StringDecoder(int ordinal, ColumnMetadata columnMetadata)
            : base(ordinal)
        {
            _columnId = columnMetadata.ColumnId;
            cache = new List<string>();
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

        private void BuildCache(Page page)
        {
            var stringColumn = page.Strings.FirstOrDefault(x => x.ColumnId == _columnId);

            if (stringColumn == null)
            {
                //TODO
                throw new Exception();
            }

            if (stringColumn.ClearPrevious)
            {
                cache.Clear();
            }

            //Add all the strings to the cache
            cache.AddRange(stringColumn.Strings);
        }

        public override void NewPage(Page page)
        {
            BuildCache(page);
            base.NewPage(page);
        }

        public override void ReadBlock(Block block, KoraliumRow[] rows)
        {
            Decode(block, (index, val) =>
            {
                rows[index].SetData(ordinal, val);
            });
        }

        public override string GetString(KoraliumRow row)
        {
            return (string)row.GetData(ordinal);
        }

        public override Type GetFieldType()
        {
            return typeof(string);
        }

        public override string GetDataTypeName()
        {
            return "string";
        }
    }
}
