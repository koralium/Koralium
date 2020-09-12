using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public abstract class WhereExecutor<Entity> : IWhereExecutor
    {
        public async ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteWhereStage whereStage)
        {
            return await ExecuteWhere((IQueryable<Entity>)queryable, whereStage);
        }

        public abstract ValueTask<IQueryable<Entity>> ExecuteWhere(IQueryable<Entity> queryable, ExecuteWhereStage whereStage);

        protected Expression<Func<Entity, bool>> GetLambda(ExecuteWhereStage whereStage)
        {
            return Expression.Lambda<Func<Entity, bool>>(whereStage.Expression, whereStage.ParameterExpression);
        }
    }
}
