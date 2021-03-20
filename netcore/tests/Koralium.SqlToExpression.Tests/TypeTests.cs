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
using Koralium.SqlToExpression.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests
{
    class TypeTests : TypeTestBase
    {
        [Test]
        public async Task TestSelectSubfield()
        {
            var actual = await SqlExecutor.Execute("SELECT object.stringValue from typetest");
            var expected = WebTests.TestData.GetTypeTests().Select(x => new { P0 = (x.Object != null) ? x.Object.StringValue : null });

            AssertAreEqual(expected, actual.Result);

            var actualInt = await SqlExecutor.Execute("SELECT object.intValue from typetest");
            var expectedInt = WebTests.TestData.GetTypeTests().Select(x => new { P0 = (x.Object != null) ? x.Object.IntValue : default(Nullable<int>) });

            AssertAreEqual(expectedInt, actualInt.Result);
        }
    }
}
