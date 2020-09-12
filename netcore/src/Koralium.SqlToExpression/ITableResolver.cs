using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression
{
    public interface ITableResolver
    {
        ValueTask<IQueryable> ResolveTableName(string name, object additionalData);
    }
}
