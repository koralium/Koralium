using Koralium.WebTests;
using Koralium.WebTests.Entities.tpch;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.TestFramework.Tests
{
    [TestFixture]
    public class Tests : QueryTest<Customer>
    {
        private TestWebFactory testWebFactory;
        private TpchData tpchData;
        public override string TableName => "customer";

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

        public override IEnumerable<Customer> TestData()
        {
            return tpchData.Customers;
        }
    }
}