using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Entities
{
    public class TypeTest
    {
        //Bool
        public bool BoolValue { get; set; }

        public bool? BoolValueNullable { get; set; }

        //Double
        public double DoubleValue { get; set; }

        public double? DoubleValueNullable { get; set; }

        //Float
        public float FloatValue { get; set; }

        public float? FloatValueNullable { get; set; }

        //Short
        //public short ShortValue { get; set; }

        //public short? ShortValueNullable { get; set; }

        //Int
        public int IntValue { get; set; }

        public int? IntValueNullable { get; set; }

        //Long
        public long LongValue { get; set; }

        public long? LongValueNullable { get; set; }

        //String
        public string StringValue { get; set; }

        //DateTime
        public DateTime DateTime { get; set; }

        public DateTime? DateTimeNullable { get; set; }

        //Object/Struct
        public TypeTestInnerObject Object { get; set; }

        //Lists
        public List<int> IntList { get; set; }

        public List<int?> IntListNullable { get; set; }

        public List<TypeTestInnerObject> ObjectList { get; set; }
    }
}
