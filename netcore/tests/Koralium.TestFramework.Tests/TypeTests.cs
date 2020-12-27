using Koralium.WebTests;
using Koralium.WebTests.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.TestFramework.Tests
{
    public class TypeTests : QueryTest<TypeTest>
    {
        private TestWebFactory testWebFactory;

        public override string TableName => "TypeTest";

        public override string GetTestWebUrl()
        {
            return testWebFactory.GetUrl();
        }

        protected override void OnSetup(IServiceCollection services)
        {
            testWebFactory = new TestWebFactory();
            base.OnSetup(services);
        }

        protected override void OnTeardown()
        {
            testWebFactory.Stop();
        }

        public override IEnumerable<TypeTest> TestData()
        {
            return Koralium.WebTests.TestData.GetTypeTests();
        }
    }
}
