﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.InsightDatabase.Extensions
{
    public static class StringExtensions
    {
        public static string GetStoredProcedureName(this string fullName) =>
            fullName.Substring(0, fullName.LastIndexOf("Async"));
    }
}
