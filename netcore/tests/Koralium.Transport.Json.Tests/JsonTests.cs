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
using FluentAssertions;
using Koralium.WebTests;
using Koralium.WebTests.Entities;
using Koralium.WebTests.Entities.tpch;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Koralium.Transport.Json.Tests
{
    public class JsonTests
    {
        private class Response<T>
        {
            public List<T> Values { get; set; }
        }

        TestWebFactory webFactory;
        HttpClient httpClient;
        TpchData tpchData;
        string url;
        [OneTimeSetUp]
        public void Setup()
        {
            webFactory = new TestWebFactory();
            httpClient = new HttpClient();
            tpchData = new TpchData("../../../../../../TestData");
            url = $"{webFactory.GetUrl()}/sql";
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            webFactory.Stop();
        }

        [Test]
        public async Task TestPost()
        {
            var content = new StringContent("select * from customer");
            var response = await httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var actual = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<Customer>>(responseContent);

            actual.Values.Should().Equal(tpchData.Customers);
        }

        [Test]
        public async Task TestGet()
        {
            var response = await httpClient.GetAsync($"{url}?query=select * from customer");
            var responseContent = await response.Content.ReadAsStringAsync();
            var actual = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<Customer>>(responseContent);

            actual.Values.Should().Equal(tpchData.Customers);
        }

        [Test]
        public async Task TestGetMissingQueryParameter()
        {
            var response = await httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseContent.Should().Be("Missing parameter 'query'");
        }

        [Test]
        public async Task TestGetMultipleQueryParameter()
        {
            var response = await httpClient.GetAsync($"{url}?query=select * from customer&query=select * from customer");
            var responseContent = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseContent.Should().Be("Only one parameter named 'query' can be sent in");
        }

        [Test]
        public async Task TestUnauthorized()
        {
            var response = await httpClient.GetAsync($"{url}?query=select * from secure");
            var responseContent = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            responseContent.Should().Be("Authorization failed");
        }

        [Test]
        public async Task TestTypes()
        {
            var response = await httpClient.GetAsync($"{url}?query=select * from typetest");
            var responseContent = await response.Content.ReadAsStringAsync();

            var actual = JsonConvert.DeserializeObject<Response<TypeTest>>(responseContent).Values;


            var expected = TestData.GetTypeTests().ToList();
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task TestPropertyNaming()
        {
            var response = await httpClient.GetAsync($"{url}?query=select object from typetest limit 1");
            var responseContent = await response.Content.ReadAsStringAsync();

            responseContent.Should().Be(@"{""values"":[{""object"":{""StringValue"":""test"",""intList"":[1,2,3],""object"":{""stringValue"":""test""},""intValue"":321,""decimalValue"":3}}]}");
        }

        [Test]
        public async Task TestPropertyNamingNoPolicy()
        {
            var response = await httpClient.GetAsync($"{url}?query=select object from nonamingpolicy limit 1");
            var responseContent = await response.Content.ReadAsStringAsync();

            responseContent.Should().Be(@"{""values"":[{""object"":{""Name"":""test""}}]}");
        }
    }
}