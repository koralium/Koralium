using Koralium.SqlToExpression;
using Koralium.SqlToExpression.Interfaces;
using System;
using System.Linq.Expressions;

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
