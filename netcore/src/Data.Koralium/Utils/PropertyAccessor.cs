using System;

namespace Data.Koralium.Utils
{
    internal class PropertyAccessor
    {
        private readonly Action<object, object> _setDelegate;

        public PropertyAccessor(string name, Type propertyType, Action<object, object> setDelegate)
        {
            Name = name;
            PropertyType = propertyType;
            _setDelegate = setDelegate;
        }

        public string Name { get; }

        public Type PropertyType { get; }

        public void SetValue(object obj, object value)
        {
            _setDelegate(obj, value);
        }
    }
}
