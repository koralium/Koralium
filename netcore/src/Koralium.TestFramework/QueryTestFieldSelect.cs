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

            var expected = Context.Entities.Select(lambdaCompiled).ToList();
            var actual = TestData().Select(lambdaCompiled).ToList();

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
