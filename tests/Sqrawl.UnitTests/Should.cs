using System;
using Xunit;

namespace Sqrawl.UnitTests
{
    public static class Should
    {
        public static void ShouldEqual<T>(this T actual, T expected)
        {
            Assert.Equal(expected, actual);
        }

        public static void ShouldApproximate(this string actual, string expected)
        {
            Assert.Equal(expected, actual, StringComparer.CurrentCultureIgnoreCase);
        }
    }
}
