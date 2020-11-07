using Koralium.WebTests.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Resolvers
{
    public class TestResolver : TableResolver<Test>
    {
        protected override Task<IQueryable<Test>> GetQueryableData()
        {
            return Task.FromResult(TestData.GetData());
        }
    }
}
