using Koralium.WebTests.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests
{
    public class ProjectResolver : TableResolver<Project>
    {
        protected override async Task<IQueryable<Project>> GetQueryableData()
        {

            return new List<Project>()
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
                }.AsQueryable();
        }
    }
}
