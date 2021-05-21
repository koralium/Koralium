using Koralium.SqlParser.From;
using Koralium.SqlParser.Visitor;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class FromAcceptTests
    {
        [Test]
        public void TestFromTableReferenceAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            FromTableReference fromTableReference = new FromTableReference();

            fromTableReference.Accept(mock.Object);
            mock.Verify(x => x.VisitFromTableReference(fromTableReference));
        }

        [Test]
        public void TestSubqueryAccept()
        {
            Mock<KoraliumSqlVisitor> mock = new Mock<KoraliumSqlVisitor>();
            Subquery subquery = new Subquery();

            subquery.Accept(mock.Object);
            mock.Verify(x => x.VisitSubquery(subquery));
        }
    }
}
