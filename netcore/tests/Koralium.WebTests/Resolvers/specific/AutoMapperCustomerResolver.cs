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
using AutoMapper;
using Koralium.Interfaces;
using Koralium.SqlToExpression;
using Koralium.WebTests.Database;
using Koralium.WebTests.Entities.specific;
using Koralium.WebTests.Entities.tpch;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers.specific
{
    public class AutoMapperCustomerResolver : TableResolver<AutoMapperCustomer>
    {
        private readonly TestContext _testContext;
        private readonly IMapper _mapper;
        public AutoMapperCustomerResolver(TestContext testContext)
        {
            _testContext = testContext;
            _mapper = new MapperConfiguration(o =>
            {
                o.AddProfile<CustomerProfile>();
            }).CreateMapper();
        }

        protected override Task<IQueryable<AutoMapperCustomer>> GetQueryableData(IQueryOptions<AutoMapperCustomer> queryOptions, ICustomMetadata customMetadata)
        {
            return Task.FromResult(_mapper.ProjectTo<AutoMapperCustomer>(_testContext.Customers));
        }

        private class CustomerProfile : Profile
        {
            public CustomerProfile()
            {
                CreateMap<Customer, AutoMapperCustomer>()
                    .ForMember(x => x.OrderKeys, opt => opt.MapFrom(src => src.Orders.Select(x => x.Orderkey)));
            }
        }
    }
}
