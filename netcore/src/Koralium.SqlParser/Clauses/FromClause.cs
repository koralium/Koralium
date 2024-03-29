﻿/*
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
using Koralium.SqlParser.From;
using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Clauses
{
    public class FromClause : SqlNode
    {
        public TableReference TableReference { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitFromClause(this);
        }

        public override SqlNode Clone()
        {
            return new FromClause()
            {
                TableReference = TableReference.Clone() as TableReference
            };
        }

        public override int GetHashCode()
        {
            return TableReference.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is FromClause other)
            {
                return Equals(TableReference, other.TableReference);
            }
            return false;
        }
    }
}
