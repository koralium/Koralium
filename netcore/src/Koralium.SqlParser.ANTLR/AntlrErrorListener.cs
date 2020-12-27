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
