using System.Collections.Generic;

namespace Koralium.SqlToExpression.Metadata
{
    public class TablesMetadata
    {
        private readonly Dictionary<string, TableMetadata> _tables;
        public TablesMetadata()
        {
            _tables = new Dictionary<string, TableMetadata>();
        }

        public void AddTable(TableMetadata tableMetadata)
        {
            _tables.Add(tableMetadata.Name.ToLower(), tableMetadata);
        }

        public bool TryGetTable(string name, out TableMetadata tableMetadata)
        {
            return _tables.TryGetValue(name.ToLower(), out tableMetadata);
        }
    }
}
