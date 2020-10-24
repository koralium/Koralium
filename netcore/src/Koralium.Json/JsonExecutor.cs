﻿/*
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
using Koralium.Metadata;
using Koralium.SqlToExpression;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Koralium.Json
{
    public class JsonExecutor
    {
        private readonly KoraliumExecutor _koraliumExecutor;
        public JsonExecutor(
            KoraliumExecutor koraliumExecutor
            )
        {
            _koraliumExecutor = koraliumExecutor;
        }

        public async Task<List<Dictionary<string, object>>> Execute(string sql, SqlParameters sqlParameters, HttpContext httpContext)
        {
            var result = await _koraliumExecutor.Execute(sql, sqlParameters, httpContext, new Dictionary<string,object>(), new CustomMetadataStore());

            List<Dictionary<string, object>> output = new List<Dictionary<string, object>>();

            foreach(var row in result.Result)
            {
                Dictionary<string, object> obj = new Dictionary<string, object>();
                foreach (var column in result.Columns)
                {
                    obj.Add(column.Name, column.GetFunction(row));   
                }
                output.Add(obj);
            }   
            return output;
        }
    }
}
