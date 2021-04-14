using Koralium.SqlToExpression.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Tests
{
    public class NullableUtilsTests
    {
        [Test]
        public void TestIntIsNullable()
        {
            Assert.IsFalse(NullableUtils.IsNullable(typeof(int)));
        }

        [Test]
        public void TestNullableIntIsNullable()
        {
            Assert.IsTrue(NullableUtils.IsNullable(typeof(int?)));
        }

        struct TestStruct
        {
        }

        [Test]
        public void TestStructIsNullable()
        {
            Assert.IsFalse(NullableUtils.IsNullable(typeof(TestStruct)));
        }

        [Test]
        public void TestNullableStructIsNullable()
        {
            Assert.IsTrue(NullableUtils.IsNullable(typeof(TestStruct?)));
        }

        [Test]
        public void TestStringIsNullable()
        {
            Assert.IsTrue(NullableUtils.IsNullable(typeof(string)));
        }

        [Test]
        public void TestIntToNullable()
        {
            Assert.AreEqual(typeof(int?), NullableUtils.ToNullable(typeof(int)));
        }

        [Test]
        public void TestNullableIntToNullable()
        {
            Assert.AreEqual(typeof(int?), NullableUtils.ToNullable(typeof(int?)));
        }

        [Test]
        public void TestStructToNullable()
        {
            Assert.AreEqual(typeof(TestStruct?), NullableUtils.ToNullable(typeof(TestStruct)));
        }

        [Test]
        public void TestStringToNullable()
        {
            Assert.AreEqual(typeof(string), NullableUtils.ToNullable(typeof(string)));
        }
    }
}
