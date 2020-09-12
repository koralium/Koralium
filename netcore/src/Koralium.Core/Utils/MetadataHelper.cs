using Koralium.Core.Decoders;
using Koralium.Core.Encoders;
using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Core.Models;
using Koralium.Core.Resolvers;
using Koralium.Grpc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Koralium.Core.Utils
{
    public static class MetadataHelper
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

            var metadata = new ColumnMetadata()
            {
                ColumnId = globalIndex++,
                Name = name,
                Type = KoraliumType.Object
            };

            foreach (var child in children)
            {
                metadata.SubColumns.Add(child.Metadata);
            }

            columns.Add(new TableColumn(
                metadata,
                name,
                metadata.ColumnId,
                getDelegate,
                memberInfo,
                propertyType,
                children,
                new ObjectEncoder(),
                null));

            return columns;
        }

        private static IEnumerable<TableColumn> CollectArrayMetadata(string name, Type propertyType, Func<object, object> getDelegate, MemberInfo memberInfo, ref int globalIndex, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            //Get the inner type of the list
            Type innerType = propertyType.GetGenericArguments()[0];

            //Create query column for the inner type
            if(!typeLookup.TryGetValue(propertyType, out var children))
            {
                children = CollectColumnMetadata("", innerType, null, ref globalIndex, typeLookup).ToList();
                typeLookup.Add(propertyType, children);
            }

            var metadata = new ColumnMetadata()
            {
                ColumnId = globalIndex++,
                Name = name,
                Type = KoraliumType.Array
            };

            foreach (var child in children)
            {
                metadata.SubColumns.Add(child.Metadata);
            }

            var tableColumn = new TableColumn(
                metadata,
                name,
                metadata.ColumnId,
                getDelegate,
                memberInfo,
                propertyType,
                children.ToList(),
                new ArrayEncoder(),
                null
                );
            return new List<TableColumn>() { tableColumn };
        }


        private static IEnumerable<TableColumn> CollectColumnMetadata(string name, Type propertyType, Func<object, object> getDelegate, ref int globalIndex, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup, MemberInfo memberInfo = null)
        {
            if (!IsBaseType(propertyType))
            {
                if (IsArray(propertyType))
                {
                    return CollectArrayMetadata(name, propertyType, getDelegate, memberInfo, ref globalIndex, typeLookup);
                }
                else
                {
                    return CollectSubObjectMetadata(name, propertyType, getDelegate, memberInfo, ref globalIndex, typeLookup);
                }
            }

            KoraliumType type = GetKoraliumType(propertyType);

            var columnMetadata = new ColumnMetadata()
            {
                Name = name,
                Type = type,
                ColumnId = globalIndex++
            };

            return new List<TableColumn>() { new TableColumn(columnMetadata, name, columnMetadata.ColumnId, getDelegate, memberInfo, propertyType, new List<TableColumn>(), GetEncoder(type), GetDecoder(type)) };
        }

        private static IEnumerable<TableColumn> CollectColumnMetadata(Type objectType, PropertyInfo propertyInfo, ref int globalIndex, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            return CollectColumnMetadata(propertyInfo.Name, propertyInfo.PropertyType, CreateGetDelegate(objectType, propertyInfo.GetGetMethod()), ref globalIndex, typeLookup, propertyInfo);
        }

        private static bool IsArray(Type type)
        {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>));
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

        internal static IEncoder GetEncoder(KoraliumType type)
        {
            switch (type)
            {
                case KoraliumType.Bool:
                    return new BoolEncoder();
                case KoraliumType.Double:
                    return new DoubleEncoder();
                case KoraliumType.Float:
                    return new FloatEncoder();
                case KoraliumType.Int32:
                    return new Int32Encoder();
                case KoraliumType.Int64:
                    return new Int64Encoder();
                case KoraliumType.String:
                    return new StringEncoder();
                case KoraliumType.Timestamp:
                    return new TimestampEncoder();
                default:
                    break;
            }
            //TODO
            throw new Exception();
            //throw new DecoderNotFoundException(prestoType);
        }

        public static IDecoder GetDecoder(KoraliumType type)
        {
            switch (type)
            {
                case KoraliumType.Bool:
                    return new BoolDecoder();
                case KoraliumType.Double:
                    return new DoubleDecoder();
                case KoraliumType.Float:
                    return new FloatDecoder();
                case KoraliumType.Int32:
                    return new IntDecoder();
                case KoraliumType.Int64:
                    return new Int64Decoder();
                case KoraliumType.String:
                    return new StringDecoder();
                case KoraliumType.Timestamp:
                    return new TimestampDecoder();
                case KoraliumType.Object:
                    return new ObjectDecoder();
                case KoraliumType.Array:
                    return new ArrayDecoder();
                default:
                    break;
            }

            return null;
        }



        public static KoraliumType GetKoraliumType(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return GetKoraliumType(Nullable.GetUnderlyingType(type));
            }
            if (type.Equals(typeof(int)))
            {
                return KoraliumType.Int32;
            }
            if (type.Equals(typeof(long)))
            {
                return KoraliumType.Int64;
            }
            if (type.Equals(typeof(string)))
            {
                return KoraliumType.String;
            }
            if (type.Equals(typeof(bool)))
            {
                return KoraliumType.Bool;
            }
            if (type.Equals(typeof(float)))
            {
                return KoraliumType.Float;
            }
            if (type.Equals(typeof(double)))
            {
                return KoraliumType.Double;
            }
            if (type.Equals(typeof(DateTime)))
            {
                return KoraliumType.Timestamp;
            }
            if (IsArray(type))
            {
                return KoraliumType.Array;
            }
            if (!IsBaseType(type))
            {
                return KoraliumType.Object;
            }

            throw new Exception("Unsupported type");
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
