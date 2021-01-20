/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlParser.Expressions
{
    public class ColumnReference : ScalarExpression
    {
        public List<string> Identifiers { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitColumnReference(this);
        }

        public override SqlNode Clone()
        {
            return new ColumnReference()
            {
                Identifiers = Identifiers.ToList()
            };
        }

        public ColumnReference()
        {
            Identifiers = new List<string>();
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();

            foreach(var identifier in Identifiers)
            {
                hashCode.Add(identifier);
            }
            return hashCode.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ColumnReference other)
            {
                return Identifiers.AreEqualCaseInsensitive(other.Identifiers);
            }
            return false;
        }
    }
}
