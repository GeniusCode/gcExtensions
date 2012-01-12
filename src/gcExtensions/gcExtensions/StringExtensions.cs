using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace gcExtensions
{
    public static class StringExtensions
    {
        public static string FormatString(this string input, params object[] args)
        {
            return string.Format(input, args);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        public static Match RegexMatch(this string input, string regexFormula)
        {
            return Regex.Match(input, regexFormula);
        }

        public static Match RegexMatch(this string input, string regexFormula, RegexOptions options)
        {
            return Regex.Match(input, regexFormula,options);
        }
    }
}
