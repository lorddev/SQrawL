using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqrawl.Core
{
    public class SelectQuery
    {
        private List<ISelectable> _selection = new List<ISelectable>();
        private Dictionary<string, Table> _tables = new Dictionary<string, Table>();

        public void AddColumn(Table table, string columnName)
        {
            _selection.Add(new Column(table, columnName));
            if (!_tables.ContainsKey(table.TableName))
            {
                _tables.Add(table.TableName, table);
            }
        }

        public override string ToString()
        {
            var query = new StringBuilder("SELECT ");
            query.Append(string.Join(",\r\n", _selection.Select(s => s.ToString())));
            query.Append(" FROM ");
            query.Append(string.Join(" JOIN ", _tables.Keys));
            return query.ToString();
        }
    }
}
