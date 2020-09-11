using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Update.Internal
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
