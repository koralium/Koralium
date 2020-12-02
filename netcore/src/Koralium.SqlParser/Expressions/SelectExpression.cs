
namespace Koralium.SqlParser.Expressions
{
    public abstract class SelectExpression : SqlExpression
    {
        public string Alias { get; set; }
    }
}
