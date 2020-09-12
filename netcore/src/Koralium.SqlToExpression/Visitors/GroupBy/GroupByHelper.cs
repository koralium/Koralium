using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.GroupBy
{
    internal static class GroupByHelper
    {
        public static GroupByStage GetGroupByStage(IQueryStage previousStage, GroupByClause groupByClause)
        {
            GroupByVisitor groupByVisitor = new GroupByVisitor(previousStage);
            groupByClause.Accept(groupByVisitor);

            var expressions = groupByVisitor.GroupByExpressions;

            var propertyTypes = expressions.Select(x => x.Expression.Type).ToArray();
            var tupleType = GetTupleType(propertyTypes);
            var builder = SqlTypeInfo.NewBuilder();
            var tupleProperties = tupleType.GetProperties();

            for (int i = 0; i < expressions.Count; i++)
            {
                builder.AddProperty(expressions[i].Name, tupleProperties[i]);
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