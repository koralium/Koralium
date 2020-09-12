using Koralium.Core.Resolvers;
using Koralium.WebTests;
using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class EmployeeCompanyIdIndexResolver : IndexResolver<Employee, string>
    {
        protected override Task<IEnumerable<Employee>> GetQueryableData(IReadOnlyList<string> keys, Expression<Func<Employee, Employee>> selectExpression)
        {
            return Task.FromResult(TestData.GetEmployees().Where(x => keys.Contains(x.CompanyId)).AsEnumerable());
        }
    }
}
