using FluentAssertions;
using Koralium.SqlToExpression.Indexing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Tests
{
    class IndexHelperTests
    {
        private class TestObject
        {
            public string Name { get; set; }
        }

        [Test]
        public void TestGetPropertyFilters()
        {
            Expression<Func<TestObject, bool>> func = (x) => x.Name == "test";

            IndexHelper<TestObject> indexHelper = new IndexHelper<TestObject>(func);

            bool foundFilters = indexHelper.TryGetEqualFiltersForProperty(x => x.Name, out var filters);

            Assert.IsTrue(foundFilters);

            List<string> expected = new List<string>() { "test" };

            filters.Should().Equal(expected);
        }
    }
}
