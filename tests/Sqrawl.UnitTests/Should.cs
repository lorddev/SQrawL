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
            expected = whitespace.Replace(expected, " ");
            actual = whitespace.Replace(actual, " ");

            var ph0 = new Regex(@"_\d+");
            actual = ph0.Replace(actual, "_ph0");
            Assert.Equal(expected, actual, StringComparer.CurrentCultureIgnoreCase);
        }
    }
}