using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Immutable;

namespace Koralium.SqlToExpression.Visitors.OrderBy
{
    internal static class OrderByHelper
    {
        public static IQueryStage GetOrderByStage(IQueryStage previousStage, OrderByClause orderByClause, VisitorMetadata visitorMetadata)
        {
            if(previousStage is GroupedStage groupedStage)
            {
                OrderByAggregationsVisitor orderByAggregationsVisitor = new OrderByAggregationsVisitor(groupedStage, visitorMetadata);
                orderByClause.Accept(orderByAggregationsVisitor);

                return new GroupedOrderByStage(
                    groupedStage.CurrentType,
                    groupedStage.ValueType,
                    groupedStage.TypeInfo,
                    groupedStage.KeyTypeInfo,
                    groupedStage.ParameterExpression,
                    groupedStage.KeyParameterExpression,
                    groupedStage.ValueParameterExpression,
                    groupedStage.FromAliases,
                    orderByAggregationsVisitor.SortItems.ToImmutableList()
                );
            }
            else
            {
                OrderByPlainVisitor visitor = new OrderByPlainVisitor(previousStage, visitorMetadata);
                orderByClause.Accept(visitor);

                return new OrderByStage(
                    previousStage.CurrentType,
                    previousStage.TypeInfo,
                    previousStage.ParameterExpression,
                    previousStage.FromAliases,
                    visitor.SortItems.ToImmutableList()
                    );
            }
        }
    }
}
