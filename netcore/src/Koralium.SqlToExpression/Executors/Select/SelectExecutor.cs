using Koralium.SqlToExpression.Executors.Select;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Immutable;
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
