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
using Koralium.Shared;
using Koralium.SqlToExpression;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Koralium.Json
{
    public class KoraliumController : ControllerBase
    {
        private readonly JsonExecutor _koraliumExecutor;
        public KoraliumController(
            JsonExecutor koraliumExecutor)
        {
            _koraliumExecutor = koraliumExecutor;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            try
            {
                var result = await _koraliumExecutor.Execute(query, null, HttpContext);
                return Ok(result);
            }
            catch(SqlErrorException e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SqlRequest sqlRequest)
        {
            try
            {
                SqlParameters sqlParameters = new SqlParameters();
                if(sqlRequest.Parameters != null)
                {
                    foreach (var parameter in sqlRequest.Parameters)
                    {
                        object val = null;
                        switch (parameter.Value.ValueKind)
                        {
                            case System.Text.Json.JsonValueKind.String:
                                val = parameter.Value.GetString();
                                break;
                            case System.Text.Json.JsonValueKind.Number:
                                val = parameter.Value.GetDouble();
                                break;
                            case System.Text.Json.JsonValueKind.False:
                            case System.Text.Json.JsonValueKind.True:
                                val = parameter.Value.GetBoolean();
                                break;
                            default:
                                throw new NotSupportedException();
                        }
                        sqlParameters.Add(SqlParameter.Create(parameter.Name, val));
                    }
                }
               

                var result = await _koraliumExecutor.Execute(sqlRequest.Query, sqlParameters, HttpContext);
                return Ok(result);
            }
            catch (SqlErrorException e)
            {
                return StatusCode(400, e.Message);
            }

        }
    }
}
