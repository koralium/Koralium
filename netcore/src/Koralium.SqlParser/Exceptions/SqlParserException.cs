using System;
using System.Runtime.Serialization;

namespace Koralium.SqlParser.Exceptions
{
    [Serializable]
    public class SqlParserException : Exception
    {
        public SqlParserException()
            : base()
        {
        }

        public SqlParserException(string message)
            : base(message)
        {
        }

        public SqlParserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SqlParserException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
