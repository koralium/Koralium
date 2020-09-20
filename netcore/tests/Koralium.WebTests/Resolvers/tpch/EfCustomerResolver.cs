using Koralium.SqlToExpression;
using Koralium.WebTests.Database;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.tpch
{
    /// <summary>
    /// Resolver for customer that uses entity framework
    /// </summary>
    public class EfCustomerResolver : TableResolver<Customer>
    {
        private readonly TestContext _testContext;
        public EfCustomerResolver(TestContext testContext)
        {
            _testContext = testContext;
        }

        protected override Task<IQueryable<Customer>> GetQueryableData()
        {
            return Task.FromResult<IQueryable<Customer>>(_testContext.Customers);
        }
    }
}
