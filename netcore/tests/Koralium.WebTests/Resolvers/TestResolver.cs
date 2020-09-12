using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class TestResolver : TableResolver<Test>
    {
        public override Task<IQueryable<Test>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(TestData.GetData());
        }
    }
}
