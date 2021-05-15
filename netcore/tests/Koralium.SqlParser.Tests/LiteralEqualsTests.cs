using Koralium.SqlParser.Literals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class LiteralEqualsTests
    {
        [Test]
        public void TestStringLiteralEquals()
        {
            StringLiteral first = new StringLiteral()
            {
                Value = "test"
            };

            StringLiteral firstClone = new StringLiteral()
            {
                Value = "test"
            };

            StringLiteral second = new StringLiteral()
            {
                Value = "test2"
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [Test]
        public void TestIntegerLiteralEquals()
        {
            IntegerLiteral first = new IntegerLiteral()
            {
                Value = 3
            };

            IntegerLiteral firstClone = new IntegerLiteral()
            {
                Value = 3
            };

            IntegerLiteral second = new IntegerLiteral()
            {
                Value = 17
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [Test]
        public void TestBooleanLiteralEquals()
        {
            BooleanLiteral first = new BooleanLiteral()
            {
                Value = true
            };

            BooleanLiteral firstClone = new BooleanLiteral()
            {
                Value = true
            };

            BooleanLiteral second = new BooleanLiteral()
            {
                Value = false
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}
