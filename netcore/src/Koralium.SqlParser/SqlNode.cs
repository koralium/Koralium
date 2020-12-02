using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser
{
    public abstract class SqlNode
    {
        public abstract void Accept(KoraliumSqlVisitor visitor);
    }
}
