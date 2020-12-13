using Koralium.Interfaces;
using Koralium.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Koralium.Services
{
    class DefaultDiscoveryService : IDiscoveryService
    {
        public DefaultDiscoveryService()
        {
        }

        public IImmutableList<ServiceLoction> GetServices()
        {
            return ImmutableList.Create<ServiceLoction>();
        }
    }
}
