using Koralium.SqlParser.Expressions;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Optimizers;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Serializers;
using System.Text.Json;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters
{
    static class ElasticSearchFormat
    {
        public static string Format(BooleanExpression booleanExpression, ElasticSearchOptions elasticSearchOptions)
        {
            elasticSearchOptions ??= new ElasticSearchOptions();

            var visitor = new ElasticSearchVisitor(elasticSearchOptions);
            visitor.Visit(booleanExpression);
            var filter = visitor.GetBool();

            while (BoolOptimizer.Optimize(filter) || RangeOptimizer.OptimizeRange(filter)) 
            {
                //Iterate until no more optimizations
            }

            var serializedFilter = JsonSerializer.Serialize(filter, new JsonSerializerOptions()
            {
                Converters =
                {
                    new BoolSerializer()
                }
            });

            return serializedFilter;
        }
    }
}
