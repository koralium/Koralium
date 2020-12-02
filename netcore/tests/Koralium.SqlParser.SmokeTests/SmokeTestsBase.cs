using System.Text;

namespace Koralium.SqlParser.SmokeTests
{
    public abstract partial class SmokeTestsBase
    {
        protected abstract ISqlParser Parser { get; }
    }
}
