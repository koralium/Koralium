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
using Koralium.SqlParser.From;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.RowLevelSecurity
{
    /// <summary>
    /// Visitor that only locates which table is involved.
    /// </summary>
    class TableLocatorVisitor : KoraliumSqlVisitor
    {
        public string TableName { get; private set; }
        public string Alias { get; private set; }

        public override void VisitFromTableReference(FromTableReference fromTableReference)
        {
            TableName = fromTableReference.TableName;
            Alias = fromTableReference.Alias;
        }

        public override void VisitSelectStatement(SelectStatement selectStatement)
        {
            //Only visit the from clause to skip checking uneccessary nodes
            Visit(selectStatement.FromClause);
        }
    }
}
