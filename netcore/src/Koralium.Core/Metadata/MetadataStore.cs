using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Metadata
{
    public class MetadataStore
    {
        public IReadOnlyList<KoraliumTable> Tables { get; }
        private readonly Dictionary<Type, IReadOnlyList<TableColumn>> _typeLookup;
        private readonly Dictionary<string, KoraliumTable> _nameToTable = new Dictionary<string, KoraliumTable>();
        private readonly TableMetadataResponse _metadataResponse;

        public MetadataStore(IReadOnlyList<KoraliumTable> tables, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            Tables = tables;
            _typeLookup = typeLookup;

            foreach(var table in tables)
            {
                _nameToTable.Add(table.Name.ToLower(), table);
            }

            _metadataResponse = new TableMetadataResponse();

            foreach (var table in tables)
            {
                _metadataResponse.Tables.Add(table.TableMetadata);
            }
        }

        public bool TryGetTable(string name, out KoraliumTable koraliumTable)
        {
            return _nameToTable.TryGetValue(name.ToLower(), out koraliumTable);
        }

        public bool TryGetTypeColumns(Type type, out IReadOnlyList<TableColumn> columns)
        {
            return _typeLookup.TryGetValue(type, out columns);
        }

        public KoraliumTable GetTable(int id)
        {
            return Tables[id];
        }

        public TableMetadataResponse GetMetadataResponse()
        {
            return _metadataResponse;
        }
    }
}
