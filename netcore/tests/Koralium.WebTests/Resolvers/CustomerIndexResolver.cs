using Koralium.WebTests.Entities.tpch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    /// <summary>
    /// Resolver to test performance on using "indexing" and get customers based on equal filters
    /// </summary>
    public class CustomerIndexResolver : TableResolver<Customer>
    {
        private readonly TpchData _tpchData;
        public CustomerIndexResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        protected override Task<IQueryable<Customer>> GetQueryableData(IQueryOptions<Customer> queryOptions, ICustomMetadata customMetadata)
        {
            if(queryOptions.TryGetEqualFiltersForProperty(x => x.Custkey, out var filters))
            {
                List<Customer> output = new List<Customer>();
                foreach(var val in filters)
                {
                    if(_tpchData.CustomerKeyIndex.TryGetValue(val, out var customer))
                    {
                        output.Add(customer);
                    }
                }
                return Task.FromResult(output.AsQueryable());
            }
            return Task.FromResult(_tpchData.Customers.AsQueryable());
        }
    }
}
