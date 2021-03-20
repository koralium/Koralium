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
using Koralium.SqlToExpression.Interfaces;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Utils
{
    internal static class MemberUtils
    {
        public static Expression GetMember(IQueryStage previousStage, List<string> identifiers, in IOperationsProvider operationsProvider, out PropertyInfo firstProperty)
        {
            Debug.Assert(previousStage != null, $"{nameof(previousStage)} was null");
            Debug.Assert(identifiers != null, $"{nameof(identifiers)} was null");
            Debug.Assert(identifiers.Count > 0, $"{nameof(identifiers)} was empty");

            return GetMember_Internal(identifiers, previousStage.FromAliases, previousStage.TypeInfo, previousStage.ParameterExpression, operationsProvider, out firstProperty);
        }

        public static Expression GetMemberGroupByInValue(GroupedStage previousStage, List<string> identifiers, in IOperationsProvider operationsProvider, out PropertyInfo firstProperty)
        {
            Debug.Assert(previousStage != null, $"{nameof(previousStage)} was null");
            Debug.Assert(identifiers != null, $"{nameof(identifiers)} was null");
            Debug.Assert(identifiers.Count > 0, $"{nameof(identifiers)} was empty");

            return GetMember_Internal(identifiers, previousStage.FromAliases, previousStage.TypeInfo, previousStage.ValueParameterExpression, operationsProvider, out firstProperty);
        }

        public static Expression GetMemberGroupByInKey(GroupedStage previousStage, List<string> identifiers, in IOperationsProvider operationsProvider, out PropertyInfo firstProperty)
        {
            Debug.Assert(previousStage != null, $"{nameof(previousStage)} was null");
            Debug.Assert(identifiers != null, $"{nameof(identifiers)} was null");
            Debug.Assert(identifiers.Count > 0, $"{nameof(identifiers)} was empty");

            return GetMember_Internal(identifiers, previousStage.FromAliases, previousStage.KeyTypeInfo, previousStage.KeyParameterExpression, operationsProvider, out firstProperty);
        }

        public static List<string> RemoveAlias(IQueryStage previousStage, List<string> identifiers)
        {
            if (previousStage.FromAliases.AliasExists(identifiers[0]))
            {
                if (identifiers.Count < 2)
                {
                    throw new SqlErrorException("Only got an alias as a order by column");
                }
                identifiers = identifiers.GetRange(1, identifiers.Count - 1);
            }
            return identifiers;
        }

        private static Expression GetMember_Internal(
            List<string> identifiers,
            in FromAliases fromAliases,
            in SqlTypeInfo typeInfo,
            in Expression parameterExpression,
            in IOperationsProvider operationsProvider,
            out PropertyInfo firstProperty)
        {
            if (!typeInfo.TryGetProperty(identifiers[0], out var property))
            {
                throw new SqlErrorException($"Column {identifiers[0]} was not found, maybe it is not in the group by?");
            }
            if (property.GetCustomAttribute<KoraliumIgnoreAttribute>() != null)
            {
                throw new SqlErrorException($"Column {identifiers[0]} does not exist");
            }
            //Set the original property, used to create a list of all used columns
            typeInfo.TryGetOriginalProperty(identifiers[0], out firstProperty);

            Expression memberAccess = Expression.MakeMemberAccess(parameterExpression, property);

            for (int i = 1; i < identifiers.Count; i++)
            {
                memberAccess = operationsProvider.MakeSubfieldMemberAccessExpression(memberAccess, GetTypeProperty(memberAccess.Type, identifiers[i]));
            }
            return memberAccess;
        }

       

        public static PropertyInfo GetTypeProperty(Type type, string property)
        {
            var propertyInfo = type.GetTypeInfo().GetProperty(property, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
            return propertyInfo;
        }
    }
}
