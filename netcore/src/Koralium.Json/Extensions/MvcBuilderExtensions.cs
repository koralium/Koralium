using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Json.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddKoraliumJson(this IMvcBuilder mvcBuilder, string prefix = "sql/")
        {
            var prefixConvention = new ApiPrefixConvention(prefix, (c) => c.ControllerType.Namespace == "Koralium.Json");

            mvcBuilder.Services.Configure<MvcOptions>(opts => opts.Conventions.Insert(0, prefixConvention));
            mvcBuilder.AddApplicationPart(typeof(KoraliumController).Assembly);

            mvcBuilder.Services.AddScoped<JsonExecutor>();

            return mvcBuilder;
        }
    }
}
