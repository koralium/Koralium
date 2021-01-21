using Grpc.Core;
using Koralium.WebTests;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Koralium.Transport.RowLevelSecurity.Tests
{
    public class RowLevelSecurityTests
    {
        private const string AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgdGVzdCIsInVuaXF1ZV9uYW1lIjoidGVzdCIsImlhdCI6MTUxNjIzOTAyMn0.aF80OiteMckPhSQcAL549V4AcyKHJA8LUs4mhzBnf2w";

        TestWebFactory webFactory;
        KoraliumRowLevelSecurity.KoraliumRowLevelSecurityClient client;
        [OneTimeSetUp]
        public void Setup()
        {
            webFactory = new TestWebFactory();
            client = new KoraliumRowLevelSecurity.KoraliumRowLevelSecurityClient(webFactory.GetChannel());
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            webFactory.Stop();
        }

        [Test]
        public async Task TestGetFilterNoAlias()
        {
            Metadata headers = new Metadata();
            headers.Add("Authorization", $"Bearer {AccessToken}");
            var filter = await client.GetRowLevelSecurityFilterAsync(new RowLevelSecurityRequest()
            {
                TableName = "secure"
            }, headers);

            Assert.AreEqual("(Custkey > 10) AND (Custkey < 100)", filter.SqlFilter);
        }

        [Test]
        public async Task TestGetFilterWithAlias()
        {
            Metadata headers = new Metadata();
            headers.Add("Authorization", $"Bearer {AccessToken}");
            var filter = await client.GetRowLevelSecurityFilterAsync(new RowLevelSecurityRequest()
            {
                TableName = "secure",
                TableAlias = "s"
            }, headers);

            Assert.AreEqual("(s.Custkey > 10) AND (s.Custkey < 100)", filter.SqlFilter);
        }
    }
}