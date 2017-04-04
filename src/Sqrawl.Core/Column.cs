// <copyright file="Column.cs" company="Devlords Cooperative">
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
using System.Text;

#pragma warning disable S1450 // Always a false positive. I've posted in Sonar Google Group about it.

namespace Devlord.Sqrawl
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

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"{_table.TableName}.{Name}";
        }

        public void AddReferencedTablesTo(List<Table> tables)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// How this entity writes itself to your query.
        /// </summary>
        /// <param name="output"></param>
        public void Write(StringBuilder output)
        {
            output.Append(this);
        }
    }
}