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
using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Executors.AggregateFunction;
using Koralium.SqlToExpression.Executors.Offset;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Providers;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.IO;

namespace Koralium.SqlToExpression.Benchmark
{

    public class SqlToExpressionParsing
    {
        private SqlExecutor sqlExecutor;
        private TSql150Parser sql150Parser;

        public SqlToExpressionParsing()
        {
            TablesMetadata tablesMetadata = new TablesMetadata();
            tablesMetadata.AddTable(new TableMetadata("project", typeof(Project)));

            var queryExecutor = new QueryExecutor(
                new TableResolver(),
                new DefaultFromTableExecutorFactory(),
                new DefaultWhereExecutorFactory(),
                new DefaultGroupByExecutorFactory(),
                new DefaultSelectExecutorFactory(),
                new DefaultOrderByExecutorFactory(),
                new DefaultOffsetExecutorFactory(),
                new DefaultDistinctExecutorFactory(),
                new DefaultAggregateFunctionFactory());

            sqlExecutor = new SqlExecutor(
                tablesMetadata, 
                queryExecutor, 
                new DefaultSearchExpressionProvider(),
                new DefaultStringOperationsProvider());

            sql150Parser = new TSql150Parser(true);
        }

        [Benchmark]
        public void MicrosoftSQLParser()
        {
            string expr = @"select sum(p.id), p.name from project p where p.name = 'alex' and (p.id = 1 OR p.id = 2) group by name";
            sql150Parser.Parse(new StringReader(expr), out var errors).Accept(new Visitor());
        }

        [Benchmark]
        public void SimpleSelect() => sqlExecutor.Execute("select name from project");

        [Benchmark]
        public void AdvancedSelect() => sqlExecutor.Execute("select sum(p.id), p.name from project p where p.name = 'alex' and (p.id = 1 OR p.id = 2) group by name");
    }


    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
