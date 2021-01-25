using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Serializers
{
    class BoolOperationSerializer : JsonConverter<BoolOperation>
    {
        private static readonly BoolSerializer boolSerializer = new BoolSerializer();
        private static readonly RangeSerializer rangeSerializer = new RangeSerializer();
        private static readonly TermSerializer termSerializer = new TermSerializer();
        private static readonly TermsSerializer termsSerializer = new TermsSerializer();

        public override BoolOperation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, BoolOperation value, JsonSerializerOptions options)
        {
            if (value is Bool b)
            {
                boolSerializer.Write(writer, b, options);
                return;
            }
            else if (value is Models.Range range)
            {
                rangeSerializer.Write(writer, range, options);
                return;
            }
            else if (value is Models.Term term)
            {
                termSerializer.Write(writer, term, options);
                return;
            }
            else if (value is Models.Terms terms)
            {
                termsSerializer.Write(writer, terms, options);
                return;
            }
            throw new NotImplementedException();
        }
    }
}
