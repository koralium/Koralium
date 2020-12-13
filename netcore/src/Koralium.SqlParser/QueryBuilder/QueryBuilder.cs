using Koralium.SqlParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlParser
{
    /// <summary>
    /// Class that helps building up specific parts of a query using expressions
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public static class QueryBuilder
    {
        /// <summary>
        /// Create a boolean sql expression using expressions
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static BooleanExpression BooleanExpression<TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            var evaluatedExpression = PartialEvaluator.PartialEval(expression);
            var visitor = new FilterExpressionVisitor();
            visitor.Visit(evaluatedExpression);
            return visitor.BooleanExpression;
        }

        public static BooleanExpression And(params BooleanExpression[] booleanBinaryExpressions)
        {
            return Binary_Internal(booleanBinaryExpressions, BooleanBinaryType.AND);
        }

        public static BooleanExpression And(IEnumerable<BooleanExpression> expressions)
        {
            return Binary_Internal(expressions, BooleanBinaryType.AND);
        }

        private static BooleanExpression Binary_Internal(IEnumerable<BooleanExpression> expressions, BooleanBinaryType booleanBinaryType)
        {
            if(!(expressions is IReadOnlyList<BooleanExpression> list))
            {
                list = expressions.ToList();
            }
            if(list.Count == 0)
            {
                return null;
            }
            var first = list.First();

            if(list.Count == 1)
            {
                return first;
            }

            var second = list[1];

            var binaryExpression = new BooleanBinaryExpression()
            {
                Left = first,
                Right = second,
                Type = booleanBinaryType
            };

            for(int i = 2; i < list.Count; i++)
            {
                binaryExpression = new BooleanBinaryExpression()
                {
                    Left = binaryExpression,
                    Right = list[i],
                    Type = booleanBinaryType
                };
            }

            return binaryExpression;
        }

        public static BooleanExpression Or(params BooleanExpression[] expressions)
        {
            return Binary_Internal(expressions, BooleanBinaryType.OR);
        }

        public static BooleanExpression Or(IEnumerable<BooleanExpression> expressions)
        {
            return Binary_Internal(expressions, BooleanBinaryType.OR);
        }
    }
}
