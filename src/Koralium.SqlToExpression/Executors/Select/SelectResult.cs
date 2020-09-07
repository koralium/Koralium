using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Koralium.SqlToExpression.Executors.Select
{
    public class SelectResult
    {
        public IQueryable Queryable { get; }

        public IImmutableList<ColumnMetadata> Columns { get; }

        public SelectResult(IQueryable queryable, IImmutableList<ColumnMetadata> columns)
        {
            Queryable = queryable;
            Columns = columns;
        }
    }
}
