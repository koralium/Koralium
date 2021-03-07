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
    public class CastExpression : ScalarExpression
    {
        public ScalarExpression ScalarExpression { get; set; }

        public string ToType { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitCastExpression(this);
        }

        public override SqlNode Clone()
        {
            return new CastExpression()
            {
                ScalarExpression = ScalarExpression.Clone() as ScalarExpression,
                ToType = ToType
            };
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ScalarExpression, ToType);
        }

        public override bool Equals(object obj)
        {
            if (obj is CastExpression other)
            {
                return Equals(ScalarExpression, other.ScalarExpression) &&
                    Equals(ToType, other.ToType);
            }
            return false;
        }
    }
}
