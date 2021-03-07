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
using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.RowLevelSecurity
{
    /// <summary>
    /// Visitor to help add to a where condition on a query
    /// </summary>
    class AddFilterVisitor : KoraliumSqlVisitor
    {
        private readonly BooleanExpression _toAdd;
        private bool _added = false;
        public AddFilterVisitor(BooleanExpression toAdd)
        {
            _toAdd = toAdd;
        }

        public override void VisitSelectStatement(SelectStatement selectStatement)
        {
            // Try to find the select statement closest to the table before applying the filter
            if (selectStatement.FromClause != null)
            {
                Visit(selectStatement.FromClause);
            }

            // Check so we have not already added the filter
            // This can happen in sub queries
            if (_added)
            {
                return;
            }
            if (selectStatement.WhereClause == null)
            {
                selectStatement.WhereClause = new SqlParser.Clauses.WhereClause()
                {
                    Expression = _toAdd
                };
            }
            else
            {
                selectStatement.WhereClause.Expression = QueryBuilder.And(selectStatement.WhereClause.Expression, _toAdd);
            }
            _added = true;
        }
    }
}
