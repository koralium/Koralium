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
using System.Threading.Tasks;
using Koralium.Json.Extensions;
using Koralium.WebTests.Entities;
using Koralium.WebTests.Entities.tpch;
using Koralium.WebTests.Resolvers;
using Koralium.WebTests.Resolvers.tpch;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services
                .AddControllers()
                .AddKoraliumJson();

            services.AddGrpc();

            services.AddKoralium(opt =>
            {
                //Add a new table resolver
                opt.AddTableResolver<ProjectResolver, Project>(tableOpt =>
                {
                    tableOpt.AddIndexResolver<ProjectIndex, string>(x => x.Name);
                });
                opt.AddTableResolver<TestResolver, Test>();
                opt.AddTableResolver<SecureResolver, Order>(opt =>
                {
                    opt.TableName = "secure";
                });
                opt.AddTableResolver<EmployeeResolver, Employee>(opt =>
                {
                    opt.AddIndexResolver<EmployeeCompanyIdIndexResolver, string>(x => x.CompanyId);
                });
                opt.AddTableResolver<CompanyResolver, Company>(t =>
                {
                    t.AddIndexResolver<CompanyIdIndexResolver, string>(x => x.CompanyId);
                    t.AddIndexResolver<CompanyIdNameIndexResolver, string, string>(x => x.CompanyId, x => x.Name, "CompanyIdName");
                });

                //TPC-H
                opt.AddTableResolver<CustomerResolver, Customer>();
                opt.AddTableResolver<LineItemResolver, LineItem>();
                opt.AddTableResolver<NationResolver, Nation>();
                opt.AddTableResolver<OrderResolver, Order>(t =>
                {
                    t.TableName = "orders";
                });
                opt.AddTableResolver<PartResolver, Part>();
                opt.AddTableResolver<PartsuppResolver, Partsupp>();
                opt.AddTableResolver<RegionResolver, Region>();
                opt.AddTableResolver<SupplierResolver, Supplier>();
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.AddKoraliumGrpcEndpoint();
                endpoints.MapControllers();
            });
        }
    }
}
