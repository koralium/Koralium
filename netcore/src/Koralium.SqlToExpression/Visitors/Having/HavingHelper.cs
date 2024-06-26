﻿/*
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
using Koralium.Shared;
using Koralium.SqlParser.Clauses;
using Koralium.SqlToExpression.Stages.CompileStages;
using System.Collections.Generic;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors.Having
{
    internal static class HavingHelper
    {
        public static HavingStage GetHavingStage(
            IQueryStage queryStage,
            HavingClause havingClause,
            VisitorMetadata visitorMetadata,
            HashSet<PropertyInfo> usedProperties)
        {
            if (queryStage is GroupedStage groupedStage)
            {
                HavingVisitor havingVisitor = new HavingVisitor(groupedStage, visitorMetadata);
                havingClause.Accept(havingVisitor);

                foreach (var property in havingVisitor.UsedProperties)
                {
                    usedProperties.Add(property);
                }

                return new HavingStage(
                        groupedStage.CurrentType,
                        groupedStage.ValueType,
                        groupedStage.TypeInfo,
                        groupedStage.KeyTypeInfo,
                        groupedStage.ParameterExpression,
                        groupedStage.KeyParameterExpression,
                        groupedStage.ValueParameterExpression,
                        groupedStage.FromAliases,
                        havingVisitor.Expression
                    );
            }
            else
            {
                throw new SqlErrorException("Having can only be used in a grouped query, or a query with only aggregations");
            }
        }
    }
}
