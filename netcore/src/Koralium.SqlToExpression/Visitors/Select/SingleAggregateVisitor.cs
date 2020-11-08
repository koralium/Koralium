using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public IImmutableList<Expression> Parameters { get; private set; }

        public Type OutType { get; private set; }

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
            var parameterListBuilder = ImmutableList.CreateBuilder<Expression>();
            foreach(var p in node.Parameters)
            {
                if(p is ColumnReferenceExpression columnReferenceExpression &&
                    columnReferenceExpression.ColumnType == ColumnType.Wildcard)
                {
                    continue;
                }
                p.Accept(this);
                var parameterExpression = PopStack();
                parameterListBuilder.Add(parameterExpression);
            }
            Parameters = parameterListBuilder.ToImmutable();
            var functionName = node.FunctionName.Value.ToLower();
            switch (functionName)
            {
                case "count":
                    FunctionName = functionName;
                    OutType = typeof(long);
                    AddNameToStack($"count(*)");
                    break;
                case "sum":
                    FunctionName = functionName;
                    var lastName = PopNameStack();

                    if(Parameters.Count != 1)
                    {
                        throw new SqlErrorException($"Sum can only be called with a single parameter");
                    }

                    var parameter = Parameters[0];
                    OutType = parameter.Type;
                    AddNameToStack($"sum({lastName})");
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
