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
using Koralium.Grpc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Data.Koralium.Client.Decoders
{
    public class ArrayDecoder : ColumnDecoder
    {
        readonly BaseDecoder childDecoder;

        public ArrayDecoder(int ordinal, ColumnMetadata columnMetadata)
            : base(ordinal)
        {
            //Arrays only have one child
            var child = columnMetadata.SubColumns.FirstOrDefault();

            Debug.Assert(child != null);

            //Ordinal doesnt matter for child decoders
            childDecoder = DecoderUtils.GetDecoder(0, child);
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
            var sizes = block.Arrays.Size;
            var values = block.Arrays.Values;

            Decode(nulls, sizes, (index, val) =>
            {
                if (val == null)
                {
                    setter(index, null);
                    return;
                }

                int size = Convert.ToInt32(val);

                var list = new JArray();

                childDecoder.Decode(values, (innerIndex, innerValue) =>
                {
                    list.Add(innerValue);
                }, size);

                setter(index, list);
            }, numberOfRows);
        }

        public override T GetFieldValue<T>(KoraliumRow row)
        {
            var arr = (JArray)row.GetData(ordinal);

            if(arr == null)
            {
                return default(T);
            }

            return arr.ToObject<T>();
        }


        public override void NewPage(Page page)
        {
            childDecoder.NewPage(page);
            base.NewPage(page);
        }

        public override Type GetFieldType()
        {
            return typeof(JArray);
        }

        public override string GetDataTypeName()
        {
            return "array";
        }
    }
}
