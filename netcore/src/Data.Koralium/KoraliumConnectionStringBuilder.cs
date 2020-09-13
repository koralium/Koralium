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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;

namespace Data.Koralium
{
    public class KoraliumConnectionStringBuilder : DbConnectionStringBuilder
    {
        private const string defaultUser = "root";

        private const string DataSourceKeyword = "Data Source";
        private const string DataSourceNoSpaceKeyword = "DataSource";
        private const string AccessTokenKeyword = "AccessToken";

        private static readonly IReadOnlyList<string> _validKeywords;
        private static readonly IReadOnlyDictionary<string, Keywords> _keywords;

        private string _dataSource = string.Empty;
        private string _accessToken = string.Empty;

        private enum Keywords
        {
            DataSource,
            AccessToken
        }

        static KoraliumConnectionStringBuilder()
        {
            var validKeywords = new string[2];
            validKeywords[(int)Keywords.DataSource] = DataSourceKeyword;
            validKeywords[(int)Keywords.AccessToken] = AccessTokenKeyword;
            _validKeywords = validKeywords;

            _keywords = new Dictionary<string, Keywords>(6, StringComparer.OrdinalIgnoreCase)
            {
                [DataSourceKeyword] = Keywords.DataSource,
                [DataSourceNoSpaceKeyword] = Keywords.DataSource,
                [AccessTokenKeyword] = Keywords.AccessToken
            };
        }

        public KoraliumConnectionStringBuilder()
        {
        }

        public KoraliumConnectionStringBuilder(string connectionString)
            => ConnectionString = connectionString;

        public virtual string DataSource
        {
            get => _dataSource;
            set => base[DataSourceKeyword] = _dataSource = value;
        }

        public virtual string AccessToken
        {
            get => _accessToken;
            set => base[AccessTokenKeyword] = _accessToken = value;
        }

        internal virtual string Host
        {
            get
            {
                return _dataSource;
            }
        }

        public override ICollection Values
        {
            get
            {
                var values = new object[_validKeywords.Count];
                for (var i = 0; i < _validKeywords.Count; i++)
                {
                    values[i] = GetAt((Keywords)i);
                }

                return new ReadOnlyCollection<object>(values);
            }
        }

        public override object this[string keyword]
        {
            get => GetAt(GetIndex(keyword));
            set
            {
                if (value == null)
                {
                    Remove(keyword);

                    return;
                }

                switch (GetIndex(keyword))
                {
                    case Keywords.DataSource:
                        DataSource = Convert.ToString(value, CultureInfo.InvariantCulture);
                        return;

                    case Keywords.AccessToken:
                        AccessToken = Convert.ToString(value, CultureInfo.InvariantCulture);
                        return;

                    default:
                        Debug.Assert(false, "Unexpected keyword: " + keyword);
                        return;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();

            for (var i = 0; i < _validKeywords.Count; i++)
            {
                Reset((Keywords)i);
            }
        }

        public override bool ContainsKey(string keyword)
            => _keywords.ContainsKey(keyword);

        public override bool ShouldSerialize(string keyword)
            => _keywords.TryGetValue(keyword, out var index) && base.ShouldSerialize(_validKeywords[(int)index]);

        public override bool TryGetValue(string keyword, out object value)
        {
            if (!_keywords.TryGetValue(keyword, out var index))
            {
                value = null;

                return false;
            }

            value = GetAt(index);

            return true;
        }

        public override bool Remove(string keyword)
        {
            if (!_keywords.TryGetValue(keyword, out var index)
                || !base.Remove(_validKeywords[(int)index]))
            {
                return false;
            }

            Reset(index);

            return true;
        }

        private object GetAt(Keywords index)
        {
            switch (index)
            {
                case Keywords.DataSource:
                    return DataSource;
                case Keywords.AccessToken:
                    return AccessToken;
                default:
                    Debug.Assert(false, "Unexpected keyword: " + index);
                    return null;
            }
        }

        private void Reset(Keywords index)
        {
            switch (index)
            {
                case Keywords.DataSource:
                    _dataSource = string.Empty;
                    return;
                case Keywords.AccessToken:
                    _accessToken = string.Empty;
                    return;
                default:
                    Debug.Assert(false, "Unexpected keyword: " + index);
                    return;
            }
        }

        private static Keywords GetIndex(string keyword)
            => !_keywords.TryGetValue(keyword, out var index)
                ? throw new ArgumentException(nameof(keyword))
                : index;
    }
}
