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
using Koralium.SqlToExpression.Interfaces;
using System;
using System.Collections.Generic;

namespace Koralium
{
    internal class KoraliumTable
    {

        public string Name { get; }

        public Type Resolver { get; }

        public Type EntityType { get; }

        public IReadOnlyList<TableColumn> Columns { get; }

        public string SecurityPolicy { get; set; }

        public IReadOnlyList<TableIndex> Indices { get; }

        public IOperationsProvider OperationsProvider { get; }

        public PartitionResolver PartitionResolver { get; }

        public KoraliumTable(
            string name,
            Type resolver,
            Type entityType,
            IReadOnlyList<TableColumn> columns,
            string securityPolicy,
            IReadOnlyList<TableIndex> indices,
            IOperationsProvider operationsProvider,
            PartitionResolver partitionResolver)
        {
            Name = name;
            Resolver = resolver;
            EntityType = entityType;
            Columns = columns;
            SecurityPolicy = securityPolicy;
            Indices = indices;
            OperationsProvider = operationsProvider;
            PartitionResolver = partitionResolver;
        }
    }
}
