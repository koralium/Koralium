using System;
using System.Collections.Concurrent;

namespace Data.Koralium.Utils
{
    internal static class ListCreators
    {
        private static readonly ConcurrentDictionary<Type, ListCreatorFactory> _listCreatorFactories = new ConcurrentDictionary<Type, ListCreatorFactory>();

        public static ListCreator GetListCreator(Type type)
        {
            if(!_listCreatorFactories.TryGetValue(type, out var factory))
            {
                factory = new ListCreatorFactory(type);
                _listCreatorFactories.TryAdd(type, factory);
            }
            return factory.NewListCreator();
        }
    }
}
