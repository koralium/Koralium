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
        private readonly Dictionary<string, PropertyInfo> _originalProperties;

        internal SqlTypeInfo(Dictionary<string, PropertyInfo> properties, Dictionary<string, PropertyInfo> originalProperties)
        {
            _properties = properties;
            _originalProperties = originalProperties;
        }

        public bool TryGetProperty(string name, out PropertyInfo propertyInfo)
        {
            return _properties.TryGetValue(name.ToLower(), out propertyInfo);
        }

        public bool TryGetOriginalProperty(string name, out PropertyInfo propertyInfo)
        {
            if(_originalProperties != null && _originalProperties.TryGetValue(name.ToLower(), out propertyInfo))
            {
                return true;
            }
            if(_properties.TryGetValue(name.ToLower(), out propertyInfo))
            {
                return true;
            }
            return false;
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
            private Dictionary<string, PropertyInfo> _originalProperties;

            public Builder AddProperty(string name, PropertyInfo propertyInfo, PropertyInfo originalProperty = null)
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

                if(originalProperty != null)
                {
                    if(_originalProperties == null)
                    {
                        _originalProperties = new Dictionary<string, PropertyInfo>();
                    }
                    _originalProperties.Add(name.ToLower(), originalProperty);
                }

                return this;
            }

            public SqlTypeInfo Build()
            {
                return new SqlTypeInfo(_properties, _originalProperties);
            }
        }
    }
}
