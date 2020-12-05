/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

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
