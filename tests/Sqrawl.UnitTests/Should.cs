using System;
using System.Text.RegularExpressions;
using Xunit;

namespace Devlord.Sqrawl.UnitTests
{
    public static class Should
    {
        public static void ShouldEqual<T>(this T actual, T expected)
        {
            Assert.Equal(expected, actual);
        }

        public static void ShouldResemble(this string actual, string expected)
        {
            var whitespace = new Regex(@"\s+");
            Assert.Equal(whitespace.Replace(expected, " "), whitespace.Replace(actual, " "),
                StringComparer.CurrentCultureIgnoreCase);
        }
    }
}