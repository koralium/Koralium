using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Models
{
    public class StoredProcedureParameter
    {
        public string Name { get; }

        public object Value { get; }

        public StoredProcedureParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
