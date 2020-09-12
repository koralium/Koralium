using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public abstract class FromTableExecutor<Entity> : IFromTableExecutor
    {
        public async ValueTask<IQueryable> Execute(ITableResolver tableResolver, ExecuteFromTableStage executeFromTableStage, object additionalData)
        {
            return await GetTable(tableResolver, executeFromTableStage, additionalData);
        }

        public abstract ValueTask<IQueryable<Entity>> GetTable(ITableResolver tableResolver, ExecuteFromTableStage executeFromTableStage, object additionalData);
    }
}
