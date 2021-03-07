/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.Interfaces;
using System;

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
