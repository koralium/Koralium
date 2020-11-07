using Koralium.WebTests;
using Koralium.WebTests.Entities.tpch;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
