using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression
{
    public class QueryResult
    {
        public IQueryable Result { get; }

        public IImmutableList<ColumnMetadata> Columns { get; }

        internal QueryResult(IQueryable result, IImmutableList<ColumnMetadata> columns)
        {
            Result = result;
            Columns = columns;
        }
    }
}
