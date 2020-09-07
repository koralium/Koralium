using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Tests.Models;
using NUnit.Framework;

namespace Koralium.SqlToExpression.Tests
{
    public class ErrorTests
    {
        [Test]
        public void TestWrongTableName()
        {
            //TablesMetadata tablesMetadata = new TablesMetadata();

            //var tree = Parser.Parse("select id from project");

            //Assert.That(() =>
            //{
            //    tree.Accept(new MainVisitor(tablesMetadata));
            //}, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("The table 'project' was not found"));
        }

        [Test]
        public void TestMissingFrom()
        {
            //TablesMetadata tablesMetadata = new TablesMetadata();

            //var tree = Parser.Parse("select id");

            //Assert.That(() =>
            //{
            //    tree.Accept(new MainVisitor(tablesMetadata));
            //}, Throws.TypeOf<SqlErrorException>().And.Message.EqualTo("Missing 'FROM {tableName}' in the query"));
        }

        [Test]
        public void TestMissingColumnInWhere()
        {
            ////Column '{identifiers[0]}' was not found, maybe it is not in the group by?

            //TablesMetadata tablesMetadata = new TablesMetadata();
            //tablesMetadata.AddTable(new TableMetadata("project", typeof(Project)));


            //var tree = Parser.Parse("select id from project where notfound = 'test'");

            //Assert.That(() =>
            //{
            //    tree.Accept(new MainVisitor(tablesMetadata));
            //}, Throws.TypeOf<SqlErrorException>());
        }
    }
}
