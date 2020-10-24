using Koralium.SqlToExpression.Interfaces;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression
{
    /// <summary>
    /// This interface allows for specific implementations of full text search
    /// </summary>
    public interface ISearchExpressionProvider
    {
        /// <summary>
        /// Returns the expression that implements the functionality of full text search
        /// </summary>
        /// <returns></returns>
        Expression GetSearchExpression(ISearchParameters searchParameters);
    }
}
