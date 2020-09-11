using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntityFrameworkCore.Koralium.Storage.Internal
{
    public class KoraliumStringTypeMapping : StringTypeMapping
    {
        public KoraliumStringTypeMapping(string storeType, DbType? dbType = null, bool unicode = false, int? size = null) : base(storeType, dbType, unicode, size)
        {
        }

        protected KoraliumStringTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
        {
        }
    }
}
