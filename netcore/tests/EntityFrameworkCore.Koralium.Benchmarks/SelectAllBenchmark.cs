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
using BenchmarkDotNet.Attributes;
using EntityFrameworkCore.Koralium.Tests.Db;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
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

        [Benchmark]
        public void SelectWithWhereAnyMatch()
        {
            var context = serviceProvider.GetRequiredService<TestDbContext>();

            _ = context.TypeTests.Select(x => new { x.IntValue }).ToList();
        }
    }
}
