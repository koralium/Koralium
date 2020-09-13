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
using Koralium.SqlToExpression.Extensions;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Visitors.Select;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.OrderBy
{
    class OrderByAggregationsVisitor : SelectAggregationVisitor
    {
        private readonly List<SortItem> sortItems = new List<SortItem>();

        public IReadOnlyList<SortItem> SortItems => sortItems;

        public OrderByAggregationsVisitor(GroupedStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
        }

        public override void ExplicitVisit(OrderByClause orderByClause)
        {
            foreach (var element in orderByClause.OrderByElements)
            {
                element.Accept(this);
            }
        }

        public override void ExplicitVisit(ExpressionWithSortOrder expressionWithSortOrder)
        {
            expressionWithSortOrder.Expression.Accept(this);

            Debug.Assert(expressionStack.Count == 1);

            bool descending = false;

            if (expressionWithSortOrder.SortOrder == SortOrder.Descending)
            {
                descending = true;
            }
            var expression = expressionStack.Pop();
            if (!expression.IsNull())
            {
                var orderByExpression = Expression.Convert(expression, typeof(object));
                sortItems.Add(new SortItem(orderByExpression, descending));
            }
        }
    }
}
