using Koralium.WebTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Koralium.Transport.Json.Tests
{
    class TestWebFactory
    {
        readonly IHost host;

        public TestWebFactory()
        {
            host = WebHostBuilder().Build(); //Create the server
            host.Start();
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        }

        private IHostBuilder WebHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                        .ConfigureWebHostDefaults(webBuilder =>
                        {
                            _ = webBuilder
                            .ConfigureKestrel(c =>
                            {
                                c.Listen(IPEndPoint.Parse("0.0.0.0:5016"), l => l.Protocols = HttpProtocols.Http1);
                            })
                            .ConfigureAppConfiguration(opt =>
                            {
                                opt.AddJsonFile("testappsettings.json");
                            })
                            .UseStartup<Startup>();
                        });
        }

        public string GetUrl()
        {
            return "http://127.0.0.1:5016";
        }
    }
}
