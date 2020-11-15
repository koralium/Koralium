using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Interfaces
{
    public interface IReadSqlParameters : IEnumerable<KeyValuePair<string, SqlParameter>>
    {
        bool TryGetParameter(string name, out SqlParameter sqlParameter);

        IEnumerable<string> Keys { get; }

        IEnumerable<SqlParameter> Values { get; }
    }
}
