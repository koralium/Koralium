using Koralium.SqlToExpression;
using Koralium.SqlToExpression.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.WebTests
{
    public class CustomSearchProvider : ISearchExpressionProvider
    {
        public Expression GetSearchExpression(ISearchParameters searchParameters)
        {

            throw new NotImplementedException();
        }
    }
}
