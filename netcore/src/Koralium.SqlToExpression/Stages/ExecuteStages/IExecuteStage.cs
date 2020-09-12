using Koralium.SqlToExpression.Executors;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public interface IExecuteStage
    {
        ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor);
    }
}
