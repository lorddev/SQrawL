using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Devlord.Sqrawl.UnitTests
{
    public class ColumnTest
    {
        [Fact]
        public void EqualsTest()
        {
            var test1 = new Column(new Table("foo"), "bar");
            var test2 = new Column(new Table("foo"), "bar");
            Assert.True(test1.Equals(test2));
            Assert.True(test1.Equals((object)test2));
        }

        [Fact]
        public void ObjectEqualsTest()
        {
            var test1 = new Column(new Table("foo"), "bar");
            var test2 = new Column(new Table("foo"), "bar");
            Assert.True(test1.Equals((object)test2));

            var test3 = new Tuple<string, string>("foo", "bar");
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.False(test1.Equals((object)test3));
        }

        [Fact]
        public void NotEqualTest()
        {
            var test1 = new Column(new Table("foo"), "bar");
            var test2 = new Column(new Table("notfoo"), "bar");
            Assert.NotEqual(test1, test2);
        }
    }
}
