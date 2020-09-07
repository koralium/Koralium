using Koralium.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Grpc.Extensions
{
    public static class ColumnExtensions
    {
        public static ColumnMetadata ToColumnMetadata(this TableColumn tableColumn)
        {
            int index = tableColumn.GlobalIndex;
            return null;//tableColumn.ToColumnMetadata(ref index);
        }

        public static ColumnMetadata ToColumnMetadata(this TableColumn tableColumn, ref int globalIndex)
        {
            ColumnMetadata column = new ColumnMetadata()
            {
                ColumnId = globalIndex++,
                Name = tableColumn.Name
            };

            foreach (var child in tableColumn.Children)
            {
                column.SubColumns.Add(child.ToColumnMetadata());
            }
            return column;
        }
    }
}
