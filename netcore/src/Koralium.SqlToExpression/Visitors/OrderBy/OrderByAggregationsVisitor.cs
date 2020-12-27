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
using Koralium.SqlParser.OrderBy;
using Koralium.SqlToExpression.Extensions;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Visitors.Select;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.OrderBy
{
    internal class OrderByAggregationsVisitor : SelectAggregationVisitor
    {
        private readonly List<SortItem> sortItems = new List<SortItem>();

        public IReadOnlyList<SortItem> SortItems => sortItems;

        public OrderByAggregationsVisitor(GroupedStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
        }

        public override void VisitOrderByClause(OrderByClause orderByClause)
        {
            foreach (var element in orderByClause.OrderExpressions)
            {
                element.Accept(this);
            }
        }

        public override void VisitOrderExpression(OrderExpression orderExpression)
        {
            orderExpression.Expression.Accept(this);

            //Ignore empty stacks, since you can sort by SELECT NULL
            if (expressionStack.Count > 0)
            {
                Debug.Assert(expressionStack.Count == 1);

                bool descending = !orderExpression.Ascending;

                var expression = expressionStack.Pop();
                if (!expression.IsNull())
                {
                    var orderByExpression = Expression.Convert(expression, typeof(object));
                    sortItems.Add(new SortItem(orderByExpression, descending));
                }
            }
        }
    }
}
