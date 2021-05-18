using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class ClausesAcceptTests
    {
        [Test]
        public void TestFromClauseAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            FromClause fromClause = new FromClause();

            fromClause.Accept(mock.Object);
            mock.Verify(x => x.VisitFromClause(fromClause));
        }

        [Test]
        public void TestGroupByClauseAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            GroupByClause groupByClause = new GroupByClause();

            groupByClause.Accept(mock.Object);
            mock.Verify(x => x.VisitGroupByClause(groupByClause));
        }

        [Test]
        public void TestHavingClauseAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            HavingClause havingClause = new HavingClause();

            havingClause.Accept(mock.Object);
            mock.Verify(x => x.VisitHavingClause(havingClause));
        }

        [Test]
        public void TestOffsetLimitClauseAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            OffsetLimitClause offsetLimitClause = new OffsetLimitClause();

            offsetLimitClause.Accept(mock.Object);
            mock.Verify(x => x.VisitOffsetLimitClause(offsetLimitClause));
        }

        [Test]
        public void TestOrderByClauseAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            OrderByClause orderByClause = new OrderByClause();

            orderByClause.Accept(mock.Object);
            mock.Verify(x => x.VisitOrderByClause(orderByClause));
        }

        [Test]
        public void TestWhereClauseAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            WhereClause whereClause = new WhereClause();

            whereClause.Accept(mock.Object);
            mock.Verify(x => x.VisitWhereClause(whereClause));
        }
    }
}
