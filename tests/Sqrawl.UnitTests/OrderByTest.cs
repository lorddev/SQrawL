using Xunit;
using Xunit.Abstractions;

namespace Devlord.Sqrawl.UnitTests
{
    public class OrderByTest
    {
        public OrderByTest(ITestOutputHelper output)
        {
            _output = output;
        }
        
        private readonly ITestOutputHelper _output;

        [Fact]
        public void TestOrderByAscending()
        {
            const string expects = @"select foo.bar from foo order by foo.bar";
            _output.WriteLine($"expects: {expects}");
            var target = new SelectQuery();
            var table = new Table("foo");
            var column = target.AddColumn(table, "bar");
            table.OrderBy(column, SortOrder.Ascending);
            var actual = target.ToString();
            _output.WriteLine($"actual:  {actual}");
            actual.ShouldResemble(expects);
        }
    }
}