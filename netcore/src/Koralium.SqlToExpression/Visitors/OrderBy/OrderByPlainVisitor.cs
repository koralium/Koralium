using Koralium.SqlToExpression.Extensions;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.OrderBy
{
    /// <summary>
    /// This order by visitor is used when there is no aggregations
    /// </summary>
    class OrderByPlainVisitor : BaseVisitor
    {
        private readonly Stack<Expression> expressions = new Stack<Expression>();
        private readonly List<SortItem> sortItems = new List<SortItem>();
        public IReadOnlyList<SortItem> SortItems => sortItems;

        public OrderByPlainVisitor(IQueryStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
        }

        public override void ExplicitVisit(OrderByClause node)
        {
            foreach (var element in node.OrderByElements)
            {
                element.Accept(this);
            }
        }

        public override void ExplicitVisit(ExpressionWithSortOrder node)
        {
            node.Expression.Accept(this);

            Debug.Assert(expressions.Count == 1);

            bool descending = false;

            if (node.SortOrder == SortOrder.Descending)
            {
                descending = true;
            }
            var expression = expressions.Pop();

            if (!expression.IsNull())
            {
                var orderByExpression = Expression.Convert(expression, typeof(object));
                sortItems.Add(new SortItem(orderByExpression, descending));
            }
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
    }
}
