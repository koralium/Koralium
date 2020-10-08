using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class EmptyResolver : TableResolver<Empty>
    {
        protected override async Task<IQueryable<Empty>> GetQueryableData()
        {
            return new List<Empty>().AsQueryable();
        }
    }
}
