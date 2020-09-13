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
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public abstract class OrderByExecutor<Entity> : IOrderByExecutor
    {
        public async ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteOrderByStage executeOrderByStage)
        {
            return await ExecuteOrderBy((IQueryable<Entity>)queryable, executeOrderByStage);
        }

        public abstract ValueTask<IQueryable<Entity>> ExecuteOrderBy(IQueryable<Entity> queryable, ExecuteOrderByStage executeOrderByStage);

        protected Expression<Func<Entity, object>> GetSortLambda(SortItem sortItem, ParameterExpression parameterExpression)
        {
            var lambda = Expression.Lambda<Func<Entity, object>>(sortItem.Expression, parameterExpression);
            return lambda;
        }
    }
}
