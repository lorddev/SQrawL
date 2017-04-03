using System.Collections.Generic;

namespace Sqrawl.Core
{
    public class Table
    {
        public Table(string tableName)
        {
            TableName = tableName;
        }

        public Dictionary<string, Column> Columns { get; set; }
        public string TableName { get; }

        internal SelectQuery Query { get; set; }

        public override string ToString()
        {
            return TableName;
        }
    }
}
