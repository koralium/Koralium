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
