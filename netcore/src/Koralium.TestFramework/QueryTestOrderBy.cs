using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.TestFramework
{
    public abstract partial class QueryTest<TEntity>
    {
        private static bool IsOrderable(Type type)
        {
            return type.IsPrimitive || type == typeof(string);
        }

        private static IEnumerable<PropertyInfo> OrderableProperties
        {
            get
            {
                foreach (var property in Properties)
                {
                    if (IsOrderable(property.PropertyType))
                    {
                        yield return property;
                    }
                }
            }
        }

        private static IEnumerable OrderOnPropertiesAscendingTestCase
        {
            get
            {
                foreach (var property in OrderableProperties)
                {
                    yield return new TestCaseData(property)
                    {
                        TestName = $"TestOrderByAscending(on {property.Name})"
                    };
                }
            }
        }

        private Func<TEntity, object> GetSortLambda(PropertyInfo property)
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var propertyMember = Expression.MakeMemberAccess(parameter, property);
            var lambda = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(propertyMember, typeof(object)), parameter);

            return lambda.Compile();
        }

        [TestCaseSourceGeneric(nameof(OrderOnPropertiesAscendingTestCase))]
        public virtual async Task TestOrderByAscending(PropertyInfo propertyInfo)
        {
            var data = TestData().ToList();

            var lambda = GetSortLambda(propertyInfo);

            var actual = Context.Entities.OrderBy(lambda).ToList();
            var expected = data.OrderBy(lambda).ToList();

            actual.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
        }

        private static IEnumerable OrderOnPropertiesDescendingTestCase
        {
            get
            {
                foreach (var property in OrderableProperties)
                {
                    yield return new TestCaseData(property)
                    {
                        TestName = $"TestOrderByDescending(on {property.Name})"
                    };
                }
            }
        }

        [TestCaseSourceGeneric(nameof(OrderOnPropertiesDescendingTestCase))]
        public virtual async Task TestOrderByDescending(PropertyInfo propertyInfo)
        {
            var data = TestData().ToList();

            var lambda = GetSortLambda(propertyInfo);

            var actual = Context.Entities.OrderByDescending(lambda).ToList();
            var expected = data.OrderByDescending(lambda).ToList();

            actual.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
        }
    }
}
