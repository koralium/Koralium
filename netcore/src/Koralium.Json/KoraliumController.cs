using Koralium.Core;
using Koralium.SqlToExpression;
using Koralium.SqlToExpression.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
