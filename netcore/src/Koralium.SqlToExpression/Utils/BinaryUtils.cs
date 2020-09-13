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
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Utils
{
    public static class BinaryUtils
    {
        public static Expression CreateBinaryExpression(Expression leftExpression, Expression rightExpression, Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType binaryExpressionType)
        {
            PredicateUtils.ConvertExpressionTypes(ref leftExpression, ref rightExpression);

            Expression expression = null;
            switch (binaryExpressionType)
            {
                case Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType.Add:
                    expression = Expression.Add(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType.BitwiseAnd:
                    expression = Expression.And(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType.BitwiseOr:
                    expression = Expression.Or(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType.BitwiseXor:
                    expression = Expression.ExclusiveOr(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType.Divide:
                    expression = Expression.Divide(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType.Modulo:
                    expression = Expression.Modulo(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType.Multiply:
                    expression = Expression.Multiply(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType.Subtract:
                    expression = Expression.Subtract(leftExpression, rightExpression);
                    break;
            }

            return expression;
        }
    }
}
