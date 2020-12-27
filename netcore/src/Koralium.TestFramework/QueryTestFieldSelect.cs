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
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.TestFramework
{
    public partial class QueryTest<TEntity>
    {
        private static IEnumerable<PropertyInfo> SelectableProperties
        {
            get
            {
                foreach (var property in Properties)
                {
                    yield return property;
                }
            }
        }

        private static IEnumerable SelectFieldsTestCase
        {
            get
            {
                foreach (var property in SelectableProperties)
                {
                    yield return new TestCaseData(property)
                    {
                        TestName = $"TestSelectSingleField(on {property.Name})"
                    };
                }
            }
        }

        [TestCaseSourceGeneric(nameof(SelectFieldsTestCase))]
        public virtual void TestSelectSingleField(PropertyInfo propertyInfo)
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var memberAccess = Expression.MakeMemberAccess(parameter, propertyInfo);
            var assignment = Expression.Bind(propertyInfo, memberAccess);
            var newExpression = Expression.New(typeof(TEntity));

            var memberInit = Expression.MemberInit(newExpression, assignment);
            var lambda = Expression.Lambda<Func<TEntity, TEntity>>(memberInit, parameter);
            var lambdaCompiled = lambda.Compile();

            var expected = Context.Entities.Select(lambda).ToList();
            var actual = TestData().Select(lambdaCompiled).ToList();

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
