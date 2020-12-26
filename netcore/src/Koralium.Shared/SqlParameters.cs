using System;
using System.Collections;
using System.Collections.Generic;

namespace Koralium.Shared
{
    public class SqlParameters : IReadSqlParameters
    {
        private readonly Dictionary<string, SqlParameter> _parameters = new Dictionary<string, SqlParameter>();

        public IEnumerable<string> Keys => _parameters.Keys;

        public IEnumerable<SqlParameter> Values => _parameters.Values;

        public SqlParameters Add(SqlParameter sqlParameter)
        {
            if (!sqlParameter.Name.StartsWith("@"))
            {
                _parameters.Add($"@{sqlParameter.Name.ToLower()}", sqlParameter);
            }
            else
            {
                _parameters.Add(sqlParameter.Name.ToLower(), sqlParameter);
            }
            return this;
        }

        public IEnumerator<KeyValuePair<string, SqlParameter>> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        public bool TryGetParameter(string name, out SqlParameter sqlParameter)
        {
            if (!name.StartsWith("@"))
            {
                name = "@" + name;
            }
            return _parameters.TryGetValue(name.ToLower(), out sqlParameter);
        }

        public bool Contains(string name)
        {
            if (!name.StartsWith("@"))
            {
                name = "@" + name;
            }
            return _parameters.ContainsKey(name.ToLower());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }
    }
}
