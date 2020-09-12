using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    [Authorize("secure")]
    public class SecureResolver : TableResolver<Secure>
    {
        public override Task<IQueryable<Secure>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(TestData.GetSecureData());
        }
    }
}
