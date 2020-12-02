using Koralium.SqlParser.Errors;
using Koralium.SqlParser.Statements;
using System.Collections.Generic;

namespace Koralium.SqlParser
{
    public interface ISqlParser
    {
        StatementList Parse(string text);

        StatementList Parse(string text, out IReadOnlyList<SqlParserError> errors);
    }
}
