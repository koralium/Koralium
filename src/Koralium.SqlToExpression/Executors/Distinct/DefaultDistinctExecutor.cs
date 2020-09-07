using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultDistinctExecutor<Entity> : DistinctExecutor<Entity>
    {
        public override ValueTask<IQueryable<Entity>> ExecuteDistinct(IQueryable<Entity> queryable, ExecuteDistinctStage executeDistinctStage)
        {
            return new ValueTask<IQueryable<Entity>>(queryable.Distinct());
        }
    }
}
