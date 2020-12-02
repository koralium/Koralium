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
