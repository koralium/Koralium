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
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Linq.Expressions;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Query.Internal
{
    public class KoraliumSqlTranslatingExpressionVisitor : RelationalSqlTranslatingExpressionVisitor
    {
        public KoraliumSqlTranslatingExpressionVisitor(RelationalSqlTranslatingExpressionVisitorDependencies dependencies, IModel model, QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor)
            : base(dependencies, model, queryableMethodTranslatingExpressionVisitor)
        {
        }

        protected virtual Expression TranslateAny(MethodCallExpression methodCallExpression)
        {
            var left = Visit(methodCallExpression.Arguments[0]) as SqlExpression;
            var lambda = methodCallExpression.Arguments[1] as LambdaExpression;
            var result = Visit(lambda.Body) as SqlExpression;

            var lambdaVisitor = new KoraliumLambdaVisitor();
            result = lambdaVisitor.Visit(result) as SqlExpression;

            var param = lambda.Parameters.First();
            var sqlParameter = Dependencies.SqlExpressionFactory.Fragment(param.Name);

            var mapping = new BoolTypeMapping("bool");
            var sqlExpression = Dependencies.SqlExpressionFactory.Function("any_match", new SqlExpression[]
            {
                left,
                new SqlLambdaExpression(sqlParameter, result, typeof(bool), mapping)
            }, typeof(bool));

            return sqlExpression;
        }

        protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
        {
            switch (methodCallExpression.Method.Name)
            {
                case "Any":
                    return TranslateAny(methodCallExpression);
            }
            return base.VisitMethodCall(methodCallExpression);
        }
    }
}
