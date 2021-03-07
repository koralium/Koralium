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
using Koralium.Shared;
using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Visitor;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using System.Collections.Generic;
using System.Diagnostics;

namespace Koralium.SqlToExpression.Visitors.From
{
    internal class FromVisitor : KoraliumSqlVisitor
    {
        private readonly VisitorMetadata _visitorMetadata;
        private TableMetadata _table;

        public TableMetadata Table => _table;
        public FromAliases FromAliases { get; } = new FromAliases();

        public IReadOnlyList<IQueryStage> Stages { get; private set; } = null;

        public FromVisitor(VisitorMetadata visitorMetadata)
        {
            _visitorMetadata = visitorMetadata;
        }

        public override void VisitFromClause(FromClause fromClause)
        {
            var tableReference = fromClause.TableReference;
            if (tableReference is FromTableReference namedTableReference)
            {
                var tableName = namedTableReference.TableName;
                Debug.Assert(tableName != null);

                if (!_visitorMetadata.TablesMetadata.TryGetTable(tableName, out _table))
                {
                    throw new SqlErrorException($"The table '{tableName}' was not found");
                }
                //Add the table name to the aliases as well, to support using the tablename infront of columns
                FromAliases.AddAlias(tableName);

                var alias = namedTableReference?.Alias;
                if (alias != null)
                {
                    FromAliases.AddAlias(alias);
                }
            }
            else if (tableReference is Subquery queryDerivedTable)
            {
                MainVisitor mainVisitor = new MainVisitor(_visitorMetadata);
                queryDerivedTable.Accept(mainVisitor);
                Stages = mainVisitor.Stages;

                var alias = queryDerivedTable?.Alias;
                if (alias != null)
                {
                    FromAliases.AddAlias(alias);
                }
            }
            else
            {
                throw new SqlErrorException("Subqueries or joins are not supported at this time");
            }
        }
    }
}
