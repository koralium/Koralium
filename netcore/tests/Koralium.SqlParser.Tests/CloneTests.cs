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
    }
}
