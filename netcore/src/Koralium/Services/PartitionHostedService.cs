using Koralium.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
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

                await Task.Delay(partitionResolver.GenerateMetadataTimespan.Value, _cancellationTokenSource.Token);

            } while (!_cancellationTokenSource.Token.IsCancellationRequested);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            await Task.WhenAll(tableTasks);
        }
    }
}
