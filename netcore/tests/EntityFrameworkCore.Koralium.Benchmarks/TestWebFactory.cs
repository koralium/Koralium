using Grpc.Net.Client;
using Koralium.WebTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore.Koralium.Benchmarks
{
    public class TestWebFactory : IDisposable
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
                            webBuilder
                            .ConfigureKestrel(c =>
                            {
                                // we will update the following line later to enable SSL
                                // Note: TLS with HTTP/2 isn't supported in mac
                                // Wait for next version of macOS
                                c.Listen(IPEndPoint.Parse("0.0.0.0:5016"), l => l.Protocols = HttpProtocols.Http2);
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

        public GrpcChannel GetChannel()
        {
            return GrpcChannel.ForAddress("http://127.0.0.1:5016");
        }

        public void Stop()
        {
            host.StopAsync().Wait();
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
