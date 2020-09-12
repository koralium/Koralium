using Koralium.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Core.Resolvers
{
    public abstract class TableResolver<T> : ITableResolver
    {
        public async Task<IQueryable> GetQueryable(HttpContext httpContext)
        {
            return await GetQueryableData(httpContext);
        }

        public abstract Task<IQueryable<T>> GetQueryableData(HttpContext context);
    }
}
