
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors.Offset
{
    public abstract class OffsetExecutor<Entity> : IOffsetExecutor
    {
        public async ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteOffsetStage executeOffsetStage)
        {
            return await ExecuteOffset((IQueryable<Entity>)queryable, executeOffsetStage);
        }

        public abstract ValueTask<IQueryable<Entity>> ExecuteOffset(IQueryable<Entity> queryable, ExecuteOffsetStage executeOffsetStage);
    }
}
