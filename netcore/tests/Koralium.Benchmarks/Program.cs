using BenchmarkDotNet.Running;
using System;

namespace Koralium.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //var webFactory = new TestWebFactory();
            var summary = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            //webFactory.Stop();
        }
    }
}
