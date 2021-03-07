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
