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
                case "count":
                    HandleCount(functionCall);
                    break;
                default:
                    throw new NotSupportedException(functionCall.FunctionName.Value);
            }
        }

        private void HandleCount(FunctionCall functionCall)
        {
            var parameters = functionCall.Parameters;
            if (parameters.Count != 1)
            {
                throw new NotSupportedException("Count can only take a single parameter");
            }

            var parameter = parameters[0];
            //check if it is a wildcard count
            if (parameter is ColumnReferenceExpression reference && reference.ColumnType == ColumnType.Wildcard)
            {
                AddExpressionToStack(AggregationUtils.CallCount(_previousStage));
                AddNameToStack($"count(*)");
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

    }
}
