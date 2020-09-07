using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Core.Resolvers;
using Koralium.Core.Utils;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Koralium.Core.Builders
{
    public class TableResolverBuilder<Entity>: ITableResolverBuilder<Entity>
    {
        private readonly List<TableColumn> _columns;
        private readonly List<TableIndex> indicies = new List<TableIndex>();
        public string TableName { get; set; }

        internal IReadOnlyList<TableIndex> Indicies
        {
            get
            {
                return indicies;
            }
        }

        public TableResolverBuilder(List<TableColumn> columns)
        {
            _columns = columns;
        }

        public ITableResolverBuilder<Entity> AddIndexResolver<Resolver, Key1>(Expression<Func<Entity, Key1>> property, string indexName = null)
            where Resolver : IndexResolver<Entity, Key1>
        {
            var existingColumn = GetIndexColumn(property);

            if (indexName == null)
            {
                indexName = MetadataHelper.GenerateIndexName(existingColumn.Name);
            }

            IndexMetadata indexMetadata = new IndexMetadata
            {
                IndexId = indicies.Count,
                Name = indexName
            };

            indexMetadata.Columns.Add(existingColumn.Metadata);

            indicies.Add(new TableIndex(typeof(Resolver), indicies.Count, new List<TableColumn>() { existingColumn }, indexName, indexMetadata));

            return this;
        }

        private TableColumn GetIndexColumn<Key>(Expression<Func<Entity, Key>> property)
        {
            if (property.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException("Only properties can be used for index", nameof(property));
            }

            var memberExpression = property.Body as MemberExpression;

            if (!(memberExpression.Member is PropertyInfo propertyInfo))
            {
                throw new ArgumentException("Only properties can be used for index", nameof(property));
            }

            var existingColumn = _columns.FirstOrDefault(x => x.Name == propertyInfo.Name);

            return existingColumn;
        }

    }
}
