/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.Shared;
using Koralium.SqlToExpression.Tests.Helpers;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests
{
    class FunctionTests : TypeTestBase
    {
        [Test]
        public void TestCallNonExistingFunction()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("SELECT not_existing() FROM typetest");
            }, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("No function exists named 'not_existing'."));
        }

        #region any_match
        [Test]
        public async Task TestSelectAnyMatch()
        {
            var actual = (await SqlExecutor.Execute("SELECT any_match(IntList, x -> x = 1) FROM typetest"));
            var expected = WebTests.TestData.GetTypeTests().Select(x => new { P0 = (x.IntList != null) && x.IntList.Any(y => y == 1) });

            AssertAreEqual(expected, actual.Result);
        }

        [Test]
        public async Task TestSelectAnyMatchSubfield()
        {
            var actual = (await SqlExecutor.Execute("SELECT any_match(objectlist, x -> x.stringvalue = 'test') FROM typetest"));
            var expected = WebTests.TestData.GetTypeTests().Select(x => new { P0 = (x.ObjectList != null) && x.ObjectList.Any(y => y.StringValue == "test") });

            AssertAreEqual(expected, actual.Result);
        }

        [Test]
        public void TestCallAnyMatchSingleParameter()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("SELECT any_match(arr) FROM typetest");
            }, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("any_match must contain two parameters"));
        }

        [Test]
        public void TestCallAnyMatchWithoutColumnReference()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("SELECT any_match(1, x -> x = 1) FROM typetest");
            }, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("any_match first parameter must be a column reference"));
        }

        [Test]
        public void TestCallAnyMatchWithoutLambda()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("SELECT any_match(IntList, 'test') FROM typetest");
            }, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("any_match second parameter must be a lambda expression"));
        }

        [Test]
        public void TestCallAnyMatchWithMultiParameterLambda()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("SELECT any_match(IntList, (x, y) -> x = 1) FROM typetest");
            }, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("any_match lambda expression can only have one input parameter"));
        }

        [Test]
        public void TestCallAnyMatchWithNonArrayProperty()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("SELECT any_match(IntValue, x -> x = 1) FROM typetest");
            }, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("any_match first parameter must be an array/list."));
        }

        [Test]
        public void TestCallAnyMatchLambdaReturnsNonBoolean()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("SELECT any_match(IntList, x -> x) FROM typetest");
            }, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("Lambda expression in any_match must return a boolean."));
        }

        #endregion
    }
}
