using BenchmarkDotNet.Attributes;
using EntityFrameworkCore.Koralium.Tests.Db;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Koralium.Extensions;
using System.Linq;

namespace EntityFrameworkCore.Koralium.Benchmarks
{
    public class SelectAllBenchmark
    {
        private IServiceProvider serviceProvider;
        public SelectAllBenchmark()
        {
            ServiceCollection services = new ServiceCollection();
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            services.AddDbContext<TestDbContext>(opt =>
            {
                opt.UseKoralium($"DataSource=http://127.0.0.1:5016");
            });
            serviceProvider = services.BuildServiceProvider();
        }

        [Benchmark]
        public void SelectAllProject()
        {
            var context = serviceProvider.GetRequiredService<TestDbContext>();
            _ = context.Projects.ToList();
        }

        [Benchmark]
        public void SelecAllOrders()
        {
            var context = serviceProvider.GetRequiredService<TestDbContext>();

            _ = context.Orders.ToList();
        }

        [Benchmark]
        public void SelectAllCustomers()
        {
            var context = serviceProvider.GetRequiredService<TestDbContext>();

            _ = context.Customers.ToList();
        }
    }
}
