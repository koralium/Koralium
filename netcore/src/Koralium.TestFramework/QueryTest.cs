using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Koralium.TestFramework
{
    [TestFixture]
    public abstract partial class QueryTest<TEntity> : QueryTestBase<TEntity> where TEntity : class
    {
        public abstract IEnumerable<TEntity> TestData();


        public virtual string GetAccessToken()
        {
            return null;
        }

        private static IEnumerable<PropertyInfo> Properties
        {
            get
            {
                var type = typeof(TEntity);

                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    yield return property;
                }
            }
        }

        private static IEnumerable<PropertyInfo> FilterableProperties
        {
            get
            {
                foreach (var property in Properties)
                {
                    if (TestFilterGenerator.IsPossibleFilter(property.PropertyType))
                    {
                        yield return property;
                    }
                }
            }
        }

        [Test]
        public void TestSelectAll()
        {
            var context = ServiceProvider.GetRequiredService<TestDbContext<TEntity>>();
            var actual = context.Entities.ToList();

            actual.Should().BeEquivalentTo(TestData());
        }

        [Test]
        public void TestCount()
        {
            int actual = Context.Entities.Count();
            int expected = TestData().Count();

            actual.Should().Be(expected);
        }
    }
}
