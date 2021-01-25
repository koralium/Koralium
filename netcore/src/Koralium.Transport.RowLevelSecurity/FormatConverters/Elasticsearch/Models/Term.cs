using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models
{
    class Term : BoolOperation
    {
        public string FieldName { get; set; }

        public object Value { get; set; }
    }
}
