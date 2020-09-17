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
using Microsoft.SqlServer.TransactSql.ScriptDom;
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
        private static Func<object, object>[] getDelegates = BuildGetDeletages();

        public static SelectStage GetSelectStage(
            IQueryStage previousStage, 
            IList<SelectElement> selectElements,
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
            NewExpression newExpression = Expression.New(typeof(AnonType));

            List<MemberAssignment> assignments = new List<MemberAssignment>();
            var columnsBuilder = ImmutableList.CreateBuilder<ColumnMetadata>();
            for (int i = 0; i < selects.Count; i++)
            {
                columnsBuilder.Add(new ColumnMetadata(selects[i].Alias, selects[i].Expression.Type, getDelegates[i]));
                var convertedSelect = Expression.Convert(selects[i].Expression, typeof(object));
                var propertyInfo = typeof(AnonType).GetProperty($"P{i}");
                var assignment = Expression.Bind(propertyInfo, convertedSelect);
                assignments.Add(assignment);
                typeBuilder.AddProperty(selects[i].Alias, propertyInfo);
            }

            var memberInit = Expression.MemberInit(newExpression, assignments);

            return new SelectStage(typeBuilder.Build(),
                Expression.Parameter(typeof(AnonType)),
                memberInit,
                typeof(AnonType),
                previousStage.CurrentType,
                previousStage.ParameterExpression,
                previousStage.FromAliases,
                columnsBuilder.ToImmutable());
        }

        private static Func<object, object>[] BuildGetDeletages()
        {
            var properties = typeof(AnonType).GetProperties();
            Func<object, object>[] output = new Func<object, object>[properties.Length];

            for(int i = 0; i < output.Length; i++)
            {
                output[i] = CreateGetDelegate(typeof(AnonType), properties[i].GetGetMethod());
            }
            return output;
        }


        static Func<object, object> CreateGetDelegate(Type objectType, MethodInfo method)
        {
            return CreateGetDelegateInternal(objectType, method);
        }

        static Func<object, object> CreateGetDelegateInternal(Type objectType, MethodInfo method)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(SelectHelper).GetMethod("CreateGetDelegateHelper",
                BindingFlags.Static | BindingFlags.NonPublic);
#pragma warning restore S3011

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (objectType, method.ReturnType);

            // Now call it. The null argument is because it's a static method.
            object ret = constructedHelper.Invoke(null, new object[] { method });

            // Cast the result to the right kind of delegate and return it
            return (Func<object, object>)ret;
        }

#pragma warning disable S1144 // Unused private types or members should be removed
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used through reflection")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed", Justification = "Assignment is used")]
        static Func<object, object> CreateGetDelegateHelper<TTarget, TReturn>(MethodInfo method)
            where TTarget : class
        {
            // Convert the slow MethodInfo into a fast, strongly typed, open delegate
            Func<TTarget, TReturn> func = (Func<TTarget, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TReturn>), method);

            // Now create a more weakly typed delegate which will call the strongly typed one
            object ret(object target) => func((TTarget)target);
            return ret;
        }
#pragma warning restore S1144 // Unused private types or members should be removed
    }
}
