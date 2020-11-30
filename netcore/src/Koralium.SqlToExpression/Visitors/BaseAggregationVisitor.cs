using Koralium.Shared;
using Koralium.SqlParser.Expressions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Visitors
{
    internal abstract class BaseAggregationVisitor : BaseVisitor
    {
        private bool _inAggregateFunction = false;
        private readonly GroupedStage _previousStage;
        public BaseAggregationVisitor(GroupedStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
            _previousStage = previousStage;
        }

        public override void VisitFunctionCall(FunctionCall functionCall)
        {
            var functionName = functionCall.FunctionName.ToLower();
            switch (functionName)
            {
                case "sum":
                    HandleSum(functionCall);
                    break;
                case "avg":
                    break;
                case "count":
                    HandleCount(functionCall);
                    break;
                default:
                    throw new NotSupportedException(functionCall.FunctionName);
            }
        }

        public override void VisitColumnReference(ColumnReference columnReference)
        {
            var identifiers = columnReference.Identifiers;
            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);

            Expression expression;
            if (_inAggregateFunction)
            {
                expression = MemberUtils.GetMemberGroupByInValue(_previousStage, identifiers, out var property);
                AddUsedProperty(property);
            }
            else
            {
                expression = MemberUtils.GetMemberGroupByInKey(_previousStage, identifiers, out var property);
                AddUsedProperty(property);
            }

            AddExpressionToStack(expression);
            AddNameToStack(string.Join(".", identifiers));
        }

        private void HandleCount(FunctionCall functionCall)
        {
            var parameters = functionCall.Parameters;

            if (functionCall.Wildcard)
            {
                AddExpressionToStack(AggregationUtils.CallCount(_previousStage));
                AddNameToStack($"count(*)");
            }
            else
            {
                throw new SqlErrorException("Count only works with '*' right now.");
            }
        }

        private void HandleSum(FunctionCall functionCall)
        {
            //Mark query as aggregate, all selects must be either aggregate or in group by
            var parameters = functionCall.Parameters;
            if (parameters.Count != 1)
            {
                throw new NotSupportedException("Sum can only take a single parameter");
            }
            _inAggregateFunction = true;
            foreach (var parameter in parameters)
            {
                parameter.Accept(this);
            }
            _inAggregateFunction = false;

            var argumentAccessExpression = PopStack();

            var callMethodExpression = AggregationUtils.CallSum(argumentAccessExpression, this._previousStage);

            AddExpressionToStack(callMethodExpression);
            var lastName = PopNameStack();
            AddNameToStack($"sum({lastName})");
        }
    }
}
