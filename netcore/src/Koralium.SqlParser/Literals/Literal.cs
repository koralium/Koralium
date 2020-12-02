using Koralium.SqlParser.Expressions;
using System.Text;

namespace Koralium.SqlParser.Literals
{
    public abstract class Literal : ScalarExpression
    {
        public abstract object GetValue();
    }
}
