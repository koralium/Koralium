using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Koralium.Transport
{
    public class QueryResult
    {
        public IQueryable Result { get; }

        public IImmutableList<Column> Columns { get; }

        public IEnumerable<KeyValuePair<string, string>> Metadata { get; }

        public QueryResult(IQueryable result, IImmutableList<Column> columns, IEnumerable<KeyValuePair<string, string>> metadata)
        {
            Result = result;
            Columns = columns;
            Metadata = metadata;
        }
    }
}
