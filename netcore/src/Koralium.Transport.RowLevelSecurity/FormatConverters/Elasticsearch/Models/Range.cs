using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models
{
    class Range : BoolOperation
    {
        //public enum Operations
        //{
        //    gt,
        //    gte,
        //    lt,
        //    lte
        //}

        public string FieldName { get; set; }

        public object GreaterThan { get; set; }

        public object GreaterThanEqual { get; set; }

        public object LessThan { get; set; }

        public object LessThanEqual { get; set; }
        //public object Value { get; set; }

        //public Operations Operation { get; set; }
    }
}
