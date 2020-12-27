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
using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Partitions
{

    class PartitionFilterVisitor : KoraliumSqlVisitor
    {
        private bool filterSet = false;
        private readonly BooleanExpression _filter;

        public PartitionFilterVisitor(BooleanExpression filter)
        {
            _filter = filter;
        }

        public override void VisitSelectStatement(SelectStatement selectStatement)
        {
            Visit(selectStatement.FromClause);

            if (!filterSet)
            {
                if(selectStatement.WhereClause != null)
                {
                    Visit(selectStatement.WhereClause);
                }
                else
                {
                    selectStatement.WhereClause = new WhereClause();
                }
            }
            Visit(selectStatement.WhereClause);
        }

        public override void VisitWhereClause(WhereClause whereClause)
        {
            if(whereClause.Expression != null) //Merge
            {
                whereClause.Expression = QueryBuilder.And(whereClause.Expression, _filter);
            }
            else //Set the filter
            {
                whereClause.Expression = _filter;
            }
        }
    }
}
