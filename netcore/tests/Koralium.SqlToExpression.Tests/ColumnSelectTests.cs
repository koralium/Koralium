using Koralium.SqlToExpression.Tests.Helpers;
using Koralium.SqlToExpression.Tests.Models;
using Koralium.SqlToExpression.Utils;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests
{
    [TestFixture]
    public class ColumnSelectTests : TpchTestsBase
    {
        public class TestCaseClass
        {
            public PropertyInfo[] Properties { get; }

            public TestCaseClass(PropertyInfo[] properties)
            {
                Properties = properties;
            }
        }

        private static IEnumerable<PropertyInfo[]> SelectProperties
        {
            get
            {
                var type = typeof(ColumnTest);

                var properties = type.GetProperties();

                for(int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo[] arr = new PropertyInfo[i + 1];
                    for (int y = 0; y <= i; y++)
                    {
                        arr[y] = properties[y];
                    }
                    yield return arr;
                }
            }
        }

        private static IEnumerable SelectColumnsTestCase
        {
            get
            {
                foreach (var propertyArray in SelectProperties)
                {
                    yield return new TestCaseData(new TestCaseClass(propertyArray))
                    {
                        TestName = $"TestSelectColumns(count {propertyArray.Length})"
                    };
                }
            }
        }

        private static IEnumerable SelectColumnsDistinctTestCase
        {
            get
            {
                foreach (var propertyArray in SelectProperties)
                {
                    yield return new TestCaseData(new TestCaseClass(propertyArray))
                    {
                        TestName = $"TestSelectColumnsDistinct(count {propertyArray.Length})"
                    };
                }
            }
        }

        private static Func<ColumnTest, object> GenerateSelectExpression(PropertyInfo[] properties)
        {
            var parameter = Expression.Parameter(typeof(ColumnTest));

            var anonType = AnonTypeUtils.GetAnonType(properties.Select(x => x.PropertyType).ToArray());

            List<MemberAssignment> memberAssignments = new List<MemberAssignment>();
            for (int i = 0; i < properties.Length; i++)
            {
                var memberAccess = Expression.MakeMemberAccess(parameter, properties[i]);
                var anonTypeProperty = anonType.GetProperty($"P{i}");
                var memberAssignment = Expression.Bind(anonTypeProperty, memberAccess);
                memberAssignments.Add(memberAssignment);
            }

            var newExpression = Expression.New(anonType);
            var memberInit = Expression.MemberInit(newExpression, memberAssignments);
            var lambda = Expression.Lambda<Func<ColumnTest, object>>(Expression.Convert(memberInit, typeof(object)), parameter);
            var compiledLambda = lambda.Compile();

            return compiledLambda;
        }

        [TestCaseSource(nameof(SelectColumnsTestCase))]
        public async Task TestSelectColumns(TestCaseClass testCase)
        {
            string sql = "SELECT ";

            sql += string.Join(", ", testCase.Properties.Select(x => x.Name));
            sql += " FROM columntest";
            var result = await SqlExecutor.Execute(sql);

            var selectLambda = GenerateSelectExpression(testCase.Properties);

            var expected = TestData.GetColumnTestData().Select(selectLambda).ToList();
            AssertAreEqual(expected.AsQueryable(), result.Result);
        }
                
        [TestCaseSource(nameof(SelectColumnsDistinctTestCase))]
        public async Task TestSelectColumnsDistinct(TestCaseClass testCase)
        {
            string sql = "SELECT DISTINCT ";

            sql += string.Join(", ", testCase.Properties.Select(x => x.Name));
            sql += " FROM columntest";
            var result = await SqlExecutor.Execute(sql);

            var selectLambda = GenerateSelectExpression(testCase.Properties);
            var expected = TestData.GetColumnTestData().Select(selectLambda).Distinct().ToList();
            AssertAreEqual(expected.AsQueryable(), result.Result);
        }
    }
}
