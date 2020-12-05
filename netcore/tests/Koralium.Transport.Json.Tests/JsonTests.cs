using FluentAssertions;
using Koralium.WebTests;
using Koralium.WebTests.Entities.tpch;
using NUnit.Framework;
using System.Collections.Generic;
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

    }
}