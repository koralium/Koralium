using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Executors.Offset;
using Koralium.SqlToExpression.Metadata;
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
                new DefaultDistinctExecutorFactory());

            sqlExecutor = new SqlExecutor(tablesMetadata, queryExecutor);

            sql150Parser = new TSql150Parser(true);
        }

        //[Benchmark]
        //public void ANTLRParserOnlySimpleSelect()
        //{
        //    Parser.Parse("select name from project");
        //}

        //[Benchmark]
        //public void ANTLRParserOnlyAdvancedSelect()
        //{
        //    Parser.Parse("select sum(p.id), p.name from project p where p.name = 'alex' and (p.id = 1 OR p.id = 2) group by name");
        //}

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
