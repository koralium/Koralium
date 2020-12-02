using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.OrderBy;
using Koralium.SqlToExpression.Extensions;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.OrderBy
{
    internal class OrderByPlainVisitor : BaseVisitor
    {
        private readonly Stack<Expression> expressions = new Stack<Expression>();
        private readonly List<SortItem> sortItems = new List<SortItem>();
        public IReadOnlyList<SortItem> SortItems => sortItems;

        public OrderByPlainVisitor(IQueryStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
        }

        public override void AddExpressionToStack(Expression expression)
        {
            expressions.Push(expression);
        }

        public override Expression PopStack()
        {
            return expressions.Pop();
        }

        public override void AddNameToStack(string name)
        {
            //Not used
        }

        public override string PopNameStack()
        {
            return string.Empty;
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

            Debug.Assert(expressions.Count == 1);

            bool descending = !orderExpression.Ascending;

            var expression = expressions.Pop();

            if (!expression.IsNull())
            {
                var orderByExpression = Expression.Convert(expression, typeof(object));
                sortItems.Add(new SortItem(orderByExpression, descending));
            }
        }
    }
}
