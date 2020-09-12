using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Storage.Internal
{
    public class KoraliumTypeMappingSource : RelationalTypeMappingSource
    {
        private const string VarcharTypeName = "string";
        private static readonly KoraliumStringTypeMapping _text = new KoraliumStringTypeMapping(VarcharTypeName);


        private readonly Dictionary<Type, RelationalTypeMapping> _clrTypeMappings
            = new Dictionary<Type, RelationalTypeMapping>
            {
                { typeof(string), _text },
                { typeof(long), new LongTypeMapping("bigint", System.Data.DbType.Int64) }
            };

        public KoraliumTypeMappingSource(TypeMappingSourceDependencies dependencies,
            RelationalTypeMappingSourceDependencies relationalDependencies) : base(dependencies, relationalDependencies)
        {
        }

        protected override RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            var clrType = mappingInfo.ClrType;

            if (mappingInfo.StoreTypeName != null)
            {
                if (mappingInfo.StoreTypeName == "object")
                {
                    return new ObjectTypeMapping("object", clrType);
                }
            }

            if (clrType != null
                && _clrTypeMappings.TryGetValue(clrType, out var mapping))
            {
                return mapping;
            }

            var o = base.FindMapping(mappingInfo);

            return o;
        }
    }
}
