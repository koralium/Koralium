using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser
{
    public abstract class SqlNode
    {
        public abstract void Accept(KoraliumSqlVisitor visitor);

        public abstract SqlNode Clone();
    }
}
