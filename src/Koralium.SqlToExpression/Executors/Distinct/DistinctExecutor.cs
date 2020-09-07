using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public abstract class DistinctExecutor<Entity> : IDistinctExecutor
    {
        public async ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteDistinctStage executeDistinctStage)
        {
            return await ExecuteDistinct((IQueryable<Entity>)queryable, executeDistinctStage);
        }

        public abstract ValueTask<IQueryable<Entity>> ExecuteDistinct(IQueryable<Entity> queryable, ExecuteDistinctStage executeDistinctStage);
    }
}
