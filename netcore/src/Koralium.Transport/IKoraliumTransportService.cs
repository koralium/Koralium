using Koralium.Shared;
using Microsoft.AspNetCore.Http;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Koralium.Transport
{
    /// <summary>
    /// Service that transport protocols can use to talk with Koralium core
    /// </summary>
    public interface IKoraliumTransportService
    {
        ValueTask<QueryResult> Execute(
            string sql,
            SqlParameters sqlParameters,
            HttpContext httpContext);

        ValueTask<object> ExecuteScalar(
            string sql,
            SqlParameters sqlParameters,
            HttpContext httpContext);

        IImmutableList<Column> GetSchema(
            string sql,
            SqlParameters sqlParameters,
            HttpContext httpContext);

        IImmutableList<Table> GetTables();
    }
}
