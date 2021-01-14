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
using Koralium.Transport;
using System;
using System.Collections.Generic;

namespace Koralium.Utils
{
    static class ColumnTypeHelper
    {

        internal static bool IsArray(Type type)
        {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>));
        }

        internal static bool IsBaseType(Type type)
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

        public static (ColumnType columnType, bool nullable) GetKoraliumType(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                return (GetKoraliumType(Nullable.GetUnderlyingType(type)).columnType, true);
            }
            if (type.Equals(typeof(int)))
            {
                return (ColumnType.Int32, false);
            }
            if (type.Equals(typeof(long)))
            {
                return (ColumnType.Int64, false);
            }
            if (type.Equals(typeof(string)))
            {
                return (ColumnType.String, true);
            }
            if (type.Equals(typeof(bool)))
            {
                return (ColumnType.Bool, false);
            }
            if (type.Equals(typeof(float)))
            {
                return (ColumnType.Float, false);
            }
            if (type.Equals(typeof(double)))
            {
                return (ColumnType.Double, false);
            }
            if (type.Equals(typeof(DateTime)))
            {
                return (ColumnType.DateTime, false);
            }
            if (type.Equals(typeof(short)))
            {
                return (ColumnType.Short, false);
            }
            if (type.Equals(typeof(uint)))
            {
                return (ColumnType.UInt32, false);
            }
            if (type.Equals(typeof(ulong)))
            {
                return (ColumnType.UInt64, false);
            }
            if (type.Equals(typeof(byte)))
            {
                return (ColumnType.Byte, false);
            }
            if (type.Equals(typeof(byte[])))
            {
                return (ColumnType.Binary, true);
            }
            if (IsArray(type))
            {
                return (ColumnType.List, true);
            }
            if (!IsBaseType(type))
            {
                return (ColumnType.Object, true);
            }

            throw new SqlErrorException($"Unsupported type '{type.FullName}");
        }
    }
}
