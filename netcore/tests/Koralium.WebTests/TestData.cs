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
using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.WebTests
{
    public class TestData
    {
        private static long lastIndexSize = 0;
        private static List<IndexTest> indexTestData;
        private static Dictionary<long, IndexTest> indexTestIndex;

        public static (IQueryable<IndexTest>, IReadOnlyDictionary<long, IndexTest>) GetIndexTestData(long indexSize)
        {
            if(indexTestData == null || (indexSize != lastIndexSize))
            {
                lastIndexSize = indexSize;
                indexTestData = new List<IndexTest>();
                indexTestIndex = new Dictionary<long, IndexTest>();
                for(int i = 0; i < indexSize; i++)
                {
                    var obj = new IndexTest()
                    {
                        Key = i,
                        StringKey = i.ToString()
                    };
                    indexTestData.Add(obj);
                    indexTestIndex.Add(i, obj);
                }
            }
            return (indexTestData.AsQueryable(), indexTestIndex);
        }

        public static IQueryable<Test> GetData()
        {
            var o = new List<Test>()
            {
                new Test()
                {
                    Name = "test",
                    TestList = new List<int>()
                    {
                        1,
                        5
                    },
                    ListInList = new List<List<int>>()
                    {
                        new List<int>()
                        {
                            6,
                            7
                        }
                    },
                    TestObject = new TestObject()
                    {
                        TestTest = "testar1",
                        OtherObject = new OtherObject()
                        {
                            Name = "other"
                        }
                    },
                    ListOfObject = new List<OtherObject>()
                    {
                        new OtherObject()
                        {
                            Name = "test"
                        },
                        new OtherObject()
                        {
                            Name = "test2"
                        }
                    },
                    BoolValue = true,
                    FloatValue = 3.0f,
                    IntValue = 1,
                    
                },
                new Test()
                {
                    Name = "test2",
                    TestList = new List<int>()
                    {
                        2,
                        6
                    },
                    ListInList = new List<List<int>>()
                    {
                        new List<int>()
                        {
                            7,
                            8
                        }
                    },
                    TestObject = new TestObject()
                    {
                        TestTest = "testar2",
                        OtherObject = new OtherObject()
                        {
                            Name = "other2"
                        }
                    },
                    ListOfObject = new List<OtherObject>()
                    {
                        new OtherObject()
                        {
                            Name = "test2"
                        },
                        new OtherObject()
                        {
                            Name = "test3"
                        }
                    },
                    BoolValue = false,
                    FloatValue = 7.0f,
                    IntValue = 2
                }
            }.AsQueryable();

            return o;
        }

        public static IQueryable<Secure> GetSecureData()
        {
            return new List<Secure>()
            {
                new Secure()
                {
                    Name = "test1"
                },
                new Secure()
                {
                    Name = "test2"
                }
            }.AsQueryable();
        }

        public static IQueryable<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Name = "test employee",
                    CompanyId = "1"
                },
                new Employee()
                {
                    Name = "Employee null company",
                    CompanyId = null
                }
            }.AsQueryable();
        }

        public static IQueryable<Company> GetCompanies()
        {
            return new List<Company>()
            {
                new Company()
                {
                    Name = "test company",
                    CompanyId = "1"
                },
                new Company()
                {
                    Name = "other company",
                    CompanyId = "2"
                }
            }.AsQueryable();
        }

        private static List<TypeTest> CreateTypeTestArray(int count)
        {
            List<TypeTest> output = new List<TypeTest>();
            for(int i = 0; i < count; i++)
            {
                output.Add(new TypeTest());
            }
            return output;
        }

        private static void SetTypeTestValue<T>(List<TypeTest> arr, Action<TypeTest, T> setValue, params T[] possibleValues)
        {
            if(possibleValues.Length > arr.Count)
            {
                throw new InvalidOperationException("More possible values than in the array of objects");
            }

            for(int i = 0; i < arr.Count; i++)
            {
                setValue(arr[i], possibleValues[i % possibleValues.Length]);
            }
        }

        private static TypeTestInnerObject[] GetTypeTestInnerObjects()
        {
            return new TypeTestInnerObject[]
            {
                new TypeTestInnerObject()
                {
                    StringValue = "test",
                    IntList = new List<int>()
                    {
                        1,
                        2,
                        3
                    },
                    Object = new TypeTestInnerInnerObject()
                    {
                        StringValue = "test"
                    }
                },
                new TypeTestInnerObject()
                {
                    StringValue = "test2",
                    IntList = new List<int>(),
                    Object = null
                },
                null
            };
        }

        public static IQueryable<TypeTest> GetTypeTests()
        {
            var arr = CreateTypeTestArray(5);

            //Primitive
            SetTypeTestValue(arr, (t, x) => t.BoolValue = x, true, false);
            SetTypeTestValue<bool?>(arr, (t, x) => t.BoolValueNullable = x, true, false, null);
            SetTypeTestValue(arr, (t, x) => t.DateTime = x, TpchData.FixDate(DateTime.Parse("1990-03-13")));
            SetTypeTestValue<DateTime?>(arr, (t, x) => t.DateTimeNullable = x, TpchData.FixDate(DateTime.Parse("1990-03-13")), null);
            SetTypeTestValue(arr, (t, x) => t.DoubleValue = x, 1.0, 3.0, 17.0);
            SetTypeTestValue<double?>(arr, (t, x) => t.DoubleValueNullable = x, 1.0, 3.0, 17.0, null);
            SetTypeTestValue(arr, (t, x) => t.FloatValue = x, 1.0f, 3.0f, 17.0f);
            SetTypeTestValue<float?>(arr, (t, x) => t.FloatValueNullable = x, 1.0f, 3.0f, 17.0f, null);
            SetTypeTestValue(arr, (t, x) => t.IntValue = x, 1, 3, 17);
            SetTypeTestValue<int?>(arr, (t, x) => t.IntValueNullable = x, 1, 3, 17, null);
            SetTypeTestValue<long>(arr, (t, x) => t.LongValue = x, 1, 3, 17);
            SetTypeTestValue<long?>(arr, (t, x) => t.LongValueNullable = x, 1, 3, 17, null);
            SetTypeTestValue<short>(arr, (t, x) => t.ShortValue = x, 1, 3, 17);
            SetTypeTestValue<short?>(arr, (t, x) => t.ShortValueNullable = x, 1, 3, 17, null);
            SetTypeTestValue(arr, (t, x) => t.StringValue = x, "test", null);
            SetTypeTestValue<uint>(arr, (t, x) => t.UIntValue = x, 1, 3, 17);
            SetTypeTestValue<uint?>(arr, (t, x) => t.UIntValueNullable = x, 1, 3, 17, null);
            SetTypeTestValue<ulong>(arr, (t, x) => t.ULongValue = x, 1, 3, 17);
            SetTypeTestValue<ulong?>(arr, (t, x) => t.ULongValueNullable = x, 1, 3, 17, null);
            SetTypeTestValue<byte>(arr, (t, x) => t.ByteValue = x, 1, 3, 17);
            SetTypeTestValue<byte?>(arr, (t, x) => t.ByteValueNullable = x, 1, 3, 17, null);


            //Complex
            SetTypeTestValue(arr, (t, x) => t.Object = x, GetTypeTestInnerObjects());

            SetTypeTestValue(arr, (t, x) => t.IntList = x, new List<int>()
            {
                1,
                2,
                3
            },
            new List<int>(),
            null);

            SetTypeTestValue(arr, (t, x) => t.IntListNullable = x, new List<int?>()
            {
                1,
                null,
                3
            },
            new List<int?>(),
            null);

            SetTypeTestValue(arr, (t, x) => t.ObjectList = x, GetTypeTestInnerObjects().ToList(), null);

            //Binary
            SetTypeTestValue<byte[]>(arr, (t, x) => t.BinaryValue = x, new byte[] { 1, 3, 17 }, null);

            return arr.AsQueryable();
        }
    }
}
