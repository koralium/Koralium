parser grammar KoraliumParser;

options {
	tokenVocab = KoraliumLexer;
}

parse: (statements_list)* EOF;

statements_list: ';'* sql_statement (';'+ sql_statement)* ';'*;

sql_statement
	: set_variable_statement
	| select_statement
	;

set_variable_statement: SET variable_reference '=' (b64=BASE64_LITERAL | scalar_expression);


select_statement: (
  SELECT (DISTINCT)? select_expression (',' select_expression)*
	// START FROM
  (FROM from_clause
	(WHERE where_clause)?
	(GROUP BY groupby_clause)?
	(HAVING having_clause)?
	)?
	//END FROM
	(ORDER BY order_by_clause)? 
	(LIMIT limit=scalar_expression)? (OFFSET offset=scalar_expression)?
);

order_by_clause: order_by_element (',' order_by_element)*;

order_by_element: (scalar=scalar_expression | query=orderby_subquery) order=(ASC | DESC)?;

having_clause: boolean_expression;

from_clause: table_name (AS? table_alias)? | subquery;

table_name: any_name;
subquery: '(' select_statement ')' ( AS? table_alias)?;

orderby_subquery: '(' select_statement ')';
group_subquery: '(' select_statement ')';

variable_reference
	: variableName=VARIABLE_ID
	| identifier=IDENTIFIER
	;

select_expression
	: '*'
	| NULL
	| tableAlias=table_name '.' '*'
	| scalar_expression ( AS? column_alias)?
	;

where_clause: boolean_expression;

groupby_clause
	: groupby_element ( ',' groupby_element)*
	;

groupby_element
	:	scalar_expression
	| group_subquery
	;

boolean_expression
	: '!' boolean_expression
	| '(' inner=boolean_expression ')'
	| left=boolean_expression boolean_binary_type right=boolean_expression
	| predicate IS NOT isValue=(TRUE | FALSE)
	| predicate
;

predicate
	: boolean_comparison_expression
	| search_expression
	| function_call
	| in_expression
	| like_expression
	| is_null_predicate
	;

is_null_predicate: scalar_expression IS NOT? NULL;

search_expression: CONTAINS '(' (wildcard='*' | '(' column_reference (',' column_reference)* ')' | column_reference) ',' scalar_expression ')';

in_expression: element=in_left_scalar NOT? IN '(' scalar_expression (',' scalar_expression)* ')';

like_expression: element=in_left_scalar NOT? LIKE right=scalar_expression;

in_left_scalar: scalar_expression;

boolean_comparison_expression: (
	left=scalar_expression boolean_comparison_type right=scalar_expression
);

boolean_comparison_type: (
	'='
	| '>'
	| '<'
	| '>='
	| '<='
	| '!='
	| '<>'
	| '!<'
	| '!>'
);

boolean_binary_type: (
	AND
	| OR
);


column_alias: IDENTIFIER;

scalar_expression2: 
  | column_reference
  | literal_value
	| left=scalar_expression binary_operation_type right=scalar_expression
	| function_call
	| variable_reference
	;

scalar_expression
	: CAST '(' casted=scalar_expression AS castedidentifier=IDENTIFIER ')'
	| literal_value
	| column_reference
	| left=scalar_expression binary_operation_type right=scalar_expression
	| function_call
	| variable_reference
	;

error: ;

binary_expression: scalar_expression binary_operation_type scalar_expression;

binary_operation_type:
	'+'
	| '-'
	| '*'
	| '/'
	| '%'
	| '&'
	| '|'
	| '^'
	;

function_call
	: function_name '(' ((scalar_expression ( ',' scalar_expression)*) | '*')? ')'
	;

column_reference: column_name ('.' column_name)*;

literal_value:
	NUMERIC_LITERAL
	| STRING_LITERAL
	| NULL
	| TRUE
	| FALSE;

column_name: IDENTIFIER;

function_name: IDENTIFIER;

table_alias: any_name;

any_name:
	IDENTIFIER
	| STRING_LITERAL
	| '(' any_name ')';