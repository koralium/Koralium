using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    /// <summary>
    /// Executor that gets a table as an IQueryable
    /// </summary>
    public interface IFromTableExecutor
    {
        ValueTask<IQueryable> Execute(ITableResolver tableResolver, ExecuteFromTableStage executeFromTableStage, object additionalData);
    }
}
