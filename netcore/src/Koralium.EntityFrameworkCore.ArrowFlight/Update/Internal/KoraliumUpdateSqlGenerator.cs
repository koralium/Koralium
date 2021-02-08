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
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Text;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Update.Internal
{
    public class KoraliumUpdateSqlGenerator : UpdateSqlGenerator
    {
        public KoraliumUpdateSqlGenerator(UpdateSqlGeneratorDependencies dependencies) : base(dependencies)
        {
        }

        protected override void AppendIdentityWhereCondition(StringBuilder commandStringBuilder, ColumnModification columnModification)
        {
            throw new NotImplementedException();
        }

        protected override ResultSetMapping AppendSelectAffectedCountCommand(
            StringBuilder commandStringBuilder, string name, string schema, int commandPosition)
        {

            commandStringBuilder
                .Append("SELECT changes()")
                .AppendLine(SqlGenerationHelper.StatementTerminator)
                .AppendLine();

            return ResultSetMapping.LastInResultSet;
        }

        protected override void AppendRowsAffectedWhereCondition(StringBuilder commandStringBuilder, int expectedRowsAffected)
        {
            throw new NotImplementedException();
        }
    }
}
