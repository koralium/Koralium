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

        public override void VisitColumnReference(ColumnReference columnReference)
        {
            
            var identifiers = columnReference.Identifiers;

            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
            var memberAccess = MemberUtils.GetMember(_previousStage, identifiers, out var property);
            AddUsedProperty(property);
            AddExpressionToStack(memberAccess);
            AddNameToStack(string.Join(".", identifiers));
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
                _visitorMetadata.StringOperationsProvider);

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
    }
}
