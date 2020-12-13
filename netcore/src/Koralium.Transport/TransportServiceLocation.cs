using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport
{
    public class TransportServiceLocation
    {
        public string Host { get; }

        public bool Tls { get; }

        public TransportServiceLocation(
            string host,
            bool tls)
        {
            Host = host;
            Tls = tls;
        }
    }
}
