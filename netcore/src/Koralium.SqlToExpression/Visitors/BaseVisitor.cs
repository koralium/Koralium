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
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors
{
    internal abstract class BaseVisitor : TSqlFragmentVisitor
    {
        private IQueryStage _previousStage;
        private readonly VisitorMetadata _visitorMetadata;
        private readonly List<PropertyInfo> _usedProperties = new List<PropertyInfo>();

        public BaseVisitor(IQueryStage previousStage, VisitorMetadata visitorMetadata)
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

        public override void ExplicitVisit(IntegerLiteral node)
        {
            AddExpressionToStack(Expression.Constant(int.Parse(node.Value)));
        }

        public override void ExplicitVisit(StringLiteral node)
        {
            if(DateTime.TryParse(node.Value, out var date))
            {
                AddExpressionToStack(Expression.Constant(date));
                return;
            }
            AddExpressionToStack(Expression.Constant(node.Value));
        }

        public override void ExplicitVisit(RealLiteral node)
        {
            AddExpressionToStack(Expression.Constant(double.Parse(node.Value, CultureInfo.InvariantCulture)));
        }

        public override void ExplicitVisit(NumericLiteral node)
        {
            AddExpressionToStack(Expression.Constant(double.Parse(node.Value, CultureInfo.InvariantCulture)));
        }

        public override void ExplicitVisit(NullLiteral node)
        {
            AddExpressionToStack(Expression.Constant(null));
            AddNameToStack("null");
        }

        public override void ExplicitVisit(ColumnReferenceExpression columnReferenceExpression)
        {
            var identifiers = columnReferenceExpression.MultiPartIdentifier.Identifiers.Select(x => x.Value).ToList();

            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
            var memberAccess = MemberUtils.GetMember(_previousStage, identifiers, out var property);
            AddUsedProperty(property);
            AddExpressionToStack(memberAccess);
            AddNameToStack(string.Join(".", identifiers));
        }

        /// <summary>
        /// Handle any binary operations in the select, such as addition etc
        /// </summary>
        /// <param name="binaryExpression"></param>
        public override void ExplicitVisit(Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpression binaryExpression)
        {
            binaryExpression.FirstExpression.Accept(this);
            binaryExpression.SecondExpression.Accept(this);


            var rightExpression = PopStack();
            var leftExpression = PopStack();

            var expression = BinaryUtils.CreateBinaryExpression(leftExpression, rightExpression, binaryExpression.BinaryExpressionType);

            AddExpressionToStack(expression);
        }

        public override void ExplicitVisit(BooleanBinaryExpression booleanBinaryExpression)
        {
            bool inOrSet = false;
            //Check if it is an OR operation and we are not already inside of one
            //This is used at this time only for checking if an index can be used or not
            if(booleanBinaryExpression.BinaryExpressionType == BooleanBinaryExpressionType.Or && !InOr)
            {
                inOrSet = true;
                InOr = true;
            }

            booleanBinaryExpression.FirstExpression.Accept(this);
            booleanBinaryExpression.SecondExpression.Accept(this);

            //Reset the in OR flag
            if (inOrSet)
            {
                InOr = false;
            }

            var rightExpression = PopStack();
            var leftExpression = PopStack(); 

            Expression expression = null;
            switch (booleanBinaryExpression.BinaryExpressionType)
            {
                case BooleanBinaryExpressionType.And:
                    expression = Expression.AndAlso(leftExpression, rightExpression);
                    break;
                case BooleanBinaryExpressionType.Or:
                    expression = Expression.OrElse(leftExpression, rightExpression);
                    break;
            }

            AddExpressionToStack(expression);
        }

        public override void ExplicitVisit(VariableReference variableReference)
        {
            if(!_visitorMetadata.Parameters.TryGetParameter(variableReference.Name, out var parameter))
            {
                throw new SqlErrorException($"The parameter {variableReference.Name} could not be found, did you have include @ before the parameter name?");
            }
            AddExpressionToStack(parameter.GetValueAsExpression());
        }

        public override void ExplicitVisit(BooleanComparisonExpression booleanComparisonExpression)
        {
            booleanComparisonExpression.FirstExpression.Accept(this);
            booleanComparisonExpression.SecondExpression.Accept(this);

            var rightExpression = PopStack();
            var leftExpression = PopStack();

            var expression = PredicateUtils.CreateComparisonExpression(
                leftExpression, 
                rightExpression, 
                booleanComparisonExpression.ComparisonType,
                _visitorMetadata.StringOperationsProvider);

            AddExpressionToStack(expression);
        }

        public override void ExplicitVisit(BooleanIsNullExpression booleanIsNullExpression)
        {
            booleanIsNullExpression.Expression.Accept(this);

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
                if(expression.Type.IsPrimitive)
                {
                    AddExpressionToStack(Expression.Constant(false));
                }
                else
                {
                    AddExpressionToStack(Expression.Equal(expression, Expression.Constant(null)));
                }
            }
        }
    }
}
