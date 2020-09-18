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
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.Where
{
    /// <summary>
    /// This visitor covers reading like conditions.
    /// 
    /// A like cannot be converted directly into expressions which makes it a bit more complicated.
    /// 
    /// </summary>
    internal class LikeVisitor : BaseVisitor
    {
        private IQueryStage _previousStage;
        private Stack<Expression> expressions = new Stack<Expression>();
        private readonly VisitorMetadata _visitorMetadata;
        public LikeVisitor(IQueryStage previousStage, VisitorMetadata visitorMetadata) : base(previousStage, visitorMetadata)
        {
            _previousStage = previousStage;
            _visitorMetadata = visitorMetadata;
        }

        public Expression Expression => expressions.Peek();

        private class VisitResult
        {
            /// <summary>
            /// This is set if a string was only a % symbol.
            /// This will otherwise flag both starts with and ends with
            /// </summary>
            public bool WildcardOnly { get; set; }

            /// <summary>
            /// Indicates that a starts with operation is required
            /// </summary>
            public bool StartsWith { get; set; }

            /// <summary>
            /// Indicates that an ends with operation is required
            /// </summary>
            public bool EndsWith { get; set; }

            /// <summary>
            /// The expression that is required to be run
            /// </summary>
            public Expression Expression { get; set; }
        }

        private VisitResult VisitInternal(ScalarExpression scalarExpression)
        {
            if(scalarExpression is Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpression binaryExpression)
            {
                var leftResult = VisitInternal(binaryExpression.FirstExpression);

                //Left result should only contain: '%text' or 'text'
                if (leftResult.StartsWith && !leftResult.WildcardOnly)
                {
                    throw new SqlErrorException("Like expression can only support starts with ('text%'), ends with ('%text') and contains ('%text%') at this time");
                }

                var rightResult = VisitInternal(binaryExpression.SecondExpression);

                //Right result should only contain 'text%' or 'text'
                if (rightResult.EndsWith && !rightResult.WildcardOnly)
                {
                    throw new SqlErrorException("Like expression can only support starts with ('text%'), ends with ('%text') and contains ('%text%') at this time");
                }

                if(binaryExpression.BinaryExpressionType != BinaryExpressionType.Add)
                {
                    throw new SqlErrorException("Like expression can only do string concatination at this time");
                }

                //If one of the results are null, they have been removed since they were just '%'
                //We only return the other result since concat is not required
                if(leftResult.Expression == null)
                {
                    return rightResult;
                }

                //Remove empty strings that was just for wildcarding
                if(leftResult.WildcardOnly && rightResult.WildcardOnly)
                {
                    return new VisitResult()
                    {
                        EndsWith = true,
                        StartsWith = true,
                        WildcardOnly = true,
                        Expression = Expression.Constant("")
                    };
                }
                else if (leftResult.WildcardOnly)
                {
                    return new VisitResult()
                    {
                        EndsWith = true,
                        StartsWith = rightResult.StartsWith,
                        Expression = rightResult.Expression
                    };
                }
                else if (rightResult.WildcardOnly)
                {
                    return new VisitResult()
                    {
                        StartsWith = true,
                        Expression = leftResult.Expression,
                        EndsWith = leftResult.EndsWith
                    };
                }

                var expression = BinaryUtils.CreateBinaryExpression(leftResult.Expression, rightResult.Expression, BinaryExpressionType.Add);

                return new VisitResult()
                {
                    StartsWith = rightResult.StartsWith || rightResult.WildcardOnly,
                    EndsWith = leftResult.EndsWith || leftResult.WildcardOnly,
                    Expression = expression
                };
            }
            else if(scalarExpression is StringLiteral stringLiteral)
            {
                var value = stringLiteral.Value;

                if (value.Equals("%"))
                {
                    return new VisitResult()
                    {
                        WildcardOnly = true,
                        StartsWith = true,
                        EndsWith = true,
                        Expression = Expression.Constant("")
                    };
                }

                bool startsWith = false;
                bool endsWith = false;
                if (value.StartsWith("%"))
                {
                    endsWith = true;
                    value = value.Substring(1);
                }
                if (value.EndsWith("%") && (value.Length - 1 == 0 || value[value.Length - 1] != '\\'))
                {
                    startsWith = true;
                    value = value.Substring(0, value.Length - 1);
                }
                
                return new VisitResult()
                {
                    EndsWith = endsWith,
                    StartsWith = startsWith,
                    Expression = Expression.Constant(value)
                };
            }
            else if (scalarExpression is VariableReference variableReference)
            {
                
                if (!_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
                {
                    throw new SqlErrorException($"The parameter {variableReference.Name} could not be found, did you have include @ before the parameter name?");
                }

                return new VisitResult()
                {
                    Expression = parameter.GetValueAsExpression()
                };
            }
            else if (scalarExpression is ColumnReferenceExpression columnReferenceExpression)
            {
                var identifiers = columnReferenceExpression.MultiPartIdentifier.Identifiers.Select(x => x.Value).ToList();

                identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
                var memberAccess = MemberUtils.GetMember(_previousStage, identifiers, out var property);
                AddUsedProperty(property);
                return new VisitResult()
                {
                    Expression = memberAccess
                };
            }
            else
            {
                throw new SqlErrorException("Like expression only supports strings, string concatination, variable references and column references");
            }
        }

        public override void ExplicitVisit(LikePredicate likePredicate)
        {
            likePredicate.FirstExpression.Accept(this);

            var leftExpression = PopStack();

            var visitResult = VisitInternal(likePredicate.SecondExpression);

            if (visitResult.StartsWith && visitResult.EndsWith)
            {
                var containsExpression = PredicateUtils.CallContains(leftExpression, visitResult.Expression);
                AddExpressionToStack(containsExpression);
            }
            //Starts with
            else if (visitResult.StartsWith)
            {
                var startsWithExpression = PredicateUtils.CallStartsWith(leftExpression, visitResult.Expression);
                AddExpressionToStack(startsWithExpression);
            }
            //Ends with
            else if (visitResult.EndsWith)
            {
                var endsWithExpression = PredicateUtils.CallEndsWith(leftExpression, visitResult.Expression);
                AddExpressionToStack(endsWithExpression);
            }
            else
            {
                var equalsExpression = PredicateUtils.CreateComparisonExpression(leftExpression, visitResult.Expression, BooleanComparisonType.Equals);
                AddExpressionToStack(equalsExpression);
            }
        }

        public override void AddExpressionToStack(Expression expression)
        {
            expressions.Push(expression);
        }

        public override void AddNameToStack(string name)
        {
        }

        public override string PopNameStack()
        {
            return string.Empty;
        }

        public override Expression PopStack()
        {
            return expressions.Pop();
        }
    }
}
