using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Koralium.SqlParser.Errors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
