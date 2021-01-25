using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models
{
    class Terms : BoolOperation
    {
        public string FieldName { get; set; }

        public List<object> Values { get; set; }
    }
}
