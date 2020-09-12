using Koralium.SqlToExpression.Stages.CompileStages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.Having
{
    class HavingVisitor : BaseAggregationVisitor
    {
        private readonly Stack<Expression> expressions = new Stack<Expression>();

        public Expression Expression => GetExpression();

        private Expression GetExpression()
        {
            Debug.Assert(expressions.Count == 1);
            return expressions.Peek();
        }

        public HavingVisitor(GroupedStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
        }

        public override void AddExpressionToStack(Expression expression)
        {
            expressions.Push(expression);
        }

        public override void AddNameToStack(string name)
        {
            //Not used
        }

        public override string PopNameStack()
        {
            return string.Empty;
        }

        public override Expression PopStack()
        {
            return expressions.Pop();
        }
    }
}
