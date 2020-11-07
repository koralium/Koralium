using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;

namespace EntityFrameworkCore.Koralium.Storage.Internal
{
    public class ListTypeMapping : RelationalTypeMapping
    {

        public ListTypeMapping(
            string storeType,
            Type clrType,
            DbType? dbType = null,
            bool unicode = false,
            int? size = null)
            : base(storeType, clrType, dbType, unicode, size)
        {
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
