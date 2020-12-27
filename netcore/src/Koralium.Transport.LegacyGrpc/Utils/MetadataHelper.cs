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
using Koralium.Grpc;
using System;
using System.Collections.Generic;

namespace Koralium.Transport.LegacyGrpc.Utils
{
    internal static class MetadataHelper
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
    }
}
