using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultSelectExecutor<InType, OutType> : SelectExecutor<InType, OutType>
    {
        public override ValueTask<IQueryable<OutType>> ExecuteSelect(IQueryable<InType> queryable, ExecuteSelectStage selectStage)
        {
            return new ValueTask<IQueryable<OutType>>(queryable.Select(GetLambda(selectStage)));
        }
    }
}
