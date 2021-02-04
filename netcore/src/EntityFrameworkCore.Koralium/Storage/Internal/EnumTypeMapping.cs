using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntityFrameworkCore.Koralium.Storage.Internal
{
    class EnumTypeMapping : RelationalTypeMapping
    {

        public EnumTypeMapping(string storeType, Type clrType, DbType? dbType = null, bool unicode = false, int? size = null)
            : base(storeType, clrType, dbType, unicode, size)
        {
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override string GenerateSqlLiteral(object value)
        {
            return $"'{value.ToString()}'";
        }
    }
}
