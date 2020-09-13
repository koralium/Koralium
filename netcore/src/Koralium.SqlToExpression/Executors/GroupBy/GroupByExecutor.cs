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
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public abstract class GroupByExecutor<Entity, KeyType> : IGroupByExecutor
    {
        public async ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteGroupByStage groupByStage)
        {
            return await ExecuteGroupBy((IQueryable<Entity>)queryable, groupByStage);
        }

        public abstract ValueTask<IQueryable<IGrouping<KeyType, Entity>>> ExecuteGroupBy(IQueryable<Entity> queryable, ExecuteGroupByStage groupByStage);

        protected Expression<Func<Entity, KeyType>> GetLambda(ExecuteGroupByStage groupByStage)
        {
            return Expression.Lambda<Func<Entity, KeyType>>(groupByStage.Expression, groupByStage.ParameterExpression);
        }
    }
}
