using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Query.Internal
{
    public class KoraliumSqlTranslatingExpressionVisitor : RelationalSqlTranslatingExpressionVisitor
    {
        public KoraliumSqlTranslatingExpressionVisitor(RelationalSqlTranslatingExpressionVisitorDependencies dependencies, IModel model, QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor)
            : base(dependencies, model, queryableMethodTranslatingExpressionVisitor)
        {
        }
    }
}
