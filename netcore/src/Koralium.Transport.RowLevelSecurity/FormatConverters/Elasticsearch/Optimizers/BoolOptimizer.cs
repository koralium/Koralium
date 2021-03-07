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
using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Optimizers
{
    static class BoolOptimizer
    {
        public static bool Optimize(Bool boolQuery)
        {
            bool optimized = false;
            if (boolQuery.Must != null)
            {
                for (int i = 0; i < boolQuery.Must.Count; i++)
                {
                    var o = boolQuery.Must[i];
                    if (o is Bool b)
                    {
                        optimized = optimized || Optimize(b);

                        if (b.Must != null && b.MustNot == null && b.Should == null)
                        {
                            boolQuery.Must.AddRange(b.Must);
                            boolQuery.Must.RemoveAt(i);
                            i--;
                            optimized = true;
                        }
                    }
                }
            }
            if (boolQuery.Should != null)
            {
                for (int i = 0; i < boolQuery.Should.Count; i++)
                {
                    var o = boolQuery.Should[i];
                    if (o is Bool b)
                    {
                        optimized = optimized || Optimize(b);

                        if (b.Should != null && b.MustNot == null && b.Must == null)
                        {
                            boolQuery.Should.AddRange(b.Should);
                            boolQuery.Should.RemoveAt(i);
                            i--;
                            optimized = true;
                        }
                        if (b.Must != null && b.Must.Count == 1 && b.Should == null && b.MustNot == null)
                        {
                            boolQuery.Should.AddRange(b.Must);
                            boolQuery.Should.RemoveAt(i);
                            optimized = true;
                        }
                    }
                }
            }
            if (boolQuery.MustNot != null)
            {
                for (int i = 0; i < boolQuery.MustNot.Count; i++)
                {
                    var o = boolQuery.MustNot[i];
                    if (o is Bool b)
                    {
                        optimized = optimized || Optimize(b);

                        // MustNot in MustNot is double negation, add those to must instead
                        if (b.MustNot != null && b.Should == null && b.Must == null)
                        {
                            if (boolQuery.Must == null)
                            {
                                boolQuery.Must = new List<BoolOperation>();
                            }
                            boolQuery.Must.AddRange(b.MustNot);
                            boolQuery.MustNot.RemoveAt(i);
                            i--;
                            optimized = true;
                        }
                        // Must translates into must not
                        if (b.Must != null && b.Should == null && b.MustNot == null)
                        {
                            boolQuery.MustNot.AddRange(b.MustNot);
                            boolQuery.MustNot.RemoveAt(i);
                            i--;
                            optimized = true;
                        }
                    }
                }
            }
            return optimized;
        }
    }
}
