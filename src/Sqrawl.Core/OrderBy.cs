// <copyright file="OrderBy.cs" company="Devlords Cooperative">
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
// <date>04/03/2017</date>

using System;
using System.Collections.Generic;
using System.Text;

namespace Devlord.Sqrawl
{
    public class OrderBy : IQueryOutput
    {
        private Dictionary<Column, SortOrder> _orderBy;
        public void AddOrderBy(Column column, SortOrder order)
        {
            if (_orderBy.IsNullOrEmpty())
            {
                _orderBy = new Dictionary<Column, SortOrder> { { column, order } };
            }

            if (_orderBy.ContainsKey(column))
            {
                _orderBy[column] = order;
            }
            else
            {
                _orderBy.Add(column, order);
            }
        }
        
        public void Write(StringBuilder output)
        {
            output.Append("order by ");

            int index = 0;
            foreach (var pair in _orderBy)
            {
                pair.Key.Write(output);
                if (pair.Value == SortOrder.Descending)
                {
                    output.Append(" desc");
                }

                if (index < _orderBy.Count - 1)
                {
                    output.Append(", ");
                }
            }
            
        }

        public void AddReferencedTablesTo(List<Table> tables)
        {
           throw new NotImplementedException();
        }

        public string ToString(IQueryOutput output)
        {
            return output.ToString();
        }
    }
}