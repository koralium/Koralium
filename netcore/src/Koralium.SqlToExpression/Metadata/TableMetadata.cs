using System;

namespace Koralium.SqlToExpression.Metadata
{
    public class TableMetadata
    {
        public string Name { get; }

        public Type Type { get; }

        public TableMetadata(string name, Type type)
        {
            Name = name;
            Type = type;
        }
    }
}
