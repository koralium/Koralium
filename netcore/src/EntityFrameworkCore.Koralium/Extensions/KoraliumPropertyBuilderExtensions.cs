using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore
{
    public static class KoraliumPropertyBuilderExtensions
    {
        public static PropertyBuilder IsObjectType(this PropertyBuilder propertyBuilder)
        {
            propertyBuilder.HasColumnType("object");

            return propertyBuilder;
        }

        public static PropertyBuilder IsArrayType(this PropertyBuilder propertyBuilder)
        {
            propertyBuilder.HasColumnType("array");

            return propertyBuilder;
        }
    }
}
