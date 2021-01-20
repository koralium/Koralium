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
using Koralium.Interfaces;
using Koralium.SqlToExpression;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    [Authorize("secure")]
    public class SecureResolver : TableResolver<Order>
    {
        private readonly TpchData _tpchData;
        public SecureResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }
        protected override Task<IQueryable<Order>> GetQueryableData(IQueryOptions<Order> queryOptions, ICustomMetadata customMetadata)
        {
            return Task.FromResult(_tpchData.Orders.AsQueryable());
        }
    }
}
