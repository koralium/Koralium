using Koralium.WebTests.Entities;
using Koralium.WebTests.Entities.tpch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class IndexTestResolver : TableResolver<IndexTest>
    {

        protected override Task<IQueryable<IndexTest>> GetQueryableData(IQueryOptions<IndexTest> queryOptions, ICustomMetadata customMetadata)
        {
            IQueryable<IndexTest> queryable;
            IReadOnlyDictionary<long, IndexTest> dict;
            
            if (queryOptions.Parameters.TryGetParameter("indexSize", out var indexSizeParameter) &&
                indexSizeParameter.TryGetValue<long>(out var indexSize))
            {
                (queryable, dict) = TestData.GetIndexTestData(indexSize);
            }
            else
            {
                (queryable, dict) = TestData.GetIndexTestData(1000000);
            }

            if(queryOptions.Parameters.TryGetParameter("useIndex", out var useIndexParameter))
            {
                if(useIndexParameter.TryGetValue<bool>(out var useIndex))
                {
                    if (queryOptions.TryGetEqualFiltersForProperty(x => x.Key, out var filters))
                    {
                        List<IndexTest> output = new List<IndexTest>();
                        foreach (var val in filters)
                        {
                            if (dict.TryGetValue(val, out var obj))
                            {
                                output.Add(obj);
                            }
                        }
                        return Task.FromResult(output.AsQueryable());
                    }
                }
            }
            
            return Task.FromResult(queryable);
        }
    }
}
