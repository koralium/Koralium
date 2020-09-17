/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;

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
                if(mappingInfo.StoreTypeName == "array")
                {
                    return new ListTypeMapping("array", clrType);
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
