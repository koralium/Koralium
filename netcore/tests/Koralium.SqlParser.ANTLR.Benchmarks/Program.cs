using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Koralium.SqlParser.ANTLR.Benchmarks
{
    public class SqlParsing
    {
        private readonly ISqlParser _sqlParser;
        public SqlParsing()
        {
            _sqlParser = new AntlrSqlParser();
        }

        [Benchmark]
        public void SimpleSelect() => _sqlParser.Parse("select name from project");

        [Benchmark]
        public void SelectWithWhereEquals() => _sqlParser.Parse("select name from project where name = 'test'");

        [Benchmark]
        public void SelectWithWhereEqualsAndEquals() => _sqlParser.Parse("select name from project where name = 'test' and c2 = 1234");
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
