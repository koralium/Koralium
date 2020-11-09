using Koralium.SqlToExpression.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
