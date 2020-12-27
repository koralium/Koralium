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

namespace Koralium.SqlParser.Expressions
{
    public class BinaryExpression : ScalarExpression
    {
        public ScalarExpression Left { get; set; }

        public ScalarExpression Right { get; set; }

        public BinaryType Type { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBinaryExpression(this);
        }

        public override SqlNode Clone()
        {
            return new BinaryExpression()
            {
                Left = Left.Clone() as ScalarExpression,
                Right = Right.Clone() as ScalarExpression,
                Type = Type
            };
        }
    }
}
