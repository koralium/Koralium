using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Data.Koralium
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
