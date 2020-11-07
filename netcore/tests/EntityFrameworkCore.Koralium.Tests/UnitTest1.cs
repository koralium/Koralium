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
using Data.Koralium.Tests;
using EntityFrameworkCore.Koralium.Extensions;
using EntityFrameworkCore.Koralium.Tests.Db;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;

namespace EntityFrameworkCore.Koralium.Tests
{
    public class Tests
    {
        private TestWebFactory webFactory;
        private IServiceProvider serviceProvider;
        
        [OneTimeSetUp]
        public void Setup()
        {
            webFactory = new TestWebFactory();
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<TestDbContext>(opt =>
            {
                opt.UseKoralium($"DataSource={webFactory.GetUrl()}");
            });
            serviceProvider = services.BuildServiceProvider();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            webFactory.Stop();
        }

        [Test]
        public void TestFirstOrDefault()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            var project = db.Projects.FirstOrDefault();

            Assert.Pass();
        }

        [Test]
        public void TestSelectAll()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            var project = db.Projects.ToList();

            Assert.Pass();
        }

        [Test]
        public void TestSelectAllOrders()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            var project = db.Orders.ToList();
            

            Assert.Pass();
        }

        [Test]
        public void TestCountAll()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            var count = db.Projects.Count();

            Assert.Pass();
        }

        [Test]
        public void TestCountWithConditionNotNull()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            var count = db.Projects.Count(x => x.Name != null);

            Assert.Pass();
        }

        [Test]
        public void TestWhere()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            var projects = db.Projects.Where(x => x.Name == "alex").Select(x => new { x.Name }).ToList();

            Assert.Pass();
        }

        [Test]
        public void TestCountCustomersWithAutomapper()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            var count = db.AutoMapperCustomers.Count();

            Assert.That(count, Is.EqualTo(1500));
        }
    }
}