using System;
using System.Collections.Concurrent;

namespace Data.Koralium.Utils
{
    internal static class TypeAccessors
    {
        private static readonly ConcurrentDictionary<Type, TypeAccessor> _typeAccessors = new ConcurrentDictionary<Type, TypeAccessor>();

        public static TypeAccessor GetTypeAccessor(Type type)
        {
            if(!_typeAccessors.TryGetValue(type, out var typeAccessor))
            {
                typeAccessor = new TypeAccessor(type);
                _typeAccessors.TryAdd(type, typeAccessor);
            }
            return typeAccessor;
        }
    }
}
