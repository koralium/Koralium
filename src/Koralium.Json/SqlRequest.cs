using Koralium.SqlToExpression;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Json
{
    public class SqlRequest
    {
        public string Query { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
