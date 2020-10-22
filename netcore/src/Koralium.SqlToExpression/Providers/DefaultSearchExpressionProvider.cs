using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Providers
{
    public class DefaultSearchExpressionProvider : ISearchExpressionProvider
    {
        public Expression GetSearchExpression(ISearchParameters searchParameters)
        {
            throw new SqlErrorException("Search is not implemented for this table");
        }
    }
}
