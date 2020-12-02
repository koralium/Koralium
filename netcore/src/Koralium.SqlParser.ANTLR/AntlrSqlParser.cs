using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Koralium.SqlParser.Errors;
using Koralium.SqlParser.Statements;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.ANTLR
{
    public class AntlrSqlParser : ISqlParser
    {
        public StatementList Parse(string text, out IReadOnlyList<SqlParserError> errors)
        {
            ICharStream stream = CharStreams.fromstring(text);
            stream = new CaseChangingCharStream(stream);

            ITokenSource lexer = new KoraliumLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            KoraliumParser parser = new KoraliumParser(tokens)
            {
                BuildParseTree = true
            };

            var errorsListener = new AntlrErrorListener();
            parser.AddErrorListener(errorsListener);

            var stmnt = parser.statements_list();

            errors = errorsListener.Errors;

            if(errors.Count > 0)
            {
                return new StatementList();
            }

            var visitor = new AntlrVisitor();

            var statements = visitor.Visit(stmnt) as List<Statement>;

            return new StatementList() 
            {
                Statements = statements
            };
        }

        public StatementList Parse(string text)
        {
            return Parse(text, out _);
        }
    }
}
