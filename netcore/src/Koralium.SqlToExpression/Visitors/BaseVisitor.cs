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
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Visitor;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors
{
    internal abstract class BaseVisitor : KoraliumSqlVisitor
    {
        private readonly IQueryStage _previousStage;
        private readonly VisitorMetadata _visitorMetadata;
        private readonly List<PropertyInfo> _usedProperties = new List<PropertyInfo>();

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

        public override void VisitCaseExpression(CaseExpression caseExpression)
        {
            if (caseExpression.WhenExpressions.Count < 1)
            {
                throw new SqlErrorException("A CASE expression must have a WHEN ... THEN");
            }

            //First when is collected since the data type must be known for the ELSE null.
            caseExpression.WhenExpressions[0].BooleanExpression.Accept(this);
            var initialBooleanExpr = PopStack();
            caseExpression.WhenExpressions[0].ScalarExpression.Accept(this);
            var initialScalarExpr = PopStack();

            var nullableType = NullableUtils.ToNullable(initialScalarExpr.Type);
            bool conversionRequired = false;

            //Create the else expression
            Expression previousExpr;
            if (caseExpression.ElseExpression != null)
            {
                caseExpression.ElseExpression.Accept(this);
                previousExpr = PopStack();

                //Check if the else expression requires conversion on the type
                if (previousExpr.Type != initialScalarExpr.Type && previousExpr.Type == nullableType)
                {
                    conversionRequired = true;
                }
            }
            else
            {
                previousExpr = Expression.Constant(null, nullableType);

                if (nullableType != initialScalarExpr.Type)
                {
                    conversionRequired = true;
                }
            }

            //Go through the other when expressions, start from the bottom and go up
            for (int i = caseExpression.WhenExpressions.Count - 1; i > 0; i--)
            {
                caseExpression.WhenExpressions[i].BooleanExpression.Accept(this);
                var booleanExpr = PopStack();
                caseExpression.WhenExpressions[i].ScalarExpression.Accept(this);
                var scalarExpr = PopStack();

                //Check if any conversion is required
                if (conversionRequired && scalarExpr.Type != nullableType)
                {
                    scalarExpr = Expression.Convert(scalarExpr, nullableType);
                }
                previousExpr = Expression.Condition(booleanExpr, scalarExpr, previousExpr);
            }

            if (conversionRequired)
            {
                initialScalarExpr = Expression.Convert(initialScalarExpr, nullableType);
            }

            //Add the initial when expression
            var expression = Expression.Condition(initialBooleanExpr, initialScalarExpr, previousExpr);
            AddExpressionToStack(expression);
        }
    }
}
