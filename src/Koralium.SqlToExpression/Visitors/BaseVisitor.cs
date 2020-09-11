using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors
{
    internal abstract class BaseVisitor : TSqlFragmentVisitor
    {
        private IQueryStage _previousStage;
        private readonly VisitorMetadata _visitorMetadata;

        public BaseVisitor(IQueryStage previousStage, VisitorMetadata visitorMetadata)
        {
            _previousStage = previousStage;
            _visitorMetadata = visitorMetadata;
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
            AddExpressionToStack(Expression.Constant(double.Parse(node.Value)));
        }

        public override void ExplicitVisit(NumericLiteral node)
        {
            AddExpressionToStack(Expression.Constant(double.Parse(node.Value)));
        }

        public override void ExplicitVisit(NullLiteral node)
        {
            AddExpressionToStack(Expression.Constant(null));
        }

        public override void ExplicitVisit(ColumnReferenceExpression columnReferenceExpression)
        {
            var identifiers = columnReferenceExpression.MultiPartIdentifier.Identifiers.Select(x => x.Value).ToList();

            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
            var memberAccess = MemberUtils.GetMember(_previousStage, identifiers);

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
            booleanBinaryExpression.FirstExpression.Accept(this);
            booleanBinaryExpression.SecondExpression.Accept(this);

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

            var expression = PredicateUtils.CreateComparisonExpression(leftExpression, rightExpression, booleanComparisonExpression.ComparisonType);

            AddExpressionToStack(expression);
        }

        public override void ExplicitVisit(BooleanIsNullExpression booleanIsNullExpression)
        {
            booleanIsNullExpression.Expression.Accept(this);

            var expression = PopStack();


            if (booleanIsNullExpression.IsNot)
            {
                AddExpressionToStack(Expression.NotEqual(expression, Expression.Constant(null)));
            }
            else
            {
                AddExpressionToStack(Expression.Equal(expression, Expression.Constant(null)));
            }
        }
    }
}
