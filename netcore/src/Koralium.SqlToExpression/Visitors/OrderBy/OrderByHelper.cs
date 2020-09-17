/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
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
            if(previousStage is GroupedStage groupedStage)
            {
                OrderByAggregationsVisitor orderByAggregationsVisitor = new OrderByAggregationsVisitor(groupedStage, visitorMetadata);
                orderByClause.Accept(orderByAggregationsVisitor);

                foreach(var property in orderByAggregationsVisitor.UsedProperties)
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
