/*
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
