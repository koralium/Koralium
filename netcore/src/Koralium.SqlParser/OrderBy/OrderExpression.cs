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
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;

namespace Koralium.SqlParser.OrderBy
{
    public class OrderExpression : OrderElement
    {
        public ScalarExpression Expression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitOrderExpression(this);
        }

        public override SqlNode Clone()
        {
            return new OrderExpression()
            {
                Ascending = Ascending,
                Expression = Expression.Clone() as ScalarExpression
            };
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Expression, Ascending);
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderExpression other)
            {
                return Equals(Expression, other.Expression) &&
                    Equals(Ascending, other.Ascending);
            }
            return false;
        }
    }
}
