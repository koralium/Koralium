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
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Storage.Internal
{
    public class KoraliumTypeMappingSource : RelationalTypeMappingSource
    {
        private const string VarcharTypeName = "string";
        private static readonly KoraliumStringTypeMapping _text = new KoraliumStringTypeMapping(VarcharTypeName);


        private readonly Dictionary<Type, RelationalTypeMapping> _clrTypeMappings
            = new Dictionary<Type, RelationalTypeMapping>
            {
                { typeof(string), _text },
                { typeof(long), new LongTypeMapping("int64", System.Data.DbType.Int64) },
                { typeof(ulong), new ULongTypeMapping("uint64", System.Data.DbType.UInt64) },
                { typeof(double), new DoubleTypeMapping("double", System.Data.DbType.Double) },
                { typeof(DateTime), new KoraliumDateTimeTypeMapping("timestamp", System.Data.DbType.DateTime) }
            };

        public KoraliumTypeMappingSource(TypeMappingSourceDependencies dependencies,
            RelationalTypeMappingSourceDependencies relationalDependencies) : base(dependencies, relationalDependencies)
        {
        }

        /// <summary>
        /// Check if a type is either some case of IEnumerable based on a list, or an array
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsArray(Type type)
        {
            if (type.IsGenericType) //If it is a generic type such as List<T>, IEnumerable<T> etc.
            {
                if (IsIEnumerableOfT(type, out var elementType))
                {
                    var genericListType = typeof(List<>).MakeGenericType(elementType);

                    if (type.IsAssignableFrom(genericListType))
                    {
                        return true;
                    }
                }
            }
            //Check if it is an array
            else if (type.IsArray)
            {
                return true;
            }
            return false;
        }

        private static bool IsPrimitiveOrStruct(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return IsPrimitiveOrStruct(Nullable.GetUnderlyingType(type));
            }

            return type.IsPrimitive || type.IsEnum || type.IsValueType || type.Equals(typeof(string));
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

            if (enumerableInterface == null)
            {
                elementType = null;
                return false;
            }

            elementType = enumerableInterface.GetGenericArguments().First();
            return true;
        }

        protected override RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            var clrType = mappingInfo.ClrType;

            if (mappingInfo.StoreTypeName != null)
            {
                if (mappingInfo.StoreTypeName == "object")
                {
                    return new ObjectTypeMapping("object", clrType);
                }
                if(mappingInfo.StoreTypeName == "array")
                {
                    return new ListTypeMapping("array", clrType);
                }
            }

            if(clrType.IsEnum)
            {
                return new EnumTypeMapping("enum", clrType);
            }

            if (IsArray(clrType))
            {
                return new ListTypeMapping("array", clrType);
            }

            if (!IsPrimitiveOrStruct(clrType))
            {
                return new ObjectTypeMapping("object", clrType);
            }

            if (clrType != null
                && _clrTypeMappings.TryGetValue(clrType, out var mapping))
            {
                return mapping;
            }

            var o = base.FindMapping(mappingInfo);

            return o;
        }
    }
}
