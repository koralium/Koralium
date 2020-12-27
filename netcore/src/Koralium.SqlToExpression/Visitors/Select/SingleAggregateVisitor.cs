using Koralium.Shared;
using Koralium.SqlParser.Expressions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq.Expressions;

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

        public override string PopNameStack()
        {
            return nameStack.Pop();
        }

        public override Expression PopStack()
        {
            return expressionStack.Pop();
        }

        public override void VisitSelectScalarExpression(SelectScalarExpression selectScalarExpression)
        {
            selectScalarExpression.Expression.Accept(this);
            ColumnName = selectScalarExpression.Alias ?? nameStack.Pop();
        }

        public override void VisitFunctionCall(FunctionCall functionCall)
        {
            //throw new Exception("FIX FUNCTION CALL WILDCARD PARAMETER");
            var parameterListBuilder = ImmutableList.CreateBuilder<Expression>();
            foreach (var p in functionCall.Parameters)
            {
                p.Accept(this);
                var parameterExpression = PopStack();
                parameterListBuilder.Add(parameterExpression);
            }
            Parameters = parameterListBuilder.ToImmutable();
            var functionName = functionCall.FunctionName.ToLower();
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

                    if (Parameters.Count != 1)
                    {
                        throw new SqlErrorException($"Sum can only be called with a single parameter");
                    }

                    var parameter = Parameters[0];
                    OutType = AggregationUtils.GetSumOutputType(parameter.Type);

                    AddNameToStack($"sum({lastName})");
                    break;
                default:
                    throw new NotSupportedException(functionCall.FunctionName);
            }
        }
    }
}
