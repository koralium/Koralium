
namespace Koralium.SqlParser.From
{
    public abstract class TableReference : SqlNode
    {
        public string Alias { get; set; }
    }
}
