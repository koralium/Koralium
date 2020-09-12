using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression
{
    public class SqlParameters
    {
        private readonly Dictionary<string, SqlParameter> _parameters = new Dictionary<string, SqlParameter>();

        public SqlParameters Add(SqlParameter sqlParameter)
        {
            _parameters.Add(sqlParameter.Name.ToLower(), sqlParameter);
            return this;
        }

        public bool TryGetParameter(string name, out SqlParameter sqlParameter)
        {
            return _parameters.TryGetValue(name.ToLower(), out sqlParameter);
        }
    }
}
