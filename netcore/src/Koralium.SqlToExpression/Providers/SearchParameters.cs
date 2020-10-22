using Koralium.SqlToExpression.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Providers
{
    public class SearchParameters : ISearchParameters
    {
        public bool SearchAllFields { get; }

        public IReadOnlyList<Expression> SearchColumns { get; }

        public string SearchText { get; }

        public ParameterExpression ParameterExpression { get; }

        public SearchParameters(
            bool searchAllFields,
            IReadOnlyList<Expression> searchColumns,
            string searchText,
            ParameterExpression parameterExpression)
        {
            SearchAllFields = searchAllFields;
            SearchColumns = searchColumns;
            SearchText = searchText;
            ParameterExpression = parameterExpression;
        }
    }
}
