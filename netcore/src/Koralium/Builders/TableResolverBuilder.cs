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
using System.Collections.Generic;
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
    }
}
