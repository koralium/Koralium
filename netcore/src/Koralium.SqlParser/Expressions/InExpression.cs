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
    public class InExpression : BooleanExpression
    {
        public ScalarExpression Expression{ get; set; }

        public List<ScalarExpression> Values { get; set; }

        /// <summary>
        /// Is it a NOT IN?
        /// </summary>
        public bool Not { get; set; }

        public InExpression()
        {
            Values = new List<ScalarExpression>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitInExpression(this);
        }

        public override SqlNode Clone()
        {
            return new InExpression()
            {
                Expression = Expression.Clone() as ScalarExpression,
                Not = Not,
                Values = Values.Select(x => x.Clone() as ScalarExpression).ToList()
            };
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Not);
            hashCode.Add(Expression);

            foreach (var value in Values)
            {
                hashCode.Add(value);
            }
            return hashCode.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is InExpression other)
            {
                return Equals(Not, other.Not) &&
                    Equals(Expression, other.Expression) &&
                    Values.AreEqual(other.Values);
            }
            return false;
        }
    }
}
