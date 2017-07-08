using System;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using Xunit.Abstractions;

namespace Devlord.Sqrawl.UnitTests
{
    public class WhereTest
    {
        public WhereTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private readonly ITestOutputHelper _output;

        [Fact]
        public void TestSimpleWhere()
        {
            var expects = @"select tables.bobby from tables where tables.bobby = @bobby_ph0";
            _output.WriteLine($"expects: {expects}");
            var query1 = new SelectQuery();
            var table = new Table("tables");
            query1.AddColumn(table, "bobby")
                .Where<int>()
                .Matches(1);
            var actual = query1.ToString();
            _output.WriteLine($"actual: {actual}");
            actual.ShouldResemble(expects);
        }
    }
}