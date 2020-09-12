using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors.Offset
{
    public class DefaultOffsetExecutor<Entity> : OffsetExecutor<Entity>
    {
        public override ValueTask<IQueryable<Entity>> ExecuteOffset(IQueryable<Entity> queryable, ExecuteOffsetStage executeOffsetStage)
        {
            if(executeOffsetStage.Skip != null)
            {
                queryable = queryable.Skip(executeOffsetStage.Skip.Value);
            }

            if(executeOffsetStage.Take != null)
            {
                queryable = queryable.Take(executeOffsetStage.Take.Value);
            }

            return new ValueTask<IQueryable<Entity>>(queryable);
        }
    }
}
