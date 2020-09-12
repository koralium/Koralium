using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Metadata
{
    public class KoraliumTable
    {
        public TableMetadata TableMetadata { get; }

        public int TableId { get; }

        public string Name { get; }

        public Type Resolver { get; }

        public Type EntityType { get; }

        public IReadOnlyList<TableColumn> Columns { get; }

        public string SecurityPolicy { get; set; }

        public IReadOnlyList<TableIndex> Indices { get; }

        public KoraliumTable(
            TableMetadata tableMetadata,
            int tableId,
            string name,
            Type resolver,
            Type entityType,
            IReadOnlyList<TableColumn> columns,
            string securityPolicy,
            IReadOnlyList<TableIndex> indices)
        {
            TableMetadata = tableMetadata;
            TableId = tableId;
            Name = name;
            Resolver = resolver;
            EntityType = entityType;
            Columns = columns;
            SecurityPolicy = securityPolicy;
            Indices = indices;
        }
    }
}
