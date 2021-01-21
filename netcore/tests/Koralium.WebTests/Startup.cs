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
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using EFCore.BulkExtensions;
using Koralium.Transport.ArrowFlight;
using Koralium.Transport.ArrowFlight.Extensions;
using Koralium.Transport.Json.Extensions;
using Koralium.Transport.LegacyGrpc.Extensions;
using Koralium.WebTests.Database;
using Koralium.WebTests.Entities;
using Koralium.WebTests.Entities.specific;
using Koralium.WebTests.Entities.tpch;
using Koralium.WebTests.PartitionResolvers;
using Koralium.WebTests.Resolvers;
using Koralium.WebTests.Resolvers.specific;
using Koralium.WebTests.Resolvers.tpch;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using QueryProtocolGrpc.TestWeb.Resolvers;

namespace Koralium.WebTests
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddGrpc()
                .AddKoraliumFlightServer();

            var connection = new SqliteConnection("Data Source=Sharable;Mode=Memory;Cache=Shared");
            connection.Open();
            services.AddDbContext<TestContext>(opt =>
            {
                opt.UseSqlite(connection);
            });
            services.AddSingleton(connection);

            services.AddKoraliumLegacyGrpcTransport();

            services.AddKoralium(opt =>
            {
                opt.AddSearchProvider<CustomSearchProvider>();

                //Add a new table resolver
                opt.AddTableResolver<ProjectResolver, Project>(tableOpt =>
                {
                });
                opt.AddTableResolver<TestResolver, Test>();
                opt.AddTableResolver<SecureResolver, Order>(opt =>
                {
                    opt.TableName = "secure";
                });
                opt.AddTableResolver<EmployeeResolver, Employee>(opt =>
                {
                });
                opt.AddTableResolver<CompanyResolver, Company>(t =>
                {
                });

                //TPC-H
                opt.AddTableResolver<CustomerResolver, Customer>();
                opt.AddTableResolver<LineItemResolver, LineItem>();
                opt.AddTableResolver<NationResolver, Nation>();
                opt.AddTableResolver<OrderResolver, Order>(t =>
                {
                    t.TableName = "orders";
                    t.UseInMemoryCaseInsensitiveStringOperations();
                });
                opt.AddTableResolver<PartResolver, Part>();
                opt.AddTableResolver<PartsuppResolver, Partsupp>();
                opt.AddTableResolver<RegionResolver, Region>();
                opt.AddTableResolver<SupplierResolver, Supplier>();

                //Entity framework
                opt.AddTableResolver<EfCustomerResolver, Customer>(t =>
                {
                    t.TableName = "efcustomer";
                });

                opt.AddTableResolver<TypeTestResolver, TypeTest>();

                //Specific
                opt.AddTableResolver<AutoMapperCustomerResolver, AutoMapperCustomer>();
                opt.AddTableResolver<EmptyResolver, Empty>();
            });
            
            var tpchDataPath = Path.Join(Configuration.GetValue<string>(WebHostDefaults.ContentRootKey), Configuration.GetValue<string>("TestDataLocation"));
            services.AddSingleton(new TpchData(tpchDataPath));
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = false,
                    ValidateAudience = false,
                    SignatureValidator = (string token, TokenValidationParameters validationParameters) =>
                    {
                        var jwt = new JwtSecurityToken(token);
                        return jwt;
                    },
                    ValidateLifetime = false,
                    RequireExpirationTime = false
                };
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("secure", o => o.RequireAuthenticatedUser());
            });
        }

        private void AddSqliteData(IServiceProvider provider)
        {
            using var initScope = provider.CreateScope();
            var context = initScope.ServiceProvider.GetService<TestContext>();
            var tpchData = initScope.ServiceProvider.GetService<TpchData>();

            using (var transaction = context.Database.BeginTransaction())
            {
                context.BulkInsert(tpchData.Customers);
                transaction.Commit();
            }
            using (var transaction = context.Database.BeginTransaction())
            {
                context.BulkInsert(tpchData.Orders);
                transaction.Commit();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AddSqliteData(app.ApplicationServices);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapKoraliumJsonPost("sql");
                endpoints.MapKoraliumJsonGet("sql");
                endpoints.MapKoraliumArrowFlight();
                endpoints.MapKoraliumRowLevelSecurityEndpoint();

                endpoints.AddKoraliumLegacyGrpcEndpoint();

                endpoints.MapControllers();
            });
        }
    }
}
