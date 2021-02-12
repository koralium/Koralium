using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Koralium.Transport.Exceptions
{
    [Serializable]
    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException()
            : base()
        {
        }

        public AuthorizationFailedException(string message)
            : base(message)
        {
        }

        public AuthorizationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AuthorizationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
