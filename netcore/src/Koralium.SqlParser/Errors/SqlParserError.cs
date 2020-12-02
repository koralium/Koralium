using System.Text;

namespace Koralium.SqlParser.Errors
{
    public class SqlParserError
    {
        public SqlParserError(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
