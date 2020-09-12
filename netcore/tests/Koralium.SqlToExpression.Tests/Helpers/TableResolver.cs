using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests
{
    public class TableResolver : ITableResolver
    {
        private readonly TpchData _tpchData;
        public TableResolver(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        private IQueryable GetQueryable(string name)
        {
            switch (name.ToLower())
            {
                case "customer":
                    return _tpchData.Customers.AsQueryable();
                case "lineitem":
                    return _tpchData.LineItem.AsQueryable();
                case "order":
                    return _tpchData.Orders.AsQueryable();
                case "Part":
                    return _tpchData.Part.AsQueryable();
                case "partsupp":
                    return _tpchData.Partsupp.AsQueryable();
                case "region":
                    return _tpchData.Region.AsQueryable();
                case "supplier":
                    return _tpchData.Supplier.AsQueryable();
            }
            throw new NotImplementedException();
        }

        public ValueTask<IQueryable> ResolveTableName(string name, object additionalData)
        {
            return new ValueTask<IQueryable>(GetQueryable(name));
        }
    }
}
