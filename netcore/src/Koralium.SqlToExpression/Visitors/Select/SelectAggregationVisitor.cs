using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal class SelectAggregationVisitor : BaseAggregationVisitor, ISelectVisitor
    {
        protected readonly List<SelectExpression> selectExpressions = new List<SelectExpression>();
        protected readonly Stack<Expression> expressionStack = new Stack<Expression>();
        protected readonly Stack<string> nameStack = new Stack<string>();
        private readonly GroupedStage _previousStage;

        public IReadOnlyList<SelectExpression> SelectExpressions => selectExpressions;

        public SelectAggregationVisitor(GroupedStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
            _previousStage = previousStage;
        }

        public override void ExplicitVisit(SelectScalarExpression selectScalarExpression)
        {
            selectScalarExpression.Expression.Accept(this);

            var expression = expressionStack.Pop();
            string columnName = selectScalarExpression.ColumnName?.Value ?? nameStack.Pop();

            selectExpressions.Add(new SelectExpression(expression, columnName));
        }

        public override void AddExpressionToStack(Expression expression)
        {
            expressionStack.Push(expression);
        }

        public override Expression PopStack()
        {
            return expressionStack.Pop();
        }

        public override void AddNameToStack(string name)
        {
            nameStack.Push(name);
        }

        public override string PopNameStack()
        {
            return nameStack.Pop();
        }

        public void VisitSelect(TSqlFragment sqlFragment)
        {
            sqlFragment.Accept(this);
        }
    }
}
