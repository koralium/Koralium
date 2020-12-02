using Koralium.SqlParser.Expressions;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal static class SelectHelper
    {
        public static SelectAggregateFunctionStage GetSelectAggregateFunctionStage(
            IQueryStage previousStage,
            IList<SqlParser.Expressions.SelectExpression> selectElements,
            VisitorMetadata visitorMetadata,
            HashSet<PropertyInfo> usedProperties
            )
        {
            SingleAggregateVisitor singleAggregateVisitor = new SingleAggregateVisitor(
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
            IList<SqlParser.Expressions.SelectExpression> selectElements,
            VisitorMetadata visitorMetadata,
            HashSet<PropertyInfo> usedProperties)
        {
            ISelectVisitor selectVisitor;
            if (previousStage is GroupedStage groupedStage)
            {
                selectVisitor = new SelectAggregationVisitor(groupedStage, visitorMetadata);
            }
            else
            {
                selectVisitor = new SelectPlainVisitor(previousStage, visitorMetadata);
            }

            foreach (var selectElement in selectElements)
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

            for (int i = 0; i < selects.Count; i++)
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
