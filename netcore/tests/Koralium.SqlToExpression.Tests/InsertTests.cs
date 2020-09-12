using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Tests
{
    /// <summary>
    /// This class contains the different test cases for insertion of data
    /// </summary>
    public class InsertTests : TpchTestsBase
    {

        [Test]
        public void TestBasicInsert()
        {
            SqlExecutor.Execute($"INSERT INTO customer (name) VALUES ('test'), ('test2')");
        }
    }
}
