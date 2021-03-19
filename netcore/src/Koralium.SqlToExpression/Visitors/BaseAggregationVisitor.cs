/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.Shared;
using Koralium.SqlParser.Expressions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors
{
    internal abstract class BaseAggregationVisitor : BaseVisitor
    {
        private bool _inAggregateFunction = false;
        private readonly GroupedStage _previousStage;
        private readonly VisitorMetadata _visitorMetadata;
        public BaseAggregationVisitor(GroupedStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
            _previousStage = previousStage;
            _visitorMetadata = visitorMetadata;
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
                expression = MemberUtils.GetMemberGroupByInValue(_previousStage, identifiers, _visitorMetadata.OperationsProvider, out var property);
                AddUsedProperty(property);
            }
            else
            {
                expression = MemberUtils.GetMemberGroupByInKey(_previousStage, identifiers, _visitorMetadata.OperationsProvider, out var property);
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
