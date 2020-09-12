using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Models
{
    /// <summary>
    /// This class contains extra data that the table resolver requires
    /// </summary>
    class TableResolverData
    {
        public HttpContext HttpContext { get; }

        public IServiceProvider ServiceProvider { get; }

        public TableResolverData(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            HttpContext = httpContext;
            ServiceProvider = serviceProvider;
        }
    }
}
