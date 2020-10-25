using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Koralium.Exceptions
{
    public class KoraliumInternalException : Exception
    {
        public KoraliumInternalException(string message)
            : base(message)
        {

        }
    }
}
