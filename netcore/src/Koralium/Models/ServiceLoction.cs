using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Models
{
    public class ServiceLoction
    {
        /// <summary>
        /// Host name of the service, may include port.
        /// </summary>
        public string Host { get; }

        /// <summary>
        /// Is the service behind TLS or not?
        /// </summary>
        public bool Tls { get; }

        /// <summary>
        /// Additional data that can be passed between partition resolvers and discovery services.
        /// </summary>
        public object AdditionalData { get; }

        public ServiceLoction(
            string host,
            bool tls,
            object additionalData = null)
        {
            Host = host;
            Tls = tls;
            AdditionalData = additionalData;
        }
    }
}
