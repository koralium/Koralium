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
