using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class LiteralAcceptTests
    {
        [Test]
        public void TestStringLiteralAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            StringLiteral stringLiteral = new StringLiteral();

            stringLiteral.Accept(mock.Object);
            mock.Verify(x => x.VisitStringLiteral(stringLiteral));
        }

        [Test]
        public void TestIntegerLiteralAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            IntegerLiteral integerLiteral = new IntegerLiteral();

            integerLiteral.Accept(mock.Object);
            mock.Verify(x => x.VisitIntegerLiteral(integerLiteral));
        }

        [Test]
        public void TestBooleanLiteralAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BooleanLiteral booleanLiteral = new BooleanLiteral();

            booleanLiteral.Accept(mock.Object);
            mock.Verify(x => x.VisitBooleanLiteral(booleanLiteral));
        }

        [Test]
        public void TestNumericLiteralAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            NumericLiteral numericLiteral = new NumericLiteral();

            numericLiteral.Accept(mock.Object);
            mock.Verify(x => x.VisitNumericLiteral(numericLiteral));
        }

        [Test]
        public void TestNullLiteralAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            NullLiteral nullLiteral = new NullLiteral();

            nullLiteral.Accept(mock.Object);
            mock.Verify(x => x.VisitNullLiteral(nullLiteral));
        }

        [Test]
        public void TestBase64LiteralAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            Base64Literal base64Literal = new Base64Literal();

            base64Literal.Accept(mock.Object);
            mock.Verify(x => x.VisitBase64Literal(base64Literal));
        }
    }
}
