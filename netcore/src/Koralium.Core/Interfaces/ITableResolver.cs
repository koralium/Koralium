using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Core.Interfaces
{
    public interface ITableResolver
    {
        Task<IQueryable> GetQueryable(HttpContext httpContext);
    }
}
