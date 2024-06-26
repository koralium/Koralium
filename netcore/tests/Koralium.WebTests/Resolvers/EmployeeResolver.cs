﻿/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium;
using Koralium.WebTests;
using Koralium.WebTests.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace QueryProtocolGrpc.TestWeb.Resolvers
{
    public class EmployeeResolver : TableResolver<Employee>
    {
        protected override Task<IQueryable<Employee>> GetQueryableData(IQueryOptions<Employee> queryOptions, ICustomMetadata customMetadata)
        {
            return Task.FromResult(TestData.GetEmployees());
        }
    }
}
