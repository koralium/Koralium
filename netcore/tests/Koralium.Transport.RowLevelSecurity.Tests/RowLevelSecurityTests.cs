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
                TableName = "secure",
                Format = Format.Sql
            }, headers);

            Assert.AreEqual("(Custkey > 10) AND (Custkey < 100)", filter.Filter);
        }

        [Test]
        public async Task TestGetFilterWithAlias()
        {
            Metadata headers = new Metadata();
            headers.Add("Authorization", $"Bearer {AccessToken}");
            var filter = await client.GetRowLevelSecurityFilterAsync(new RowLevelSecurityRequest()
            {
                TableName = "secure",
                Format = Format.Sql,
                SqlOptions = new SqlOptions()
                {
                    TableAlias = "s"
                }
            }, headers);

            Assert.AreEqual("(s.Custkey > 10) AND (s.Custkey < 100)", filter.Filter);
        }

        [Test]
        public async Task TestGetElasticSearchFilter()
        {
            Metadata headers = new Metadata();
            headers.Add("Authorization", $"Bearer {AccessToken}");
            var filter = await client.GetRowLevelSecurityFilterAsync(new RowLevelSecurityRequest()
            {
                TableName = "secure",
                Format = Format.Elasticsearch
            }, headers);

            Assert.AreEqual("{\"bool\":{\"must\":[{\"range\":{\"Custkey\":{\"gt\":10,\"lt\":100}}}]}}", filter.Filter);
        }

        [Test]
        public async Task TestGetCubeJsFilter()
        {
            Metadata headers = new Metadata();
            headers.Add("Authorization", $"Bearer {AccessToken}");
            var filter = await client.GetRowLevelSecurityFilterAsync(new RowLevelSecurityRequest()
            {
                TableName = "secure",
                Format = Format.Cubejs,
                CubejsOptions = new CubeJsOptions()
                {
                    CubeName = "orders",
                    LowerCaseFirstMemberCharacter = true
                }
            }, headers);

            Assert.AreEqual("{\"and\":[{\"member\":\"orders.custkey\",\"operator\":\"gt\",\"values\":[\"10\"]},{\"member\":\"orders.custkey\",\"operator\":\"lt\",\"values\":[\"100\"]}]}", filter.Filter);
        }
    }
}