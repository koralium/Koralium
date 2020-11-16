using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.Where
{
    internal class LikeVisitor : BaseVisitor
    {
        private readonly IQueryStage _previousStage;
        private readonly Stack<Expression> expressions = new Stack<Expression>();
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

        private VisitResult VisitBinaryExpression_Internal(SqlParser.Expressions.BinaryExpression binaryExpression)
        {
            var leftResult = VisitInternal(binaryExpression.Left);

            //Left result should only contain: '%text' or 'text'
            if (leftResult.StartsWith && !leftResult.WildcardOnly)
            {
                throw new SqlErrorException("Like expression can only support starts with ('text%'), ends with ('%text') and contains ('%text%') at this time");
            }

            var rightResult = VisitInternal(binaryExpression.Right);

            //Right result should only contain 'text%' or 'text'
            if (rightResult.EndsWith && !rightResult.WildcardOnly)
            {
                throw new SqlErrorException("Like expression can only support starts with ('text%'), ends with ('%text') and contains ('%text%') at this time");
            }

            if (binaryExpression.Type != BinaryType.Add)
            {
                throw new SqlErrorException("Like expression can only do string concatination at this time");
            }

            //If one of the results are null, they have been removed since they were just '%'
            //We only return the other result since concat is not required
            if (leftResult.Expression == null)
            {
                return rightResult;
            }

            //Remove empty strings that was just for wildcarding
            if (leftResult.WildcardOnly && rightResult.WildcardOnly)
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

            var expression = BinaryUtils.CreateBinaryExpression(leftResult.Expression, rightResult.Expression, BinaryType.Add);

            return new VisitResult()
            {
                StartsWith = rightResult.StartsWith || rightResult.WildcardOnly,
                EndsWith = leftResult.EndsWith || leftResult.WildcardOnly,
                Expression = expression
            };
        }

        private VisitResult VisitStringLiteral_Internal(StringLiteral stringLiteral)
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

        private VisitResult VisitVariableReference_Internal(VariableReference variableReference)
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

        private VisitResult VisitColumnReferenceExpression_Internal(ColumnReference columnReference)
        {
            var identifiers = columnReference.Identifiers;

            identifiers = MemberUtils.RemoveAlias(_previousStage, identifiers);
            var memberAccess = MemberUtils.GetMember(_previousStage, identifiers, out var property);
            AddUsedProperty(property);
            return new VisitResult()
            {
                Expression = memberAccess
            };
        }

        private VisitResult VisitInternal(ScalarExpression scalarExpression)
        {
            if (scalarExpression is SqlParser.Expressions.BinaryExpression binaryExpression)
            {
                return VisitBinaryExpression_Internal(binaryExpression);
            }
            else if (scalarExpression is StringLiteral stringLiteral)
            {
                return VisitStringLiteral_Internal(stringLiteral);
            }
            else if (scalarExpression is VariableReference variableReference)
            {
                return VisitVariableReference_Internal(variableReference);
            }
            else if (scalarExpression is ColumnReference columnReferenceExpression)
            {
                return VisitColumnReferenceExpression_Internal(columnReferenceExpression);
            }
            else
            {
                throw new SqlErrorException("Like expression only supports strings, string concatination, variable references and column references");
            }
        }

        public override void VisitLikeExpression(LikeExpression likeExpression)
        {
            likeExpression.Left.Accept(this);

            var leftExpression = PopStack();

            var visitResult = VisitInternal(likeExpression.Right);

            if (visitResult.StartsWith && visitResult.EndsWith)
            {
                var containsExpression = PredicateUtils.CallContains(
                    leftExpression,
                    visitResult.Expression,
                    _visitorMetadata.StringOperationsProvider);
                AddExpressionToStack(containsExpression);
            }
            //Starts with
            else if (visitResult.StartsWith)
            {
                var startsWithExpression = PredicateUtils.CallStartsWith(
                    leftExpression,
                    visitResult.Expression,
                    _visitorMetadata.StringOperationsProvider);
                AddExpressionToStack(startsWithExpression);
            }
            //Ends with
            else if (visitResult.EndsWith)
            {
                var endsWithExpression = PredicateUtils.CallEndsWith(
                    leftExpression,
                    visitResult.Expression,
                    _visitorMetadata.StringOperationsProvider);
                AddExpressionToStack(endsWithExpression);
            }
            else
            {
                var equalsExpression = PredicateUtils.CreateComparisonExpression(
                    leftExpression,
                    visitResult.Expression,
                    BooleanComparisonType.Equals,
                    _visitorMetadata.StringOperationsProvider);
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
