using System;
using System.Collections.Generic;
using System.Text;

namespace Sqrawl.Core
{
    public class Column : ISelectable
    {
        private readonly Table _table;
        private readonly string _columnName;
        
        public Column(Table table, string columnName)
        {
            _table = table;
            _columnName = columnName;
        }

        public override string ToString()
        {
            return $"{_table.TableName}.{_columnName}";
        }
    }
}
