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
using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlParser.Clauses
{
    public class OrderByClause : SqlNode
    {
        public List<OrderElement> OrderExpressions { get; set; }

        public OrderByClause()
        {
            OrderExpressions = new List<OrderElement>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitOrderByClause(this);
        }

        public override SqlNode Clone()
        {
            return new OrderByClause()
            {
                OrderExpressions = OrderExpressions.Select(x => x.Clone() as OrderElement).ToList()
            };
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            foreach (var o in OrderExpressions)
            {
                hashCode.Add(o);
            }
            return hashCode.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderByClause other)
            {
                return OrderExpressions.AreEqual(other.OrderExpressions);
            }
            return false;
        }
    }
}
