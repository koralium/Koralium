using Data.Koralium.Tests;
using EntityFrameworkCore.Koralium.Extensions;
using EntityFrameworkCore.Koralium.Tests.Db;
using Koralium.WebTests;
using Koralium.WebTests.Entities;
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
        
        [SetUp]
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

        [Test]
        public void TestFirstOrDefault()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            var project = db.Projects.FirstOrDefault();

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

            var projects = db.Projects.Where(x => x.Name == "alex").ToList();

            Assert.Pass();
        }

        [Test]
        public void TestInsert()
        {
            var db = serviceProvider.GetService<TestDbContext>();

            db.Projects.Add(new Project()
            {
                Name = "alex",
                Company = new Company()
                {
                    Name = "alex"
                }
            });

            db.SaveChanges();
        }
    }
}