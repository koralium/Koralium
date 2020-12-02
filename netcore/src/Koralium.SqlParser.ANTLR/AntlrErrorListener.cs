using Antlr4.Runtime;
using Koralium.SqlParser.Errors;
using System.Collections.Generic;
using System.IO;

namespace Koralium.SqlParser.ANTLR
{
    internal class AntlrErrorListener : BaseErrorListener
    {
        private readonly List<SqlParserError> _errors = new List<SqlParserError>();

        public IReadOnlyList<SqlParserError> Errors => _errors;

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            _errors.Add(new SqlParserError(msg));
        }
    }
}
