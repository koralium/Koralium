using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class ExpressionsAcceptTests
    {
        [Test]
        public void TestBetweenExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BetweenExpression betweenExpression = new BetweenExpression();

            betweenExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitBetweenExpression(betweenExpression));
        }

        [Test]
        public void TestBinaryExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            BinaryExpression binaryExpression = new BinaryExpression();

            binaryExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitBinaryExpression(binaryExpression));
        }
    }
}
