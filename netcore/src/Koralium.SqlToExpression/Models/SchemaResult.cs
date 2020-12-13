using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Koralium.SqlToExpression.Models
{
    public class SchemaResult
    {
        public string TableName { get; }

        public IImmutableList<ColumnMetadata> Columns { get; }
        
        public SchemaResult(string tableName, IImmutableList<ColumnMetadata> columns)
        {
            TableName = tableName;
            Columns = columns;
        }
    }
}
