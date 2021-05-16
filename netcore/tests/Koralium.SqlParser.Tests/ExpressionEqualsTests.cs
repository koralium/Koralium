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

        [Test]
        public void TestBooleanBinaryExpressionEquals()
        {
            BooleanBinaryExpression first = new BooleanBinaryExpression()
            {
                Type = BooleanBinaryType.AND,
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new IntegerLiteral() { Value = 3 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.GreaterThan,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                    Right = new IntegerLiteral() { Value = 17 }
                }
            };

            BooleanBinaryExpression firstClone = new BooleanBinaryExpression()
            {
                Type = BooleanBinaryType.AND,
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new IntegerLiteral() { Value = 3 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.GreaterThan,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                    Right = new IntegerLiteral() { Value = 17 }
                }
            };

            BooleanBinaryExpression second = new BooleanBinaryExpression()
            {
                Type = BooleanBinaryType.OR,
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new IntegerLiteral() { Value = 3 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.GreaterThan,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                    Right = new IntegerLiteral() { Value = 17 }
                }
            };

            BooleanBinaryExpression third = new BooleanBinaryExpression()
            {
                Type = BooleanBinaryType.AND,
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new IntegerLiteral() { Value = 4 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.GreaterThan,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                    Right = new IntegerLiteral() { Value = 17 }
                }
            };

            BooleanBinaryExpression fourth = new BooleanBinaryExpression()
            {
                Type = BooleanBinaryType.AND,
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new IntegerLiteral() { Value = 3 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.GreaterThan,
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                    Right = new IntegerLiteral() { Value = 18 }
                }
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
        public void TestBooleanComparisonExpressionEquals()
        {
            BooleanComparisonExpression first = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            BooleanComparisonExpression firstClone = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            BooleanComparisonExpression second = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.GreaterThan,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            BooleanComparisonExpression third = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            BooleanComparisonExpression fourth = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
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

        [Test]
        public void TestBooleanIsNullExpressionEquals()
        {
            BooleanIsNullExpression first = new BooleanIsNullExpression()
            {
                IsNot = false,
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };

            BooleanIsNullExpression firstClone = new BooleanIsNullExpression()
            {
                IsNot = false,
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };

            BooleanIsNullExpression second = new BooleanIsNullExpression()
            {
                IsNot = true,
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };

            BooleanIsNullExpression third = new BooleanIsNullExpression()
            {
                IsNot = false,
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c2" } }
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
        public void TestCastExpressionEquals()
        {
            CastExpression first = new CastExpression()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                ToType = "t"
            };

            CastExpression firstClone = new CastExpression()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                ToType = "t"
            };

            CastExpression second = new CastExpression()
            {
                ScalarExpression = new StringLiteral() { Value = "test2" },
                ToType = "t"
            };

            CastExpression third = new CastExpression()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                ToType = "t2"
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
        public void TestInExpressionEquals()
        {
            InExpression first = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Not = false,
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "test" }
                }
            };

            InExpression firstClone = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Not = false,
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "test" }
                }
            };

            InExpression second = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                Not = false,
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "test" }
                }
            };

            InExpression third = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Not = true,
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "test" }
                }
            };

            InExpression fourth = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Not = false,
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "test2" }
                }
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
        public void TestLikeExpressionEquals()
        {
            LikeExpression first = new LikeExpression()
            {
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new StringLiteral() { Value = "test" },
                Not = false
            };

            LikeExpression firstClone = new LikeExpression()
            {
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new StringLiteral() { Value = "test" },
                Not = false
            };

            LikeExpression second = new LikeExpression()
            {
                Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                Right = new StringLiteral() { Value = "test" },
                Not = false
            };

            LikeExpression third = new LikeExpression()
            {
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new StringLiteral() { Value = "test2" },
                Not = false
            };

            LikeExpression fourth = new LikeExpression()
            {
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new StringLiteral() { Value = "test" },
                Not = true
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
        public void TestNotExpressionEquals()
        {
            NotExpression first = new NotExpression()
            {
                BooleanExpression = new BooleanScalarExpression() { ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } } }
            };

            NotExpression firstClone = new NotExpression()
            {
                BooleanExpression = new BooleanScalarExpression() { ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } } }
            };

            NotExpression second = new NotExpression()
            {
                BooleanExpression = new BooleanScalarExpression() { ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c2" } } }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [Test]
        public void TestSearchExpressionEquals()
        {
            SearchExpression first = new SearchExpression()
            {
                AllColumns = false,
                Columns = new List<ColumnReference>() { new ColumnReference() { Identifiers = new List<string>() { "c1" } } },
                Value = new StringLiteral() { Value = "test" }
            };

            SearchExpression firstClone = new SearchExpression()
            {
                AllColumns = false,
                Columns = new List<ColumnReference>() { new ColumnReference() { Identifiers = new List<string>() { "c1" } } },
                Value = new StringLiteral() { Value = "test" }
            };

            SearchExpression second = new SearchExpression()
            {
                AllColumns = true,
                Columns = new List<ColumnReference>() { new ColumnReference() { Identifiers = new List<string>() { "c1" } } },
                Value = new StringLiteral() { Value = "test" }
            };

            SearchExpression third = new SearchExpression()
            {
                AllColumns = false,
                Columns = new List<ColumnReference>() { new ColumnReference() { Identifiers = new List<string>() { "c2" } } },
                Value = new StringLiteral() { Value = "test" }
            };

            SearchExpression fourth = new SearchExpression()
            {
                AllColumns = false,
                Columns = new List<ColumnReference>() { new ColumnReference() { Identifiers = new List<string>() { "c1" } } },
                Value = new StringLiteral() { Value = "test2" }
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
        public void TestSelectNullExpressionEquals()
        {
            SelectNullExpression first = new SelectNullExpression()
            {
                Alias = "test"
            };

            SelectNullExpression firstClone = new SelectNullExpression()
            {
                Alias = "test"
            };

            SelectNullExpression second = new SelectNullExpression()
            {
                Alias = "test2"
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [Test]
        public void TestSelectScalarExpressionEquals()
        {
            SelectScalarExpression first = new SelectScalarExpression()
            {
                Alias = "test",
                Expression = new StringLiteral() { Value = "t" }
            };

            SelectScalarExpression firstClone = new SelectScalarExpression()
            {
                Alias = "test",
                Expression = new StringLiteral() { Value = "t" }
            };

            SelectScalarExpression second = new SelectScalarExpression()
            {
                Alias = "test2",
                Expression = new StringLiteral() { Value = "t" }
            };

            SelectScalarExpression third = new SelectScalarExpression()
            {
                Alias = "test",
                Expression = new StringLiteral() { Value = "t2" }
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
        public void TestSelectStarExpressionEquals()
        {
            SelectStarExpression first = new SelectStarExpression()
            {
                Alias = "test"
            };

            SelectStarExpression firstClone = new SelectStarExpression()
            {
                Alias = "test"
            };

            SelectStarExpression second = new SelectStarExpression()
            {
                Alias = "test2"
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [Test]
        public void TestVariableReferenceEquals()
        {
            VariableReference first = new VariableReference()
            {
                Name = "test"
            };

            VariableReference firstClone = new VariableReference()
            {
                Name = "test"
            };

            VariableReference second = new VariableReference()
            {
                Name = "test2"
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}
