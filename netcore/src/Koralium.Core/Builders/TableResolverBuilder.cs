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
using System.Collections.Generic;
using Koralium.SqlToExpression.Interfaces;

namespace Koralium.Builders
{
    public class TableResolverBuilder<Entity>: ITableResolverBuilder<Entity>
    {
        private readonly List<TableIndex> indicies = new List<TableIndex>();
        private IOperationsProvider _operationsProvider;
        public string TableName { get; set; }
        
        internal PartitionResolver PartitionResolver { get; private set; }

        internal IReadOnlyList<TableIndex> Indicies
        {
            get
            {
                return indicies;
            }
        }

        internal IOperationsProvider OperationsProvider
        {
            get
            {
                return _operationsProvider;
            }
        }

        internal TableResolverBuilder()
        {
        }

        public ITableResolverBuilder<Entity> SetOperationsProvider(IOperationsProvider operationsProvider)
        {
            _operationsProvider = operationsProvider;
            return this;
        }

        public ITableResolverBuilder<Entity> SetPartitionResolver(PartitionResolver partitionResolver)
        {
            PartitionResolver = partitionResolver;
            return this;
        }
    }
}
