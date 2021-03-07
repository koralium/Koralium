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

namespace Koralium.SqlParser.Literals
{
    public class BooleanLiteral : Literal
    {
        public bool Value { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBooleanLiteral(this);
        }

        public override SqlNode Clone()
        {
            return new BooleanLiteral()
            {
                Value = Value
            };
        }

        public override object GetValue()
        {
            return Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is BooleanLiteral other)
            {
                return Equals(Value, other.Value);
            }
            return false;
        }
    }
}
