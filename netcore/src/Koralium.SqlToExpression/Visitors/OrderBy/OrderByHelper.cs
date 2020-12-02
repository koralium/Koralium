using Koralium.SqlParser.Clauses;
using Koralium.SqlToExpression.Stages.CompileStages;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors.OrderBy
{
    internal static class OrderByHelper
    {
        public static IQueryStage GetOrderByStage(
            IQueryStage previousStage,
            OrderByClause orderByClause,
            VisitorMetadata visitorMetadata,
            HashSet<PropertyInfo> usedProperties)
        {
            if (previousStage is GroupedStage groupedStage)
            {
                OrderByAggregationsVisitor orderByAggregationsVisitor = new OrderByAggregationsVisitor(groupedStage, visitorMetadata);
                orderByClause.Accept(orderByAggregationsVisitor);

                foreach (var property in orderByAggregationsVisitor.UsedProperties)
                {
                    usedProperties.Add(property);
                }

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

                foreach (var property in visitor.UsedProperties)
                {
                    usedProperties.Add(property);
                }

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
