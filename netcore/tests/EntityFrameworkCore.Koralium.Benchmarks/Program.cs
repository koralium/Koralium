using BenchmarkDotNet.Running;

namespace EntityFrameworkCore.Koralium.Benchmarks
{
    static class Program
    {
        static void Main(string[] args)
        {
            var webFactory = new TestWebFactory();
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            webFactory.Stop();
        }
    }
}
