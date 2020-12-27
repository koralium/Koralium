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
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlParser.Expressions
{
    public class SearchExpression : BooleanExpression
    {
        /// <summary>
        /// Set if all possible columns should be searched, (wildcard)
        /// </summary>
        public bool AllColumns { get; set; }

        public List<ColumnReference> Columns { get; set; }

        public ScalarExpression Value { get; set; }

        public SearchExpression()
        {
            Columns = new List<ColumnReference>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSearchExpression(this);
        }

        public override SqlNode Clone()
        {
            return new SearchExpression()
            {
                AllColumns = AllColumns,
                Columns = Columns.Select(x => x.Clone() as ColumnReference).ToList(),
                Value = Value.Clone() as ScalarExpression
            };
        }
    }
}
