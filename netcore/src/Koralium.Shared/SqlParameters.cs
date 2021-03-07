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
