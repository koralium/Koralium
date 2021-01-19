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

namespace Koralium.SqlParser.OrderBy
{
    public class OrderBySubquery : OrderElement
    {
        public SelectStatement SelectStatement { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitOrderBySubquery(this);
        }

        public override SqlNode Clone()
        {
            return new OrderBySubquery()
            {
                Ascending = Ascending,
                SelectStatement = SelectStatement.Clone() as SelectStatement
            };
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SelectStatement, Ascending);
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderBySubquery other)
            {
                return Equals(SelectStatement, other.SelectStatement) &&
                    Equals(Ascending, other.Ascending);
            }
            return false;
        }
    }
}
