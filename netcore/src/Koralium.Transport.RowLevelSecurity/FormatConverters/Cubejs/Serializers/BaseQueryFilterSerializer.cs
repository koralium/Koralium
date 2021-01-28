using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Serializers
{
    class BaseQueryFilterSerializer : JsonConverter<BaseQueryFilter>
    {
        private static readonly BinaryQueryFilterSerializer binaryQueryFilterSerializer = new BinaryQueryFilterSerializer();
        private static readonly QueryFilterSerializer queryFilterSerializer = new QueryFilterSerializer();
        internal static readonly BaseQueryFilterSerializer baseSerializer = new BaseQueryFilterSerializer();

        public override BaseQueryFilter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, BaseQueryFilter value, JsonSerializerOptions options)
        {
            if (value is BinaryQueryFilter binaryQueryFilter)
            {
                binaryQueryFilterSerializer.Write(writer, binaryQueryFilter, options);
                return;
            }
            else if (value is QueryFilter queryFilter)
            {
                queryFilterSerializer.Write(writer, queryFilter, options);
                return;
            }
            throw new NotImplementedException();
        }
    }
}
