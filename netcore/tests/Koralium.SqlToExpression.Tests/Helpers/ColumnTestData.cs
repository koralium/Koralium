using Koralium.SqlToExpression.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.SqlToExpression.Tests.Helpers
{
    public static class ColumnTestData
    {
        public static IQueryable<ColumnTest> GetData()
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
                        }
                    }.AsQueryable();
        }
    }
}
