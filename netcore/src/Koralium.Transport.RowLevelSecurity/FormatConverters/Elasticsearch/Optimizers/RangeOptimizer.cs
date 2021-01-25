using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Optimizers
{
    static class RangeOptimizer
    {
        /// <summary>
        /// Merges together range queries if possible
        /// </summary>
        /// <param name="boolQuery"></param>
        public static bool OptimizeRange(Bool boolQuery)
        {
            bool optimized = false;
            if (boolQuery.Must != null)
            {
                Dictionary<string, Models.Range> rangeQueries = new Dictionary<string, Models.Range>();
                for (int i = 0; i < boolQuery.Must.Count; i++)
                {
                    var b = boolQuery.Must[i];
                    
                    if (b is Bool inner)
                    {
                        optimized = optimized || OptimizeRange(inner);
                    }
                    if (b is Models.Range range)
                    {
                        if (rangeQueries.TryGetValue(range.FieldName, out var existing))
                        {
                            bool canDelete = true;
                            if (range.GreaterThan != null)
                            {
                                if (existing.GreaterThan == null)
                                {
                                    existing.GreaterThan = range.GreaterThan;
                                    optimized = true;
                                }
                                else
                                {
                                    canDelete = false;
                                }
                            }
                            if (range.GreaterThanEqual != null)
                            {
                                if (existing.GreaterThanEqual == null)
                                {
                                    existing.GreaterThanEqual = range.GreaterThanEqual;
                                    optimized = true;
                                }
                                else
                                {
                                    canDelete = false;
                                }
                            }
                            if (range.LessThan != null)
                            {
                                if (existing.LessThan == null)
                                {
                                    existing.LessThan = range.LessThan;
                                    optimized = true;
                                }
                                else
                                {
                                    canDelete = false;
                                }
                            }
                            if (range.LessThanEqual != null)
                            {
                                if (existing.LessThanEqual == null)
                                {
                                    existing.LessThanEqual = range.LessThanEqual;
                                }
                                else
                                {
                                    canDelete = false;
                                }
                            }
                            if (canDelete)
                            {
                                boolQuery.Must.RemoveAt(i);
                                i--;
                                optimized = true;
                            }
                        }
                        else
                        {
                            rangeQueries.Add(range.FieldName, range);
                        }
                    }
                }
            }

            if (boolQuery.Should != null)
            {
                foreach(var op in boolQuery.Should)
                {
                    if (op is Bool inner)
                    {
                        optimized = optimized || OptimizeRange(inner);
                    }
                }
            }

            if (boolQuery.MustNot != null)
            {
                foreach (var op in boolQuery.MustNot)
                {
                    if (op is Bool inner)
                    {
                        optimized = optimized || OptimizeRange(inner);
                    }
                }
            }

            return optimized;
        }
    }
}
