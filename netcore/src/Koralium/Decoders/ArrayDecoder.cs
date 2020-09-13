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
using System.Collections;
using System.Linq;

namespace Koralium.Decoders
{
    public class ArrayDecoder : BaseDecoder
    {
        IDecoder childDecoder;
        Func<object> newObjectDelegate;
        public override IDecoder Create(int columnId, TableColumn column)
        {
            var child = column.Children.FirstOrDefault();

            return new ArrayDecoder()
            {
                childDecoder = child.Decoder.Create(child.Metadata.ColumnId, child),
                newObjectDelegate = MetadataHelper.CreateNewObjectDelegate(column.ColumnType)
            };
        }

        public override void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue)
        {
            var nulls = block.Nulls;
            var sizes = block.Arrays.Size;
            var values = block.Arrays.Values;

            Decode(nulls, sizes, (index, val) =>
            {
                int size = Convert.ToInt32(val);

                var list = newObjectDelegate() as IList;

                childDecoder.Decode(values, (innerIndex, innerValue) =>
                {
                    list.Add(innerValue);
                }, size);

                setter(index, list);
            }, numberOfRows);
        }

        public override void NewPage(Page page)
        {
            childDecoder.NewPage(page);
            base.NewPage(page);
        }
    }
}
