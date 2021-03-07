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
using Grpc.Core;
using NUnit.Framework;
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

        [Test]
        public void TestUnauthorized()
        {
            Metadata headers = new Metadata();

            var ex = Assert.ThrowsAsync<RpcException>(async () =>
            {
                await client.GetRowLevelSecurityFilterAsync(new RowLevelSecurityRequest()
                {
                    TableName = "secure",
                    Format = Format.Cubejs,
                    CubejsOptions = new CubeJsOptions()
                    {
                        CubeName = "orders",
                        LowerCaseFirstMemberCharacter = true
                    }
                }, headers);
            });

            Assert.That(ex.StatusCode, Is.EqualTo(StatusCode.Unauthenticated));
            Assert.That(ex.Status.Detail, Is.EqualTo("Authorization failed"));
        }
    }
}