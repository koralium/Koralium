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
using Grpc.Net.Client;
using Koralium.WebTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

namespace Data.Koralium.Tests
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
            return "http://localhost:5016";
        }

        public GrpcChannel GetChannel()
        {
            return GrpcChannel.ForAddress("http://localhost:5016");
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
