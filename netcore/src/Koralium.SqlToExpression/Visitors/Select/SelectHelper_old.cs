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
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal static class SelectHelper_old
    {
        public static SelectAggregateFunctionStage GetSelectAggregateFunctionStage(
            IQueryStage previousStage,
            IList<SelectElement> selectElements,
            VisitorMetadata visitorMetadata,
            HashSet<PropertyInfo> usedProperties
            )
        {
            SingleAggregateVisitor_old singleAggregateVisitor = new SingleAggregateVisitor_old(
                previousStage,
                visitorMetadata
                );

            foreach (var selectElement in selectElements)
            {
                selectElement.Accept(singleAggregateVisitor);
            }

            foreach (var usedProperty in singleAggregateVisitor.UsedProperties)
            {
                usedProperties.Add(usedProperty);
            }

            var typeBuilder = SqlTypeInfo.NewBuilder();
            var anonType = AnonTypeUtils.GetAnonType(singleAggregateVisitor.OutType);
            var propertyInfo = anonType.GetProperty($"P0");
            typeBuilder.AddProperty(singleAggregateVisitor.ColumnName, propertyInfo);

            return new SelectAggregateFunctionStage(
                typeBuilder.Build(),
                Expression.Parameter(anonType),
                anonType,
                previousStage.CurrentType,
                previousStage.FromAliases,
                singleAggregateVisitor.FunctionName,
                previousStage.ParameterExpression,
                singleAggregateVisitor.ColumnName,
                singleAggregateVisitor.Parameters,
                singleAggregateVisitor.OutType
                );
        }

        public static SelectStage GetSelectStage(
            IQueryStage previousStage, 
            IList<SelectElement> selectElements,
            VisitorMetadata visitorMetadata,
            HashSet<PropertyInfo> usedProperties)
        {
            ISelectVisitor_old selectVisitor;
            if (previousStage is GroupedStage groupedStage)
            {
                selectVisitor = new SelectAggregationVisitor_old(groupedStage, visitorMetadata);
            }
            else
            {
                selectVisitor = new SelectPlainVisitor_old(previousStage, visitorMetadata);
            }

            foreach(var selectElement in selectElements)
            {
                selectVisitor.VisitSelect(selectElement);
            }

            foreach (var property in selectVisitor.UsedProperties)
            {
                usedProperties.Add(property);
            }

            var selects = selectVisitor.SelectExpressions;

            Debug.Assert(selects != null);
            Debug.Assert(selects.Count > 0);

            var typeBuilder = SqlTypeInfo.NewBuilder();

            Type[] propertyTypes = new Type[selects.Count];

            for(int i = 0; i < selects.Count; i++)
            {
                propertyTypes[i] = selects[i].Expression.Type;
            }

            var anonType = AnonTypeUtils.GetAnonType(propertyTypes);

            var getDelegates = AnonTypeUtils.GetDelegates(anonType);

            NewExpression newExpression = Expression.New(anonType);

            List<MemberAssignment> assignments = new List<MemberAssignment>();
            var columnsBuilder = ImmutableList.CreateBuilder<ColumnMetadata>();
            for (int i = 0; i < selects.Count; i++)
            {
                columnsBuilder.Add(new ColumnMetadata(selects[i].Alias, selects[i].Expression.Type, getDelegates[i]));
                //var convertedSelect = Expression.Convert(selects[i].Expression, typeof(object));
                var propertyInfo = anonType.GetProperty($"P{i}");
                var assignment = Expression.Bind(propertyInfo, selects[i].Expression);
                assignments.Add(assignment);
                typeBuilder.AddProperty(selects[i].Alias, propertyInfo);
            }

            var memberInit = Expression.MemberInit(newExpression, assignments);

            return new SelectStage(typeBuilder.Build(),
                Expression.Parameter(anonType),
                memberInit,
                anonType,
                previousStage.CurrentType,
                previousStage.ParameterExpression,
                previousStage.FromAliases,
                columnsBuilder.ToImmutable());
        }
    }
}
