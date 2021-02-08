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
using System.Data;
using System.Data.Common;

namespace Koralium.Data.ArrowFlight
{
    public class KoraliumParameter : DbParameter
    {
        private string _parameterName = string.Empty;
        private object _value;
        private int? _size;
        private string _sourceColumn = string.Empty;


        public override DbType DbType { get; set; } = DbType.String;
        public override ParameterDirection Direction
        {
            get => ParameterDirection.Input;
            set
            {
                if (value != ParameterDirection.Input)
                {
                    throw new ArgumentException();
                }
            }
        }

        public override bool IsNullable { get; set; }

        public override string ParameterName
        {
            get => _parameterName;
            set => _parameterName = value ?? String.Empty;
        }

        public override int Size
        {
            get => _size
                ?? (_value is string stringValue
                    ? stringValue.Length
                    : _value is byte[] byteArray
                        ? byteArray.Length
                        : 0);

            set
            {
                if (value < -1)
                {
                    // NB: Message is provided by the framework
                    throw new ArgumentOutOfRangeException(nameof(value), value, message: null);
                }

                _size = value;
            }
        }

        public override string SourceColumn
        {
            get => _sourceColumn;
            set => _sourceColumn = value ?? string.Empty;
        }

        public override bool SourceColumnNullMapping { get; set; }
        public override object Value
        {
            get => _value;
            set { _value = value; }
        }

        public override void ResetDbType()
        {
            DbType = DbType.String;
        }

        public string GenerateSqlValue()
        {
            if (DbType == DbType.String)
            {
                return $"'{Value}'";
            }
            return Value.ToString();
        }
    }
}
