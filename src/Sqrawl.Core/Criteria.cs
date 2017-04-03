using System;
using System.Collections.Generic;
using System.Text;

namespace Sqrawl.Core
{
    public class Criteria<T>
    {
        private Column<T> _target;
        private T _matchValue;
        private SelectQuery _query;

        internal Criteria(SelectQuery query, Column<T> target)
        {
            _query = query;
            _target = target;
        }

        public SelectQuery Equals(T value)
        {
            _matchValue = value;
            _query.Criteria.Add($"@{_target.Name.ToLower()}_{Guid.NewGuid().ToString("N").Substring(0, 8)}", value);
            return _query;
        }
    }

     public class Column<T> { }

    public static class CriteriaExtensions
    {
        public static Criteria<T> Where<T>(this Table table, Column<T> column)
        {
            return new Criteria<T>(table.Query, column);
        }
    }
}
