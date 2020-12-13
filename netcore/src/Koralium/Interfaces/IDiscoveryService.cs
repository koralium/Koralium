using Koralium.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Koralium.Interfaces
{
    public interface IDiscoveryService
    {
        /// <summary>
        /// Get the service locations that was discovered.
        /// </summary>
        /// <returns>A list of service locations</returns>
        IImmutableList<ServiceLoction> GetServices();
    }
}
