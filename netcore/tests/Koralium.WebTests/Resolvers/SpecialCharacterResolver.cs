using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class SpecialCharacterResolver : TableResolver<SpecialCharactersTest>
    {
        protected override Task<IQueryable<SpecialCharactersTest>> GetQueryableData(IQueryOptions<SpecialCharactersTest> queryOptions, ICustomMetadata customMetadata)
        {
            return Task.FromResult(TestData.GetSpecialCharactersTests());
        }
    }
}
