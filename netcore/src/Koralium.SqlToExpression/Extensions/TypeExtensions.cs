using Koralium.SqlToExpression.Models;
using System;

namespace Koralium.SqlToExpression.Extensions
{
    public static class TypeExtensions
    {
        public static SqlTypeInfo ToSqlTypeInfo(this Type type)
        {
            var properties = type.GetProperties();

            var builder = SqlTypeInfo.NewBuilder();
            foreach (var property in properties)
            {
                builder.AddProperty(property.Name, property);
            }
            return builder.Build();
        }
    }
}
