using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class ExpressionEqualsTests
    {
        [Test]
        public void TestBooleanScalarExpressionEquals()
        {
            BooleanScalarExpression left = new BooleanScalarExpression()
            {
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "test" } }
            };

            BooleanScalarExpression leftClone = new BooleanScalarExpression()
            {
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "test" } }
            };

            BooleanScalarExpression right = new BooleanScalarExpression()
            {
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "t2" } }
            };

            //Equals
            Assert.IsTrue(Equals(left, leftClone));
            Assert.IsFalse(Equals(left, null));
            Assert.IsFalse(Equals(left, right));
            Assert.IsFalse(Equals(left, "other type"));

            //Hash code
            Assert.AreEqual(left.GetHashCode(), leftClone.GetHashCode());
            Assert.AreNotEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Test]
        public void TestLambdaExpressionEquals()
        {
            LambdaExpression first = new LambdaExpression()
            {
                Expression = new BooleanLiteral() { Value = true },
                Parameters = new List<string>() { "p1" }
            };

            LambdaExpression firstClone = new LambdaExpression()
            {
                Expression = new BooleanLiteral() { Value = true },
                Parameters = new List<string>() { "p1" }
            };

            LambdaExpression second = new LambdaExpression()
            {
                Expression = new BooleanLiteral() { Value = false },
                Parameters = new List<string>() { "p1" }
            };

            LambdaExpression third = new LambdaExpression()
            {
                Expression = new BooleanLiteral() { Value = true },
                Parameters = new List<string>() { "p2" }
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
        public void TestFunctionCallEquals()
        {
            FunctionCall first = new FunctionCall()
            {
                FunctionName = "test",
                Parameters = new List<SqlExpression>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() {"c1" }}
                },
                Wildcard = false
            };

            FunctionCall firstClone = new FunctionCall()
            {
                FunctionName = "test",
                Parameters = new List<SqlExpression>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() {"c1" }}
                },
                Wildcard = false
            };

            FunctionCall second = new FunctionCall()
            {
                FunctionName = "test2",
                Parameters = new List<SqlExpression>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() {"c1" }}
                },
                Wildcard = false
            };

            FunctionCall third = new FunctionCall()
            {
                FunctionName = "test",
                Parameters = new List<SqlExpression>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() {"c2" }}
                },
                Wildcard = false
            };

            FunctionCall fourth = new FunctionCall()
            {
                FunctionName = "test",
                Parameters = new List<SqlExpression>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() {"c1" }}
                },
                Wildcard = true
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, fourth));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), fourth.GetHashCode());
        }

        [Test]
        public void TestColumnReferenceEquals()
        {
            ColumnReference first = new ColumnReference()
            {
                Identifiers = new List<string>() { "test" }
            };

            ColumnReference firstClone = new ColumnReference()
            {
                Identifiers = new List<string>() { "test" }
            };

            ColumnReference second = new ColumnReference()
            {
                Identifiers = new List<string>() { "test2" }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [Test]
        public void TestBetweenExpressionEquals()
        {
            BetweenExpression first = new BetweenExpression()
            {
                Expression = new ColumnReference { Identifiers = new List<string>() { "c1" } },
                From = new IntegerLiteral() { Value = 3 },
                To = new IntegerLiteral() { Value = 17 }
            };

            BetweenExpression firstClone = new BetweenExpression()
            {
                Expression = new ColumnReference { Identifiers = new List<string>() { "c1" } },
                From = new IntegerLiteral() { Value = 3 },
                To = new IntegerLiteral() { Value = 17 }
            };

            BetweenExpression second = new BetweenExpression()
            {
                Expression = new ColumnReference { Identifiers = new List<string>() { "c2" } },
                From = new IntegerLiteral() { Value = 3 },
                To = new IntegerLiteral() { Value = 17 }
            };

            BetweenExpression third = new BetweenExpression()
            {
                Expression = new ColumnReference { Identifiers = new List<string>() { "c1" } },
                From = new IntegerLiteral() { Value = 4 },
                To = new IntegerLiteral() { Value = 17 }
            };

            BetweenExpression fourth = new BetweenExpression()
            {
                Expression = new ColumnReference { Identifiers = new List<string>() { "c1" } },
                From = new IntegerLiteral() { Value = 3 },
                To = new IntegerLiteral() { Value = 19 }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, fourth));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), fourth.GetHashCode());
        }

        [Test]
        public void TestBinaryExpressionEquals()
        {
            BinaryExpression first = new BinaryExpression()
            {
                Type = BinaryType.Add,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            BinaryExpression firstClone = new BinaryExpression()
            {
                Type = BinaryType.Add,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            BinaryExpression second = new BinaryExpression()
            {
                Type = BinaryType.Divide,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            BinaryExpression third = new BinaryExpression()
            {
                Type = BinaryType.Add,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            BinaryExpression fourth = new BinaryExpression()
            {
                Type = BinaryType.Add,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 17 }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, fourth));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), fourth.GetHashCode());
        }
    }
}
