// <copyright file="Table.cs" company="Devlords Cooperative">
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

using System.Collections.Generic;

namespace Devlord.Sqrawl
{
    public class Table
    {
        public Table(string name)
        {
            Name = name;
        }

        public Dictionary<string, Column> Columns { get; set; }
        public string Name { get; }

        internal SelectQuery Query { get; set; }

        public override string ToString()
        {
            return Name;
        }


        public SelectQuery OrderBy(Column column, SortOrder order)
        {
            Query.AddOrderBy(column, order);
            return Query;
        }
    }
}