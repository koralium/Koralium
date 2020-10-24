using BenchmarkDotNet.Running;

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
