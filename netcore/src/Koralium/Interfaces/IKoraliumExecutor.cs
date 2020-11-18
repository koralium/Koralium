using Koralium.SqlToExpression;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Koralium
{
    public interface IKoraliumExecutor
    {
        ValueTask<Transport.QueryResult> Execute(
            string sql,
            SqlParameters sqlParameters,
            HttpContext httpContext);

        ValueTask<object> ExecuteScalar(
            string sql,
            SqlParameters sqlParameters,
            HttpContext httpContext);

    }
}
