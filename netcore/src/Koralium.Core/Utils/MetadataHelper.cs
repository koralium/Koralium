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
using Koralium.Transport;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Koralium.Utils
{
    internal static class MetadataHelper
    {
        /// <summary>
        /// Index must be static, since all tables and their columns must have their unique columnId
        /// 
        /// Otherwise serialization in gRPC wont be as fast.
        /// </summary>
        private static int index = 0;

        public static string CreateTableName(Type type)
        {
            return type.Name;
        }

        public static string GenerateIndexName(params string[] propertyNames)
        {
            return string.Join("_", propertyNames);
        }

        public static string GetSecurityPolicy<T, Entity>() where T : TableResolver<Entity>
        {
            var classAttribute = typeof(T).GetCustomAttribute<AuthorizeAttribute>();

            if (classAttribute != null)
            {
                if (classAttribute.Policy == null)
                    return "default";

                return classAttribute.Policy;
            }

            return null;
        }

        public static List<TableColumn> CollectMetadata(Type type, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            return CollectMetadata(type, ref index, typeLookup);
        }

        public static List<TableColumn> CollectMetadata(Type type, ref int globalIndex, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            List<TableColumn> columns = new List<TableColumn>();
            var properties = type.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                columns.AddRange(CollectColumnMetadata(type, properties[i], ref globalIndex, typeLookup));
            }

            if (!typeLookup.ContainsKey(type))
            {
                typeLookup.Add(type, columns);
            }
            
            return columns;
        }

        private static IEnumerable<TableColumn> CollectSubObjectMetadata(string name, Type propertyType, Func<object, object> getDelegate, MemberInfo memberInfo, ref int globalIndex, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            List<TableColumn> columns = new List<TableColumn>();

            //Check so this type has not been read already
            if(!typeLookup.TryGetValue(propertyType, out var children))
            {
                children = CollectMetadata(propertyType, typeLookup);
            }

            columns.Add(new TableColumn(
                name,
                getDelegate,
                memberInfo,
                propertyType,
                children));

            return columns;
        }

        private static IEnumerable<TableColumn> CollectArrayMetadata(string name, Type propertyType, Func<object, object> getDelegate, MemberInfo memberInfo, ref int globalIndex, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            //Get the inner type of the list
            Type innerType = propertyType.GetGenericArguments()[0];

            //Create query column for the inner type
            if(!typeLookup.TryGetValue(propertyType, out var children))
            {
                children = CollectColumnMetadata("", innerType, x => x, ref globalIndex, typeLookup).ToList();
                typeLookup.Add(propertyType, children);
            }

            var tableColumn = new TableColumn(
                name,
                getDelegate,
                memberInfo,
                propertyType,
                children.ToList()
                );
            return new List<TableColumn>() { tableColumn };
        }


        private static IEnumerable<TableColumn> CollectColumnMetadata(string name, Type propertyType, Func<object, object> getDelegate, ref int globalIndex, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup, MemberInfo memberInfo = null)
        {
            var (columnType, _) = ColumnTypeHelper.GetKoraliumType(propertyType);
            if (columnType == ColumnType.Object || columnType == ColumnType.List)
            {
                if (columnType == ColumnType.List)
                {
                    return CollectArrayMetadata(name, propertyType, getDelegate, memberInfo, ref globalIndex, typeLookup);
                }
                else
                {
                    return CollectSubObjectMetadata(name, propertyType, getDelegate, memberInfo, ref globalIndex, typeLookup);
                }
            }

            return new List<TableColumn>() { new TableColumn(name, getDelegate, memberInfo, propertyType, new List<TableColumn>()) };
        }

        private static IEnumerable<TableColumn> CollectColumnMetadata(Type objectType, PropertyInfo propertyInfo, ref int globalIndex, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            if(propertyInfo.GetCustomAttribute<KoraliumIgnoreAttribute>() != null)
            {
                return Enumerable.Empty<TableColumn>();
            }
            return CollectColumnMetadata(propertyInfo.Name, propertyInfo.PropertyType, CreateGetDelegate(objectType, propertyInfo.GetGetMethod()), ref globalIndex, typeLookup, propertyInfo);
        }

        private static bool IsBaseType(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return IsBaseType(Nullable.GetUnderlyingType(type));
            }
            if (type.IsPrimitive ||
                type.Equals(typeof(string)) ||
                type.Equals(typeof(DateTime)))
                return true;
            return false;
        }


        internal static Func<object> CreateNewObjectDelegate(Type objectType)
        {
            return CreateNewObjectDelegateInternal(objectType);
        }

        static Func<object> CreateNewObjectDelegateInternal(Type objectType)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(MetadataHelper).GetMethod("CreateNewObjectDelegateHelper",
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

        internal static Action<object, object> CreateSetDelegate(Type objectType, MethodInfo method)
        {
            return CreateSetDelegateInternal(objectType, method);
        }

        static Action<object, object> CreateSetDelegateInternal(Type objectType, MethodInfo method)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(MetadataHelper).GetMethod("CreateSetDelegateHelper",
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


        static Func<object, object> CreateGetDelegate(Type objectType, MethodInfo method)
        {
            return CreateGetDelegateInternal(objectType, method);
        }

        static Func<object, object> CreateGetDelegateInternal(Type objectType, MethodInfo method)
        {
            // First fetch the generic form
#pragma warning disable S3011 // Make sure that this accessibility bypass is safe here.
            MethodInfo genericHelper = typeof(MetadataHelper).GetMethod("CreateGetDelegateHelper",
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
