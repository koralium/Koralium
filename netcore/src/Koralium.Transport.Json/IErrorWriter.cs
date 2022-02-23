using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Transport.Json
{
    public interface IErrorWriter
    {
        Task WriteAsync(HttpContext context, int statusCode, string message);
    }
}
