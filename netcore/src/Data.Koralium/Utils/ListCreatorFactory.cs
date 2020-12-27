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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Data.Koralium.Utils
{
    /// <summary>
    /// Helper class to create different lists in C#
    /// </summary>
    internal class ListCreatorFactory
    {
        private readonly Type _elementType;
        private readonly bool _isArray;
        private readonly Func<object> _newListDelegate;
        
        public Type Type { get; }

        public ListCreatorFactory(Type type)
        {
            Type = type;

            if (type.IsGenericType) //If it is a generic type such as List<T>, IEnumerable<T> etc.
            {
                if (IsIEnumerableOfT(type, out var elementType))
                {
                    var genericListType = typeof(List<>).MakeGenericType(elementType);

                    if (type.IsAssignableFrom(genericListType))
                    {
                        _elementType = elementType;
                    }
                }

                _isArray = false;
            }
            //Check if it is an array
            else if (type.IsArray)
            {
                _elementType = type.GetElementType();
                _isArray = true;
            }

            var listType = typeof(List<>).MakeGenericType(_elementType);
            _newListDelegate = CreateNewObjectDelegate(listType);
        }

        public ListCreator NewListCreator()
        {
            var list = (IList)_newListDelegate();
            return new GenericListCreator(list, _elementType, _isArray);
        }

        private static bool IsIEnumerableOfT(Type type, out Type elementType)
        {
            //If it is an IEnumerable passed in, check for that
            if (type.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
            {
                elementType = type.GetGenericArguments().First();
                return true;
            }

            var enumerableInterface = type.GetInterfaces().FirstOrDefault(x => x.IsGenericType
                   && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            
            if(enumerableInterface == null)
            {
                elementType = null;
                return false;
            }
            
            elementType = enumerableInterface.GetGenericArguments().First();
            return true;
        }


        private static Func<object> CreateNewObjectDelegate(Type objectType)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(ListCreatorFactory).GetMethod("CreateNewObjectDelegateHelper",
                BindingFlags.Static | BindingFlags.NonPublic);
#pragma warning restore S3011

            // Now supply the type arguments
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (objectType);

            object ret = constructedHelper.Invoke(null, null);

            // Cast the result to the right kind of delegate and return it
            return (Func<object>)ret;
        }

#pragma warning disable S1144 // Unused private types or members should be removed
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used through reflection")]
        static Func<object> CreateNewObjectDelegateHelper<TTarget>()
            where TTarget : class, new()
        {
            return () => new TTarget();
        }
#pragma warning restore S1144 // Unused private types or members should be removed
    }
}
