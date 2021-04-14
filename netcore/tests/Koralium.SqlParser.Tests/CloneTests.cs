using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class CloneTests
    {
        [Test]
        public void TestCloneCaseExpression()
        {
            CaseExpression caseExpression = new CaseExpression()
            {
                ElseExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Left = new ColumnReference(){ Identifiers = new List<string>(){"c1"}},
                            Right = new StringLiteral(){Value = "v"},
                            Type = BooleanComparisonType.Equals
                        },
                        ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                    }
                }
            };
            var clone = caseExpression.Clone() as CaseExpression;
            Assert.IsFalse(ReferenceEquals(caseExpression, clone));
            Assert.IsFalse(ReferenceEquals(caseExpression.ElseExpression, clone.ElseExpression));

            for(int i = 0; i < caseExpression.WhenExpressions.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(caseExpression.WhenExpressions[i], clone.WhenExpressions[i]));
            }
            Assert.AreEqual(caseExpression, clone);
        }

        [Test]
        public void TestCloneWhenExpression()
        {
            var whenExpression = new WhenExpression()
            {
                BooleanExpression = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new StringLiteral() { Value = "v" },
                    Type = BooleanComparisonType.Equals
                },
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };
            var clone = whenExpression.Clone() as WhenExpression;
            Assert.IsFalse(ReferenceEquals(whenExpression, clone));
            Assert.IsFalse(ReferenceEquals(whenExpression.BooleanExpression, clone.BooleanExpression));
            Assert.IsFalse(ReferenceEquals(whenExpression.ScalarExpression, clone.ScalarExpression));
            Assert.AreEqual(whenExpression, clone);
        }
    }
}
