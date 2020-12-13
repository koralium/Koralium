using Koralium.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Models
{
    public class PartitionOptions
    {
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Discovery service that helps getting a list of all the services that are being run.
        /// Useful when generating partition locations.
        /// </summary>
        public IDiscoveryService DiscoveryService { get; }

        internal PartitionOptions(IServiceProvider serviceProvider, IDiscoveryService discoveryService)
        {
            ServiceProvider = serviceProvider;
            DiscoveryService = discoveryService;
        }
    }
}
