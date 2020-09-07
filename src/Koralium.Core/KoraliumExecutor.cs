using Koralium.Core.Models;
using Koralium.SqlToExpression;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Core
{
    public class KoraliumExecutor
    {
        private readonly SqlExecutor _sqlExecutor;
        private readonly IServiceProvider _serviceProvider;
        public KoraliumExecutor(SqlExecutor sqlExecutor, IServiceProvider serviceProvider)
        {
            _sqlExecutor = sqlExecutor;
            _serviceProvider = serviceProvider;
        }

        public ValueTask<QueryResult> Execute(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            return _sqlExecutor.Execute(sql, sqlParameters, new TableResolverData(httpContext, _serviceProvider));
        }
    }
}
