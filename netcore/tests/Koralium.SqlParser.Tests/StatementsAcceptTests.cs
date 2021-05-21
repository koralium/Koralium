using Koralium.SqlParser.Statements;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class StatementsAcceptTests
    {
        [Test]
        public void TestSelectStatementAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            SelectStatement selectStatement = new SelectStatement();

            selectStatement.Accept(mock.Object);
            mock.Verify(x => x.VisitSelectStatement(selectStatement));
        }

        [Test]
        public void TestSetVariableStatementAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            SetVariableStatement setVariableStatement = new SetVariableStatement();

            setVariableStatement.Accept(mock.Object);
            mock.Verify(x => x.VisitSetVariableStatement(setVariableStatement));
        }

        [Test]
        public void TestStatementListAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            StatementList statementList = new StatementList();

            statementList.Accept(mock.Object);
            mock.Verify(x => x.VisitStatementList(statementList));
        }
    }
}
