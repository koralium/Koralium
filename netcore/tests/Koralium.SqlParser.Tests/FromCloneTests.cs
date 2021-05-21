using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.From;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class FromCloneTests
    {
        [Test]
        public void TestCloneFromTableReference()
        {
            FromTableReference fromTableReference = new FromTableReference()
            {
                Alias = "test",
                TableName = "t"
            };

            var clone = fromTableReference.Clone() as FromTableReference;

            Assert.AreEqual(fromTableReference, clone);
            Assert.IsFalse(ReferenceEquals(fromTableReference, clone));
        }

        [Test]
        public void TestCloneSubquery()
        {
            Subquery subquery = new Subquery()
            {
                Alias = "t",
                SelectStatement = new SelectStatement()
                {
                    FromClause = new FromClause() { TableReference = new FromTableReference() { TableName = "test" } }
                }
            };

            var clone = subquery.Clone() as Subquery;

            Assert.AreEqual(subquery, clone);
            Assert.IsFalse(ReferenceEquals(subquery, clone));
            Assert.IsFalse(ReferenceEquals(subquery.SelectStatement, clone.SelectStatement));
        }
    }
}
