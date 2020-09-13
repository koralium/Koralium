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
