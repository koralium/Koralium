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
using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Statements;
using Koralium.SqlParser.Visitor;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlParser
{
    public class SelectStatement : Statement
    {
        public SelectStatement() 
        {
            SelectElements = new List<SelectExpression>();
        }

        public bool Distinct { get; set; }

        public List<SelectExpression> SelectElements { get; set; }

        public FromClause FromClause { get; set; }

        public WhereClause WhereClause { get; set; }

        public GroupByClause GroupByClause { get; set; }

        public HavingClause HavingClause { get; set; }

        public OrderByClause OrderByClause { get; set; }

        public OffsetLimitClause OffsetLimitClause { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectStatement(this);
        }

        public override SqlNode Clone()
        {
            return new SelectStatement()
            {
                Distinct = Distinct,
                FromClause = FromClause?.Clone() as FromClause,
                GroupByClause = GroupByClause?.Clone() as GroupByClause,
                HavingClause = HavingClause?.Clone() as HavingClause,
                OffsetLimitClause = OffsetLimitClause?.Clone() as OffsetLimitClause,
                OrderByClause = OrderByClause?.Clone() as OrderByClause,
                SelectElements = SelectElements?.Select(x => x.Clone() as SelectExpression).ToList(),
                WhereClause = WhereClause?.Clone() as WhereClause
            };
        }
    }
}
