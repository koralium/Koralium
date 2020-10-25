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
using Data.Koralium.Client.Utils;
using Data.Koralium.Exceptions;
using Koralium.Grpc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Koralium.Client.Decoders
{
    public class ObjectDecoder : ColumnDecoder
    {
        private readonly int columnId;
        private readonly List<JObject> cache;
        private readonly BaseDecoder[] decoders;
        private readonly string[] columnNames;

        public ObjectDecoder(int ordinal, ColumnMetadata columnMetadata)
            : base(ordinal)
        {
            columnId = columnMetadata.ColumnId;
            columnNames = columnMetadata.SubColumns.Select(x => x.Name).ToArray();
            cache = new List<JObject>();

            List<BaseDecoder> decoderList = new List<BaseDecoder>();
            foreach(var child in columnMetadata.SubColumns)
            {
                //Ordinal doesnt matter for child decoders
                decoderList.Add(DecoderUtils.GetDecoder(0, child));
            }
            decoders = decoderList.ToArray();
        }

        public override void ReadBlock(Block block, KoraliumRow[] rows)
        {
            Decode(block, (index, val) =>
            {
                rows[index].SetData(ordinal, val);
            });
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var values = block.Objects.Values;

            Decode(nulls, values, (index, val) =>
            {
                if (val == null)
                {
                    setter(index, null);
                    return;
                }
                var localIndex = Convert.ToInt32(val);
                setter(index, cache[localIndex]);
            }, numberOfRows);
        }

        public override void NewPage(Page page)
        {
            for (int blockId = 0; blockId < decoders.Length; blockId++)
            {
                decoders[blockId].NewPage(page);
            }
            BuildCache(page);
            base.NewPage(page);
        }

        private void BuildCache(Page page)
        {
            var objectColumn = page.Objects.FirstOrDefault(x => x.ColumnId == columnId);

            if (objectColumn == null)
            {
                throw new KoraliumInternalException("Object column could not be found in results");
            }

            if (objectColumn.ClearPrevious)
            {
                cache.Clear();
            }

            var blocks = objectColumn.Objects.Blocks;

            List<JObject> objects = new List<JObject>();
            for (int i = 0; i < objectColumn.Count; i++)
            {
                objects.Add(new JObject());
            }
            for (int d = 0; d < decoders.Length; d++)
            {
                decoders[d].Decode(blocks[d], (index, val) =>
                {
                    objects[index].Add(columnNames[d], JToken.FromObject(val));
                });
            }

            cache.AddRange(objects);
        }

        public override Type GetFieldType()
        {
            return typeof(JObject);
        }

        public override string GetDataTypeName()
        {
            return "object";
        }

        public override T GetFieldValue<T>(KoraliumRow row)
        {
            var arr = (JObject)row.GetData(ordinal);
            if (arr == null)
                return default(T);
            return arr.ToObject<T>();
        }
    }
}
