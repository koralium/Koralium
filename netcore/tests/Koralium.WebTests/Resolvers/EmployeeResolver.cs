using Grpc.Core;
using Koralium.Core.Resolvers;
using Koralium.WebTests;
using Koralium.WebTests.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueryProtocolGrpc.TestWeb.Resolvers
{
    public class EmployeeResolver : TableResolver<Employee>
    {
        public override Task<IQueryable<Employee>> GetQueryableData(HttpContext context)
        {
            return Task.FromResult(TestData.GetEmployees());
        }
    }
}
