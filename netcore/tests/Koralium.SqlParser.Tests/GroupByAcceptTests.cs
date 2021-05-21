using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class GroupByAcceptTests
    {
        [Test]
        public void TestExpressionGroupAccept() 
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            ExpressionGroup expressionGroup = new ExpressionGroup();

            expressionGroup.Accept(mock.Object);
            mock.Verify(x => x.VisitExpressionGroup(expressionGroup));
        }

        [Test]
        public void TestSelectStatementGroupAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            SelectStatementGroup selectStatementGroup = new SelectStatementGroup();

            selectStatementGroup.Accept(mock.Object);
            mock.Verify(x => x.VisitSelectStatementGroup(selectStatementGroup));
        }
    }
}
