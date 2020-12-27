using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class TypeTestResolver : TableResolver<TypeTest>
    {
        protected override Task<IQueryable<TypeTest>> GetQueryableData()
        {
            return Task.FromResult(TestData.GetTypeTests());
        }
    }
}
