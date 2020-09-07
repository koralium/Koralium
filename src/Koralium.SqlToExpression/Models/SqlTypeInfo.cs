using System;
using System.Collections.Generic;
using System.Reflection;

namespace Koralium.SqlToExpression.Models
{
    /// <summary>
    /// Helper class that remembers the property names between stages
    /// 
    /// Required in for instance GroupBy where the property names are lost when using a tuple.
    /// </summary>
    public class SqlTypeInfo
    {
        private readonly Dictionary<string, PropertyInfo> _properties;

        internal SqlTypeInfo(Dictionary<string, PropertyInfo> properties)
        {
            _properties = properties;
        }

        public bool TryGetProperty(string name, out PropertyInfo propertyInfo)
        {
            return _properties.TryGetValue(name.ToLower(), out propertyInfo);
        }

        public IEnumerable<KeyValuePair<string, PropertyInfo>> GetProperties()
        {
            return _properties;
        }

        public static Builder NewBuilder()
        {
            return new Builder();
        }

        public class Builder
        {
            private readonly Dictionary<string, PropertyInfo> _properties = new Dictionary<string, PropertyInfo>();

            public Builder AddProperty(string name, PropertyInfo propertyInfo)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Name is null", nameof(name));
                }

                if (propertyInfo is null)
                {
                    throw new ArgumentNullException(nameof(propertyInfo));
                }

                _properties.Add(name.ToLower(), propertyInfo);
                return this;
            }

            public SqlTypeInfo Build()
            {
                return new SqlTypeInfo(_properties);
            }
        }
    }
}
