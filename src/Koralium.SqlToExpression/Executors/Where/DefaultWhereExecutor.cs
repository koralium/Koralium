using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultWhereExecutor<Entity> : WhereExecutor<Entity>
    {
        public override ValueTask<IQueryable<Entity>> ExecuteWhere(IQueryable<Entity> queryable, ExecuteWhereStage whereStage)
        {
            return new ValueTask<IQueryable<Entity>>(queryable.Where(GetLambda(whereStage)));
        }
    }
}
