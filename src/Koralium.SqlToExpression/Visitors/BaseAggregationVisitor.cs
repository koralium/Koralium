using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public override void ExplicitVisit(FunctionCall functionCall)
        {
            var functionName = functionCall.FunctionName.Value.ToLower();
            switch (functionName)
            {
                case "sum":
                    HandleSum(functionCall);
                    break;
                case "avg":
                    //HandleAvg(functionCall);
                    break;
                default:
                    throw new NotSupportedException(functionCall.FunctionName.Value);
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

        public override void ExplicitVisit(ColumnReferenceExpression columnReferenceExpression)
        {
            var identifiers = columnReferenceExpression.MultiPartIdentifier.Identifiers.Select(x => x.Value).ToList();
            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);

            Expression expression;
            if (_inAggregateFunction)
            {
                expression = MemberUtils.GetMemberGroupByInValue(_previousStage, identifiers);
            }
            else
            {
                expression = MemberUtils.GetMemberGroupByInKey(_previousStage, identifiers);
            }

            AddExpressionToStack(expression);
            AddNameToStack(string.Join(".", identifiers));
        }

    }
}
