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

namespace Koralium.SqlToExpression.Tests
{
    class IndexVisitorTests
    {
        private class TestObject
        {
            public string Name { get; set; }

            public InnerObject InnerObject { get; set; }

            public string Prop2 { get; set; }
        }

        private class InnerObject
        {
            public string Test { get; set; }
        }

        [Test]
        public void TestSinglePropertyEquals()
        {
            Expression<Func<TestObject, bool>> func = (x) => x.Name == "test";
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
                {"Name", new List<object>(){ "test" } }
            };

            filters.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void TestInnerObjectPropertyEquals()
        {
            Expression<Func<TestObject, bool>> func = (x) => x.InnerObject.Test == "test";
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
                {"InnerObject.Test", new List<object>(){ "test" } }
            };

            filters.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void TestTwoPropertyEquals()
        {
            Expression<Func<TestObject, bool>> func = (x) => x.Name == "test" && x.Prop2 == "test2";
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
                {"Name", new List<object>() { "test" } },
                { "Prop2", new List<object>() { "test2"} }
            };

            filters.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void TestSinglePropertyMultipleEquals()
        {
            Expression<Func<TestObject, bool>> func = (x) => x.Name == "test" && x.Name == "test2";
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
                {"Name", new List<object>() { "test", "test2" } }
            };

            filters.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void TestListContains()
        {
            List<string> containsValues = new List<string>() { "test1", "test2", "test3" };
            Expression<Func<TestObject, bool>> func = (x) => containsValues.Contains(x.Name);
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
                {"Name", new List<object>() { "test1", "test2", "test3" } }
            };

            filters.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void TestListContainsAndEquals()
        {
            List<string> containsValues = new List<string>() { "test1", "test2", "test3" };
            Expression<Func<TestObject, bool>> func = (x) => x.Name == "test" && containsValues.Contains(x.Name);
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
                {"Name", new List<object>() { "test", "test1", "test2", "test3" } }
            };

            filters.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void TestOrIsIgnored()
        {
            List<string> containsValues = new List<string>() { "test1", "test2", "test3" };
            Expression<Func<TestObject, bool>> func = (x) => x.Name == "test" || containsValues.Contains(x.Name);
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
            };

            filters.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void TestOrBelowAndIsIgnored()
        {
            Expression<Func<TestObject, bool>> func = (x) => x.Name == "test" && (x.Name == "test1" || x.Name == "test");
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
                {"Name", new List<object>() { "test" } }
            };

            filters.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void TestNotIsIgnored()
        {
            Expression<Func<TestObject, bool>> func = (x) => !(x.Name == "test");
            IndexBuilderVisitor indexBuilderVisitor = new IndexBuilderVisitor();

            indexBuilderVisitor.Visit(func);

            var filters = indexBuilderVisitor.Filters;

            Dictionary<string, List<object>> expected = new Dictionary<string, List<object>>()
            {
            };

            filters.Should().BeEquivalentTo(expected);
        }
    }
}
