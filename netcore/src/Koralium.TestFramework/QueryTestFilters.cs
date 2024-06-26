﻿/*
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
using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Koralium.TestFramework
{
    public abstract partial class QueryTest<TEntity>
    {

        private static IEnumerable FilterOnPropertiesTestCase
        {
            get
            {
                foreach (var property in FilterableProperties)
                {
                    yield return new TestCaseData(property)
                    {
                        TestName = $"TestFiltersEqual(on {property.Name})"
                    };
                }
            }
        }

        [TestCaseSourceGeneric(nameof(FilterOnPropertiesTestCase))]
        public virtual async Task TestFiltersEqual(PropertyInfo propertyInfo)
        {
            var data = TestData().ToList();
            var firstRow = data.FirstOrDefault();
            var firstValue = propertyInfo.GetValue(firstRow);

            var parameter = Expression.Parameter(typeof(TEntity));
            var propertyMember = Expression.MakeMemberAccess(parameter, propertyInfo);
            var equalsExpression = Expression.Equal(propertyMember, Expression.Constant(firstValue, propertyMember.Type));

            var lambdaExpression = Expression.Lambda(equalsExpression, parameter);
            var filterFunction = (Expression<Func<TEntity, bool>>)lambdaExpression;

            var actual = Context.Entities.Where(filterFunction).ToList();

            var expected = data.Where(x => Equals(propertyInfo.GetValue(x), firstValue)).ToList();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
