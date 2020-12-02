using Koralium.SqlParser.Expressions;

namespace Koralium.SqlParser.Literals
{
    public abstract class Literal : ScalarExpression
    {
        public abstract object GetValue();
    }
}
