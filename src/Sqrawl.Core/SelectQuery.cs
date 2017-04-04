using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqrawl.Core
{
    public class SelectQuery
    {
        private readonly List<ISelectable> _selection = new List<ISelectable>();
        private readonly Dictionary<string, Table> _tables = new Dictionary<string, Table>();

        internal Dictionary<string, object> Criteria = new Dictionary<string, object>();

        public void AddColumn(Table table, string columnName)
        {
            if (table.Query == null)
            {
                table.Query = this;
            }
            else if (table.Query != this)
            {
                throw new InvalidOperationException("This table instance belongs to another query.");
            }

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