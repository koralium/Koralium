using Koralium.WebTests.Entities.tpch;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
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
