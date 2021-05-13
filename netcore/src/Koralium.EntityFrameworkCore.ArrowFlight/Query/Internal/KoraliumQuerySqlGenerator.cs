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
using Koralium.EntityFrameworkCore.ArrowFlight.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Query.Internal
{
    public class KoraliumQuerySqlGenerator : QuerySqlGenerator
    {
        public KoraliumQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies) : base(dependencies)
        {
            //NOP
        }

        public override Expression Visit(Expression node)
        {
            if (node is SqlLambdaExpression lambdaExpression)
            {
                GenerateLambda(lambdaExpression);
                return node;
            }
            return base.Visit(node);
        }

        protected virtual void GenerateLambda(SqlLambdaExpression lambdaExpression)
        {
            Visit(lambdaExpression.LambdaParameter);
            Sql.Append(" -> ");
            Visit(lambdaExpression.Inner);
        }

        protected override void GenerateLimitOffset(SelectExpression selectExpression)
        {
            if (selectExpression.Limit != null
                || selectExpression.Offset != null)
            {
                Sql.AppendLine()
                    .Append("LIMIT ");

                Visit(
                    selectExpression.Limit
                    ?? new SqlConstantExpression(Expression.Constant(-1), selectExpression.Offset.TypeMapping));

                if (selectExpression.Offset != null)
                {
                    Sql.Append(" OFFSET ");

                    Visit(selectExpression.Offset);
                }
            }
        }
    }
}
