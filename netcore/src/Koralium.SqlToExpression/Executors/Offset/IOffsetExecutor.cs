using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors.Offset
{
    public interface IOffsetExecutor
    {
        ValueTask<IQueryable> Execute(IQueryable queryable, ExecuteOffsetStage executeOffsetStage);
    }
}
