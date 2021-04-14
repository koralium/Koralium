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
using Koralium.SqlToExpression.Tests.Models;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlToExpression.Tests.Helpers
{
    public static class TestData
    {

        public static IQueryable<NullTest> GetNullTestData()
        {
            return new List<NullTest>()
            {
                new NullTest()
                {
                    IsNull = null
                }
            }.AsQueryable();
        }

        public static IQueryable<EnumTest> GetEnumTestData()
        {
            return new List<EnumTest>()
            {
                new EnumTest()
                {
                    Enum = Enum.testval
                }
            }.AsQueryable();
        }

        public static IQueryable<ColumnTest> GetColumnTestData()
        {
            return new List<ColumnTest>()
                    {
                        new ColumnTest()
                        {
                            P0 = "0",
                            P1 = "1",
                            P2 = "2",
                            P3 = "3",
                            P4 = "4",
                            P5 = "5",
                            P6 = "6",
                            P7 = "7",
                            P8 = "8",
                            P9 = "9",
                            P10 = "10",
                            P11 = "11",
                            P12 = "12",
                            P13 = "13",
                            P14 = "14",
                            P15 = "15",
                            P16 = "16",
                            P17 = "17",
                            P18 = "18",
                            P19 = "19",
                            P20 = "20"
                        },
                        new ColumnTest()
                        {
                            P0 = "0",
                            P1 = "1",
                            P2 = "2",
                            P3 = "3",
                            P4 = "4",
                            P5 = "5",
                            P6 = "6",
                            P7 = "7",
                            P8 = "8",
                            P9 = "9",
                            P10 = "10",
                            P11 = "11",
                            P12 = "12",
                            P13 = "13",
                            P14 = "14",
                            P15 = "15",
                            P16 = "16",
                            P17 = "17",
                            P18 = "18",
                            P19 = "19",
                            P20 = "20"
                        },
                        new ColumnTest()
                        {
                            P0 = "00",
                            P1 = "11",
                            P2 = "22",
                            P3 = "33",
                            P4 = "44",
                            P5 = "55",
                            P6 = "66",
                            P7 = "77",
                            P8 = "88",
                            P9 = "99",
                            P10 = "101",
                            P11 = "111",
                            P12 = "121",
                            P13 = "131",
                            P14 = "141",
                            P15 = "151",
                            P16 = "161",
                            P17 = "171",
                            P18 = "181",
                            P19 = "191",
                            P20 = "201"
                        }
                    }.AsQueryable();
        }
    }
}
