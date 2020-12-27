lexer grammar KoraliumLexer;

SCOL: ';';
DOT: '.';
OPEN_PAR: '(';
CLOSE_PAR: ')';
COMMA: ',';
ASSIGN: '=';
STAR: '*';
PLUS: '+';
MINUS: '-';
TILDE: '~';
PIPE2: '||';
DIV: '/';
MOD: '%';
LT2: '<<';
GT2: '>>';
AMP: '&';
PIPE: '|';
LT: '<';
LT_EQ: '<=';
GT: '>';
GT_EQ: '>=';
EQ: '==';
NOT_EQ1: '!=';
NOT_EQ2: '<>';
NLT: '!<';
NGT: '!>';
XOR: '^';
EXCLAMATION: '!';

SELECT: 'SELECT';
DISTINCT: 'DISTINCT';
FROM: 'FROM';
AS: 'AS';
NULL: 'NULL';
TRUE: 'TRUE';
FALSE: 'FALSE';
WHERE: 'WHERE';
AND: 'AND';
OR: 'OR';
IS: 'IS';
NOT: 'NOT';
LIKE: 'LIKE';
GROUP: 'GROUP';
BY: 'BY';
HAVING: 'HAVING';
IN: 'IN';
ORDER: 'ORDER';
ASC: 'ASC';
DESC: 'DESC';
LIMIT: 'LIMIT';
OFFSET: 'OFFSET';
SET: 'SET';
CONTAINS: 'CONTAINS';
CAST: 'CAST';

SPACES: [ \u000B\t\r\n] -> channel(HIDDEN);

IDENTIFIER:
	'"' (~'"' | '""')* '"'
	| '`' (~'`' | '``')* '`'
	| '[' ~']'* ']'
	| [a-zA-Z_] [a-zA-Z_0-9]*;

COMMENT
  :  '--' ~( '\r' | '\n' )*
  ;

BASE64_LITERAL: 'B64' STRING_LITERAL;

STRING_LITERAL: '\'' ( ~'\'' | '\'\'')* '\'';

VARIABLE_ID: '@' [a-zA-Z_] [a-zA-Z_0-9]*;

NUMERIC_LITERAL:
	'-'? ((DIGIT+ ('.' DIGIT*)?) | ('.' DIGIT+)) ('E' [-+]? DIGIT+)?;

fragment DIGIT: [0-9];