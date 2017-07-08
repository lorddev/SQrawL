// <copyright file="Criteria.cs" company="Devlords Cooperative">
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
// <date>03/14/2017</date>

using System;

namespace Devlord.Sqrawl
{
    public abstract class Criteria
    {
        public Column Target { get; protected set; }

        public string ParameterName { get; protected set; }
    }

    public class Criteria<T> : Criteria
    {
        private readonly SelectQuery _query;
        private T _matchValue;
        
        internal Criteria(SelectQuery query, Column target)
        {
            _query = query;
            Target = target;
            ParameterName = $"@{Target.Name.ToLowerInvariant()}_{Math.Abs(Target.GetHashCode())}";
        }
        
        public SelectQuery Matches(T value)
        {
            _matchValue = value;
            _query.Criteria.Add(this);
            return _query;
        }
    }
}