using System.Text;

namespace Koralium.SqlParser.OrderBy
{
    public abstract class OrderElement : SqlNode
    {
        public bool Ascending { get; set; }
    }
}
