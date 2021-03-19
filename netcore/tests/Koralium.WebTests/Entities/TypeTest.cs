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
using System;
using System.Collections.Generic;

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
        public short ShortValue { get; set; }

        public short? ShortValueNullable { get; set; }

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

        //UInt32
        public uint UIntValue { get; set; }

        public uint? UIntValueNullable { get; set; }

        //UInt64
        public ulong ULongValue { get; set; }

        public ulong? ULongValueNullable { get; set; }

        //Byte
        public byte ByteValue { get; set; }

        public byte? ByteValueNullable { get; set; }

        //Object/Struct
        public TypeTestInnerObject Object { get; set; }

        //Lists
        public List<int> IntList { get; set; }

        public List<int?> IntListNullable { get; set; }

        public List<TypeTestInnerObject> ObjectList { get; set; }

        //Binary
        public byte[] BinaryValue { get; set; }

        public TestTypeEnum EnumValue { get; set; }

        public IEnumerable<int> EnumerableList { get; set; }
    }
}
