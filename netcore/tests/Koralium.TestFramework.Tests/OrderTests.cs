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
using Koralium.WebTests;
using Koralium.WebTests.Entities.tpch;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Koralium.TestFramework.Tests
{
    public class OrderTests : QueryTest<Order>
    {
        private TestWebFactory testWebFactory;
        private TpchData tpchData;
        public override string TableName => "orders";

        public override string GetTestWebUrl()
        {
            return testWebFactory.GetUrl();
        }

        protected override void OnSetup(IServiceCollection services)
        {
            testWebFactory = new TestWebFactory();
            tpchData = new TpchData("../../../../../../TestData");
            base.OnSetup(services);
        }

        protected override void OnTeardown()
        {
            testWebFactory.Stop();
        }

        public override IEnumerable<Order> TestData()
        {
            return tpchData.Orders;
        }
    }
}
