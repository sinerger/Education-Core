using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.InsightDatabase.Extensions
{
    public static class StringExtensions
    {
        public static string GetRouteByClassName(this string className) =>
            className.Substring(0, className.LastIndexOf("Controller"));
        public static string GetRouteByString(this string str) => "/" + str;
    }
}
