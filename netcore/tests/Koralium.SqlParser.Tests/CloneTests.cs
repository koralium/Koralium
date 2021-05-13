using Koralium.SqlParser.Expressions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class CloneTests
    {
        [Test]
        public void TestCloneBooleanScalarExpression()
        {
            BooleanScalarExpression booleanScalarExpression = new BooleanScalarExpression()
            {
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "test" } }
            };

            var clone = booleanScalarExpression.Clone() as BooleanScalarExpression;

            Assert.IsFalse(ReferenceEquals(booleanScalarExpression, clone));
            Assert.IsFalse(ReferenceEquals(booleanScalarExpression.ScalarExpression, clone.ScalarExpression));
            Assert.AreEqual(booleanScalarExpression, clone);
        }
    }
}
