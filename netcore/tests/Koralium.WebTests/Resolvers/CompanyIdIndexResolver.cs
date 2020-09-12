using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class CompanyIdIndexResolver : IndexResolver<Company, string>
    {
        protected override Task<IEnumerable<Company>> GetQueryableData(IReadOnlyList<string> keys, Expression<Func<Company, Company>> selectExpression)
        {
            List<Company> output = new List<Company>();
            foreach(var key in keys)
            {
                output.Add(TestData.GetCompanies().FirstOrDefault(x => x.CompanyId == key));
            }

            return Task.FromResult<IEnumerable<Company>>(output);
        }
    }
}
