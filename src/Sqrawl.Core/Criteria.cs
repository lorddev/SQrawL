using System;

namespace Sqrawl.Core
{
    public class Criteria<T>
    {
        private T _matchValue;
        private readonly SelectQuery _query;
        private readonly Column _target;

        internal Criteria(SelectQuery query, Column target)
        {
            _query = query;
            _target = target;
        }

        // TODO: Need to rename this so it doesn't get confused with Object.Equals()
        public SelectQuery Equals(T value)
        {
            _matchValue = value;
            _query.Criteria.Add($"@{_target.Name.ToLowerInvariant()}_{Guid.NewGuid().ToString("N").Substring(0, 8)}", value);
            return _query;
        }
    }

    public static class CriteriaExtensions
    {
        public static Criteria<T> Where<T>(this Table table, Column column)
        {
            return new Criteria<T>(table.Query, column);
        }
    }
}