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
using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Converter;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Serializers;
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
