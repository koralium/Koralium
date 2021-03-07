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
