using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Koralium.Json
{
    public class Parameter
    {
        public string Name { get; set; }

        public JsonElement Value { get; set; }
    }
}
