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
using System;
using System.Text.RegularExpressions;

namespace Koralium.SqlToExpression.Utils
{
    /// <summary>
    /// This class helps parsing the SQL query to find if there are any LIMIT ??? OFFSET ??? query in it.
    /// It is ugly right now and need fixing
    /// 
    /// It needs to first locate the limit, also then find out if there is any group by already, or if it has to be added
    /// </summary>
    public static class OffsetLimitUtils
    {
        private const string Limit = "LIMIT";
        private const string Offset = "OFFSET";
        private const string OrderBy = "ORDER BY";

        private static Regex limitOffsetRegex = new Regex(@"limit\s(\d+|@\w+) offset\s(\d+|@\w+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Regex limitRegex = new Regex(@"limit\s(\d+|@\w+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Regex offsetRegex = new Regex(@"offset\s(\d+|@\w+)(\srow)*", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static string TransformQuery(string sql)
        {

            var matches = limitOffsetRegex.Matches(sql);

            //Contained both limit and offset
            if(matches.Count > 0)
            {
                sql = HandleLimitOffset(sql, matches);
            }

            matches = limitRegex.Matches(sql);

            if(matches.Count > 0)
            {
                sql = HandleLimit(sql, matches);
            }

            matches = offsetRegex.Matches(sql);

            if(matches.Count > 0)
            {
                sql = HandleOffset(sql, matches);
            }

            return sql;
        }

        private static string HandleOffset(string sql, MatchCollection matchCollection)
        {
            for (int i = 0; i < matchCollection.Count; i++)
            {
                var match = matchCollection[i];
                if (!match.Success)
                    continue;

                //If a match was found on the word row, skip the match since its valid
                if (match.Groups[2].Success)
                    continue;

                if (!AffectedByOrderBy(sql, match.Index, 0))
                {
                    sql = sql.Replace(match.Value, $"ORDER BY (SELECT NULL) OFFSET {match.Groups[1].Value} ROWS");
                }
                else
                {
                    sql = sql.Replace(match.Value, $"OFFSET {match.Groups[1].Value} ROWS");
                }
            }
            return sql;
        }

        private static string HandleLimit(string sql, MatchCollection matchCollection)
        {
            for (int i = 0; i < matchCollection.Count; i++)
            {
                var match = matchCollection[i];
                if (!match.Success)
                    continue;

                if (!AffectedByOrderBy(sql, match.Index, 0))
                {
                    sql = sql.Replace(match.Value, $"ORDER BY (SELECT NULL) OFFSET 0 ROWS FETCH NEXT {match.Groups[1].Value} ROWS ONLY");
                }
                else
                {
                    sql = sql.Replace(match.Value, $"OFFSET 0 ROWS FETCH NEXT {match.Groups[1].Value} ROWS ONLY");
                }
            }
            return sql;
        }

        private static string HandleLimitOffset(string sql, MatchCollection matchCollection)
        {
            int addedCount = 0;
            for (int i = 0; i < matchCollection.Count; i++)
            {
                var match = matchCollection[i];
                if (!match.Success)
                    continue;

                if(!AffectedByOrderBy(sql, match.Index + addedCount, 0))
                {
                    string replacement = $"ORDER BY (SELECT NULL) OFFSET {match.Groups[2].Value} ROWS FETCH NEXT {match.Groups[1].Value} ROWS ONLY";
                    sql = sql.Remove(match.Index + addedCount, match.Length).Insert(match.Index + addedCount, replacement);
                    addedCount += replacement.Length - match.Length;
                }
                else
                {
                    sql = sql.Remove(match.Index + addedCount, match.Length).Insert(match.Index + addedCount, $"OFFSET {match.Groups[2].Value} ROWS FETCH NEXT {match.Groups[1].Value} ROWS ONLY");
                }
            }
            return sql;
        }

        private static bool AffectedByOrderBy(string sql, int startIndex, int openBracket)
        {
            int orderByOffset = sql.LastIndexOf(OrderBy, startIndex, StringComparison.InvariantCultureIgnoreCase);

            if (orderByOffset == -1)
                return false;

            //Walk from order by to start, check if there are any parenthesis in the way
            for(int i = orderByOffset; i < startIndex; i++)
            {
                if(sql[i] == '(')
                {
                    openBracket++;
                }
                if(sql[i] == ')')
                {
                    openBracket--;
                }
            }

            //Matched open brackets
            if (openBracket == 0)
                return true;

            if(openBracket < 0)
            {
                return AffectedByOrderBy(sql, orderByOffset, openBracket);
            }

            return false;
        }
    }
}
