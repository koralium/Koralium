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
