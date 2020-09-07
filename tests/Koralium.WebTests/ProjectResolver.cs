using Koralium.Core.Resolvers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests
{
    public class ProjectResolver : TableResolver<Project>
    {
        public override async Task<IQueryable<Project>> GetQueryableData(HttpContext context)
        {

            return new List<Project>()
                {
                     new Project()
                    {
                        Id = 1,
                        Name = "alex",
                        Company = new Company()
                        {
                            Id = "1",
                            Name = "Test company"
                        }
                    },
                    new Project()
                    {
                        Id = 2,
                        Name = "alex2"
                    }
                }.AsQueryable();
        }
    }
}
