using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Core.Utils;
using Koralium.Grpc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.Core.Decoders
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
