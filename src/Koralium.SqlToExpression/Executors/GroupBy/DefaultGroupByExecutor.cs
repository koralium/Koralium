using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultGroupByExecutor<Entity, KeyType> : GroupByExecutor<Entity, KeyType>
    {

        public override ValueTask<IQueryable<IGrouping<KeyType, Entity>>> ExecuteGroupBy(IQueryable<Entity> queryable, ExecuteGroupByStage groupByStage)
        {
            return new ValueTask<IQueryable<IGrouping<KeyType, Entity>>>(queryable.GroupBy(GetLambda(groupByStage)));
        }
    }
}
