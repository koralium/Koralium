using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Benchmarks
{
    [BenchmarkCategory("Index")]
    [CategoriesColumn]
    public class IndexBenchmarks
    {
        private TestWebFactory webFactory;
        HttpClient httpClient;
        string jsonUrl;

        public IndexBenchmarks()
        {
            httpClient = new HttpClient();
            jsonUrl = "http://127.0.0.1:5015/sql";
        }

        [GlobalSetup]
        public void Setup()
        {
            webFactory = new TestWebFactory();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            webFactory.Stop();
        }

        [Params(10000, 100000, 1000000, 10000000)]
        public int Size;

        public string NoIndexSql => $"SET @indexSize = {Size}; select * from indextest where key in (1, 2, 3, 4, 5, 6, 7, 8, 9 ,10)";

        public string IndexSql => "SET @useIndex = true;" + NoIndexSql;

        [Benchmark]
        public async Task NoIndex()
        {
            var jsonSelect = new StringContent(NoIndexSql);
            var result = await httpClient.PostAsync(jsonUrl, jsonSelect);
            var text = await result.Content.ReadAsStringAsync();
        }

        [Benchmark]
        public async Task WithIndex()
        {
            var jsonSelect = new StringContent(IndexSql);
            var result = await httpClient.PostAsync(jsonUrl, jsonSelect);
            var text = await result.Content.ReadAsStringAsync();
        }
    }
}
