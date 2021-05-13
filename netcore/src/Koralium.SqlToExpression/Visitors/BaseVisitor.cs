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
using Koralium.Shared.Utils;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Visitor;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors
{
    internal abstract class BaseVisitor : KoraliumSqlVisitor
    {
        private readonly IQueryStage _previousStage;
        private readonly VisitorMetadata _visitorMetadata;
        private readonly List<PropertyInfo> _usedProperties = new List<PropertyInfo>();

        internal protected Stack<Dictionary<string, ParameterExpression>> _lambdaParameters; 

        protected BaseVisitor(IQueryStage previousStage, VisitorMetadata visitorMetadata)
        {
            _previousStage = previousStage;
            _visitorMetadata = visitorMetadata;
        }

        public IEnumerable<PropertyInfo> UsedProperties => _usedProperties;

        protected bool InOr { get; private set; } = false;

        protected void AddUsedProperty(PropertyInfo propertyInfo)
        {
            _usedProperties.Add(propertyInfo);
        }

        public abstract void AddExpressionToStack(Expression expression);

        public abstract Expression PopStack();

        public abstract void AddNameToStack(string name);

        public abstract string PopNameStack();

        public override void VisitIntegerLiteral(IntegerLiteral integerLiteral)
        {
            AddExpressionToStack(Expression.Constant(integerLiteral.Value));
        }

        public override void VisitStringLiteral(StringLiteral stringLiteral)
        {
            if (DateTime.TryParse(stringLiteral.Value, out var date))
            {
                AddExpressionToStack(Expression.Constant(date));
                return;
            }
            AddExpressionToStack(Expression.Constant(stringLiteral.Value));
        }

        public override void VisitNumericLiteral(NumericLiteral numericLiteral)
        {
            AddExpressionToStack(Expression.Constant(numericLiteral.Value));
        }

        public override void VisitNullLiteral(NullLiteral nullLiteral)
        {
            AddExpressionToStack(Expression.Constant(null));
            AddNameToStack("null");
        }

        public override void VisitBooleanLiteral(BooleanLiteral booleanLiteral)
        {
            AddExpressionToStack(Expression.Constant(booleanLiteral.Value));
            AddNameToStack("bool");
        }

        public override void VisitColumnReference(ColumnReference columnReference)
        {
            var identifiers = columnReference.Identifiers;

            if (_lambdaParameters != null && _lambdaParameters.Count > 0)
            {
                if (_lambdaParameters.Peek().TryGetValue(identifiers.FirstOrDefault(), out var parameterExpression))
                {
                    AddExpressionToStack(parameterExpression);
                    return;
                }
            }

            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
            var memberAccess = MemberUtils.GetMember(_previousStage, identifiers, _visitorMetadata.OperationsProvider, out var property);
            AddUsedProperty(property);
            AddExpressionToStack(memberAccess);
            AddNameToStack(string.Join(".", identifiers));
        }

        public override void VisitNotExpression(NotExpression notExpression)
        {
            notExpression.BooleanExpression.Accept(this);

            var expr = PopStack();
            AddExpressionToStack(Expression.Not(expr));
        }

        public override void VisitBetweenExpression(BetweenExpression betweenExpression)
        {
            //Convert the between expression into a boolean binary expression
            var convertedExpression = new BooleanBinaryExpression()
            {
                Left = new BooleanComparisonExpression()
                {
                    Left = betweenExpression.Expression,
                    Right = betweenExpression.From,
                    Type = BooleanComparisonType.GreaterThanOrEqualTo
                },
                Right = new BooleanComparisonExpression()
                {
                    Left = betweenExpression.Expression,
                    Right = betweenExpression.To,
                    Type = BooleanComparisonType.LessThanOrEqualTo
                },
                Type = BooleanBinaryType.AND
            };

            //Visit the newly constructed boolean binary expression instead
            convertedExpression.Accept(this);
        }

        public override void VisitBinaryExpression(SqlParser.Expressions.BinaryExpression binaryExpression)
        {
            binaryExpression.Left.Accept(this);
            binaryExpression.Right.Accept(this);


            var rightExpression = PopStack();
            var leftExpression = PopStack();

            var expression = BinaryUtils.CreateBinaryExpression(leftExpression, rightExpression, binaryExpression.Type);

            AddExpressionToStack(expression);
        }

        public override void VisitBooleanBinaryExpression(BooleanBinaryExpression booleanBinaryExpression)
        {
            bool inOrSet = false;
            //Check if it is an OR operation and we are not already inside of one
            //This is used at this time only for checking if an index can be used or not
            if (booleanBinaryExpression.Type == BooleanBinaryType.OR && !InOr)
            {
                inOrSet = true;
                InOr = true;
            }

            booleanBinaryExpression.Left.Accept(this);
            booleanBinaryExpression.Right.Accept(this);

            //Reset the in OR flag
            if (inOrSet)
            {
                InOr = false;
            }

            var rightExpression = PopStack();
            var leftExpression = PopStack();

            Expression expression = null;
            switch (booleanBinaryExpression.Type)
            {
                case BooleanBinaryType.AND:
                    expression = Expression.AndAlso(leftExpression, rightExpression);
                    break;
                case BooleanBinaryType.OR:
                    expression = Expression.OrElse(leftExpression, rightExpression);
                    break;
            }

            AddExpressionToStack(expression);
        }

        public override void VisitVariableReference(VariableReference variableReference)
        {
            if (!_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
            {
                throw new SqlErrorException($"The parameter {variableReference.Name} could not be found, did you have include @ before the parameter name?");
            }
            AddExpressionToStack(parameter.GetValueAsExpression());
        }

        public override void VisitBooleanComparisonExpression(BooleanComparisonExpression booleanComparisonExpression)
        {
            booleanComparisonExpression.Left.Accept(this);
            booleanComparisonExpression.Right.Accept(this);

            var rightExpression = PopStack();
            var leftExpression = PopStack();

            var expression = PredicateUtils.CreateComparisonExpression(
                leftExpression,
                rightExpression,
                booleanComparisonExpression.Type,
                _visitorMetadata.OperationsProvider);

            AddExpressionToStack(expression);
        }

        public override void VisitBooleanIsNullExpression(BooleanIsNullExpression booleanIsNullExpression)
        {
            booleanIsNullExpression.ScalarExpression.Accept(this);

            var expression = PopStack();


            if (booleanIsNullExpression.IsNot)
            {
                if (expression.Type.IsPrimitive)
                {
                    AddExpressionToStack(Expression.Constant(true));
                }
                else
                {
                    AddExpressionToStack(Expression.NotEqual(expression, Expression.Constant(null)));
                }
            }
            else
            {
                if (expression.Type.IsPrimitive)
                {
                    AddExpressionToStack(Expression.Constant(false));
                }
                else
                {
                    AddExpressionToStack(Expression.Equal(expression, Expression.Constant(null)));
                }
            }
        }

        public override void VisitCastExpression(CastExpression castExpression)
        {
            castExpression.ScalarExpression.Accept(this);

            var expression = PopStack();

            Type toType = Type.GetType(castExpression.ToType, false, true);

            if(toType == null && !castExpression.ToType.StartsWith("System."))
            {
                toType = Type.GetType($"System.{castExpression.ToType}", false, true);
            }

            if(toType == null)
            {
                throw new SqlErrorException($"Cannot cast to the type {castExpression.ToType}");
            }

            if (!toType.IsPrimitive)
            {
                throw new SqlErrorException($"Cannot cast to the type {castExpression.ToType}, only primitive types are supported");
            }

            //If it is a nullable type, treat the converted type as nullable as well.
            //This is required when handling in memory data where sum or other aggregations will have problems with null objects if it is not converted to a nullable.
            if(Nullable.GetUnderlyingType(expression.Type) != null)
            {
                toType = typeof(Nullable<>).MakeGenericType(toType);
            }

            AddExpressionToStack(Expression.Convert(expression, toType));
        }

        public override void VisitFunctionCall(FunctionCall functionCall)
        {
            if (functionCall.FunctionName.Equals("any_match", StringComparison.OrdinalIgnoreCase))
            {
                if (functionCall.Parameters.Count != 2)
                {
                    throw new SqlErrorException("any_match must contain two parameters");
                }

                if (!(functionCall.Parameters[0] is ColumnReference columnReference))
                {
                    throw new SqlErrorException("any_match first parameter must be a column reference");
                }

                if (!(functionCall.Parameters[1] is SqlParser.Expressions.LambdaExpression lambdaExpression))
                {
                    throw new SqlErrorException("any_match second parameter must be a lambda expression");
                }

                if (lambdaExpression.Parameters.Count != 1)
                {
                    throw new SqlErrorException("any_match lambda expression can only have one input parameter");
                }

                columnReference.Accept(this);
                var column = PopStack();

                //Check that is in an array (IEnumerable)
                if (!ArrayUtils.IsArray(column.Type))
                {
                    throw new SqlErrorException("any_match first parameter must be an array/list.");
                }

                //Get the type that the array contains
                var elementType = ArrayUtils.GetArrayElementType(column.Type);

                //Add the type to the lambda settings in the base visitor
                if (_lambdaParameters == null)
                {
                    _lambdaParameters = new Stack<Dictionary<string, ParameterExpression>>();
                }
                
                _lambdaParameters.Push(new Dictionary<string, ParameterExpression>()
                {
                    { lambdaExpression.Parameters.First(), Expression.Parameter(elementType) }
                });

                //Visit the lambda expression
                lambdaExpression.Accept(this);
                var lambda = PopStack();

                if (!(lambda is System.Linq.Expressions.LambdaExpression expr) || expr.ReturnType != typeof(bool))
                {
                    throw new SqlErrorException("Lambda expression in any_match must return a boolean.");
                }

                //Create an expression that calls Any() on the array with the lambda.
                var anyCall = ArrayFunctionUtils.CallAny(elementType, column, lambda);

                var nullCheck = Expression.Condition(Expression.Equal(column, Expression.Constant(null, column.Type)), Expression.Constant(false), anyCall);

                AddExpressionToStack(nullCheck);
                return;
            }

            throw new SqlErrorException($"No function exists named '{functionCall.FunctionName}'.");
        }

        public override void VisitLambdaExpression(SqlParser.Expressions.LambdaExpression lambdaExpression)
        {
            if (_lambdaParameters == null || _lambdaParameters.Count == 0)
            {
                throw new SqlErrorException("Did not expect a lambda expression.");
            }
            lambdaExpression.Expression.Accept(this);
            var expr = PopStack();

            var parameters = _lambdaParameters.Peek().Values;
            AddExpressionToStack(Expression.Lambda(expr, parameters));
        }

        public override void VisitBooleanScalarExpression(BooleanScalarExpression booleanScalarExpression)
        {
            booleanScalarExpression.ScalarExpression.Accept(this);
            var expr = PopStack();

            if (expr.Type != typeof(bool))
            {
                throw new SqlErrorException("WHERE condition must return a boolean.");
            }

            AddExpressionToStack(expr);
        }
    }
}
