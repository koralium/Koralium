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
using Koralium.SqlToExpression.Exceptions;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Koralium.SqlToExpression.Visitors.Offset
{
    internal class OffsetVisitor : TSqlFragmentVisitor
    {
        private readonly VisitorMetadata _visitorMetadata;

        private int? offsetCount = null;
        private int? takeCount = null;

        public int? OffsetCount => offsetCount;
        public int? TakeCount => takeCount;

        public OffsetVisitor(VisitorMetadata visitorMetadata)
        {
            _visitorMetadata = visitorMetadata;
        }

        public override void ExplicitVisit(OffsetClause node)
        {
            {
                if (node.OffsetExpression != null)
                {
                    if (node.OffsetExpression is IntegerLiteral integerLiteral && int.TryParse(integerLiteral.Value, out var value))
                    {
                        offsetCount = value;
                    }
                    else if(node.OffsetExpression is VariableReference variableReference)
                    {
                        if(!_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
                        {
                            throw new SqlErrorException($"The parameter {variableReference.Name} was not found");
                        }
                        if(parameter.TryGetValue<int>(out var parameterValue))
                        {
                            offsetCount = parameterValue;
                        }
                        else
                        {
                            throw new SqlErrorException($"The value in parameter {variableReference.Name} used in offset can only contain integer values");
                        }
                    }
                    else
                    {
                        throw new SqlErrorException("Only integers or variables can be used as offset");
                    }
                }
            }
            {
                if (node.FetchExpression != null)
                {
                    if (node.FetchExpression is IntegerLiteral integerLiteral && int.TryParse(integerLiteral.Value, out var value))
                    {
                        takeCount = value;
                    }
                    else if (node.FetchExpression is VariableReference variableReference)
                    {
                        if (!_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
                        {
                            throw new SqlErrorException($"The parameter {variableReference.Name} was not found");
                        }
                        if (parameter.TryGetValue<int>(out var parameterValue))
                        {
                            takeCount = parameterValue;
                        }
                        else
                        {
                            throw new SqlErrorException($"The value in parameter {variableReference.Name} used in fetch can only contain integer values");
                        }
                    }
                    else
                    {
                        throw new SqlErrorException("Only integers or variables can be used as offset");
                    }
                }
            }
        }
    }
}
