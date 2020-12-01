using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.Extensions
{
    public static class TransportTableExtensions
    {
        public static string SelectAllColumnsStatement(this Transport.Table table)
        {
            return $"select * from {table.Name}";
        }
    }
}
