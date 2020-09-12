using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultFromTableExecutor<Entity> : FromTableExecutor<Entity>
    {
        public override async ValueTask<IQueryable<Entity>> GetTable(ITableResolver tableResolver, ExecuteFromTableStage executeFromTableStage, object additionalData)
        {
            return (IQueryable<Entity>)await tableResolver.ResolveTableName(executeFromTableStage.TableName, additionalData);
        }
    }
}
