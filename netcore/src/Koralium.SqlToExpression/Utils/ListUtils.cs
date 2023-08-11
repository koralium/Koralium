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
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Koralium.SqlToExpression.Utils
{
    internal static class ListUtils
    {
        private static ConcurrentDictionary<Type, Func<IList>> newListFunctions = new ConcurrentDictionary<Type, Func<IList>>();

        public static Func<IList> GetNewListFunction(Type type)
        {
            if(!newListFunctions.TryGetValue(type, out var func))
            {
                func = CreateNewListDelegate(type);
                newListFunctions.AddOrUpdate(type, func, (key, old) => func);
            }
            return func;
        }

        static Func<IList> CreateNewListDelegate(Type objectType)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(ListUtils).GetMethod("CreateNewListDelegateHelper",
                BindingFlags.Static | BindingFlags.NonPublic);
#pragma warning restore S3011

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (objectType);

            object ret = constructedHelper.Invoke(null, null);

            // Cast the result to the right kind of delegate and return it
            return (Func<IList>)ret;
        }

#pragma warning disable S1144 // Unused private types or members should be removed
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used through reflection")]
        static Func<IList> CreateNewListDelegateHelper<TTarget>()
        {
            return () => new List<TTarget>();
        }
    }
}
