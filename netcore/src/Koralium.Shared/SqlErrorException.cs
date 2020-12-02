using System;

namespace Koralium.Shared
{
    public class SqlErrorException : Exception
    {
        public SqlErrorException(string message)
            : base(message)
        {

        }
    }
}
