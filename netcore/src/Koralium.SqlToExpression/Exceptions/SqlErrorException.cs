using System;

namespace Koralium.SqlToExpression.Exceptions
{
    public class SqlErrorException : Exception
    {
        public SqlErrorException(string message)
            : base(message)
        {

        }
    }
}
