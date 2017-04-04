using Xunit;

namespace Devlord.Sqrawl.UnitTests
{
    public class TableTest
    {
        [Fact]
        public void TestTableGenerator()
        {
            var expected = "foo";
            var target = new Table("foo");
            var actual = target.ToString();
            actual.ShouldEqual(expected);
        }
    }
}