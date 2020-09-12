using Koralium.Core.Resolvers;
using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.WebTests
{
    public class ProjectIndex : IndexResolver<Project, string>
    {
        protected override Task<IEnumerable<Project>> GetQueryableData(IReadOnlyList<string> keys, Expression<Func<Project, Project>> selectExpression)
        {
            return Task.FromResult(new List<Project>()
                {
                     new Project()
                    {
                        Id = 1,
                        Name = "alex",
                        Company = new Company()
                        {
                            CompanyId = "1",
                            Name = "Test company"
                        }
                    },
                    new Project()
                    {
                        Id = 2,
                        Name = "alex2"
                    }
                }.AsQueryable().Where(x => keys.Contains(x.Name)).AsEnumerable());
        }
    }
}
