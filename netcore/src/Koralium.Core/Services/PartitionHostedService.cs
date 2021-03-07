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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Koralium.Services
{
    /// <summary>
    /// Hosted service that handles calling GenerateMetadata on partition resolvers
    /// </summary>
    class PartitionHostedService : IHostedService
    {
        private readonly MetadataStore _metadataStore;
        private readonly IServiceProvider _serviceProvider;
        private readonly List<Task> tableTasks = new List<Task>();
        private readonly CancellationTokenSource _cancellationTokenSource;
        public PartitionHostedService(
            MetadataStore metadataStore,
            IServiceProvider serviceProvider)
        {
            _metadataStore = metadataStore;
            _serviceProvider = serviceProvider;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        { 
            foreach(var table in _metadataStore.Tables)
            {
                if(table.PartitionResolver.GenerateMetadataTimespan == null)
                {
                    continue;
                }
                tableTasks.Add(Task.Factory.StartNew(async (resolver) =>
                {
                    var partitionResolver = resolver as PartitionResolver;
                    await Run(partitionResolver);
                }, table.PartitionResolver, TaskCreationOptions.LongRunning).Unwrap());
            }
            return Task.CompletedTask;
        }

        private async Task Run(PartitionResolver partitionResolver)
        {
            do
            {
                using var scope = _serviceProvider.CreateScope();
                var discoveryService = scope.ServiceProvider.GetService<IDiscoveryService>();
                await partitionResolver.GeneratPartitionMetadata(new Models.PartitionOptions(scope.ServiceProvider, discoveryService));

                try
                {
                    await Task.Delay(partitionResolver.GenerateMetadataTimespan.Value, _cancellationTokenSource.Token);
                }
                catch (TaskCanceledException)
                {
                    //Do nothing if the task was cancelled
                }
            } while (!_cancellationTokenSource.Token.IsCancellationRequested);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            await Task.WhenAll(tableTasks);
        }
    }
}
