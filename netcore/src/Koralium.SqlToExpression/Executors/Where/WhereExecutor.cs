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
    public abstract class WhereExecutor<Entity> : IWhereExecutor
    {
        public async ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteWhereStage executeWhereStage)
        {
            return await ExecuteWhere((IQueryable<Entity>)queryable, executeWhereStage);
        }

        public abstract ValueTask<IQueryable<Entity>> ExecuteWhere(IQueryable<Entity> queryable, ExecuteWhereStage whereStage);

        protected Expression<Func<Entity, bool>> GetLambda(ExecuteWhereStage whereStage)
        {
            return Expression.Lambda<Func<Entity, bool>>(whereStage.Expression, whereStage.ParameterExpression);
        }
    }
}
