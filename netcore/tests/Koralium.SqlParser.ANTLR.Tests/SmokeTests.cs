using Koralium.SqlParser.SmokeTests;
using NUnit.Framework;

namespace Koralium.SqlParser.ANTLR.Tests
{
    [TestFixture]
    public class SmokeTests : SmokeTestsBase
    {
        protected override ISqlParser Parser => new Koralium.SqlParser.ANTLR.AntlrSqlParser();
    }
}