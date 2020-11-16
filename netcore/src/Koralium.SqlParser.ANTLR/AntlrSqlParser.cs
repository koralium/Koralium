using Antlr4.Runtime;
using Koralium.SqlParser.Statements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.ANTLR
{
    public class AntlrSqlParser : ISqlParser
    {
        public StatementList Parse(string sql)
        {
            ICharStream stream = CharStreams.fromstring(sql);
            stream = new CaseChangingCharStream(stream);

            ITokenSource lexer = new KoraliumLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            KoraliumParser parser = new KoraliumParser(tokens)
            {
                BuildParseTree = true,
            };

            var stmnt = parser.statements_list();

            var visitor = new AntlrVisitor();

            var statements = visitor.Visit(stmnt) as List<Statement>;

            return new StatementList() 
            {
                Statements = statements
            };
        }
    }
}
