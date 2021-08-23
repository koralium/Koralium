using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class NoNamingPolicyResolver : TableResolver<NoNamingPolicyTest>
    {
        protected override Task<IQueryable<NoNamingPolicyTest>> GetQueryableData(IQueryOptions<NoNamingPolicyTest> queryOptions, ICustomMetadata customMetadata)
        {
            var data = new List<NoNamingPolicyTest>()
            {
                new NoNamingPolicyTest()
                {
                    Object = new NoPolicyInner()
                    {
                        Name = "test"
                    }
                }
            };
            return Task.FromResult(data.AsQueryable());
        }
    }
}
