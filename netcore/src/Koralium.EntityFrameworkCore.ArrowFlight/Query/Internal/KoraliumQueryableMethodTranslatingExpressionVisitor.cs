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
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Query.Internal
{
    public class KoraliumQueryableMethodTranslatingExpressionVisitor : RelationalQueryableMethodTranslatingExpressionVisitor
    {
        public KoraliumQueryableMethodTranslatingExpressionVisitor(QueryableMethodTranslatingExpressionVisitorDependencies dependencies,
            RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies, IModel model)
            : base(dependencies, relationalDependencies, model)
        {
        }

        protected override ShapedQueryExpression TranslateAny(ShapedQueryExpression source, LambdaExpression predicate)
        {
            return base.TranslateAny(source, predicate);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            return base.VisitBinary(node);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            return base.VisitUnary(node);
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            return base.VisitConditional(node);
        }

        protected override Expression VisitConstant(ConstantExpression constantExpression)
        {
            return base.VisitConstant(constantExpression);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return base.VisitLambda(node);
        }

        protected override ShapedQueryExpression TranslateWhere(ShapedQueryExpression source, LambdaExpression predicate)
        {
            return base.TranslateWhere(source, predicate);
        }

        protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
        {
            
            return base.VisitMethodCall(methodCallExpression);
        }
    }
}
