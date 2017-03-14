using Sqrawl.Core;
using Xunit;

namespace Sqrawl.UnitTests
{
    public class SimpleSelectTest
    {
        [Fact]
        public void TestSimpleSelect()
        {
            var expects = @"select tables.bobby from tables";
            var query1 = new SelectQuery();
            var table = new Table("tables");
            query1.AddColumn(table, "bobby");
            var actual = query1.ToString();
            actual.ShouldApproximate(expects);
        }
    }
}
