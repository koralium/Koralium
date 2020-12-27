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
using FluentAssertions.Common;
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
                    if (!property.HasAttribute<KoraliumIgnoreAttribute>())
                    {
                        yield return property;
                    }
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
