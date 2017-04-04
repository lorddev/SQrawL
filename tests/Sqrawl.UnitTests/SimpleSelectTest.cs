using Xunit;
using Xunit.Abstractions;

namespace Devlord.Sqrawl.UnitTests
{
    public class SimpleSelectTest
    {
        public SimpleSelectTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private readonly ITestOutputHelper _output;

        [Fact]
        public void TestSimpleSelect()
        {
            var expects = @"select tables.bobby from tables";
            _output.WriteLine($"expects: {expects}");
            var query1 = new SelectQuery();
            var table = new Table("tables");
            query1.AddColumn(table, "bobby");
            var actual = query1.ToString();
            _output.WriteLine($"actual: {actual}");
            actual.ShouldResemble(expects);
        }
    }
}