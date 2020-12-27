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
using Data.Koralium.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Data.Koralium.Utils
{
    /// <summary>
    /// Helper class to allow the creation of objects and fill its properties in a fast way.
    /// </summary>
    internal class TypeAccessor
    {
        private static readonly Type[] EmptyTypeArray = new Type[0];

        private readonly IReadOnlyDictionary<string, PropertyAccessor> _setDelegates;
        public TypeAccessor(Type type)
        {
            Type = type;
            CanCreateInstance = Type.GetConstructor(EmptyTypeArray) != null;
            _setDelegates = CreatePropertyDelegates(type);
        }

        public Type Type { get; }

        public bool CanCreateInstance { get; }

        private static IReadOnlyDictionary<string, PropertyAccessor> CreatePropertyDelegates(Type type)
        {
            var properties = type.GetProperties();

            Dictionary<string, PropertyAccessor> setDelegates = new Dictionary<string, PropertyAccessor>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < properties.Length; i++)
            {
                if(!setDelegates.TryAdd(properties[i].Name, new PropertyAccessor(properties[i].Name, properties[i].PropertyType, CreateSetDelegate(type, properties[i].GetSetMethod()))))
                {
                    throw new InvalidOperationException(Resources.NonUniquePropertyName(properties[i].Name));
                }
            }
            return setDelegates;
        }

        /// <summary>
        /// Returns a list of delegates that corresponds to sent in column names.
        /// If a name is not found in the type, null is set for that column name.
        /// </summary>
        /// <param name="names">Column names to get delegates for.</param>
        /// <returns></returns>
        public IReadOnlyList<PropertyAccessor> GetSetDelegates(params string[] names)
        {
            List<PropertyAccessor> delegates = new List<PropertyAccessor>(names.Length);

            foreach(var name in names)
            {
                if(_setDelegates.TryGetValue(name, out var del))
                {
                    delegates.Add(del);
                }
                else
                {
                    delegates.Add(null);
                }
            }
            return delegates;
        }


        private static Action<object, object> CreateSetDelegate(Type objectType, MethodInfo method)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(TypeAccessor).GetMethod("CreateSetDelegateHelper",
                BindingFlags.Static | BindingFlags.NonPublic);
#pragma warning restore S3011

            var type = method.GetParameters().First().ParameterType;

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (objectType, type);

            // Now call it. The null argument is because it's a static method.
            object ret = constructedHelper.Invoke(null, new object[] { method });

            // Cast the result to the right kind of delegate and return it
            return (Action<object, object>)ret;
        }

#pragma warning disable S1144 // Unused private types or members should be removed
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used through reflection")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed", Justification = "Assignment is used")]
        static Action<object, object> CreateSetDelegateHelper<TTarget, TReturn>(MethodInfo method)
            where TTarget : class
        {
            // Convert the slow MethodInfo into a fast, strongly typed, open delegate
            Action<TTarget, TReturn> func = (Action<TTarget, TReturn>)Delegate.CreateDelegate
                (typeof(Action<TTarget, TReturn>), method);

            // Now create a more weakly typed delegate which will call the strongly typed one
            void ret(object target, object val) => func((TTarget)target, (TReturn)val);
            return ret;
        }
#pragma warning restore S1144 // Unused private types or members should be removed
    }
}
