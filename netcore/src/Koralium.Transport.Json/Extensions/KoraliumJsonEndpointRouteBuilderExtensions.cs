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
using Koralium.Transport.Json;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.Builder
{
    public static class KoraliumJsonEndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapKoraliumJsonPost(this IEndpointRouteBuilder endpointRouteBuilder, string pattern)
        {
            return endpointRouteBuilder.MapPost(pattern, JsonExecutor.PostMethod);
        }

        public static IEndpointConventionBuilder MapKoraliumJsonGet(this IEndpointRouteBuilder endpointRouteBuilder, string pattern)
        {
            return endpointRouteBuilder.MapGet(pattern, JsonExecutor.GetMethod);
        }
    }
}
