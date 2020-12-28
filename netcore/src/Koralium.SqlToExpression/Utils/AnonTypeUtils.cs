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
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Koralium.SqlToExpression.Utils
{
    public static class AnonTypeUtils
    {
        private static ConcurrentDictionary<Type, Func<object, object>[]> typeToGetDelegates = new ConcurrentDictionary<Type, Func<object, object>[]>();

        public static Func<object, object>[] GetDelegates(Type anonType)
        {
            if(!typeToGetDelegates.TryGetValue(anonType, out var delegates))
            {
                delegates = BuildGetDeletages(anonType);
                typeToGetDelegates.TryAdd(anonType, delegates);
            }
            return delegates;
        }

        private static Func<object, object>[] BuildGetDeletages(Type type)
        {
            var properties = type.GetProperties();
            Func<object, object>[] output = new Func<object, object>[properties.Length];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = CreateGetDelegate(type, properties[i].GetGetMethod());
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
            MethodInfo genericHelper = typeof(AnonTypeUtils).GetMethod("CreateGetDelegateHelper",
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
