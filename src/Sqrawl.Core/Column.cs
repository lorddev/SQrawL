namespace Sqrawl.Core
{
    public class Column : ISelectable
    {
        private readonly Table _table;

        public Column(Table table, string columnName)
        {
            _table = table;
            Name = columnName;
        }

        public string Name { get; }

        public override string ToString()
        {
            return $"{_table.TableName}.{Name}";
        }
    }
}