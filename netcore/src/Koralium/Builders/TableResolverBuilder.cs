/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.Interfaces;
using Koralium.Metadata;
using Koralium.Utils;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Koralium.SqlToExpression.Interfaces;

namespace Koralium.Builders
{
    public class TableResolverBuilder<Entity>: ITableResolverBuilder<Entity>
    {
        private readonly List<TableColumn> _columns;
        private readonly List<TableIndex> indicies = new List<TableIndex>();
        private IStringOperationsProvider _stringOperationsProvider;
        public string TableName { get; set; }
        

        internal IReadOnlyList<TableIndex> Indicies
        {
            get
            {
                return indicies;
            }
        }

        internal IStringOperationsProvider StringOperationsProvider
        {
            get
            {
                return _stringOperationsProvider;
            }
        }

        public TableResolverBuilder(List<TableColumn> columns)
        {
            _columns = columns;
        }

        public ITableResolverBuilder<Entity> SetStringOperationsProvider(IStringOperationsProvider stringOperationsProvider)
        {
            _stringOperationsProvider = stringOperationsProvider;
            return this;
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

        public ITableResolverBuilder<Entity> AddIndexResolver<Resolver, Key1, Key2>(Expression<Func<Entity, Key1>> property1, Expression<Func<Entity, Key2>> property2, string indexName = null) where Resolver : IndexResolver<Entity, Key1, Key2>
        {
            var existingColumn1 = GetIndexColumn(property1);
            var existingColumn2 = GetIndexColumn(property2);

            if (indexName == null)
            {
                indexName = MetadataHelper.GenerateIndexName(existingColumn1.Metadata.Name, existingColumn2.Metadata.Name);
            }

            IndexMetadata indexMetadata = new IndexMetadata
            {
                IndexId = indicies.Count,
                Name = indexName
            };

            indexMetadata.Columns.Add(existingColumn1.Metadata);
            indexMetadata.Columns.Add(existingColumn2.Metadata);

            indicies.Add(new TableIndex(typeof(Resolver), indicies.Count, new List<TableColumn>() { existingColumn1, existingColumn2 }, indexName, indexMetadata));

            return this;
            throw new NotImplementedException();
        }
    }
}
