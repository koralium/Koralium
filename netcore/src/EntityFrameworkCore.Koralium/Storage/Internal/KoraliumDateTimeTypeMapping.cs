using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EntityFrameworkCore.Koralium.Storage.Internal
{
    public class KoraliumDateTimeTypeMapping : DateTimeTypeMapping
    {
        private const string DateTimeFormatConst = @"'{0:yyyy-MM-dd HH\:mm\:ss.fffffff}'";

        public KoraliumDateTimeTypeMapping(
            [NotNull] string storeType,
            DbType? dbType = null)
            : base(storeType, dbType)
        {
        }

        protected KoraliumDateTimeTypeMapping(RelationalTypeMappingParameters parameters)
            : base(parameters)
        {
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
            => new KoraliumDateTimeTypeMapping(parameters);

        protected override string SqlLiteralFormatString
            => DateTimeFormatConst;
    }
}
