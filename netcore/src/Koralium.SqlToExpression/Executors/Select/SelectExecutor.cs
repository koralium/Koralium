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
using Koralium.SqlToExpression.Executors.Select;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public abstract class SelectExecutor<InType, OutType> : ISelectExecutor
    {
        public async ValueTask<SelectResult> Execute(IQueryable queryable, ExecuteSelectStage selectStage)
        {
            return new SelectResult(await ExecuteSelect((IQueryable<InType>)queryable, selectStage), selectStage.Columns);
        }

        public abstract ValueTask<IQueryable<OutType>> ExecuteSelect(IQueryable<InType> queryable, ExecuteSelectStage selectStage);

        protected Expression<Func<InType, OutType>> GetLambda(ExecuteSelectStage selectStage)
        {
            var lambda = Expression.Lambda<Func<InType, OutType>>(selectStage.Expression, selectStage.ParameterExpression);
            return lambda;
        }
    }
}
