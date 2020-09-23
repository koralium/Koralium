using Koralium.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Metadata
{
    public class CustomMetadataStore : ICustomMetadataStore
    {
        private Dictionary<string, object> values = new Dictionary<string, object>();
        public void AddMetadata<T>(string name, T value)
        {
            if (values.ContainsKey(name))
            {
                values[name] = value;
            }
            else
            {
                values.Add(name, value);
            }
        }

        internal IEnumerable<KeyValuePair<string, object>> GetMetadataValues()
        {
            return values;
        }
    }
}
