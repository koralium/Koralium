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

namespace Koralium.SqlParser.Expressions
{
    public class BetweenExpression : BooleanExpression
    {
        public ScalarExpression Expression { get; set; }

        public ScalarExpression From { get; set; }

        public ScalarExpression To { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBetweenExpression(this);
        }

        public override SqlNode Clone()
        {
            return new BetweenExpression()
            {
                Expression = Expression.Clone() as ScalarExpression,
                From = From.Clone() as ScalarExpression,
                To = To.Clone() as ScalarExpression
            };
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Expression, From, To);
        }

        public override bool Equals(object obj)
        {
            if (obj is BetweenExpression other)
            {
                return Equals(Expression, other.Expression) &&
                    Equals(From, other.From) &&
                    Equals(To, other.To);
            }
            return false;
        }
    }
}
