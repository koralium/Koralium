using Koralium.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Grpc.Extensions
{
    public static class TableExtensions
    {
        public static TableMetadata ToTableMetadata(this KoraliumTable koraliumTable)
        {
            var table = new TableMetadata()
            {
                Name = koraliumTable.Name,
                TableId = koraliumTable.TableId
            };

            foreach(var column in koraliumTable.Columns)
            {
                table.Columns.Add(column.ToColumnMetadata());
            }
            return table;
        }
    }
}
