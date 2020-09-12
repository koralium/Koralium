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
