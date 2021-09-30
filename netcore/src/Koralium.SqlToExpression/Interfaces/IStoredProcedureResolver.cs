using Koralium.SqlParser.Statements;
using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Interfaces
{
    public interface IStoredProcedureResolver
    {
        ValueTask<IQueryable> ResolveStoredProcedure(string name, List<StoredProcedureParameter> parameters);
    }
}
