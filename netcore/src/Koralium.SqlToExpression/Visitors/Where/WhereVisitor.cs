using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.Where
{
    internal class WhereVisitor : BaseVisitor
    {
        private readonly IQueryStage _previousStage;
        private readonly Stack<Expression> expressions = new Stack<Expression>();

        public Expression Expression => GetExpression();

        private Expression GetExpression()
        {
            Debug.Assert(expressions.Count == 1);
            return expressions.Peek();
        }

        public WhereVisitor(IQueryStage queryStage, VisitorMetadata visitorMetadata)
            : base(queryStage, visitorMetadata)
        {
            Debug.Assert(queryStage != null, $"{nameof(queryStage)} was null");

            _previousStage = queryStage;
        }

        public override void ExplicitVisit(WhereClause whereClause)
        {
            whereClause.SearchCondition.Accept(this);
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
