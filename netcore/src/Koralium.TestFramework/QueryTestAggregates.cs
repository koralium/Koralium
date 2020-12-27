using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Koralium.TestFramework
{
    public partial class QueryTest<TEntity>
    {

        private static bool CanBeAggregated(Type type)
        {
            var nullableInner = Nullable.GetUnderlyingType(type);

            if(nullableInner != null)
            {
                return CanBeAggregated(nullableInner);
            }

            var typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return true;
                default:
                    return false;
            }
        }

        private static IEnumerable<PropertyInfo> AggregateProperties
        {
            get
            {
                foreach (var property in Properties)
                {
                    if (CanBeAggregated(property.PropertyType))
                    {
                        yield return property;
                    }
                }
            }
        }

        private static IEnumerable SumAggregateTestCase
        {
            get
            {
                foreach (var property in AggregateProperties)
                {
                    yield return new TestCaseData(property)
                    {
                        TestName = $"TestSum(on {property.Name})"
                    };
                }
            }
        }

        [TestCaseSourceGeneric(nameof(SumAggregateTestCase))]
        public virtual void TestSum(PropertyInfo propertyInfo)
        {
            TestSumInternal(propertyInfo);
        }

        private void TestSumInternal(PropertyInfo propertyInfo)
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var memberAccess = Expression.MakeMemberAccess(parameter, propertyInfo);

            if (propertyInfo.PropertyType == typeof(decimal?))
            {
                var lambda = Expression.Lambda<Func<TEntity, decimal?>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(decimal))
            {
                var lambda = Expression.Lambda<Func<TEntity, decimal>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(double?))
            {
                var lambda = Expression.Lambda<Func<TEntity, double?>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(double))
            {
                var lambda = Expression.Lambda<Func<TEntity, double>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(float?))
            {
                var lambda = Expression.Lambda<Func<TEntity, float?>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(float))
            {
                var lambda = Expression.Lambda<Func<TEntity, float>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(int?))
            {
                var lambda = Expression.Lambda<Func<TEntity, int?>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(int))
            {
                var lambda = Expression.Lambda<Func<TEntity, int>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(long?))
            {
                var lambda = Expression.Lambda<Func<TEntity, long?>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
            if (propertyInfo.PropertyType == typeof(long))
            {
                var lambda = Expression.Lambda<Func<TEntity, long>>(memberAccess, parameter);
                var lambdaCompiled = lambda.Compile();

                var expected = Context.Entities.Sum(lambda);
                var actual = TestData().Sum(lambdaCompiled);

                expected.Should().Be(actual);
            }
        }
    }
}
