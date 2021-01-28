using Koralium.SqlParser.Expressions;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Converter;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Serializers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs
{
    internal static class CubejsFormat
    {
        public static string Format(BooleanExpression booleanExpression, CubeJsOptions cubeJsOptions)
        {
            cubeJsOptions = cubeJsOptions ?? new CubeJsOptions();
            var visitor = new CubejsVisitor(cubeJsOptions);
            visitor.Visit(booleanExpression);
            var filter = visitor.GetFilter();

            var serializedFilter = JsonSerializer.Serialize(filter, new JsonSerializerOptions()
            {
                Converters =
                {
                    new BaseQueryFilterSerializer()
                }
            });

            return serializedFilter;
        }
    }
}
