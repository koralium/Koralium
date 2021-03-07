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
using Koralium.WebTests.Entities;
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
