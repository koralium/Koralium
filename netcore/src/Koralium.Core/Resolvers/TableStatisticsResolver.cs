using Koralium.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.Core.Resolvers
{
    internal class TableStatisticsResolver : TableResolver<TableStatistic>
    {
        protected override Task<IQueryable<TableStatistic>> GetQueryableData(IQueryOptions<TableStatistic> queryOptions, ICustomMetadata customMetadata)
        {
            throw new NotImplementedException();
        }
    }
}
