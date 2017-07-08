// <copyright file="SelectQuery.cs" company="Devlords Cooperative">
// SQrawL is Open Source!
// Copyright © 2017 Lord Design
// Inspired by Java Squiggle library Copyright © 2004 Joe Walnes joe@truemesh.com
// </copyright>
// <license type="GPL">
// * This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public 
//   License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later 
//   version. 
// * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
//   warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
// * You should have received a copy of the GNU General Public License along with this program.  If you've misplaced it, 
//   check out http://www.gnu.org/licenses/
// </license>
// <author>Aaron Lord</author>
// <date>03/13/2017</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#pragma warning disable S1450 // Always a false positive. I've posted in Sonar Google Group about it.

namespace Devlord.Sqrawl
{
    public class SelectQuery
    {
        private readonly List<ISelectable> _selection = new List<ISelectable>();

        private readonly Dictionary<string, Table> _tables = new Dictionary<string, Table>();

        internal List<Criteria> Criteria = new List<Criteria>();

        public OrderBy OrderBy { get; set; }

        public Column AddColumn(Table table, string columnName)
        {
            if (table.Query == null)
            {
                table.Query = this;
            }
            else if (table.Query != this)
            {
                throw new InvalidOperationException("This table instance belongs to another query.");
            }

            var column = new Column(table, columnName);
            _selection.Add(column);
            if (!_tables.ContainsKey(table.Name))
            {
                _tables.Add(table.Name, table);
            }

            return column;
        }

        public override string ToString()
        {
            var query = new StringBuilder("SELECT ");
            query.Append(string.Join(",\r\n", _selection.Select(s => s.ToString())));
            query.Append(" FROM ");

            // Todo: "ON" is required here.
            query.Append(string.Join(" JOIN ", _tables.Keys));

            //foreach (var table in _tables)
            //{
            //    if (table)
            ////}

            for (int i = 0; i < Criteria.Count; i++)
            {
                if (i == 0)
                {
                    query.Append(" WHERE ");
                }

                var item = Criteria.ElementAt(i);
                query.Append(item.Target).Append(" = ").Append(item.ParameterName);
            }
            
            
            OrderBy?.Write(query);

            return query.ToString();
        }

        public void AddOrderBy(Column column, SortOrder order)
        {
            if (OrderBy == null)
            {
                OrderBy = new OrderBy();
            }

            OrderBy.AddOrderBy(column, order);
        }
    }
}