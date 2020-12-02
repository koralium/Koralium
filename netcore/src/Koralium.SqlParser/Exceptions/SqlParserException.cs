using System;

namespace Koralium.SqlParser.Exceptions
{
    public class SqlParserException : Exception
    {
        public SqlParserException(string message)
            : base(message)
        {

        }
    }
}
