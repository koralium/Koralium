using Koralium.SqlParser.Clauses;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.GroupBy
{
    internal static class GroupByHelper
    {
        public static GroupByStage GetGroupByStage(
            IQueryStage previousStage,
            GroupByClause groupByClause,
            HashSet<PropertyInfo> usedProperties)
        {
            GroupByVisitor groupByVisitor = new GroupByVisitor(previousStage);
            groupByClause.Accept(groupByVisitor);

            foreach (var property in groupByVisitor.UsedProperties)
            {
                usedProperties.Add(property);
            }

            var expressions = groupByVisitor.GroupByExpressions;

            var propertyTypes = expressions.Select(x => x.Expression.Type).ToArray();
            var tupleType = GetTupleType(propertyTypes);
            var builder = SqlTypeInfo.NewBuilder();
            var tupleProperties = tupleType.GetProperties();

            for (int i = 0; i < expressions.Count; i++)
            {
                builder.AddProperty(expressions[i].Name, tupleProperties[i], expressions[i].OriginalProperty);
            }

            var groupingType = GetGroupingType(tupleType, previousStage.CurrentType);

            var constructor = tupleType.GetConstructor(propertyTypes);
            var groupByExpression = Expression.New(constructor, expressions.Select(x => x.Expression));

            var groupParameter = Expression.Parameter(groupingType);

            var keyPropertyInfo = groupingType.GetProperty("Key");
            var keyParameterExpression = Expression.MakeMemberAccess(groupParameter, keyPropertyInfo);

            return new GroupByStage(
                groupingType,
                previousStage.CurrentType,
                previousStage.TypeInfo,
                builder.Build(),
                groupParameter,
                keyParameterExpression,
                previousStage.ParameterExpression,
                groupByExpression,
                tupleType,
                previousStage.FromAliases
                );
        }

        private static Type GetTupleType(Type[] propertyTypes)
        {
            var tupleTypeDefinition = typeof(Tuple).Assembly.GetType("System.Tuple`" + propertyTypes.Length);
            var tupleType = tupleTypeDefinition.MakeGenericType(propertyTypes);
            return tupleType;
        }

        private static Type GetGroupingType(Type keyType, Type inputType)
        {
            var groupingTypeDefinition = typeof(IGrouping<,>);
            return groupingTypeDefinition.MakeGenericType(keyType, inputType);
        }
    }
}
