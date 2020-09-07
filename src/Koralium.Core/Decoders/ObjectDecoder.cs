using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Core.Utils;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.Core.Decoders
{
    public class ObjectDecoder : BaseDecoder
    {
        private List<IDecoder> decoders;
        private int columnId;
        List<object> cache;
        Func<object> newObjectDelegate;
        TableColumn column;

        public override IDecoder Create(int columnId, TableColumn column)
        {
            return new ObjectDecoder()
            {
                columnId = columnId,
                decoders = column.Children.Select(x => x.Decoder.Create(x.Metadata.ColumnId, x)).ToList(),
                cache = new List<object>(),
                newObjectDelegate = MetadataHelper.CreateNewObjectDelegate(column.ColumnType),
                column = column
            };
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
                }
                var localIndex = Convert.ToInt32(val);
                setter(index, cache[localIndex]);
            }, numberOfRows);
        }

        private void BuildCache(Page page)
        {
            var objectColumn = page.Objects.FirstOrDefault(x => x.ColumnId == columnId);

            if (objectColumn == null)
            {
                throw new Exception("Object column could not be found in results");
            }

            if (objectColumn.ClearPrevious)
            {
                cache.Clear();
            }

            var blocks = objectColumn.Objects.Blocks;

            List<object> objects = new List<object>();
            for (int i = 0; i < objectColumn.Count; i++)
            {
                objects.Add(newObjectDelegate());
            }
            for (int d = 0; d < decoders.Count; d++)
            {
                decoders[d].Decode(blocks[d], (index, val) =>
                {
                    column.Children[d].SetDelegate(objects[index], val);
                });
            }

            cache.AddRange(objects);
        }

        public void NewPage(Page page)
        {
            for (int blockId = 0; blockId < decoders.Count; blockId++)
            {
                decoders[blockId].NewPage(page);
            }
            BuildCache(page);
            base.NewPage(page);
        }
    }
}
