using Koralium.WebTests.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class CompanyResolver : TableResolver<Company>
    {
        protected override Task<IQueryable<Company>> GetQueryableData()
        {
            return Task.FromResult(TestData.GetCompanies());
        }
    }
}
