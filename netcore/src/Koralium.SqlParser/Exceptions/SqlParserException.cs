using System;
using System.Collections.Generic;
using System.Text;

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
