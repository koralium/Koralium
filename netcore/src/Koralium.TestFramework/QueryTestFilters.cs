using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
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
            var equalsExpression = Expression.Equal(propertyMember, Expression.Constant(firstValue));

            var lambdaExpression = Expression.Lambda(equalsExpression, parameter);
            var filterFunction = (Expression<Func<TEntity, bool>>)lambdaExpression;

            var actual = Context.Entities.Where(filterFunction).ToList();

            var expected = data.Where(x => propertyInfo.GetValue(x).Equals(firstValue)).ToList();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
