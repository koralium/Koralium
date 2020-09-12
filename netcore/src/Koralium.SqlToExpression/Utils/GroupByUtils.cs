using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Utils
{
    class GroupByUtils
    {

        internal static GroupByStage CreateStaticGroupBy(
            IQueryStage previousStage
            )
        {
            return CreateStaticGroupBy(previousStage.CurrentType, previousStage.TypeInfo, previousStage.ParameterExpression, previousStage.FromAliases);
        }

        internal static GroupByStage CreateStaticGroupBy(
            Type inputType,
            SqlTypeInfo previousStageTypeInfo,
            ParameterExpression previousStageParameterExpression,
            FromAliases fromAliases)
        {
            var tupleType = GetTupleType(typeof(int));
            var groupingType = GetGroupingType(tupleType, inputType);

            //There is no group by, so there is no key or possibility to select anything else than aggregations
            var keyTypeInfo = SqlTypeInfo.NewBuilder().Build();

            var groupParameter = Expression.Parameter(groupingType);

            var keyParameterExpression = GetKeyParameterExpression(groupingType, groupParameter);

            var constructor = tupleType.GetConstructor(new[] { typeof(int) });
            var groupByExpression = Expression.New(constructor, new[] { Expression.Constant(1) });

            return new GroupByStage(
                groupingType,
                inputType,
                previousStageTypeInfo,
                keyTypeInfo,
                groupParameter,
                keyParameterExpression,
                previousStageParameterExpression,
                groupByExpression,
                tupleType,
                fromAliases
                );
        }

        internal static Expression GetKeyParameterExpression(Type groupingType, ParameterExpression groupParameter)
        {
            var keyPropertyInfo = groupingType.GetProperty("Key");
            return Expression.MakeMemberAccess(groupParameter, keyPropertyInfo);
        }

        internal static Type GetTupleType(params Type[] types)
        {
            var tupleTypeDefinition = typeof(Tuple).Assembly.GetType("System.Tuple`" + types.Length);
            var tupleType = tupleTypeDefinition.MakeGenericType(types);
            return tupleType;
        }

        internal static Type GetGroupingType(Type keyType, Type inputType)
        {
            var groupingTypeDefinition = typeof(IGrouping<,>);
            return groupingTypeDefinition.MakeGenericType(keyType, inputType);
        }
    }
}
