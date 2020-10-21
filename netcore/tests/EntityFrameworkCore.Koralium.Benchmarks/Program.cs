using BenchmarkDotNet.Running;
using Grpc.Net.Client;
using System;

namespace EntityFrameworkCore.Koralium.Benchmarks
{
    class Program
    {
        public static string ServerUrl;
        static void Main(string[] args)
        {
            var webFactory = new TestWebFactory();
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            webFactory.Stop();
        }
    }
}
