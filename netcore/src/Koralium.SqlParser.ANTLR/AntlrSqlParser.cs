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
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Statements;
using System.Collections.Generic;

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

        public BooleanExpression ParseFilter(string text, out IReadOnlyList<SqlParserError> errors)
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

            var booleanExpression = parser.boolean_expression();

            errors = errorsListener.Errors;

            if (errors.Count > 0)
            {
                return null;
            }

            var visitor = new AntlrVisitor();

            var result = visitor.Visit(booleanExpression) as BooleanExpression;
            return result;
        }
    }
}
