using AutoMapper;
using Koralium.SqlToExpression;
using Koralium.WebTests.Database;
using Koralium.WebTests.Entities.specific;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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

        protected override Task<IQueryable<AutoMapperCustomer>> GetQueryableData()
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
