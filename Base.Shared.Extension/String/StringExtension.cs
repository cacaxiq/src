using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Base.Shared.Extension.String
{
    public static class StringExtension
    {
        public static string FormatCellPhone(this string number)
        {
            return Regex.Replace(number, @"(\d{2})(\d{5})(\d{4})", "($1) $2 $3");
        }

        public static string FormatHomePhone(this string number)
        {
            return Regex.Replace(number, @"(\d{2})(\d{4})(\d{4})", "($1) $2 $3");
        }
    }
}
