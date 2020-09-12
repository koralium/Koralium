using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.Core.Decoders
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
