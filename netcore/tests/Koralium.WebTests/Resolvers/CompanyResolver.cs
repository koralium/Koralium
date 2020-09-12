using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class CompanyResolver : TableResolver<Company>
    {
        public override Task<IQueryable<Company>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(TestData.GetCompanies());
        }
    }
}
