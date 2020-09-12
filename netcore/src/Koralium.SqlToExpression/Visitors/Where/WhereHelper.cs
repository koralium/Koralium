using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Koralium.SqlToExpression.Visitors.Where
{
    internal static class WhereHelper
    {
        public static WhereStage GetWhereStage(IQueryStage previousStage, WhereClause whereClause, VisitorMetadata visitorMetadata)
        {
            WhereVisitor whereVisitor = new WhereVisitor(previousStage, visitorMetadata);
            whereClause.Accept(whereVisitor);

            return new WhereStage(
                previousStage.TypeInfo,
                previousStage.ParameterExpression,
                whereVisitor.Expression,
                previousStage.CurrentType,
                previousStage.FromAliases
                );
        }
    }
}
