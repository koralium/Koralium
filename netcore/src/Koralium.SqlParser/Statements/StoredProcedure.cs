using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.SqlParser.Statements
{
    public class StoredProcedure : Statement
    {
        public string ProcedureName { get; set; }

        public List<SetVariableStatement> Variables { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override SqlNode Clone()
        {
            return new StoredProcedure()
            {
                ProcedureName = ProcedureName,
                Variables = Variables.Select(x => x.Clone() as SetVariableStatement).ToList()
            };
        }
    }
}
