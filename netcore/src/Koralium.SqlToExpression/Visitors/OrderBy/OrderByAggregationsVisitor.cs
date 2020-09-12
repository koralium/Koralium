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
