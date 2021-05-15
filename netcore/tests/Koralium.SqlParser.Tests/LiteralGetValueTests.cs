using Koralium.SqlParser.Literals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class LiteralGetValueTests
    {
        [Test]
        public void TestBooleanLiteralGetValue()
        {
            BooleanLiteral booleanLiteral = new BooleanLiteral()
            {
                Value = true
            };

            Assert.AreEqual(true, booleanLiteral.GetValue());

            booleanLiteral.Value = false;

            Assert.AreEqual(false, booleanLiteral.GetValue());
        }

        [Test]
        public void TestStringLiteralGetValue()
        {
            StringLiteral stringLiteral = new StringLiteral()
            {
                Value = "test"
            };

            Assert.AreEqual("test", stringLiteral.GetValue());
        }

        [Test]
        public void TestIntegerLiteralGetValue()
        {
            IntegerLiteral integerLiteral = new IntegerLiteral()
            {
                Value = 3
            };

            Assert.AreEqual(3, integerLiteral.GetValue());
        }

        [Test]
        public void TestNumericLiteralGetValue()
        {
            NumericLiteral numericLiteral = new NumericLiteral()
            {
                Value = 17
            };

            Assert.AreEqual(17m, numericLiteral.GetValue());
        }

        [Test]
        public void TestNullLiteralGetValue()
        {
            NullLiteral nullLiteral = new NullLiteral();

            Assert.AreEqual(null, nullLiteral.GetValue());
        }

        [Test]
        public void TestBase64LiteralGetValue()
        {
            Base64Literal base64Literal = new Base64Literal()
            {
                Value = "test"
            };

            Assert.AreEqual("test", base64Literal.GetValue());
        }
    }
}
