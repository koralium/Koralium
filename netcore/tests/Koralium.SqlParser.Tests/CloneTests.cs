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

        [Test]
        public void TestCloneLambdaExpression()
        {
            LambdaExpression lambdaExpression = new LambdaExpression()
            {
                Expression = new BooleanLiteral() { Value = true },
                Parameters = new List<string>() { "p1" }
            };

            var clone = lambdaExpression.Clone() as LambdaExpression;

            Assert.IsFalse(ReferenceEquals(lambdaExpression, clone));
            Assert.IsFalse(ReferenceEquals(lambdaExpression.Expression, clone.Expression));
            Assert.IsFalse(ReferenceEquals(lambdaExpression.Parameters, clone.Parameters));
            Assert.AreEqual(lambdaExpression, clone);
        }

        [Test]
        public void TestCloneFunctionCall()
        {
            FunctionCall functionCall = new FunctionCall()
            {
                FunctionName = "test",
                Parameters = new List<SqlExpression>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() {"c1" }}
                },
                Wildcard = false
            };

            var clone = functionCall.Clone() as FunctionCall;

            Assert.AreEqual(functionCall, clone);
            Assert.IsFalse(ReferenceEquals(functionCall, clone));
            Assert.IsFalse(ReferenceEquals(functionCall.Parameters, clone.Parameters));
            for(int i = 0; i < functionCall.Parameters.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(functionCall.Parameters[i], clone.Parameters[i]));
            }
        }

        [Test]
        public void TestCloneColumnReference()
        {
            ColumnReference columnReference = new ColumnReference()
            {
                Identifiers = new List<string>() { "test" }
            };

            var clone = columnReference.Clone() as ColumnReference;
            Assert.AreEqual(columnReference, clone);
            Assert.IsFalse(ReferenceEquals(columnReference, clone));
            Assert.IsFalse(ReferenceEquals(columnReference.Identifiers , clone.Identifiers));
        }

        [Test]
        public void TestCloneStringLiteral()
        {
            StringLiteral stringLiteral = new StringLiteral()
            {
                Value = "test"
            };

            var clone = stringLiteral.Clone() as StringLiteral;

            Assert.AreEqual(stringLiteral, clone);
            Assert.IsFalse(ReferenceEquals(stringLiteral, clone));
        }

        [Test]
        public void TestCloneIntegerLiteral()
        {
            IntegerLiteral integerLiteral = new IntegerLiteral()
            {
                Value = 3
            };

            var clone = integerLiteral.Clone() as IntegerLiteral;

            Assert.AreEqual(integerLiteral, clone);
            Assert.IsFalse(ReferenceEquals(integerLiteral, clone));
        }

        [Test]
        public void TestCloneBooleanLiteral()
        {
            BooleanLiteral booleanLiteral = new BooleanLiteral()
            {
                Value = true
            };

            var clone = booleanLiteral.Clone() as BooleanLiteral;

            Assert.AreEqual(booleanLiteral, clone);
            Assert.IsFalse(ReferenceEquals(booleanLiteral, clone));
        }

        [Test]
        public void TestCloneNullLiteral()
        {
            NullLiteral nullLiteral = new NullLiteral();

            var clone = nullLiteral.Clone();

            Assert.AreEqual(nullLiteral, clone);
            Assert.IsFalse(ReferenceEquals(nullLiteral, clone));
        }

        [Test]
        public void TestCloneNumericLiteral()
        {
            NumericLiteral numericLiteral = new NumericLiteral()
            {
                Value = 3
            };

            var clone = numericLiteral.Clone() as NumericLiteral;

            Assert.AreEqual(numericLiteral, clone);
            Assert.IsFalse(ReferenceEquals(numericLiteral, clone));
        }

        [Test]
        public void TestCloneBase64Literal()
        {
            Base64Literal base64Literal = new Base64Literal()
            {
                Value = "test"
            };

            var clone = base64Literal.Clone() as Base64Literal;

            Assert.AreEqual(base64Literal, clone);
            Assert.IsFalse(ReferenceEquals(base64Literal, clone));
        }

        [Test]
        public void TestCloneBetweenExpression()
        {
            BetweenExpression betweenExpression = new BetweenExpression()
            {
                Expression = new ColumnReference { Identifiers = new List<string>() { "c1" } },
                From = new IntegerLiteral() { Value = 3 },
                To = new IntegerLiteral() { Value = 17 }
            };

            var clone = betweenExpression.Clone() as BetweenExpression;

            Assert.AreEqual(betweenExpression, clone);
            Assert.IsFalse(ReferenceEquals(betweenExpression, clone));
            Assert.IsFalse(ReferenceEquals(betweenExpression.Expression, clone.Expression));
            Assert.IsFalse(ReferenceEquals(betweenExpression.From, clone.From));
            Assert.IsFalse(ReferenceEquals(betweenExpression.To, clone.To));
        }

        [Test]
        public void TestCloneBinaryExpression()
        {
            BinaryExpression binaryExpression = new BinaryExpression()
            {
                Type = BinaryType.Add,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            var clone = binaryExpression.Clone() as BinaryExpression;

            Assert.AreEqual(binaryExpression, clone);
            Assert.IsFalse(ReferenceEquals(binaryExpression, clone));
            Assert.IsFalse(ReferenceEquals(binaryExpression.Left, clone.Left));
            Assert.IsFalse(ReferenceEquals(binaryExpression.Right, clone.Right));
        }

        [Test]
        public void TestCloneBooleanBinaryExpression()
        {
            BooleanBinaryExpression booleanBinaryExpression = new BooleanBinaryExpression()
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

            var clone = booleanBinaryExpression.Clone() as BooleanBinaryExpression;

            Assert.AreEqual(booleanBinaryExpression, clone);
            Assert.IsFalse(ReferenceEquals(booleanBinaryExpression, clone));
            Assert.IsFalse(ReferenceEquals(booleanBinaryExpression.Left, clone.Left));
            Assert.IsFalse(ReferenceEquals(booleanBinaryExpression.Right, clone.Right));
        }

        [Test]
        public void TestCloneBooleanComparisonExpression()
        {
            BooleanComparisonExpression booleanComparisonExpression = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new IntegerLiteral() { Value = 3 }
            };

            var clone = booleanComparisonExpression.Clone() as BooleanComparisonExpression;

            Assert.AreEqual(booleanComparisonExpression, clone);
            Assert.IsFalse(ReferenceEquals(booleanComparisonExpression, clone));
            Assert.IsFalse(ReferenceEquals(booleanComparisonExpression.Left, clone.Left));
            Assert.IsFalse(ReferenceEquals(booleanComparisonExpression.Right, clone.Right));
        }

        [Test]
        public void TestCloneBooleanIsNullExpression()
        {
            BooleanIsNullExpression booleanIsNullExpression = new BooleanIsNullExpression()
            {
                IsNot = false,
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };

            var clone = booleanIsNullExpression.Clone() as BooleanIsNullExpression;

            Assert.AreEqual(booleanIsNullExpression, clone);
            Assert.IsFalse(ReferenceEquals(booleanIsNullExpression, clone));
            Assert.IsFalse(ReferenceEquals(booleanIsNullExpression.ScalarExpression, clone.ScalarExpression));
        }

        [Test]
        public void TestCloneCastExpression()
        {
            CastExpression castExpression = new CastExpression()
            {
                ScalarExpression = new StringLiteral() { Value = "test" },
                ToType = "t"
            };

            var clone = castExpression.Clone() as CastExpression;

            Assert.AreEqual(castExpression, clone);
            Assert.IsFalse(ReferenceEquals(castExpression, clone));
            Assert.IsFalse(ReferenceEquals(castExpression.ScalarExpression, clone.ScalarExpression));
        }

        [Test]
        public void TestCloneInExpression()
        {
            InExpression inExpression = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Not = false,
                Values = new List<ScalarExpression>()
                {
                    new StringLiteral() { Value = "test" }
                }
            };

            var clone = inExpression.Clone() as InExpression;

            Assert.AreEqual(inExpression, clone);
            Assert.IsFalse(ReferenceEquals(inExpression, clone));
            Assert.IsFalse(ReferenceEquals(inExpression.Expression, clone.Expression));
            Assert.IsFalse(ReferenceEquals(inExpression.Values, clone.Values));
            for (int i = 0; i < inExpression.Values.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(inExpression.Values[i], clone.Values[i]));
            }
        }

        [Test]
        public void TestCloneLikeExpression()
        {
            LikeExpression likeExpression = new LikeExpression()
            {
                Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                Right = new StringLiteral() { Value = "test" },
                Not = false
            };

            var clone = likeExpression.Clone() as LikeExpression;

            Assert.AreEqual(likeExpression, clone);
            Assert.IsFalse(ReferenceEquals(likeExpression, clone));
            Assert.IsFalse(ReferenceEquals(likeExpression.Left, clone.Left));
            Assert.IsFalse(ReferenceEquals(likeExpression.Right, clone.Right));
        }

        [Test]
        public void TestCloneNotExpression()
        {
            NotExpression notExpression = new NotExpression()
            {
                BooleanExpression = new BooleanScalarExpression() { ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } } }
            };

            var clone = notExpression.Clone() as NotExpression;

            Assert.AreEqual(notExpression, clone);
            Assert.IsFalse(ReferenceEquals(notExpression, clone));
            Assert.IsFalse(ReferenceEquals(notExpression.BooleanExpression, clone.BooleanExpression));
        }

        [Test]
        public void TestCloneSearchExpression()
        {
            SearchExpression searchExpression = new SearchExpression()
            {
                AllColumns = false,
                Columns = new List<ColumnReference>() { new ColumnReference() { Identifiers = new List<string>() { "c1" } } },
                Value = new StringLiteral() { Value = "test" }
            };

            var clone = searchExpression.Clone() as SearchExpression;

            Assert.AreEqual(searchExpression, clone);
            Assert.IsFalse(ReferenceEquals(searchExpression, clone));
            Assert.IsFalse(ReferenceEquals(searchExpression.Value, clone.Value));

            for (int i = 0; i < searchExpression.Columns.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(searchExpression.Columns[i], clone.Columns[i]));
            }
        }

        [Test]
        public void TestCloneSelectNullExpression()
        {
            SelectNullExpression selectNullExpression = new SelectNullExpression()
            {
                Alias = "test"
            };

            var clone = selectNullExpression.Clone() as SelectNullExpression;

            Assert.AreEqual(selectNullExpression, clone);
            Assert.IsFalse(ReferenceEquals(selectNullExpression, clone));
        }

        [Test]
        public void TestCloneSelectScalarExpression()
        {
            SelectScalarExpression selectScalarExpression = new SelectScalarExpression()
            {
                Alias = "test",
                Expression = new StringLiteral() { Value = "t" }
            };

            var clone = selectScalarExpression.Clone() as SelectScalarExpression;

            Assert.AreEqual(selectScalarExpression, clone);
            Assert.IsFalse(ReferenceEquals(selectScalarExpression, clone));
            Assert.IsFalse(ReferenceEquals(selectScalarExpression.Expression, clone.Expression));
        }

        [Test]
        public void TestCloneSelectStarExpression()
        {
            SelectStarExpression selectStarExpression = new SelectStarExpression()
            {
                Alias = "test"
            };

            var clone = selectStarExpression.Clone() as SelectStarExpression;

            Assert.AreEqual(selectStarExpression, clone);
            Assert.IsFalse(ReferenceEquals(selectStarExpression, clone));
        }

        [Test]
        public void TestCloneVariableReference()
        {
            VariableReference variableReference = new VariableReference()
            {
                Name = "test"
            };

            var clone = variableReference.Clone() as VariableReference;

            Assert.AreEqual(variableReference, clone);
            Assert.IsFalse(ReferenceEquals(variableReference, clone));
        }
    }
}
