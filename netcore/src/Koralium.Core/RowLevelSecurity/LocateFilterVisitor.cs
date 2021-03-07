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
using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;

namespace Koralium.Core.RowLevelSecurity
{
    class LocateFilterVisitor : KoraliumSqlVisitor
    {
        private readonly BooleanExpression _toFind;
        public bool Exists { get; private set; } = false;

        public LocateFilterVisitor(BooleanExpression toFind)
        {
            _toFind = toFind;
        }

        public override void Visit(SqlNode sqlNode)
        {
            if (Equals(_toFind, sqlNode))
            {
                Exists = true;
                return;
            }
            base.Visit(sqlNode);
        }

        public override void VisitBooleanBinaryExpression(BooleanBinaryExpression booleanBinaryExpression)
        {
            if( booleanBinaryExpression.Type == BooleanBinaryType.AND)
            {
                //Only go deeper if we are in an AND
                base.VisitBooleanBinaryExpression(booleanBinaryExpression);
            }
        }
    }
}
