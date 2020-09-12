using Koralium.Core;
using Koralium.SqlToExpression;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
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
            var result = await _koraliumExecutor.Execute(sql, sqlParameters, httpContext);

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
