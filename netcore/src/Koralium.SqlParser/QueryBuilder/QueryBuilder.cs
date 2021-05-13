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
using Koralium.SqlParser.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            var evaluatedExpression = PartialEvaluator.PartialEval(expression) as System.Linq.Expressions.LambdaExpression;
            var visitor = new FilterExpressionVisitor();

            visitor.Visit(evaluatedExpression.Body);
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
