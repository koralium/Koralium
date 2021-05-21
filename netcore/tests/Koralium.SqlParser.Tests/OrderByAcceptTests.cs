using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class OrderByAcceptTests
    {
        [Test]
        public void TestOrderBySubqueryAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            OrderBySubquery orderBySubquery = new OrderBySubquery();

            orderBySubquery.Accept(mock.Object);
            mock.Verify(x => x.VisitOrderBySubquery(orderBySubquery));
        }

        [Test]
        public void TestOrderExpressionAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            OrderExpression orderExpression = new OrderExpression();

            orderExpression.Accept(mock.Object);
            mock.Verify(x => x.VisitOrderExpression(orderExpression));
        }
    }
}
