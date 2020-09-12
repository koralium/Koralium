using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Koralium.WebTests
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                         .ConfigureKestrel((context, options) =>
                         {
                             if (context.HostingEnvironment.IsDevelopment())
                             {
                                 // we will update the following line later to enable SSL
                                 // Note: TLS with HTTP/2 isn't supported in mac
                                 // Wait for next version of macOS
                                 options.Listen(IPEndPoint.Parse("0.0.0.0:5015"), l => l.Protocols = HttpProtocols.Http1);
                                 options.Listen(IPEndPoint.Parse("0.0.0.0:5016"), l => l.Protocols = HttpProtocols.Http2);
                             }
                             else if (context.HostingEnvironment.IsProduction())
                             {
                                 options.Listen(IPEndPoint.Parse("0.0.0.0:5015"), l => l.Protocols = HttpProtocols.Http2);
                             }
                         })
                        .UseStartup<Startup>();
                });
    }
}
