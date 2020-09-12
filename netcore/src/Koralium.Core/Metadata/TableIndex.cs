using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Metadata
{
    public class TableIndex
    {
        public Type Resolver { get; }

        public int IndexId { get; }

        public List<TableColumn> Columns { get; }

        public string Name { get; }

        public IndexMetadata IndexMetadata { get; }

        public TableIndex(Type resolver, int indexId, List<TableColumn> columns, string name, IndexMetadata indexMetadata)
        {
            Resolver = resolver;
            IndexId = indexId;
            Columns = columns;
            Name = name;
            IndexMetadata = indexMetadata;
        }
    }
}
