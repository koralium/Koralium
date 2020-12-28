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
using Koralium.Shared;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Utils
{
    internal static class AggregationUtils
    {
        private static readonly Dictionary<Type, MethodInfo> sumDictionary = BuildSumDictionary();
        private static readonly Dictionary<Type, MethodInfo> avgDictionary = BuildAvgDictionary();
        private static readonly MethodInfo CountWildcardMethod = GetCountWildcardMethod();


        private static MethodInfo GetCountWildcardMethod()
        {
            var countMethods = typeof(Enumerable).GetMethods().Where(x => x.Name == "Count" && x.GetParameters().Length == 1).ToList();

            return countMethods.First();
        }

        private static Dictionary<Type, MethodInfo> BuildSumDictionary()
        {
            var sumMethods = typeof(Enumerable).GetMethods().Where(x => x.Name == "Sum" && x.IsGenericMethod).ToList();

            Dictionary<Type, MethodInfo> sumDict = new Dictionary<Type, MethodInfo>();
            foreach (var method in sumMethods)
            {
                sumDict.Add(method.ReturnType, method);
            }

            return sumDict;
        }

        private static Dictionary<Type, MethodInfo> BuildAvgDictionary()
        {
            var avgMethods = typeof(Enumerable).GetMethods().Where(x => x.Name == "Average" && x.IsGenericMethod).ToList();

            Dictionary<Type, MethodInfo> avgDict = new Dictionary<Type, MethodInfo>();
            foreach (var method in avgMethods)
            {
                //Last parameter of average is function select of the input type.
                var parameter = method.GetParameters().Last();
                var genericArguments = parameter.ParameterType.GetGenericArguments();

                //Last generic argument in the type that the method accepts
                var inputType = genericArguments.Last();

                avgDict.Add(inputType, method);
            }

            return avgDict;
        }

        public static AggregationType GetAggregationType(string name)
        {
            switch (name.ToLower())
            {
                case "sum":
                    return AggregationType.Sum;
                default:
                    throw new SqlErrorException($"The method '{name}' is not supported");
            }
        }

        public static MethodInfo GetSumMethod(Type inputType)
        {
            if (sumDictionary.TryGetValue(inputType, out var methodInfo))
            {
                return methodInfo;
            }

            throw new NotSupportedException($"Cannot do sum on the type {inputType.Name}");
        }

        public static MethodInfo GetAvgMethod(Type inputType)
        {
            if (avgDictionary.TryGetValue(inputType, out var methodInfo))
            {
                return methodInfo;
            }

            throw new NotSupportedException($"Cannot do average on the type {inputType.Name}");
        }

        public static Expression CallCount(GroupedStage groupedStage)
        {
            var groupedCountMethod = CountWildcardMethod.MakeGenericMethod(groupedStage.ValueType);
            var call = Expression.Call(
                instance: null,
                method: groupedCountMethod,
                arguments: new Expression[] { groupedStage.ParameterExpression});
            return call;
        }

        public static Type GetSumOutputType(Type type)
        {
            if(Equals(type, typeof(short)))
            {
                return typeof(int);
            }
            if(Equals(type, typeof(short?)))
            {
                return typeof(int?);
            }
            if(Equals(type, typeof(uint)))
            {
                return typeof(long);
            }
            if (Equals(type, typeof(uint?)))
            {
                return typeof(long?);
            }
            if(Equals(type, typeof(ulong)))
            {
                return typeof(long);
            }
            if (Equals(type, typeof(ulong?)))
            {
                return typeof(long?);
            }
            if (Equals(type, typeof(byte)))
            {
                return typeof(long);
            }
            if (Equals(type, typeof(byte?)))
            {
                return typeof(long?);
            }
            return type;
        }

        public static Expression CallSum(Expression expression, GroupedStage groupedStage)
        {
            var sumOutputType = GetSumOutputType(expression.Type);

            if (!Equals(sumOutputType, expression.Type))
            {
                expression = Expression.Convert(expression, sumOutputType);
            }

            var sumMethod = GetSumMethod(sumOutputType);
            return CallMethod(expression, sumMethod, groupedStage);
        }

        public static Expression CallMethod(Expression expression, MethodInfo method, GroupedStage stage)
        {
            var groupedSumMethod = method.MakeGenericMethod(stage.ValueType);

            var argumentLambda = Expression.Lambda(expression, stage.ValueParameterExpression);
            var call = Expression.Call(
                instance: null,
                method: groupedSumMethod,
                arguments: new Expression[] { stage.ParameterExpression, argumentLambda });

            return call;
        }
    }
}
