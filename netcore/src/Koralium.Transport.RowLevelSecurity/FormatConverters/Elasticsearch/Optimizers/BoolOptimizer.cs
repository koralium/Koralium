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
