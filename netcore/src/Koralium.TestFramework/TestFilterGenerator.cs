﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Koralium.TestFramework
{
    internal static class TestFilterGenerator
    {

        public static bool IsPossibleFilter(Type type)
        {
            return type.IsPrimitive || type == typeof(string);
        }

        public static string GetValue(object value)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var type = value.GetType();
            if (type.IsPrimitive)
                return value.ToString();

            if (type == typeof(string))
            {
                return $"'{value}'";
            }

            throw new NotImplementedException($"The type {type.FullName} is not implemented");
        }
    }
}