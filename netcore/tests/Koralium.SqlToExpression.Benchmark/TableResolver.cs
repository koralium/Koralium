using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression
{
    public class TableResolver : ITableResolver
    {
        public ValueTask<IQueryable> ResolveTableName(string name, object additionalData)
        {
            if(name == "project")
            {
                return new ValueTask<IQueryable>(new List<Project>()
                {
                     new Project()
                    {
                        Id = 1,
                        Name = "alex"
                    },
                    new Project()
                    {
                        Id = 2,
                        Name = "alex"
                    }
                }.AsQueryable());
            }
            throw new NotImplementedException();
        }
    }
}
