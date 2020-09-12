using Koralium.SqlToExpression.Stages.CompileStages;

namespace Koralium.SqlToExpression.Visitors.Distinct
{
    internal static class DistinctHelper
    {
        public static DistinctStage GetDistinctStage(IQueryStage previousStage)
        {
            return new DistinctStage(
                previousStage.TypeInfo,
                previousStage.ParameterExpression,
                previousStage.CurrentType,
                previousStage.FromAliases
                );
        }
    }
}
