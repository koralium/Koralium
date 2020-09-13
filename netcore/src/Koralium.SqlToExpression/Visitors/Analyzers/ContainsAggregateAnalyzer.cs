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
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Koralium.SqlToExpression.Visitors.Analyzers
{
    public class ContainsAggregateAnalyzer : TSqlFragmentVisitor
    {
        private bool isAggregate = false;

        public bool IsAggregate => isAggregate;

        public override void Visit(ScalarExpression scalarExpression)
        {
            if (scalarExpression is FunctionCall functionCall)
            {
                HandleFunctionCall(functionCall);
            }
        }

        private void HandleFunctionCall(FunctionCall functionCall)
        {
            var functionName = functionCall.FunctionName.Value.ToLower();
            switch (functionName)
            {
                case "sum":
                    isAggregate = true;
                    break;
                case "min":
                    isAggregate = true;
                    break;
                case "max":
                    isAggregate = true;
                    break;
                case "count":
                    isAggregate = true;
                    break;
                case "count_big":
                    isAggregate = true;
                    break;
                case "avg":
                    isAggregate = true;
                    break;
            }
        }
    }
}
