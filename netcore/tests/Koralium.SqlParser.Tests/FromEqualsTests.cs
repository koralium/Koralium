using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.From;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class FromEqualsTests
    {
        [Test]
        public void TestFromTableReferenceEquals()
        {
            FromTableReference first = new FromTableReference()
            {
                Alias = "test",
                TableName = "t"
            };

            FromTableReference firstClone = new FromTableReference()
            {
                Alias = "test",
                TableName = "t"
            };

            FromTableReference second = new FromTableReference()
            {
                Alias = "test2",
                TableName = "t"
            };

            FromTableReference third = new FromTableReference()
            {
                Alias = "test",
                TableName = "t2"
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
        }

        [Test]
        public void TestSubqueryEquals()
        {
            Subquery first = new Subquery()
            {
                Alias = "t",
                SelectStatement = new SelectStatement()
                {
                    FromClause = new FromClause() { TableReference = new FromTableReference() { TableName = "test" } }
                }
            };

            Subquery firstClone = new Subquery()
            {
                Alias = "t",
                SelectStatement = new SelectStatement()
                {
                    FromClause = new FromClause() { TableReference = new FromTableReference() { TableName = "test" } }
                }
            };

            Subquery second = new Subquery()
            {
                Alias = "t2",
                SelectStatement = new SelectStatement()
                {
                    FromClause = new FromClause() { TableReference = new FromTableReference() { TableName = "test" } }
                }
            };

            Subquery third = new Subquery()
            {
                Alias = "t",
                SelectStatement = new SelectStatement()
                {
                    FromClause = new FromClause() { TableReference = new FromTableReference() { TableName = "test2" } }
                }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
        }
    }
}
