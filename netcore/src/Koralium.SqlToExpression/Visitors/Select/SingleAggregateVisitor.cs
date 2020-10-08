using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal class SingleAggregateVisitor : BaseVisitor
    {
        private Expression parameter;
        private Stack<Expression> expressionStack = new Stack<Expression>();
        private Stack<string> nameStack = new Stack<string>();

        public SingleAggregateVisitor(IQueryStage previousStage, VisitorMetadata visitorMetadata) 
            : base(previousStage, visitorMetadata)
        {
        }

        public string FunctionName { get; private set; }

        public string ColumnName { get; private set; }

        public override void AddExpressionToStack(Expression expression)
        {
            expressionStack.Push(expression);
        }

        public override void AddNameToStack(string name)
        {
            nameStack.Push(name);
        }

        public override void ExplicitVisit(SelectScalarExpression selectScalarExpression)
        {
            selectScalarExpression.Expression.Accept(this);
            ColumnName = selectScalarExpression.ColumnName?.Value ?? nameStack.Pop();
        }

        public override void ExplicitVisit(FunctionCall node)
        {
            var functionName = node.FunctionName.Value.ToLower();
            switch (functionName)
            {
                case "count":
                    FunctionName = functionName;
                    AddNameToStack($"count(*)");
                    break;
                default:
                    throw new NotSupportedException(node.FunctionName.Value);
            }
        }

        public override string PopNameStack()
        {
            return nameStack.Pop();
        }

        public override Expression PopStack()
        {
            return expressionStack.Pop();
        }
    }
}
