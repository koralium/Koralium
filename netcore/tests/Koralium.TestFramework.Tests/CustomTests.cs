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
using Koralium.WebTests.Entities.tpch;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;

namespace Koralium.TestFramework.Tests
{
    [TestFixture]
    public class CustomTests : QueryTestBase<Customer>
    {
        TestWebFactory webFactory;
        public override string TableName => "customer";

        public override string GetTestWebUrl()
        {
            return webFactory.GetUrl();
        }

        protected override void OnSetup(IServiceCollection services)
        {
            webFactory = new TestWebFactory();
        }

        protected override void OnTeardown()
        {
            webFactory.Stop();
        }

        [Test]
        public void CustomTest()
        {
            var result = Context.Entities.Where(x => x.Custkey == 1).ToList();

            var singleField = Context.Entities.Select(x => new { x.Custkey }).First();
        }
    }
}
