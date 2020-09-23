using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Interfaces
{
    public interface ISearchParameters
    {
        /// <summary>
        /// Should all fields be searched?
        /// </summary>
        bool SearchAllFields { get; }

        ParameterExpression ParameterExpression { get; }

        /// <summary>
        /// If not all fields should be searched, this contains the specific columns that should be searched
        /// </summary>
        IReadOnlyList<Expression> SearchColumns { get; }

        /// <summary>
        /// The text that should be used in the search
        /// </summary>
        string SearchText { get; }
    }
}
