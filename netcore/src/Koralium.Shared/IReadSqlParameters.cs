using System.Collections.Generic;

namespace Koralium.Shared
{
    public interface IReadSqlParameters : IEnumerable<KeyValuePair<string, SqlParameter>>
    {
        bool TryGetParameter(string name, out SqlParameter sqlParameter);

        IEnumerable<string> Keys { get; }

        IEnumerable<SqlParameter> Values { get; }
    }
}
