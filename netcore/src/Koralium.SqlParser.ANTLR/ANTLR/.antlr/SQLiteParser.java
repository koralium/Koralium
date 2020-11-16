// Generated from c:\Dev\Koralium.SqlParser\Koralium.SqlParser.ANTLR\ANTLR\SQLiteParser.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class SQLiteParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		SCOL=1, DOT=2, OPEN_PAR=3, CLOSE_PAR=4, COMMA=5, ASSIGN=6, STAR=7, PLUS=8, 
		MINUS=9, TILDE=10, PIPE2=11, DIV=12, MOD=13, LT2=14, GT2=15, AMP=16, PIPE=17, 
		LT=18, LT_EQ=19, GT=20, GT_EQ=21, EQ=22, NOT_EQ1=23, NOT_EQ2=24, ABORT=25, 
		ACTION=26, ADD=27, AFTER=28, ALL=29, ALTER=30, ANALYZE=31, AND=32, AS=33, 
		ASC=34, ATTACH=35, AUTOINCREMENT=36, BEFORE=37, BEGIN=38, BETWEEN=39, 
		BY=40, CASCADE=41, CASE=42, CAST=43, CHECK=44, COLLATE=45, COLUMN=46, 
		COMMIT=47, CONFLICT=48, CONSTRAINT=49, CREATE=50, CROSS=51, CURRENT_DATE=52, 
		CURRENT_TIME=53, CURRENT_TIMESTAMP=54, DATABASE=55, DEFAULT=56, DEFERRABLE=57, 
		DEFERRED=58, DELETE=59, DESC=60, DETACH=61, DISTINCT=62, DROP=63, EACH=64, 
		ELSE=65, END=66, ESCAPE=67, EXCEPT=68, EXCLUSIVE=69, EXISTS=70, EXPLAIN=71, 
		FAIL=72, FOR=73, FOREIGN=74, FROM=75, FULL=76, GLOB=77, GROUP=78, HAVING=79, 
		IF=80, IGNORE=81, IMMEDIATE=82, IN=83, INDEX=84, INDEXED=85, INITIALLY=86, 
		INNER=87, INSERT=88, INSTEAD=89, INTERSECT=90, INTO=91, IS=92, ISNULL=93, 
		JOIN=94, KEY=95, LEFT=96, LIKE=97, LIMIT=98, MATCH=99, NATURAL=100, NO=101, 
		NOT=102, NOTNULL=103, NULL_=104, OF=105, OFFSET=106, ON=107, OR=108, ORDER=109, 
		OUTER=110, PLAN=111, PRAGMA=112, PRIMARY=113, QUERY=114, RAISE=115, RECURSIVE=116, 
		REFERENCES=117, REGEXP=118, REINDEX=119, RELEASE=120, RENAME=121, REPLACE=122, 
		RESTRICT=123, RIGHT=124, ROLLBACK=125, ROW=126, ROWS=127, SAVEPOINT=128, 
		SELECT=129, SET=130, TABLE=131, TEMP=132, TEMPORARY=133, THEN=134, TO=135, 
		TRANSACTION=136, TRIGGER=137, UNION=138, UNIQUE=139, UPDATE=140, USING=141, 
		VACUUM=142, VALUES=143, VIEW=144, VIRTUAL=145, WHEN=146, WHERE=147, WITH=148, 
		WITHOUT=149, FIRST_VALUE=150, OVER=151, PARTITION=152, RANGE=153, PRECEDING=154, 
		UNBOUNDED=155, CURRENT=156, FOLLOWING=157, CUME_DIST=158, DENSE_RANK=159, 
		LAG=160, LAST_VALUE=161, LEAD=162, NTH_VALUE=163, NTILE=164, PERCENT_RANK=165, 
		RANK=166, ROW_NUMBER=167, GENERATED=168, ALWAYS=169, STORED=170, TRUE_=171, 
		FALSE_=172, WINDOW=173, NULLS=174, FIRST=175, LAST=176, FILTER=177, GROUPS=178, 
		EXCLUDE=179, TIES=180, OTHERS=181, DO=182, NOTHING=183, IDENTIFIER=184, 
		NUMERIC_LITERAL=185, BIND_PARAMETER=186, STRING_LITERAL=187, BLOB_LITERAL=188, 
		SINGLE_LINE_COMMENT=189, MULTILINE_COMMENT=190, SPACES=191, UNEXPECTED_CHAR=192;
	public static final int
		RULE_parse = 0, RULE_error = 1, RULE_sql_stmt_list = 2, RULE_sql_stmt = 3, 
		RULE_alter_table_stmt = 4, RULE_analyze_stmt = 5, RULE_attach_stmt = 6, 
		RULE_begin_stmt = 7, RULE_commit_stmt = 8, RULE_rollback_stmt = 9, RULE_savepoint_stmt = 10, 
		RULE_release_stmt = 11, RULE_create_index_stmt = 12, RULE_indexed_column = 13, 
		RULE_create_table_stmt = 14, RULE_column_def = 15, RULE_type_name = 16, 
		RULE_column_constraint = 17, RULE_signed_number = 18, RULE_table_constraint = 19, 
		RULE_foreign_key_clause = 20, RULE_conflict_clause = 21, RULE_create_trigger_stmt = 22, 
		RULE_create_view_stmt = 23, RULE_create_virtual_table_stmt = 24, RULE_with_clause = 25, 
		RULE_cte_table_name = 26, RULE_recursive_cte = 27, RULE_common_table_expression = 28, 
		RULE_delete_stmt = 29, RULE_delete_stmt_limited = 30, RULE_detach_stmt = 31, 
		RULE_drop_stmt = 32, RULE_expr = 33, RULE_raise_function = 34, RULE_literal_value = 35, 
		RULE_insert_stmt = 36, RULE_upsert_clause = 37, RULE_pragma_stmt = 38, 
		RULE_pragma_value = 39, RULE_reindex_stmt = 40, RULE_select_stmt = 41, 
		RULE_join_clause = 42, RULE_select_core = 43, RULE_factored_select_stmt = 44, 
		RULE_simple_select_stmt = 45, RULE_compound_select_stmt = 46, RULE_table_or_subquery = 47, 
		RULE_result_column = 48, RULE_join_operator = 49, RULE_join_constraint = 50, 
		RULE_compound_operator = 51, RULE_update_stmt = 52, RULE_column_name_list = 53, 
		RULE_update_stmt_limited = 54, RULE_qualified_table_name = 55, RULE_vacuum_stmt = 56, 
		RULE_filter_clause = 57, RULE_window_defn = 58, RULE_over_clause = 59, 
		RULE_frame_spec = 60, RULE_frame_clause = 61, RULE_simple_function_invocation = 62, 
		RULE_aggregate_function_invocation = 63, RULE_window_function_invocation = 64, 
		RULE_common_table_stmt = 65, RULE_order_by_stmt = 66, RULE_limit_stmt = 67, 
		RULE_ordering_term = 68, RULE_asc_desc = 69, RULE_frame_left = 70, RULE_frame_right = 71, 
		RULE_frame_single = 72, RULE_window_function = 73, RULE_offset = 74, RULE_default_value = 75, 
		RULE_partition_by = 76, RULE_order_by_expr = 77, RULE_order_by_expr_asc_desc = 78, 
		RULE_expr_asc_desc = 79, RULE_initial_select = 80, RULE_recursive_select = 81, 
		RULE_unary_operator = 82, RULE_error_message = 83, RULE_module_argument = 84, 
		RULE_column_alias = 85, RULE_keyword = 86, RULE_name = 87, RULE_function_name = 88, 
		RULE_schema_name = 89, RULE_table_name = 90, RULE_table_or_index_name = 91, 
		RULE_new_table_name = 92, RULE_column_name = 93, RULE_collation_name = 94, 
		RULE_foreign_table = 95, RULE_index_name = 96, RULE_trigger_name = 97, 
		RULE_view_name = 98, RULE_module_name = 99, RULE_pragma_name = 100, RULE_savepoint_name = 101, 
		RULE_table_alias = 102, RULE_transaction_name = 103, RULE_window_name = 104, 
		RULE_alias = 105, RULE_filename = 106, RULE_base_window_name = 107, RULE_simple_func = 108, 
		RULE_aggregate_func = 109, RULE_table_function_name = 110, RULE_any_name = 111;
	private static String[] makeRuleNames() {
		return new String[] {
			"parse", "error", "sql_stmt_list", "sql_stmt", "alter_table_stmt", "analyze_stmt", 
			"attach_stmt", "begin_stmt", "commit_stmt", "rollback_stmt", "savepoint_stmt", 
			"release_stmt", "create_index_stmt", "indexed_column", "create_table_stmt", 
			"column_def", "type_name", "column_constraint", "signed_number", "table_constraint", 
			"foreign_key_clause", "conflict_clause", "create_trigger_stmt", "create_view_stmt", 
			"create_virtual_table_stmt", "with_clause", "cte_table_name", "recursive_cte", 
			"common_table_expression", "delete_stmt", "delete_stmt_limited", "detach_stmt", 
			"drop_stmt", "expr", "raise_function", "literal_value", "insert_stmt", 
			"upsert_clause", "pragma_stmt", "pragma_value", "reindex_stmt", "select_stmt", 
			"join_clause", "select_core", "factored_select_stmt", "simple_select_stmt", 
			"compound_select_stmt", "table_or_subquery", "result_column", "join_operator", 
			"join_constraint", "compound_operator", "update_stmt", "column_name_list", 
			"update_stmt_limited", "qualified_table_name", "vacuum_stmt", "filter_clause", 
			"window_defn", "over_clause", "frame_spec", "frame_clause", "simple_function_invocation", 
			"aggregate_function_invocation", "window_function_invocation", "common_table_stmt", 
			"order_by_stmt", "limit_stmt", "ordering_term", "asc_desc", "frame_left", 
			"frame_right", "frame_single", "window_function", "offset", "default_value", 
			"partition_by", "order_by_expr", "order_by_expr_asc_desc", "expr_asc_desc", 
			"initial_select", "recursive_select", "unary_operator", "error_message", 
			"module_argument", "column_alias", "keyword", "name", "function_name", 
			"schema_name", "table_name", "table_or_index_name", "new_table_name", 
			"column_name", "collation_name", "foreign_table", "index_name", "trigger_name", 
			"view_name", "module_name", "pragma_name", "savepoint_name", "table_alias", 
			"transaction_name", "window_name", "alias", "filename", "base_window_name", 
			"simple_func", "aggregate_func", "table_function_name", "any_name"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "';'", "'.'", "'('", "')'", "','", "'='", "'*'", "'+'", "'-'", 
			"'~'", "'||'", "'/'", "'%'", "'<<'", "'>>'", "'&'", "'|'", "'<'", "'<='", 
			"'>'", "'>='", "'=='", "'!='", "'<>'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SCOL", "DOT", "OPEN_PAR", "CLOSE_PAR", "COMMA", "ASSIGN", "STAR", 
			"PLUS", "MINUS", "TILDE", "PIPE2", "DIV", "MOD", "LT2", "GT2", "AMP", 
			"PIPE", "LT", "LT_EQ", "GT", "GT_EQ", "EQ", "NOT_EQ1", "NOT_EQ2", "ABORT", 
			"ACTION", "ADD", "AFTER", "ALL", "ALTER", "ANALYZE", "AND", "AS", "ASC", 
			"ATTACH", "AUTOINCREMENT", "BEFORE", "BEGIN", "BETWEEN", "BY", "CASCADE", 
			"CASE", "CAST", "CHECK", "COLLATE", "COLUMN", "COMMIT", "CONFLICT", "CONSTRAINT", 
			"CREATE", "CROSS", "CURRENT_DATE", "CURRENT_TIME", "CURRENT_TIMESTAMP", 
			"DATABASE", "DEFAULT", "DEFERRABLE", "DEFERRED", "DELETE", "DESC", "DETACH", 
			"DISTINCT", "DROP", "EACH", "ELSE", "END", "ESCAPE", "EXCEPT", "EXCLUSIVE", 
			"EXISTS", "EXPLAIN", "FAIL", "FOR", "FOREIGN", "FROM", "FULL", "GLOB", 
			"GROUP", "HAVING", "IF", "IGNORE", "IMMEDIATE", "IN", "INDEX", "INDEXED", 
			"INITIALLY", "INNER", "INSERT", "INSTEAD", "INTERSECT", "INTO", "IS", 
			"ISNULL", "JOIN", "KEY", "LEFT", "LIKE", "LIMIT", "MATCH", "NATURAL", 
			"NO", "NOT", "NOTNULL", "NULL_", "OF", "OFFSET", "ON", "OR", "ORDER", 
			"OUTER", "PLAN", "PRAGMA", "PRIMARY", "QUERY", "RAISE", "RECURSIVE", 
			"REFERENCES", "REGEXP", "REINDEX", "RELEASE", "RENAME", "REPLACE", "RESTRICT", 
			"RIGHT", "ROLLBACK", "ROW", "ROWS", "SAVEPOINT", "SELECT", "SET", "TABLE", 
			"TEMP", "TEMPORARY", "THEN", "TO", "TRANSACTION", "TRIGGER", "UNION", 
			"UNIQUE", "UPDATE", "USING", "VACUUM", "VALUES", "VIEW", "VIRTUAL", "WHEN", 
			"WHERE", "WITH", "WITHOUT", "FIRST_VALUE", "OVER", "PARTITION", "RANGE", 
			"PRECEDING", "UNBOUNDED", "CURRENT", "FOLLOWING", "CUME_DIST", "DENSE_RANK", 
			"LAG", "LAST_VALUE", "LEAD", "NTH_VALUE", "NTILE", "PERCENT_RANK", "RANK", 
			"ROW_NUMBER", "GENERATED", "ALWAYS", "STORED", "TRUE_", "FALSE_", "WINDOW", 
			"NULLS", "FIRST", "LAST", "FILTER", "GROUPS", "EXCLUDE", "TIES", "OTHERS", 
			"DO", "NOTHING", "IDENTIFIER", "NUMERIC_LITERAL", "BIND_PARAMETER", "STRING_LITERAL", 
			"BLOB_LITERAL", "SINGLE_LINE_COMMENT", "MULTILINE_COMMENT", "SPACES", 
			"UNEXPECTED_CHAR"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "SQLiteParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public SQLiteParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ParseContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(SQLiteParser.EOF, 0); }
		public List<Sql_stmt_listContext> sql_stmt_list() {
			return getRuleContexts(Sql_stmt_listContext.class);
		}
		public Sql_stmt_listContext sql_stmt_list(int i) {
			return getRuleContext(Sql_stmt_listContext.class,i);
		}
		public List<ErrorContext> error() {
			return getRuleContexts(ErrorContext.class);
		}
		public ErrorContext error(int i) {
			return getRuleContext(ErrorContext.class,i);
		}
		public ParseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parse; }
	}

	public final ParseContext parse() throws RecognitionException {
		ParseContext _localctx = new ParseContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_parse);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(228);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << SCOL) | (1L << ALTER) | (1L << ANALYZE) | (1L << ATTACH) | (1L << BEGIN) | (1L << COMMIT) | (1L << CREATE) | (1L << DEFAULT) | (1L << DELETE) | (1L << DETACH) | (1L << DROP))) != 0) || ((((_la - 66)) & ~0x3f) == 0 && ((1L << (_la - 66)) & ((1L << (END - 66)) | (1L << (EXPLAIN - 66)) | (1L << (INSERT - 66)) | (1L << (PRAGMA - 66)) | (1L << (REINDEX - 66)) | (1L << (RELEASE - 66)) | (1L << (REPLACE - 66)) | (1L << (ROLLBACK - 66)) | (1L << (SAVEPOINT - 66)) | (1L << (SELECT - 66)))) != 0) || ((((_la - 140)) & ~0x3f) == 0 && ((1L << (_la - 140)) & ((1L << (UPDATE - 140)) | (1L << (VACUUM - 140)) | (1L << (VALUES - 140)) | (1L << (WITH - 140)) | (1L << (UNEXPECTED_CHAR - 140)))) != 0)) {
				{
				setState(226);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case SCOL:
				case ALTER:
				case ANALYZE:
				case ATTACH:
				case BEGIN:
				case COMMIT:
				case CREATE:
				case DEFAULT:
				case DELETE:
				case DETACH:
				case DROP:
				case END:
				case EXPLAIN:
				case INSERT:
				case PRAGMA:
				case REINDEX:
				case RELEASE:
				case REPLACE:
				case ROLLBACK:
				case SAVEPOINT:
				case SELECT:
				case UPDATE:
				case VACUUM:
				case VALUES:
				case WITH:
					{
					setState(224);
					sql_stmt_list();
					}
					break;
				case UNEXPECTED_CHAR:
					{
					setState(225);
					error();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(230);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(231);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ErrorContext extends ParserRuleContext {
		public Token UNEXPECTED_CHAR;
		public TerminalNode UNEXPECTED_CHAR() { return getToken(SQLiteParser.UNEXPECTED_CHAR, 0); }
		public ErrorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_error; }
	}

	public final ErrorContext error() throws RecognitionException {
		ErrorContext _localctx = new ErrorContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_error);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(233);
			((ErrorContext)_localctx).UNEXPECTED_CHAR = match(UNEXPECTED_CHAR);
			 
			     throw new RuntimeException("UNEXPECTED_CHAR=" + (((ErrorContext)_localctx).UNEXPECTED_CHAR!=null?((ErrorContext)_localctx).UNEXPECTED_CHAR.getText():null)); 
			   
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Sql_stmt_listContext extends ParserRuleContext {
		public List<Sql_stmtContext> sql_stmt() {
			return getRuleContexts(Sql_stmtContext.class);
		}
		public Sql_stmtContext sql_stmt(int i) {
			return getRuleContext(Sql_stmtContext.class,i);
		}
		public List<TerminalNode> SCOL() { return getTokens(SQLiteParser.SCOL); }
		public TerminalNode SCOL(int i) {
			return getToken(SQLiteParser.SCOL, i);
		}
		public Sql_stmt_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sql_stmt_list; }
	}

	public final Sql_stmt_listContext sql_stmt_list() throws RecognitionException {
		Sql_stmt_listContext _localctx = new Sql_stmt_listContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_sql_stmt_list);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(239);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SCOL) {
				{
				{
				setState(236);
				match(SCOL);
				}
				}
				setState(241);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(242);
			sql_stmt();
			setState(251);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(244); 
					_errHandler.sync(this);
					_la = _input.LA(1);
					do {
						{
						{
						setState(243);
						match(SCOL);
						}
						}
						setState(246); 
						_errHandler.sync(this);
						_la = _input.LA(1);
					} while ( _la==SCOL );
					setState(248);
					sql_stmt();
					}
					} 
				}
				setState(253);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			}
			setState(257);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(254);
					match(SCOL);
					}
					} 
				}
				setState(259);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Sql_stmtContext extends ParserRuleContext {
		public Alter_table_stmtContext alter_table_stmt() {
			return getRuleContext(Alter_table_stmtContext.class,0);
		}
		public Analyze_stmtContext analyze_stmt() {
			return getRuleContext(Analyze_stmtContext.class,0);
		}
		public Attach_stmtContext attach_stmt() {
			return getRuleContext(Attach_stmtContext.class,0);
		}
		public Begin_stmtContext begin_stmt() {
			return getRuleContext(Begin_stmtContext.class,0);
		}
		public Commit_stmtContext commit_stmt() {
			return getRuleContext(Commit_stmtContext.class,0);
		}
		public Create_index_stmtContext create_index_stmt() {
			return getRuleContext(Create_index_stmtContext.class,0);
		}
		public Create_table_stmtContext create_table_stmt() {
			return getRuleContext(Create_table_stmtContext.class,0);
		}
		public Create_trigger_stmtContext create_trigger_stmt() {
			return getRuleContext(Create_trigger_stmtContext.class,0);
		}
		public Create_view_stmtContext create_view_stmt() {
			return getRuleContext(Create_view_stmtContext.class,0);
		}
		public Create_virtual_table_stmtContext create_virtual_table_stmt() {
			return getRuleContext(Create_virtual_table_stmtContext.class,0);
		}
		public Delete_stmtContext delete_stmt() {
			return getRuleContext(Delete_stmtContext.class,0);
		}
		public Delete_stmt_limitedContext delete_stmt_limited() {
			return getRuleContext(Delete_stmt_limitedContext.class,0);
		}
		public Detach_stmtContext detach_stmt() {
			return getRuleContext(Detach_stmtContext.class,0);
		}
		public Drop_stmtContext drop_stmt() {
			return getRuleContext(Drop_stmtContext.class,0);
		}
		public Insert_stmtContext insert_stmt() {
			return getRuleContext(Insert_stmtContext.class,0);
		}
		public Pragma_stmtContext pragma_stmt() {
			return getRuleContext(Pragma_stmtContext.class,0);
		}
		public Reindex_stmtContext reindex_stmt() {
			return getRuleContext(Reindex_stmtContext.class,0);
		}
		public Release_stmtContext release_stmt() {
			return getRuleContext(Release_stmtContext.class,0);
		}
		public Rollback_stmtContext rollback_stmt() {
			return getRuleContext(Rollback_stmtContext.class,0);
		}
		public Savepoint_stmtContext savepoint_stmt() {
			return getRuleContext(Savepoint_stmtContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Update_stmtContext update_stmt() {
			return getRuleContext(Update_stmtContext.class,0);
		}
		public Update_stmt_limitedContext update_stmt_limited() {
			return getRuleContext(Update_stmt_limitedContext.class,0);
		}
		public Vacuum_stmtContext vacuum_stmt() {
			return getRuleContext(Vacuum_stmtContext.class,0);
		}
		public TerminalNode EXPLAIN() { return getToken(SQLiteParser.EXPLAIN, 0); }
		public TerminalNode QUERY() { return getToken(SQLiteParser.QUERY, 0); }
		public TerminalNode PLAN() { return getToken(SQLiteParser.PLAN, 0); }
		public Sql_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sql_stmt; }
	}

	public final Sql_stmtContext sql_stmt() throws RecognitionException {
		Sql_stmtContext _localctx = new Sql_stmtContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_sql_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(265);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==EXPLAIN) {
				{
				setState(260);
				match(EXPLAIN);
				setState(263);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==QUERY) {
					{
					setState(261);
					match(QUERY);
					setState(262);
					match(PLAN);
					}
				}

				}
			}

			setState(291);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				setState(267);
				alter_table_stmt();
				}
				break;
			case 2:
				{
				setState(268);
				analyze_stmt();
				}
				break;
			case 3:
				{
				setState(269);
				attach_stmt();
				}
				break;
			case 4:
				{
				setState(270);
				begin_stmt();
				}
				break;
			case 5:
				{
				setState(271);
				commit_stmt();
				}
				break;
			case 6:
				{
				setState(272);
				create_index_stmt();
				}
				break;
			case 7:
				{
				setState(273);
				create_table_stmt();
				}
				break;
			case 8:
				{
				setState(274);
				create_trigger_stmt();
				}
				break;
			case 9:
				{
				setState(275);
				create_view_stmt();
				}
				break;
			case 10:
				{
				setState(276);
				create_virtual_table_stmt();
				}
				break;
			case 11:
				{
				setState(277);
				delete_stmt();
				}
				break;
			case 12:
				{
				setState(278);
				delete_stmt_limited();
				}
				break;
			case 13:
				{
				setState(279);
				detach_stmt();
				}
				break;
			case 14:
				{
				setState(280);
				drop_stmt();
				}
				break;
			case 15:
				{
				setState(281);
				insert_stmt();
				}
				break;
			case 16:
				{
				setState(282);
				pragma_stmt();
				}
				break;
			case 17:
				{
				setState(283);
				reindex_stmt();
				}
				break;
			case 18:
				{
				setState(284);
				release_stmt();
				}
				break;
			case 19:
				{
				setState(285);
				rollback_stmt();
				}
				break;
			case 20:
				{
				setState(286);
				savepoint_stmt();
				}
				break;
			case 21:
				{
				setState(287);
				select_stmt();
				}
				break;
			case 22:
				{
				setState(288);
				update_stmt();
				}
				break;
			case 23:
				{
				setState(289);
				update_stmt_limited();
				}
				break;
			case 24:
				{
				setState(290);
				vacuum_stmt();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Alter_table_stmtContext extends ParserRuleContext {
		public Column_nameContext old_column_name;
		public Column_nameContext new_column_name;
		public TerminalNode ALTER() { return getToken(SQLiteParser.ALTER, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode RENAME() { return getToken(SQLiteParser.RENAME, 0); }
		public TerminalNode ADD() { return getToken(SQLiteParser.ADD, 0); }
		public Column_defContext column_def() {
			return getRuleContext(Column_defContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode COLUMN() { return getToken(SQLiteParser.COLUMN, 0); }
		public TerminalNode TO() { return getToken(SQLiteParser.TO, 0); }
		public New_table_nameContext new_table_name() {
			return getRuleContext(New_table_nameContext.class,0);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public Alter_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_alter_table_stmt; }
	}

	public final Alter_table_stmtContext alter_table_stmt() throws RecognitionException {
		Alter_table_stmtContext _localctx = new Alter_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_alter_table_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(293);
			match(ALTER);
			setState(294);
			match(TABLE);
			setState(298);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				setState(295);
				schema_name();
				setState(296);
				match(DOT);
				}
				break;
			}
			setState(300);
			table_name();
			setState(318);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RENAME:
				{
				setState(301);
				match(RENAME);
				setState(311);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
				case 1:
					{
					{
					setState(302);
					match(TO);
					setState(303);
					new_table_name();
					}
					}
					break;
				case 2:
					{
					{
					setState(305);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
					case 1:
						{
						setState(304);
						match(COLUMN);
						}
						break;
					}
					setState(307);
					((Alter_table_stmtContext)_localctx).old_column_name = column_name();
					setState(308);
					match(TO);
					setState(309);
					((Alter_table_stmtContext)_localctx).new_column_name = column_name();
					}
					}
					break;
				}
				}
				break;
			case ADD:
				{
				setState(313);
				match(ADD);
				setState(315);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
				case 1:
					{
					setState(314);
					match(COLUMN);
					}
					break;
				}
				setState(317);
				column_def();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Analyze_stmtContext extends ParserRuleContext {
		public TerminalNode ANALYZE() { return getToken(SQLiteParser.ANALYZE, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public Table_or_index_nameContext table_or_index_name() {
			return getRuleContext(Table_or_index_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Analyze_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_analyze_stmt; }
	}

	public final Analyze_stmtContext analyze_stmt() throws RecognitionException {
		Analyze_stmtContext _localctx = new Analyze_stmtContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_analyze_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(320);
			match(ANALYZE);
			setState(328);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				{
				setState(321);
				schema_name();
				}
				break;
			case 2:
				{
				setState(325);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
				case 1:
					{
					setState(322);
					schema_name();
					setState(323);
					match(DOT);
					}
					break;
				}
				setState(327);
				table_or_index_name();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Attach_stmtContext extends ParserRuleContext {
		public TerminalNode ATTACH() { return getToken(SQLiteParser.ATTACH, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DATABASE() { return getToken(SQLiteParser.DATABASE, 0); }
		public Attach_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attach_stmt; }
	}

	public final Attach_stmtContext attach_stmt() throws RecognitionException {
		Attach_stmtContext _localctx = new Attach_stmtContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_attach_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(330);
			match(ATTACH);
			setState(332);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				{
				setState(331);
				match(DATABASE);
				}
				break;
			}
			setState(334);
			expr(0);
			setState(335);
			match(AS);
			setState(336);
			schema_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Begin_stmtContext extends ParserRuleContext {
		public TerminalNode BEGIN() { return getToken(SQLiteParser.BEGIN, 0); }
		public TerminalNode TRANSACTION() { return getToken(SQLiteParser.TRANSACTION, 0); }
		public TerminalNode DEFERRED() { return getToken(SQLiteParser.DEFERRED, 0); }
		public TerminalNode IMMEDIATE() { return getToken(SQLiteParser.IMMEDIATE, 0); }
		public TerminalNode EXCLUSIVE() { return getToken(SQLiteParser.EXCLUSIVE, 0); }
		public Transaction_nameContext transaction_name() {
			return getRuleContext(Transaction_nameContext.class,0);
		}
		public Begin_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_begin_stmt; }
	}

	public final Begin_stmtContext begin_stmt() throws RecognitionException {
		Begin_stmtContext _localctx = new Begin_stmtContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_begin_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(338);
			match(BEGIN);
			setState(340);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (((((_la - 58)) & ~0x3f) == 0 && ((1L << (_la - 58)) & ((1L << (DEFERRED - 58)) | (1L << (EXCLUSIVE - 58)) | (1L << (IMMEDIATE - 58)))) != 0)) {
				{
				setState(339);
				_la = _input.LA(1);
				if ( !(((((_la - 58)) & ~0x3f) == 0 && ((1L << (_la - 58)) & ((1L << (DEFERRED - 58)) | (1L << (EXCLUSIVE - 58)) | (1L << (IMMEDIATE - 58)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(346);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TRANSACTION) {
				{
				setState(342);
				match(TRANSACTION);
				setState(344);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
				case 1:
					{
					setState(343);
					transaction_name();
					}
					break;
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Commit_stmtContext extends ParserRuleContext {
		public TerminalNode COMMIT() { return getToken(SQLiteParser.COMMIT, 0); }
		public TerminalNode END() { return getToken(SQLiteParser.END, 0); }
		public TerminalNode TRANSACTION() { return getToken(SQLiteParser.TRANSACTION, 0); }
		public Commit_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_commit_stmt; }
	}

	public final Commit_stmtContext commit_stmt() throws RecognitionException {
		Commit_stmtContext _localctx = new Commit_stmtContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_commit_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(348);
			_la = _input.LA(1);
			if ( !(_la==COMMIT || _la==END) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(350);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TRANSACTION) {
				{
				setState(349);
				match(TRANSACTION);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Rollback_stmtContext extends ParserRuleContext {
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode TRANSACTION() { return getToken(SQLiteParser.TRANSACTION, 0); }
		public TerminalNode TO() { return getToken(SQLiteParser.TO, 0); }
		public Savepoint_nameContext savepoint_name() {
			return getRuleContext(Savepoint_nameContext.class,0);
		}
		public TerminalNode SAVEPOINT() { return getToken(SQLiteParser.SAVEPOINT, 0); }
		public Rollback_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_rollback_stmt; }
	}

	public final Rollback_stmtContext rollback_stmt() throws RecognitionException {
		Rollback_stmtContext _localctx = new Rollback_stmtContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_rollback_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(352);
			match(ROLLBACK);
			setState(354);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TRANSACTION) {
				{
				setState(353);
				match(TRANSACTION);
				}
			}

			setState(361);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TO) {
				{
				setState(356);
				match(TO);
				setState(358);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,22,_ctx) ) {
				case 1:
					{
					setState(357);
					match(SAVEPOINT);
					}
					break;
				}
				setState(360);
				savepoint_name();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Savepoint_stmtContext extends ParserRuleContext {
		public TerminalNode SAVEPOINT() { return getToken(SQLiteParser.SAVEPOINT, 0); }
		public Savepoint_nameContext savepoint_name() {
			return getRuleContext(Savepoint_nameContext.class,0);
		}
		public Savepoint_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_savepoint_stmt; }
	}

	public final Savepoint_stmtContext savepoint_stmt() throws RecognitionException {
		Savepoint_stmtContext _localctx = new Savepoint_stmtContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_savepoint_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(363);
			match(SAVEPOINT);
			setState(364);
			savepoint_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Release_stmtContext extends ParserRuleContext {
		public TerminalNode RELEASE() { return getToken(SQLiteParser.RELEASE, 0); }
		public Savepoint_nameContext savepoint_name() {
			return getRuleContext(Savepoint_nameContext.class,0);
		}
		public TerminalNode SAVEPOINT() { return getToken(SQLiteParser.SAVEPOINT, 0); }
		public Release_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_release_stmt; }
	}

	public final Release_stmtContext release_stmt() throws RecognitionException {
		Release_stmtContext _localctx = new Release_stmtContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_release_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(366);
			match(RELEASE);
			setState(368);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				{
				setState(367);
				match(SAVEPOINT);
				}
				break;
			}
			setState(370);
			savepoint_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_index_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode INDEX() { return getToken(SQLiteParser.INDEX, 0); }
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Indexed_columnContext> indexed_column() {
			return getRuleContexts(Indexed_columnContext.class);
		}
		public Indexed_columnContext indexed_column(int i) {
			return getRuleContext(Indexed_columnContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode UNIQUE() { return getToken(SQLiteParser.UNIQUE, 0); }
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Create_index_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_index_stmt; }
	}

	public final Create_index_stmtContext create_index_stmt() throws RecognitionException {
		Create_index_stmtContext _localctx = new Create_index_stmtContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_create_index_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(372);
			match(CREATE);
			setState(374);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==UNIQUE) {
				{
				setState(373);
				match(UNIQUE);
				}
			}

			setState(376);
			match(INDEX);
			setState(380);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				{
				setState(377);
				match(IF);
				setState(378);
				match(NOT);
				setState(379);
				match(EXISTS);
				}
				break;
			}
			setState(385);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
			case 1:
				{
				setState(382);
				schema_name();
				setState(383);
				match(DOT);
				}
				break;
			}
			setState(387);
			index_name();
			setState(388);
			match(ON);
			setState(389);
			table_name();
			setState(390);
			match(OPEN_PAR);
			setState(391);
			indexed_column();
			setState(396);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(392);
				match(COMMA);
				setState(393);
				indexed_column();
				}
				}
				setState(398);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(399);
			match(CLOSE_PAR);
			setState(402);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(400);
				match(WHERE);
				setState(401);
				expr(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Indexed_columnContext extends ParserRuleContext {
		public Column_nameContext column_name() {
			return getRuleContext(Column_nameContext.class,0);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Asc_descContext asc_desc() {
			return getRuleContext(Asc_descContext.class,0);
		}
		public Indexed_columnContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_indexed_column; }
	}

	public final Indexed_columnContext indexed_column() throws RecognitionException {
		Indexed_columnContext _localctx = new Indexed_columnContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_indexed_column);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(406);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
			case 1:
				{
				setState(404);
				column_name();
				}
				break;
			case 2:
				{
				setState(405);
				expr(0);
				}
				break;
			}
			setState(410);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLLATE) {
				{
				setState(408);
				match(COLLATE);
				setState(409);
				collation_name();
				}
			}

			setState(413);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(412);
				asc_desc();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_table_stmtContext extends ParserRuleContext {
		public Token rowID;
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode TEMP() { return getToken(SQLiteParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(SQLiteParser.TEMPORARY, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Column_defContext> column_def() {
			return getRuleContexts(Column_defContext.class);
		}
		public Column_defContext column_def(int i) {
			return getRuleContext(Column_defContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public List<Table_constraintContext> table_constraint() {
			return getRuleContexts(Table_constraintContext.class);
		}
		public Table_constraintContext table_constraint(int i) {
			return getRuleContext(Table_constraintContext.class,i);
		}
		public TerminalNode WITHOUT() { return getToken(SQLiteParser.WITHOUT, 0); }
		public TerminalNode IDENTIFIER() { return getToken(SQLiteParser.IDENTIFIER, 0); }
		public Create_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_table_stmt; }
	}

	public final Create_table_stmtContext create_table_stmt() throws RecognitionException {
		Create_table_stmtContext _localctx = new Create_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_create_table_stmt);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(415);
			match(CREATE);
			setState(417);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEMP || _la==TEMPORARY) {
				{
				setState(416);
				_la = _input.LA(1);
				if ( !(_la==TEMP || _la==TEMPORARY) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(419);
			match(TABLE);
			setState(423);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,34,_ctx) ) {
			case 1:
				{
				setState(420);
				match(IF);
				setState(421);
				match(NOT);
				setState(422);
				match(EXISTS);
				}
				break;
			}
			setState(428);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,35,_ctx) ) {
			case 1:
				{
				setState(425);
				schema_name();
				setState(426);
				match(DOT);
				}
				break;
			}
			setState(430);
			table_name();
			setState(454);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
				{
				{
				setState(431);
				match(OPEN_PAR);
				setState(432);
				column_def();
				setState(437);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(433);
						match(COMMA);
						setState(434);
						column_def();
						}
						} 
					}
					setState(439);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
				}
				setState(444);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(440);
					match(COMMA);
					setState(441);
					table_constraint();
					}
					}
					setState(446);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(447);
				match(CLOSE_PAR);
				setState(450);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WITHOUT) {
					{
					setState(448);
					match(WITHOUT);
					setState(449);
					((Create_table_stmtContext)_localctx).rowID = match(IDENTIFIER);
					}
				}

				}
				}
				break;
			case AS:
				{
				{
				setState(452);
				match(AS);
				setState(453);
				select_stmt();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_defContext extends ParserRuleContext {
		public Column_nameContext column_name() {
			return getRuleContext(Column_nameContext.class,0);
		}
		public Type_nameContext type_name() {
			return getRuleContext(Type_nameContext.class,0);
		}
		public List<Column_constraintContext> column_constraint() {
			return getRuleContexts(Column_constraintContext.class);
		}
		public Column_constraintContext column_constraint(int i) {
			return getRuleContext(Column_constraintContext.class,i);
		}
		public Column_defContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_def; }
	}

	public final Column_defContext column_def() throws RecognitionException {
		Column_defContext _localctx = new Column_defContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_column_def);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(456);
			column_name();
			setState(458);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
			case 1:
				{
				setState(457);
				type_name();
				}
				break;
			}
			setState(463);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(460);
					column_constraint();
					}
					} 
				}
				setState(465);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Type_nameContext extends ParserRuleContext {
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Signed_numberContext> signed_number() {
			return getRuleContexts(Signed_numberContext.class);
		}
		public Signed_numberContext signed_number(int i) {
			return getRuleContext(Signed_numberContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Type_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type_name; }
	}

	public final Type_nameContext type_name() throws RecognitionException {
		Type_nameContext _localctx = new Type_nameContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_type_name);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(467); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(466);
					name();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(469); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,42,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(481);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,43,_ctx) ) {
			case 1:
				{
				setState(471);
				match(OPEN_PAR);
				setState(472);
				signed_number();
				setState(473);
				match(CLOSE_PAR);
				}
				break;
			case 2:
				{
				setState(475);
				match(OPEN_PAR);
				setState(476);
				signed_number();
				setState(477);
				match(COMMA);
				setState(478);
				signed_number();
				setState(479);
				match(CLOSE_PAR);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_constraintContext extends ParserRuleContext {
		public TerminalNode CHECK() { return getToken(SQLiteParser.CHECK, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode DEFAULT() { return getToken(SQLiteParser.DEFAULT, 0); }
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Foreign_key_clauseContext foreign_key_clause() {
			return getRuleContext(Foreign_key_clauseContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public TerminalNode CONSTRAINT() { return getToken(SQLiteParser.CONSTRAINT, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode PRIMARY() { return getToken(SQLiteParser.PRIMARY, 0); }
		public TerminalNode KEY() { return getToken(SQLiteParser.KEY, 0); }
		public TerminalNode UNIQUE() { return getToken(SQLiteParser.UNIQUE, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public Literal_valueContext literal_value() {
			return getRuleContext(Literal_valueContext.class,0);
		}
		public Conflict_clauseContext conflict_clause() {
			return getRuleContext(Conflict_clauseContext.class,0);
		}
		public TerminalNode GENERATED() { return getToken(SQLiteParser.GENERATED, 0); }
		public TerminalNode ALWAYS() { return getToken(SQLiteParser.ALWAYS, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode NULL_() { return getToken(SQLiteParser.NULL_, 0); }
		public TerminalNode STORED() { return getToken(SQLiteParser.STORED, 0); }
		public TerminalNode VIRTUAL() { return getToken(SQLiteParser.VIRTUAL, 0); }
		public Asc_descContext asc_desc() {
			return getRuleContext(Asc_descContext.class,0);
		}
		public TerminalNode AUTOINCREMENT() { return getToken(SQLiteParser.AUTOINCREMENT, 0); }
		public Column_constraintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_constraint; }
	}

	public final Column_constraintContext column_constraint() throws RecognitionException {
		Column_constraintContext _localctx = new Column_constraintContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_column_constraint);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(485);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CONSTRAINT) {
				{
				setState(483);
				match(CONSTRAINT);
				setState(484);
				name();
				}
			}

			setState(534);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PRIMARY:
				{
				{
				setState(487);
				match(PRIMARY);
				setState(488);
				match(KEY);
				setState(490);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ASC || _la==DESC) {
					{
					setState(489);
					asc_desc();
					}
				}

				setState(493);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(492);
					conflict_clause();
					}
				}

				setState(496);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AUTOINCREMENT) {
					{
					setState(495);
					match(AUTOINCREMENT);
					}
				}

				}
				}
				break;
			case NOT:
			case UNIQUE:
				{
				setState(501);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case NOT:
					{
					{
					setState(498);
					match(NOT);
					setState(499);
					match(NULL_);
					}
					}
					break;
				case UNIQUE:
					{
					setState(500);
					match(UNIQUE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(504);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(503);
					conflict_clause();
					}
				}

				}
				break;
			case CHECK:
				{
				setState(506);
				match(CHECK);
				setState(507);
				match(OPEN_PAR);
				setState(508);
				expr(0);
				setState(509);
				match(CLOSE_PAR);
				}
				break;
			case DEFAULT:
				{
				setState(511);
				match(DEFAULT);
				setState(518);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,50,_ctx) ) {
				case 1:
					{
					setState(512);
					signed_number();
					}
					break;
				case 2:
					{
					setState(513);
					literal_value();
					}
					break;
				case 3:
					{
					{
					setState(514);
					match(OPEN_PAR);
					setState(515);
					expr(0);
					setState(516);
					match(CLOSE_PAR);
					}
					}
					break;
				}
				}
				break;
			case COLLATE:
				{
				setState(520);
				match(COLLATE);
				setState(521);
				collation_name();
				}
				break;
			case REFERENCES:
				{
				setState(522);
				foreign_key_clause();
				}
				break;
			case AS:
			case GENERATED:
				{
				setState(525);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==GENERATED) {
					{
					setState(523);
					match(GENERATED);
					setState(524);
					match(ALWAYS);
					}
				}

				setState(527);
				match(AS);
				setState(528);
				match(OPEN_PAR);
				setState(529);
				expr(0);
				setState(530);
				match(CLOSE_PAR);
				setState(532);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==VIRTUAL || _la==STORED) {
					{
					setState(531);
					_la = _input.LA(1);
					if ( !(_la==VIRTUAL || _la==STORED) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
				}

				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Signed_numberContext extends ParserRuleContext {
		public TerminalNode NUMERIC_LITERAL() { return getToken(SQLiteParser.NUMERIC_LITERAL, 0); }
		public TerminalNode PLUS() { return getToken(SQLiteParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(SQLiteParser.MINUS, 0); }
		public Signed_numberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_signed_number; }
	}

	public final Signed_numberContext signed_number() throws RecognitionException {
		Signed_numberContext _localctx = new Signed_numberContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_signed_number);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(537);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PLUS || _la==MINUS) {
				{
				setState(536);
				_la = _input.LA(1);
				if ( !(_la==PLUS || _la==MINUS) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(539);
			match(NUMERIC_LITERAL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_constraintContext extends ParserRuleContext {
		public TerminalNode CONSTRAINT() { return getToken(SQLiteParser.CONSTRAINT, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Indexed_columnContext> indexed_column() {
			return getRuleContexts(Indexed_columnContext.class);
		}
		public Indexed_columnContext indexed_column(int i) {
			return getRuleContext(Indexed_columnContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode CHECK() { return getToken(SQLiteParser.CHECK, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode FOREIGN() { return getToken(SQLiteParser.FOREIGN, 0); }
		public TerminalNode KEY() { return getToken(SQLiteParser.KEY, 0); }
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public Foreign_key_clauseContext foreign_key_clause() {
			return getRuleContext(Foreign_key_clauseContext.class,0);
		}
		public TerminalNode PRIMARY() { return getToken(SQLiteParser.PRIMARY, 0); }
		public TerminalNode UNIQUE() { return getToken(SQLiteParser.UNIQUE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Conflict_clauseContext conflict_clause() {
			return getRuleContext(Conflict_clauseContext.class,0);
		}
		public Table_constraintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_constraint; }
	}

	public final Table_constraintContext table_constraint() throws RecognitionException {
		Table_constraintContext _localctx = new Table_constraintContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_table_constraint);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(543);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CONSTRAINT) {
				{
				setState(541);
				match(CONSTRAINT);
				setState(542);
				name();
				}
			}

			setState(582);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PRIMARY:
			case UNIQUE:
				{
				{
				setState(548);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case PRIMARY:
					{
					setState(545);
					match(PRIMARY);
					setState(546);
					match(KEY);
					}
					break;
				case UNIQUE:
					{
					setState(547);
					match(UNIQUE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(550);
				match(OPEN_PAR);
				setState(551);
				indexed_column();
				setState(556);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(552);
					match(COMMA);
					setState(553);
					indexed_column();
					}
					}
					setState(558);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(559);
				match(CLOSE_PAR);
				setState(561);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(560);
					conflict_clause();
					}
				}

				}
				}
				break;
			case CHECK:
				{
				{
				setState(563);
				match(CHECK);
				setState(564);
				match(OPEN_PAR);
				setState(565);
				expr(0);
				setState(566);
				match(CLOSE_PAR);
				}
				}
				break;
			case FOREIGN:
				{
				{
				setState(568);
				match(FOREIGN);
				setState(569);
				match(KEY);
				setState(570);
				match(OPEN_PAR);
				setState(571);
				column_name();
				setState(576);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(572);
					match(COMMA);
					setState(573);
					column_name();
					}
					}
					setState(578);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(579);
				match(CLOSE_PAR);
				setState(580);
				foreign_key_clause();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Foreign_key_clauseContext extends ParserRuleContext {
		public TerminalNode REFERENCES() { return getToken(SQLiteParser.REFERENCES, 0); }
		public Foreign_tableContext foreign_table() {
			return getRuleContext(Foreign_tableContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode DEFERRABLE() { return getToken(SQLiteParser.DEFERRABLE, 0); }
		public List<TerminalNode> ON() { return getTokens(SQLiteParser.ON); }
		public TerminalNode ON(int i) {
			return getToken(SQLiteParser.ON, i);
		}
		public List<TerminalNode> MATCH() { return getTokens(SQLiteParser.MATCH); }
		public TerminalNode MATCH(int i) {
			return getToken(SQLiteParser.MATCH, i);
		}
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public List<TerminalNode> DELETE() { return getTokens(SQLiteParser.DELETE); }
		public TerminalNode DELETE(int i) {
			return getToken(SQLiteParser.DELETE, i);
		}
		public List<TerminalNode> UPDATE() { return getTokens(SQLiteParser.UPDATE); }
		public TerminalNode UPDATE(int i) {
			return getToken(SQLiteParser.UPDATE, i);
		}
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode INITIALLY() { return getToken(SQLiteParser.INITIALLY, 0); }
		public List<TerminalNode> CASCADE() { return getTokens(SQLiteParser.CASCADE); }
		public TerminalNode CASCADE(int i) {
			return getToken(SQLiteParser.CASCADE, i);
		}
		public List<TerminalNode> RESTRICT() { return getTokens(SQLiteParser.RESTRICT); }
		public TerminalNode RESTRICT(int i) {
			return getToken(SQLiteParser.RESTRICT, i);
		}
		public TerminalNode DEFERRED() { return getToken(SQLiteParser.DEFERRED, 0); }
		public TerminalNode IMMEDIATE() { return getToken(SQLiteParser.IMMEDIATE, 0); }
		public List<TerminalNode> SET() { return getTokens(SQLiteParser.SET); }
		public TerminalNode SET(int i) {
			return getToken(SQLiteParser.SET, i);
		}
		public List<TerminalNode> NO() { return getTokens(SQLiteParser.NO); }
		public TerminalNode NO(int i) {
			return getToken(SQLiteParser.NO, i);
		}
		public List<TerminalNode> ACTION() { return getTokens(SQLiteParser.ACTION); }
		public TerminalNode ACTION(int i) {
			return getToken(SQLiteParser.ACTION, i);
		}
		public List<TerminalNode> NULL_() { return getTokens(SQLiteParser.NULL_); }
		public TerminalNode NULL_(int i) {
			return getToken(SQLiteParser.NULL_, i);
		}
		public List<TerminalNode> DEFAULT() { return getTokens(SQLiteParser.DEFAULT); }
		public TerminalNode DEFAULT(int i) {
			return getToken(SQLiteParser.DEFAULT, i);
		}
		public Foreign_key_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_foreign_key_clause; }
	}

	public final Foreign_key_clauseContext foreign_key_clause() throws RecognitionException {
		Foreign_key_clauseContext _localctx = new Foreign_key_clauseContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_foreign_key_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(584);
			match(REFERENCES);
			setState(585);
			foreign_table();
			setState(597);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(586);
				match(OPEN_PAR);
				setState(587);
				column_name();
				setState(592);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(588);
					match(COMMA);
					setState(589);
					column_name();
					}
					}
					setState(594);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(595);
				match(CLOSE_PAR);
				}
			}

			setState(613);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==MATCH || _la==ON) {
				{
				setState(611);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case ON:
					{
					{
					setState(599);
					match(ON);
					setState(600);
					_la = _input.LA(1);
					if ( !(_la==DELETE || _la==UPDATE) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(607);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case SET:
						{
						{
						setState(601);
						match(SET);
						setState(602);
						_la = _input.LA(1);
						if ( !(_la==DEFAULT || _la==NULL_) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						}
						}
						break;
					case CASCADE:
						{
						setState(603);
						match(CASCADE);
						}
						break;
					case RESTRICT:
						{
						setState(604);
						match(RESTRICT);
						}
						break;
					case NO:
						{
						{
						setState(605);
						match(NO);
						setState(606);
						match(ACTION);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					}
					}
					break;
				case MATCH:
					{
					{
					setState(609);
					match(MATCH);
					setState(610);
					name();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(615);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(624);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,68,_ctx) ) {
			case 1:
				{
				setState(617);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NOT) {
					{
					setState(616);
					match(NOT);
					}
				}

				setState(619);
				match(DEFERRABLE);
				setState(622);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==INITIALLY) {
					{
					setState(620);
					match(INITIALLY);
					setState(621);
					_la = _input.LA(1);
					if ( !(_la==DEFERRED || _la==IMMEDIATE) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
				}

				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Conflict_clauseContext extends ParserRuleContext {
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public TerminalNode CONFLICT() { return getToken(SQLiteParser.CONFLICT, 0); }
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public Conflict_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_conflict_clause; }
	}

	public final Conflict_clauseContext conflict_clause() throws RecognitionException {
		Conflict_clauseContext _localctx = new Conflict_clauseContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_conflict_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(626);
			match(ON);
			setState(627);
			match(CONFLICT);
			setState(628);
			_la = _input.LA(1);
			if ( !(_la==ABORT || ((((_la - 72)) & ~0x3f) == 0 && ((1L << (_la - 72)) & ((1L << (FAIL - 72)) | (1L << (IGNORE - 72)) | (1L << (REPLACE - 72)) | (1L << (ROLLBACK - 72)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_trigger_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode TRIGGER() { return getToken(SQLiteParser.TRIGGER, 0); }
		public Trigger_nameContext trigger_name() {
			return getRuleContext(Trigger_nameContext.class,0);
		}
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode BEGIN() { return getToken(SQLiteParser.BEGIN, 0); }
		public TerminalNode END() { return getToken(SQLiteParser.END, 0); }
		public TerminalNode DELETE() { return getToken(SQLiteParser.DELETE, 0); }
		public TerminalNode INSERT() { return getToken(SQLiteParser.INSERT, 0); }
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode BEFORE() { return getToken(SQLiteParser.BEFORE, 0); }
		public TerminalNode AFTER() { return getToken(SQLiteParser.AFTER, 0); }
		public TerminalNode FOR() { return getToken(SQLiteParser.FOR, 0); }
		public TerminalNode EACH() { return getToken(SQLiteParser.EACH, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public TerminalNode WHEN() { return getToken(SQLiteParser.WHEN, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public List<TerminalNode> SCOL() { return getTokens(SQLiteParser.SCOL); }
		public TerminalNode SCOL(int i) {
			return getToken(SQLiteParser.SCOL, i);
		}
		public TerminalNode TEMP() { return getToken(SQLiteParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(SQLiteParser.TEMPORARY, 0); }
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public TerminalNode INSTEAD() { return getToken(SQLiteParser.INSTEAD, 0); }
		public List<TerminalNode> OF() { return getTokens(SQLiteParser.OF); }
		public TerminalNode OF(int i) {
			return getToken(SQLiteParser.OF, i);
		}
		public List<Update_stmtContext> update_stmt() {
			return getRuleContexts(Update_stmtContext.class);
		}
		public Update_stmtContext update_stmt(int i) {
			return getRuleContext(Update_stmtContext.class,i);
		}
		public List<Insert_stmtContext> insert_stmt() {
			return getRuleContexts(Insert_stmtContext.class);
		}
		public Insert_stmtContext insert_stmt(int i) {
			return getRuleContext(Insert_stmtContext.class,i);
		}
		public List<Delete_stmtContext> delete_stmt() {
			return getRuleContexts(Delete_stmtContext.class);
		}
		public Delete_stmtContext delete_stmt(int i) {
			return getRuleContext(Delete_stmtContext.class,i);
		}
		public List<Select_stmtContext> select_stmt() {
			return getRuleContexts(Select_stmtContext.class);
		}
		public Select_stmtContext select_stmt(int i) {
			return getRuleContext(Select_stmtContext.class,i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Create_trigger_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_trigger_stmt; }
	}

	public final Create_trigger_stmtContext create_trigger_stmt() throws RecognitionException {
		Create_trigger_stmtContext _localctx = new Create_trigger_stmtContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_create_trigger_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(630);
			match(CREATE);
			setState(632);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEMP || _la==TEMPORARY) {
				{
				setState(631);
				_la = _input.LA(1);
				if ( !(_la==TEMP || _la==TEMPORARY) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(634);
			match(TRIGGER);
			setState(638);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,70,_ctx) ) {
			case 1:
				{
				setState(635);
				match(IF);
				setState(636);
				match(NOT);
				setState(637);
				match(EXISTS);
				}
				break;
			}
			setState(643);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,71,_ctx) ) {
			case 1:
				{
				setState(640);
				schema_name();
				setState(641);
				match(DOT);
				}
				break;
			}
			setState(645);
			trigger_name();
			setState(650);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BEFORE:
				{
				setState(646);
				match(BEFORE);
				}
				break;
			case AFTER:
				{
				setState(647);
				match(AFTER);
				}
				break;
			case INSTEAD:
				{
				{
				setState(648);
				match(INSTEAD);
				setState(649);
				match(OF);
				}
				}
				break;
			case DELETE:
			case INSERT:
			case UPDATE:
				break;
			default:
				break;
			}
			setState(666);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case DELETE:
				{
				setState(652);
				match(DELETE);
				}
				break;
			case INSERT:
				{
				setState(653);
				match(INSERT);
				}
				break;
			case UPDATE:
				{
				{
				setState(654);
				match(UPDATE);
				setState(664);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==OF) {
					{
					setState(655);
					match(OF);
					setState(656);
					column_name();
					setState(661);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(657);
						match(COMMA);
						setState(658);
						column_name();
						}
						}
						setState(663);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(668);
			match(ON);
			setState(669);
			table_name();
			setState(673);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==FOR) {
				{
				setState(670);
				match(FOR);
				setState(671);
				match(EACH);
				setState(672);
				match(ROW);
				}
			}

			setState(677);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHEN) {
				{
				setState(675);
				match(WHEN);
				setState(676);
				expr(0);
				}
			}

			setState(679);
			match(BEGIN);
			setState(688); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(684);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,78,_ctx) ) {
				case 1:
					{
					setState(680);
					update_stmt();
					}
					break;
				case 2:
					{
					setState(681);
					insert_stmt();
					}
					break;
				case 3:
					{
					setState(682);
					delete_stmt();
					}
					break;
				case 4:
					{
					setState(683);
					select_stmt();
					}
					break;
				}
				setState(686);
				match(SCOL);
				}
				}
				setState(690); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==DEFAULT || _la==DELETE || ((((_la - 88)) & ~0x3f) == 0 && ((1L << (_la - 88)) & ((1L << (INSERT - 88)) | (1L << (REPLACE - 88)) | (1L << (SELECT - 88)) | (1L << (UPDATE - 88)) | (1L << (VALUES - 88)) | (1L << (WITH - 88)))) != 0) );
			setState(692);
			match(END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_view_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode VIEW() { return getToken(SQLiteParser.VIEW, 0); }
		public View_nameContext view_name() {
			return getRuleContext(View_nameContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode TEMP() { return getToken(SQLiteParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(SQLiteParser.TEMPORARY, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Create_view_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_view_stmt; }
	}

	public final Create_view_stmtContext create_view_stmt() throws RecognitionException {
		Create_view_stmtContext _localctx = new Create_view_stmtContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_create_view_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(694);
			match(CREATE);
			setState(696);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEMP || _la==TEMPORARY) {
				{
				setState(695);
				_la = _input.LA(1);
				if ( !(_la==TEMP || _la==TEMPORARY) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(698);
			match(VIEW);
			setState(702);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,81,_ctx) ) {
			case 1:
				{
				setState(699);
				match(IF);
				setState(700);
				match(NOT);
				setState(701);
				match(EXISTS);
				}
				break;
			}
			setState(707);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,82,_ctx) ) {
			case 1:
				{
				setState(704);
				schema_name();
				setState(705);
				match(DOT);
				}
				break;
			}
			setState(709);
			view_name();
			setState(721);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(710);
				match(OPEN_PAR);
				setState(711);
				column_name();
				setState(716);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(712);
					match(COMMA);
					setState(713);
					column_name();
					}
					}
					setState(718);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(719);
				match(CLOSE_PAR);
				}
			}

			setState(723);
			match(AS);
			setState(724);
			select_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_virtual_table_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode VIRTUAL() { return getToken(SQLiteParser.VIRTUAL, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode USING() { return getToken(SQLiteParser.USING, 0); }
		public Module_nameContext module_name() {
			return getRuleContext(Module_nameContext.class,0);
		}
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Module_argumentContext> module_argument() {
			return getRuleContexts(Module_argumentContext.class);
		}
		public Module_argumentContext module_argument(int i) {
			return getRuleContext(Module_argumentContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Create_virtual_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_virtual_table_stmt; }
	}

	public final Create_virtual_table_stmtContext create_virtual_table_stmt() throws RecognitionException {
		Create_virtual_table_stmtContext _localctx = new Create_virtual_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_create_virtual_table_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(726);
			match(CREATE);
			setState(727);
			match(VIRTUAL);
			setState(728);
			match(TABLE);
			setState(732);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,85,_ctx) ) {
			case 1:
				{
				setState(729);
				match(IF);
				setState(730);
				match(NOT);
				setState(731);
				match(EXISTS);
				}
				break;
			}
			setState(737);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,86,_ctx) ) {
			case 1:
				{
				setState(734);
				schema_name();
				setState(735);
				match(DOT);
				}
				break;
			}
			setState(739);
			table_name();
			setState(740);
			match(USING);
			setState(741);
			module_name();
			setState(753);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(742);
				match(OPEN_PAR);
				setState(743);
				module_argument();
				setState(748);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(744);
					match(COMMA);
					setState(745);
					module_argument();
					}
					}
					setState(750);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(751);
				match(CLOSE_PAR);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class With_clauseContext extends ParserRuleContext {
		public TerminalNode WITH() { return getToken(SQLiteParser.WITH, 0); }
		public List<Cte_table_nameContext> cte_table_name() {
			return getRuleContexts(Cte_table_nameContext.class);
		}
		public Cte_table_nameContext cte_table_name(int i) {
			return getRuleContext(Cte_table_nameContext.class,i);
		}
		public List<TerminalNode> AS() { return getTokens(SQLiteParser.AS); }
		public TerminalNode AS(int i) {
			return getToken(SQLiteParser.AS, i);
		}
		public List<TerminalNode> OPEN_PAR() { return getTokens(SQLiteParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(SQLiteParser.OPEN_PAR, i);
		}
		public List<Select_stmtContext> select_stmt() {
			return getRuleContexts(Select_stmtContext.class);
		}
		public Select_stmtContext select_stmt(int i) {
			return getRuleContext(Select_stmtContext.class,i);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(SQLiteParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(SQLiteParser.CLOSE_PAR, i);
		}
		public TerminalNode RECURSIVE() { return getToken(SQLiteParser.RECURSIVE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public With_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_with_clause; }
	}

	public final With_clauseContext with_clause() throws RecognitionException {
		With_clauseContext _localctx = new With_clauseContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_with_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(755);
			match(WITH);
			setState(757);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,89,_ctx) ) {
			case 1:
				{
				setState(756);
				match(RECURSIVE);
				}
				break;
			}
			setState(759);
			cte_table_name();
			setState(760);
			match(AS);
			setState(761);
			match(OPEN_PAR);
			setState(762);
			select_stmt();
			setState(763);
			match(CLOSE_PAR);
			setState(773);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(764);
				match(COMMA);
				setState(765);
				cte_table_name();
				setState(766);
				match(AS);
				setState(767);
				match(OPEN_PAR);
				setState(768);
				select_stmt();
				setState(769);
				match(CLOSE_PAR);
				}
				}
				setState(775);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Cte_table_nameContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Cte_table_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cte_table_name; }
	}

	public final Cte_table_nameContext cte_table_name() throws RecognitionException {
		Cte_table_nameContext _localctx = new Cte_table_nameContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_cte_table_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(776);
			table_name();
			setState(788);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(777);
				match(OPEN_PAR);
				setState(778);
				column_name();
				setState(783);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(779);
					match(COMMA);
					setState(780);
					column_name();
					}
					}
					setState(785);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(786);
				match(CLOSE_PAR);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Recursive_cteContext extends ParserRuleContext {
		public Cte_table_nameContext cte_table_name() {
			return getRuleContext(Cte_table_nameContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public Initial_selectContext initial_select() {
			return getRuleContext(Initial_selectContext.class,0);
		}
		public TerminalNode UNION() { return getToken(SQLiteParser.UNION, 0); }
		public Recursive_selectContext recursive_select() {
			return getRuleContext(Recursive_selectContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode ALL() { return getToken(SQLiteParser.ALL, 0); }
		public Recursive_cteContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_recursive_cte; }
	}

	public final Recursive_cteContext recursive_cte() throws RecognitionException {
		Recursive_cteContext _localctx = new Recursive_cteContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_recursive_cte);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(790);
			cte_table_name();
			setState(791);
			match(AS);
			setState(792);
			match(OPEN_PAR);
			setState(793);
			initial_select();
			setState(794);
			match(UNION);
			setState(796);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ALL) {
				{
				setState(795);
				match(ALL);
				}
			}

			setState(798);
			recursive_select();
			setState(799);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Common_table_expressionContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public List<TerminalNode> OPEN_PAR() { return getTokens(SQLiteParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(SQLiteParser.OPEN_PAR, i);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(SQLiteParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(SQLiteParser.CLOSE_PAR, i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Common_table_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_common_table_expression; }
	}

	public final Common_table_expressionContext common_table_expression() throws RecognitionException {
		Common_table_expressionContext _localctx = new Common_table_expressionContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_common_table_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(801);
			table_name();
			setState(813);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(802);
				match(OPEN_PAR);
				setState(803);
				column_name();
				setState(808);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(804);
					match(COMMA);
					setState(805);
					column_name();
					}
					}
					setState(810);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(811);
				match(CLOSE_PAR);
				}
			}

			setState(815);
			match(AS);
			setState(816);
			match(OPEN_PAR);
			setState(817);
			select_stmt();
			setState(818);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Delete_stmtContext extends ParserRuleContext {
		public TerminalNode DELETE() { return getToken(SQLiteParser.DELETE, 0); }
		public TerminalNode FROM() { return getToken(SQLiteParser.FROM, 0); }
		public Qualified_table_nameContext qualified_table_name() {
			return getRuleContext(Qualified_table_nameContext.class,0);
		}
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Delete_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_delete_stmt; }
	}

	public final Delete_stmtContext delete_stmt() throws RecognitionException {
		Delete_stmtContext _localctx = new Delete_stmtContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_delete_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(821);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(820);
				with_clause();
				}
			}

			setState(823);
			match(DELETE);
			setState(824);
			match(FROM);
			setState(825);
			qualified_table_name();
			setState(828);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(826);
				match(WHERE);
				setState(827);
				expr(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Delete_stmt_limitedContext extends ParserRuleContext {
		public TerminalNode DELETE() { return getToken(SQLiteParser.DELETE, 0); }
		public TerminalNode FROM() { return getToken(SQLiteParser.FROM, 0); }
		public Qualified_table_nameContext qualified_table_name() {
			return getRuleContext(Qualified_table_nameContext.class,0);
		}
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Limit_stmtContext limit_stmt() {
			return getRuleContext(Limit_stmtContext.class,0);
		}
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Delete_stmt_limitedContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_delete_stmt_limited; }
	}

	public final Delete_stmt_limitedContext delete_stmt_limited() throws RecognitionException {
		Delete_stmt_limitedContext _localctx = new Delete_stmt_limitedContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_delete_stmt_limited);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(831);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(830);
				with_clause();
				}
			}

			setState(833);
			match(DELETE);
			setState(834);
			match(FROM);
			setState(835);
			qualified_table_name();
			setState(838);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(836);
				match(WHERE);
				setState(837);
				expr(0);
				}
			}

			setState(844);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT || _la==ORDER) {
				{
				setState(841);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(840);
					order_by_stmt();
					}
				}

				setState(843);
				limit_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Detach_stmtContext extends ParserRuleContext {
		public TerminalNode DETACH() { return getToken(SQLiteParser.DETACH, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DATABASE() { return getToken(SQLiteParser.DATABASE, 0); }
		public Detach_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_detach_stmt; }
	}

	public final Detach_stmtContext detach_stmt() throws RecognitionException {
		Detach_stmtContext _localctx = new Detach_stmtContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_detach_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(846);
			match(DETACH);
			setState(848);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,102,_ctx) ) {
			case 1:
				{
				setState(847);
				match(DATABASE);
				}
				break;
			}
			setState(850);
			schema_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Drop_stmtContext extends ParserRuleContext {
		public Token object;
		public TerminalNode DROP() { return getToken(SQLiteParser.DROP, 0); }
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public TerminalNode INDEX() { return getToken(SQLiteParser.INDEX, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public TerminalNode TRIGGER() { return getToken(SQLiteParser.TRIGGER, 0); }
		public TerminalNode VIEW() { return getToken(SQLiteParser.VIEW, 0); }
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Drop_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_drop_stmt; }
	}

	public final Drop_stmtContext drop_stmt() throws RecognitionException {
		Drop_stmtContext _localctx = new Drop_stmtContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_drop_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(852);
			match(DROP);
			setState(853);
			((Drop_stmtContext)_localctx).object = _input.LT(1);
			_la = _input.LA(1);
			if ( !(((((_la - 84)) & ~0x3f) == 0 && ((1L << (_la - 84)) & ((1L << (INDEX - 84)) | (1L << (TABLE - 84)) | (1L << (TRIGGER - 84)) | (1L << (VIEW - 84)))) != 0)) ) {
				((Drop_stmtContext)_localctx).object = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(856);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,103,_ctx) ) {
			case 1:
				{
				setState(854);
				match(IF);
				setState(855);
				match(EXISTS);
				}
				break;
			}
			setState(861);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,104,_ctx) ) {
			case 1:
				{
				setState(858);
				schema_name();
				setState(859);
				match(DOT);
				}
				break;
			}
			setState(863);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExprContext extends ParserRuleContext {
		public Literal_valueContext literal_value() {
			return getRuleContext(Literal_valueContext.class,0);
		}
		public TerminalNode BIND_PARAMETER() { return getToken(SQLiteParser.BIND_PARAMETER, 0); }
		public Column_nameContext column_name() {
			return getRuleContext(Column_nameContext.class,0);
		}
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public List<TerminalNode> DOT() { return getTokens(SQLiteParser.DOT); }
		public TerminalNode DOT(int i) {
			return getToken(SQLiteParser.DOT, i);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public Unary_operatorContext unary_operator() {
			return getRuleContext(Unary_operatorContext.class,0);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Function_nameContext function_name() {
			return getRuleContext(Function_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Filter_clauseContext filter_clause() {
			return getRuleContext(Filter_clauseContext.class,0);
		}
		public Over_clauseContext over_clause() {
			return getRuleContext(Over_clauseContext.class,0);
		}
		public TerminalNode DISTINCT() { return getToken(SQLiteParser.DISTINCT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public TerminalNode CAST() { return getToken(SQLiteParser.CAST, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Type_nameContext type_name() {
			return getRuleContext(Type_nameContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode CASE() { return getToken(SQLiteParser.CASE, 0); }
		public TerminalNode END() { return getToken(SQLiteParser.END, 0); }
		public List<TerminalNode> WHEN() { return getTokens(SQLiteParser.WHEN); }
		public TerminalNode WHEN(int i) {
			return getToken(SQLiteParser.WHEN, i);
		}
		public List<TerminalNode> THEN() { return getTokens(SQLiteParser.THEN); }
		public TerminalNode THEN(int i) {
			return getToken(SQLiteParser.THEN, i);
		}
		public TerminalNode ELSE() { return getToken(SQLiteParser.ELSE, 0); }
		public Raise_functionContext raise_function() {
			return getRuleContext(Raise_functionContext.class,0);
		}
		public TerminalNode PIPE2() { return getToken(SQLiteParser.PIPE2, 0); }
		public TerminalNode DIV() { return getToken(SQLiteParser.DIV, 0); }
		public TerminalNode MOD() { return getToken(SQLiteParser.MOD, 0); }
		public TerminalNode PLUS() { return getToken(SQLiteParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(SQLiteParser.MINUS, 0); }
		public TerminalNode LT2() { return getToken(SQLiteParser.LT2, 0); }
		public TerminalNode GT2() { return getToken(SQLiteParser.GT2, 0); }
		public TerminalNode AMP() { return getToken(SQLiteParser.AMP, 0); }
		public TerminalNode PIPE() { return getToken(SQLiteParser.PIPE, 0); }
		public TerminalNode LT() { return getToken(SQLiteParser.LT, 0); }
		public TerminalNode LT_EQ() { return getToken(SQLiteParser.LT_EQ, 0); }
		public TerminalNode GT() { return getToken(SQLiteParser.GT, 0); }
		public TerminalNode GT_EQ() { return getToken(SQLiteParser.GT_EQ, 0); }
		public TerminalNode ASSIGN() { return getToken(SQLiteParser.ASSIGN, 0); }
		public TerminalNode EQ() { return getToken(SQLiteParser.EQ, 0); }
		public TerminalNode NOT_EQ1() { return getToken(SQLiteParser.NOT_EQ1, 0); }
		public TerminalNode NOT_EQ2() { return getToken(SQLiteParser.NOT_EQ2, 0); }
		public TerminalNode IS() { return getToken(SQLiteParser.IS, 0); }
		public TerminalNode IN() { return getToken(SQLiteParser.IN, 0); }
		public TerminalNode LIKE() { return getToken(SQLiteParser.LIKE, 0); }
		public TerminalNode GLOB() { return getToken(SQLiteParser.GLOB, 0); }
		public TerminalNode MATCH() { return getToken(SQLiteParser.MATCH, 0); }
		public TerminalNode REGEXP() { return getToken(SQLiteParser.REGEXP, 0); }
		public TerminalNode AND() { return getToken(SQLiteParser.AND, 0); }
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public TerminalNode BETWEEN() { return getToken(SQLiteParser.BETWEEN, 0); }
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public TerminalNode ESCAPE() { return getToken(SQLiteParser.ESCAPE, 0); }
		public TerminalNode ISNULL() { return getToken(SQLiteParser.ISNULL, 0); }
		public TerminalNode NOTNULL() { return getToken(SQLiteParser.NOTNULL, 0); }
		public TerminalNode NULL_() { return getToken(SQLiteParser.NULL_, 0); }
		public Table_function_nameContext table_function_name() {
			return getRuleContext(Table_function_nameContext.class,0);
		}
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
	}

	public final ExprContext expr() throws RecognitionException {
		return expr(0);
	}

	private ExprContext expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 66;
		enterRecursionRule(_localctx, 66, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(953);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,118,_ctx) ) {
			case 1:
				{
				setState(866);
				literal_value();
				}
				break;
			case 2:
				{
				setState(867);
				match(BIND_PARAMETER);
				}
				break;
			case 3:
				{
				setState(876);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,106,_ctx) ) {
				case 1:
					{
					setState(871);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,105,_ctx) ) {
					case 1:
						{
						setState(868);
						schema_name();
						setState(869);
						match(DOT);
						}
						break;
					}
					setState(873);
					table_name();
					setState(874);
					match(DOT);
					}
					break;
				}
				setState(878);
				column_name();
				}
				break;
			case 4:
				{
				setState(879);
				unary_operator();
				setState(880);
				expr(21);
				}
				break;
			case 5:
				{
				setState(882);
				function_name();
				setState(883);
				match(OPEN_PAR);
				setState(896);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case OPEN_PAR:
				case PLUS:
				case MINUS:
				case TILDE:
				case ABORT:
				case ACTION:
				case ADD:
				case AFTER:
				case ALL:
				case ALTER:
				case ANALYZE:
				case AND:
				case AS:
				case ASC:
				case ATTACH:
				case AUTOINCREMENT:
				case BEFORE:
				case BEGIN:
				case BETWEEN:
				case BY:
				case CASCADE:
				case CASE:
				case CAST:
				case CHECK:
				case COLLATE:
				case COLUMN:
				case COMMIT:
				case CONFLICT:
				case CONSTRAINT:
				case CREATE:
				case CROSS:
				case CURRENT_DATE:
				case CURRENT_TIME:
				case CURRENT_TIMESTAMP:
				case DATABASE:
				case DEFAULT:
				case DEFERRABLE:
				case DEFERRED:
				case DELETE:
				case DESC:
				case DETACH:
				case DISTINCT:
				case DROP:
				case EACH:
				case ELSE:
				case END:
				case ESCAPE:
				case EXCEPT:
				case EXCLUSIVE:
				case EXISTS:
				case EXPLAIN:
				case FAIL:
				case FOR:
				case FOREIGN:
				case FROM:
				case FULL:
				case GLOB:
				case GROUP:
				case HAVING:
				case IF:
				case IGNORE:
				case IMMEDIATE:
				case IN:
				case INDEX:
				case INDEXED:
				case INITIALLY:
				case INNER:
				case INSERT:
				case INSTEAD:
				case INTERSECT:
				case INTO:
				case IS:
				case ISNULL:
				case JOIN:
				case KEY:
				case LEFT:
				case LIKE:
				case LIMIT:
				case MATCH:
				case NATURAL:
				case NO:
				case NOT:
				case NOTNULL:
				case NULL_:
				case OF:
				case OFFSET:
				case ON:
				case OR:
				case ORDER:
				case OUTER:
				case PLAN:
				case PRAGMA:
				case PRIMARY:
				case QUERY:
				case RAISE:
				case RECURSIVE:
				case REFERENCES:
				case REGEXP:
				case REINDEX:
				case RELEASE:
				case RENAME:
				case REPLACE:
				case RESTRICT:
				case RIGHT:
				case ROLLBACK:
				case ROW:
				case ROWS:
				case SAVEPOINT:
				case SELECT:
				case SET:
				case TABLE:
				case TEMP:
				case TEMPORARY:
				case THEN:
				case TO:
				case TRANSACTION:
				case TRIGGER:
				case UNION:
				case UNIQUE:
				case UPDATE:
				case USING:
				case VACUUM:
				case VALUES:
				case VIEW:
				case VIRTUAL:
				case WHEN:
				case WHERE:
				case WITH:
				case WITHOUT:
				case FIRST_VALUE:
				case OVER:
				case PARTITION:
				case RANGE:
				case PRECEDING:
				case UNBOUNDED:
				case CURRENT:
				case FOLLOWING:
				case CUME_DIST:
				case DENSE_RANK:
				case LAG:
				case LAST_VALUE:
				case LEAD:
				case NTH_VALUE:
				case NTILE:
				case PERCENT_RANK:
				case RANK:
				case ROW_NUMBER:
				case GENERATED:
				case ALWAYS:
				case STORED:
				case TRUE_:
				case FALSE_:
				case WINDOW:
				case NULLS:
				case FIRST:
				case LAST:
				case FILTER:
				case GROUPS:
				case EXCLUDE:
				case IDENTIFIER:
				case NUMERIC_LITERAL:
				case BIND_PARAMETER:
				case STRING_LITERAL:
				case BLOB_LITERAL:
					{
					{
					setState(885);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,107,_ctx) ) {
					case 1:
						{
						setState(884);
						match(DISTINCT);
						}
						break;
					}
					setState(887);
					expr(0);
					setState(892);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(888);
						match(COMMA);
						setState(889);
						expr(0);
						}
						}
						setState(894);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
					}
					break;
				case STAR:
					{
					setState(895);
					match(STAR);
					}
					break;
				case CLOSE_PAR:
					break;
				default:
					break;
				}
				setState(898);
				match(CLOSE_PAR);
				setState(900);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,110,_ctx) ) {
				case 1:
					{
					setState(899);
					filter_clause();
					}
					break;
				}
				setState(903);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,111,_ctx) ) {
				case 1:
					{
					setState(902);
					over_clause();
					}
					break;
				}
				}
				break;
			case 6:
				{
				setState(905);
				match(OPEN_PAR);
				setState(906);
				expr(0);
				setState(911);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(907);
					match(COMMA);
					setState(908);
					expr(0);
					}
					}
					setState(913);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(914);
				match(CLOSE_PAR);
				}
				break;
			case 7:
				{
				setState(916);
				match(CAST);
				setState(917);
				match(OPEN_PAR);
				setState(918);
				expr(0);
				setState(919);
				match(AS);
				setState(920);
				type_name();
				setState(921);
				match(CLOSE_PAR);
				}
				break;
			case 8:
				{
				setState(927);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==EXISTS || _la==NOT) {
					{
					setState(924);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==NOT) {
						{
						setState(923);
						match(NOT);
						}
					}

					setState(926);
					match(EXISTS);
					}
				}

				setState(929);
				match(OPEN_PAR);
				setState(930);
				select_stmt();
				setState(931);
				match(CLOSE_PAR);
				}
				break;
			case 9:
				{
				setState(933);
				match(CASE);
				setState(935);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,115,_ctx) ) {
				case 1:
					{
					setState(934);
					expr(0);
					}
					break;
				}
				setState(942); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(937);
					match(WHEN);
					setState(938);
					expr(0);
					setState(939);
					match(THEN);
					setState(940);
					expr(0);
					}
					}
					setState(944); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==WHEN );
				setState(948);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ELSE) {
					{
					setState(946);
					match(ELSE);
					setState(947);
					expr(0);
					}
				}

				setState(950);
				match(END);
				}
				break;
			case 10:
				{
				setState(952);
				raise_function();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(1074);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,134,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(1072);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,133,_ctx) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(955);
						if (!(precpred(_ctx, 20))) throw new FailedPredicateException(this, "precpred(_ctx, 20)");
						setState(956);
						match(PIPE2);
						setState(957);
						expr(21);
						}
						break;
					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(958);
						if (!(precpred(_ctx, 19))) throw new FailedPredicateException(this, "precpred(_ctx, 19)");
						setState(959);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << DIV) | (1L << MOD))) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(960);
						expr(20);
						}
						break;
					case 3:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(961);
						if (!(precpred(_ctx, 18))) throw new FailedPredicateException(this, "precpred(_ctx, 18)");
						setState(962);
						_la = _input.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(963);
						expr(19);
						}
						break;
					case 4:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(964);
						if (!(precpred(_ctx, 17))) throw new FailedPredicateException(this, "precpred(_ctx, 17)");
						setState(965);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LT2) | (1L << GT2) | (1L << AMP) | (1L << PIPE))) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(966);
						expr(18);
						}
						break;
					case 5:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(967);
						if (!(precpred(_ctx, 16))) throw new FailedPredicateException(this, "precpred(_ctx, 16)");
						setState(968);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LT) | (1L << LT_EQ) | (1L << GT) | (1L << GT_EQ))) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(969);
						expr(17);
						}
						break;
					case 6:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(970);
						if (!(precpred(_ctx, 15))) throw new FailedPredicateException(this, "precpred(_ctx, 15)");
						setState(983);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,119,_ctx) ) {
						case 1:
							{
							setState(971);
							match(ASSIGN);
							}
							break;
						case 2:
							{
							setState(972);
							match(EQ);
							}
							break;
						case 3:
							{
							setState(973);
							match(NOT_EQ1);
							}
							break;
						case 4:
							{
							setState(974);
							match(NOT_EQ2);
							}
							break;
						case 5:
							{
							setState(975);
							match(IS);
							}
							break;
						case 6:
							{
							setState(976);
							match(IS);
							setState(977);
							match(NOT);
							}
							break;
						case 7:
							{
							setState(978);
							match(IN);
							}
							break;
						case 8:
							{
							setState(979);
							match(LIKE);
							}
							break;
						case 9:
							{
							setState(980);
							match(GLOB);
							}
							break;
						case 10:
							{
							setState(981);
							match(MATCH);
							}
							break;
						case 11:
							{
							setState(982);
							match(REGEXP);
							}
							break;
						}
						setState(985);
						expr(16);
						}
						break;
					case 7:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(986);
						if (!(precpred(_ctx, 14))) throw new FailedPredicateException(this, "precpred(_ctx, 14)");
						setState(987);
						match(AND);
						setState(988);
						expr(15);
						}
						break;
					case 8:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(989);
						if (!(precpred(_ctx, 13))) throw new FailedPredicateException(this, "precpred(_ctx, 13)");
						setState(990);
						match(OR);
						setState(991);
						expr(14);
						}
						break;
					case 9:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(992);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(993);
						match(IS);
						setState(995);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,120,_ctx) ) {
						case 1:
							{
							setState(994);
							match(NOT);
							}
							break;
						}
						setState(997);
						expr(7);
						}
						break;
					case 10:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(998);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(1000);
						_errHandler.sync(this);
						_la = _input.LA(1);
						if (_la==NOT) {
							{
							setState(999);
							match(NOT);
							}
						}

						setState(1002);
						match(BETWEEN);
						setState(1003);
						expr(0);
						setState(1004);
						match(AND);
						setState(1005);
						expr(6);
						}
						break;
					case 11:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(1007);
						if (!(precpred(_ctx, 9))) throw new FailedPredicateException(this, "precpred(_ctx, 9)");
						setState(1008);
						match(COLLATE);
						setState(1009);
						collation_name();
						}
						break;
					case 12:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(1010);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(1012);
						_errHandler.sync(this);
						_la = _input.LA(1);
						if (_la==NOT) {
							{
							setState(1011);
							match(NOT);
							}
						}

						setState(1014);
						_la = _input.LA(1);
						if ( !(((((_la - 77)) & ~0x3f) == 0 && ((1L << (_la - 77)) & ((1L << (GLOB - 77)) | (1L << (LIKE - 77)) | (1L << (MATCH - 77)) | (1L << (REGEXP - 77)))) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(1015);
						expr(0);
						setState(1018);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,123,_ctx) ) {
						case 1:
							{
							setState(1016);
							match(ESCAPE);
							setState(1017);
							expr(0);
							}
							break;
						}
						}
						break;
					case 13:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(1020);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(1025);
						_errHandler.sync(this);
						switch (_input.LA(1)) {
						case ISNULL:
							{
							setState(1021);
							match(ISNULL);
							}
							break;
						case NOTNULL:
							{
							setState(1022);
							match(NOTNULL);
							}
							break;
						case NOT:
							{
							{
							setState(1023);
							match(NOT);
							setState(1024);
							match(NULL_);
							}
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						}
						break;
					case 14:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(1027);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(1029);
						_errHandler.sync(this);
						_la = _input.LA(1);
						if (_la==NOT) {
							{
							setState(1028);
							match(NOT);
							}
						}

						setState(1031);
						match(IN);
						setState(1070);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,132,_ctx) ) {
						case 1:
							{
							{
							setState(1032);
							match(OPEN_PAR);
							setState(1042);
							_errHandler.sync(this);
							switch ( getInterpreter().adaptivePredict(_input,127,_ctx) ) {
							case 1:
								{
								setState(1033);
								select_stmt();
								}
								break;
							case 2:
								{
								setState(1034);
								expr(0);
								setState(1039);
								_errHandler.sync(this);
								_la = _input.LA(1);
								while (_la==COMMA) {
									{
									{
									setState(1035);
									match(COMMA);
									setState(1036);
									expr(0);
									}
									}
									setState(1041);
									_errHandler.sync(this);
									_la = _input.LA(1);
								}
								}
								break;
							}
							setState(1044);
							match(CLOSE_PAR);
							}
							}
							break;
						case 2:
							{
							{
							setState(1048);
							_errHandler.sync(this);
							switch ( getInterpreter().adaptivePredict(_input,128,_ctx) ) {
							case 1:
								{
								setState(1045);
								schema_name();
								setState(1046);
								match(DOT);
								}
								break;
							}
							setState(1050);
							table_name();
							}
							}
							break;
						case 3:
							{
							{
							setState(1054);
							_errHandler.sync(this);
							switch ( getInterpreter().adaptivePredict(_input,129,_ctx) ) {
							case 1:
								{
								setState(1051);
								schema_name();
								setState(1052);
								match(DOT);
								}
								break;
							}
							setState(1056);
							table_function_name();
							setState(1057);
							match(OPEN_PAR);
							setState(1066);
							_errHandler.sync(this);
							_la = _input.LA(1);
							if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAR) | (1L << PLUS) | (1L << MINUS) | (1L << TILDE) | (1L << ABORT) | (1L << ACTION) | (1L << ADD) | (1L << AFTER) | (1L << ALL) | (1L << ALTER) | (1L << ANALYZE) | (1L << AND) | (1L << AS) | (1L << ASC) | (1L << ATTACH) | (1L << AUTOINCREMENT) | (1L << BEFORE) | (1L << BEGIN) | (1L << BETWEEN) | (1L << BY) | (1L << CASCADE) | (1L << CASE) | (1L << CAST) | (1L << CHECK) | (1L << COLLATE) | (1L << COLUMN) | (1L << COMMIT) | (1L << CONFLICT) | (1L << CONSTRAINT) | (1L << CREATE) | (1L << CROSS) | (1L << CURRENT_DATE) | (1L << CURRENT_TIME) | (1L << CURRENT_TIMESTAMP) | (1L << DATABASE) | (1L << DEFAULT) | (1L << DEFERRABLE) | (1L << DEFERRED) | (1L << DELETE) | (1L << DESC) | (1L << DETACH) | (1L << DISTINCT) | (1L << DROP))) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (EACH - 64)) | (1L << (ELSE - 64)) | (1L << (END - 64)) | (1L << (ESCAPE - 64)) | (1L << (EXCEPT - 64)) | (1L << (EXCLUSIVE - 64)) | (1L << (EXISTS - 64)) | (1L << (EXPLAIN - 64)) | (1L << (FAIL - 64)) | (1L << (FOR - 64)) | (1L << (FOREIGN - 64)) | (1L << (FROM - 64)) | (1L << (FULL - 64)) | (1L << (GLOB - 64)) | (1L << (GROUP - 64)) | (1L << (HAVING - 64)) | (1L << (IF - 64)) | (1L << (IGNORE - 64)) | (1L << (IMMEDIATE - 64)) | (1L << (IN - 64)) | (1L << (INDEX - 64)) | (1L << (INDEXED - 64)) | (1L << (INITIALLY - 64)) | (1L << (INNER - 64)) | (1L << (INSERT - 64)) | (1L << (INSTEAD - 64)) | (1L << (INTERSECT - 64)) | (1L << (INTO - 64)) | (1L << (IS - 64)) | (1L << (ISNULL - 64)) | (1L << (JOIN - 64)) | (1L << (KEY - 64)) | (1L << (LEFT - 64)) | (1L << (LIKE - 64)) | (1L << (LIMIT - 64)) | (1L << (MATCH - 64)) | (1L << (NATURAL - 64)) | (1L << (NO - 64)) | (1L << (NOT - 64)) | (1L << (NOTNULL - 64)) | (1L << (NULL_ - 64)) | (1L << (OF - 64)) | (1L << (OFFSET - 64)) | (1L << (ON - 64)) | (1L << (OR - 64)) | (1L << (ORDER - 64)) | (1L << (OUTER - 64)) | (1L << (PLAN - 64)) | (1L << (PRAGMA - 64)) | (1L << (PRIMARY - 64)) | (1L << (QUERY - 64)) | (1L << (RAISE - 64)) | (1L << (RECURSIVE - 64)) | (1L << (REFERENCES - 64)) | (1L << (REGEXP - 64)) | (1L << (REINDEX - 64)) | (1L << (RELEASE - 64)) | (1L << (RENAME - 64)) | (1L << (REPLACE - 64)) | (1L << (RESTRICT - 64)) | (1L << (RIGHT - 64)) | (1L << (ROLLBACK - 64)) | (1L << (ROW - 64)) | (1L << (ROWS - 64)))) != 0) || ((((_la - 128)) & ~0x3f) == 0 && ((1L << (_la - 128)) & ((1L << (SAVEPOINT - 128)) | (1L << (SELECT - 128)) | (1L << (SET - 128)) | (1L << (TABLE - 128)) | (1L << (TEMP - 128)) | (1L << (TEMPORARY - 128)) | (1L << (THEN - 128)) | (1L << (TO - 128)) | (1L << (TRANSACTION - 128)) | (1L << (TRIGGER - 128)) | (1L << (UNION - 128)) | (1L << (UNIQUE - 128)) | (1L << (UPDATE - 128)) | (1L << (USING - 128)) | (1L << (VACUUM - 128)) | (1L << (VALUES - 128)) | (1L << (VIEW - 128)) | (1L << (VIRTUAL - 128)) | (1L << (WHEN - 128)) | (1L << (WHERE - 128)) | (1L << (WITH - 128)) | (1L << (WITHOUT - 128)) | (1L << (FIRST_VALUE - 128)) | (1L << (OVER - 128)) | (1L << (PARTITION - 128)) | (1L << (RANGE - 128)) | (1L << (PRECEDING - 128)) | (1L << (UNBOUNDED - 128)) | (1L << (CURRENT - 128)) | (1L << (FOLLOWING - 128)) | (1L << (CUME_DIST - 128)) | (1L << (DENSE_RANK - 128)) | (1L << (LAG - 128)) | (1L << (LAST_VALUE - 128)) | (1L << (LEAD - 128)) | (1L << (NTH_VALUE - 128)) | (1L << (NTILE - 128)) | (1L << (PERCENT_RANK - 128)) | (1L << (RANK - 128)) | (1L << (ROW_NUMBER - 128)) | (1L << (GENERATED - 128)) | (1L << (ALWAYS - 128)) | (1L << (STORED - 128)) | (1L << (TRUE_ - 128)) | (1L << (FALSE_ - 128)) | (1L << (WINDOW - 128)) | (1L << (NULLS - 128)) | (1L << (FIRST - 128)) | (1L << (LAST - 128)) | (1L << (FILTER - 128)) | (1L << (GROUPS - 128)) | (1L << (EXCLUDE - 128)) | (1L << (IDENTIFIER - 128)) | (1L << (NUMERIC_LITERAL - 128)) | (1L << (BIND_PARAMETER - 128)) | (1L << (STRING_LITERAL - 128)) | (1L << (BLOB_LITERAL - 128)))) != 0)) {
								{
								setState(1058);
								expr(0);
								setState(1063);
								_errHandler.sync(this);
								_la = _input.LA(1);
								while (_la==COMMA) {
									{
									{
									setState(1059);
									match(COMMA);
									setState(1060);
									expr(0);
									}
									}
									setState(1065);
									_errHandler.sync(this);
									_la = _input.LA(1);
								}
								}
							}

							setState(1068);
							match(CLOSE_PAR);
							}
							}
							break;
						}
						}
						break;
					}
					} 
				}
				setState(1076);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,134,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class Raise_functionContext extends ParserRuleContext {
		public TerminalNode RAISE() { return getToken(SQLiteParser.RAISE, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Error_messageContext error_message() {
			return getRuleContext(Error_messageContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public Raise_functionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_raise_function; }
	}

	public final Raise_functionContext raise_function() throws RecognitionException {
		Raise_functionContext _localctx = new Raise_functionContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_raise_function);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1077);
			match(RAISE);
			setState(1078);
			match(OPEN_PAR);
			setState(1083);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IGNORE:
				{
				setState(1079);
				match(IGNORE);
				}
				break;
			case ABORT:
			case FAIL:
			case ROLLBACK:
				{
				{
				setState(1080);
				_la = _input.LA(1);
				if ( !(_la==ABORT || _la==FAIL || _la==ROLLBACK) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1081);
				match(COMMA);
				setState(1082);
				error_message();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(1085);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Literal_valueContext extends ParserRuleContext {
		public TerminalNode NUMERIC_LITERAL() { return getToken(SQLiteParser.NUMERIC_LITERAL, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public TerminalNode BLOB_LITERAL() { return getToken(SQLiteParser.BLOB_LITERAL, 0); }
		public TerminalNode NULL_() { return getToken(SQLiteParser.NULL_, 0); }
		public TerminalNode TRUE_() { return getToken(SQLiteParser.TRUE_, 0); }
		public TerminalNode FALSE_() { return getToken(SQLiteParser.FALSE_, 0); }
		public TerminalNode CURRENT_TIME() { return getToken(SQLiteParser.CURRENT_TIME, 0); }
		public TerminalNode CURRENT_DATE() { return getToken(SQLiteParser.CURRENT_DATE, 0); }
		public TerminalNode CURRENT_TIMESTAMP() { return getToken(SQLiteParser.CURRENT_TIMESTAMP, 0); }
		public Literal_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literal_value; }
	}

	public final Literal_valueContext literal_value() throws RecognitionException {
		Literal_valueContext _localctx = new Literal_valueContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_literal_value);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1087);
			_la = _input.LA(1);
			if ( !(((((_la - 52)) & ~0x3f) == 0 && ((1L << (_la - 52)) & ((1L << (CURRENT_DATE - 52)) | (1L << (CURRENT_TIME - 52)) | (1L << (CURRENT_TIMESTAMP - 52)) | (1L << (NULL_ - 52)))) != 0) || ((((_la - 171)) & ~0x3f) == 0 && ((1L << (_la - 171)) & ((1L << (TRUE_ - 171)) | (1L << (FALSE_ - 171)) | (1L << (NUMERIC_LITERAL - 171)) | (1L << (STRING_LITERAL - 171)) | (1L << (BLOB_LITERAL - 171)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Insert_stmtContext extends ParserRuleContext {
		public TerminalNode INTO() { return getToken(SQLiteParser.INTO, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode INSERT() { return getToken(SQLiteParser.INSERT, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Table_aliasContext table_alias() {
			return getRuleContext(Table_aliasContext.class,0);
		}
		public List<TerminalNode> OPEN_PAR() { return getTokens(SQLiteParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(SQLiteParser.OPEN_PAR, i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(SQLiteParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(SQLiteParser.CLOSE_PAR, i);
		}
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public Upsert_clauseContext upsert_clause() {
			return getRuleContext(Upsert_clauseContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public TerminalNode VALUES() { return getToken(SQLiteParser.VALUES, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode DEFAULT() { return getToken(SQLiteParser.DEFAULT, 0); }
		public Insert_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_insert_stmt; }
	}

	public final Insert_stmtContext insert_stmt() throws RecognitionException {
		Insert_stmtContext _localctx = new Insert_stmtContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_insert_stmt);
		int _la;
		try {
			setState(1159);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INSERT:
			case REPLACE:
			case WITH:
				enterOuterAlt(_localctx, 1);
				{
				setState(1090);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WITH) {
					{
					setState(1089);
					with_clause();
					}
				}

				setState(1097);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,137,_ctx) ) {
				case 1:
					{
					setState(1092);
					match(INSERT);
					}
					break;
				case 2:
					{
					setState(1093);
					match(REPLACE);
					}
					break;
				case 3:
					{
					{
					setState(1094);
					match(INSERT);
					setState(1095);
					match(OR);
					setState(1096);
					_la = _input.LA(1);
					if ( !(_la==ABORT || ((((_la - 72)) & ~0x3f) == 0 && ((1L << (_la - 72)) & ((1L << (FAIL - 72)) | (1L << (IGNORE - 72)) | (1L << (REPLACE - 72)) | (1L << (ROLLBACK - 72)))) != 0)) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
					}
					break;
				}
				setState(1099);
				match(INTO);
				setState(1103);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,138,_ctx) ) {
				case 1:
					{
					setState(1100);
					schema_name();
					setState(1101);
					match(DOT);
					}
					break;
				}
				setState(1105);
				table_name();
				setState(1108);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AS) {
					{
					setState(1106);
					match(AS);
					setState(1107);
					table_alias();
					}
				}

				setState(1121);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==OPEN_PAR) {
					{
					setState(1110);
					match(OPEN_PAR);
					setState(1111);
					column_name();
					setState(1116);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1112);
						match(COMMA);
						setState(1113);
						column_name();
						}
						}
						setState(1118);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					setState(1119);
					match(CLOSE_PAR);
					}
				}

				{
				setState(1152);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,145,_ctx) ) {
				case 1:
					{
					{
					setState(1123);
					match(VALUES);
					setState(1124);
					match(OPEN_PAR);
					setState(1125);
					expr(0);
					setState(1130);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1126);
						match(COMMA);
						setState(1127);
						expr(0);
						}
						}
						setState(1132);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					setState(1133);
					match(CLOSE_PAR);
					setState(1148);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1134);
						match(COMMA);
						setState(1135);
						match(OPEN_PAR);
						setState(1136);
						expr(0);
						setState(1141);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==COMMA) {
							{
							{
							setState(1137);
							match(COMMA);
							setState(1138);
							expr(0);
							}
							}
							setState(1143);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						setState(1144);
						match(CLOSE_PAR);
						}
						}
						setState(1150);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
					}
					break;
				case 2:
					{
					setState(1151);
					select_stmt();
					}
					break;
				}
				setState(1155);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(1154);
					upsert_clause();
					}
				}

				}
				}
				break;
			case DEFAULT:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1157);
				match(DEFAULT);
				setState(1158);
				match(VALUES);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Upsert_clauseContext extends ParserRuleContext {
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public TerminalNode CONFLICT() { return getToken(SQLiteParser.CONFLICT, 0); }
		public TerminalNode DO() { return getToken(SQLiteParser.DO, 0); }
		public TerminalNode NOTHING() { return getToken(SQLiteParser.NOTHING, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Indexed_columnContext> indexed_column() {
			return getRuleContexts(Indexed_columnContext.class);
		}
		public Indexed_columnContext indexed_column(int i) {
			return getRuleContext(Indexed_columnContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public TerminalNode SET() { return getToken(SQLiteParser.SET, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public List<TerminalNode> WHERE() { return getTokens(SQLiteParser.WHERE); }
		public TerminalNode WHERE(int i) {
			return getToken(SQLiteParser.WHERE, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<TerminalNode> EQ() { return getTokens(SQLiteParser.EQ); }
		public TerminalNode EQ(int i) {
			return getToken(SQLiteParser.EQ, i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<Column_name_listContext> column_name_list() {
			return getRuleContexts(Column_name_listContext.class);
		}
		public Column_name_listContext column_name_list(int i) {
			return getRuleContext(Column_name_listContext.class,i);
		}
		public Upsert_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_upsert_clause; }
	}

	public final Upsert_clauseContext upsert_clause() throws RecognitionException {
		Upsert_clauseContext _localctx = new Upsert_clauseContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_upsert_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1161);
			match(ON);
			setState(1162);
			match(CONFLICT);
			setState(1177);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(1163);
				match(OPEN_PAR);
				setState(1164);
				indexed_column();
				setState(1169);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1165);
					match(COMMA);
					setState(1166);
					indexed_column();
					}
					}
					setState(1171);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1172);
				match(CLOSE_PAR);
				setState(1175);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(1173);
					match(WHERE);
					setState(1174);
					expr(0);
					}
				}

				}
			}

			setState(1179);
			match(DO);
			setState(1206);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NOTHING:
				{
				setState(1180);
				match(NOTHING);
				}
				break;
			case UPDATE:
				{
				{
				setState(1181);
				match(UPDATE);
				setState(1182);
				match(SET);
				{
				setState(1185);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,151,_ctx) ) {
				case 1:
					{
					setState(1183);
					column_name();
					}
					break;
				case 2:
					{
					setState(1184);
					column_name_list();
					}
					break;
				}
				setState(1187);
				match(EQ);
				setState(1188);
				expr(0);
				setState(1199);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1189);
					match(COMMA);
					setState(1192);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,152,_ctx) ) {
					case 1:
						{
						setState(1190);
						column_name();
						}
						break;
					case 2:
						{
						setState(1191);
						column_name_list();
						}
						break;
					}
					setState(1194);
					match(EQ);
					setState(1195);
					expr(0);
					}
					}
					setState(1201);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1204);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(1202);
					match(WHERE);
					setState(1203);
					expr(0);
					}
				}

				}
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Pragma_stmtContext extends ParserRuleContext {
		public TerminalNode PRAGMA() { return getToken(SQLiteParser.PRAGMA, 0); }
		public Pragma_nameContext pragma_name() {
			return getRuleContext(Pragma_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode ASSIGN() { return getToken(SQLiteParser.ASSIGN, 0); }
		public Pragma_valueContext pragma_value() {
			return getRuleContext(Pragma_valueContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Pragma_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pragma_stmt; }
	}

	public final Pragma_stmtContext pragma_stmt() throws RecognitionException {
		Pragma_stmtContext _localctx = new Pragma_stmtContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_pragma_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1208);
			match(PRAGMA);
			setState(1212);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,156,_ctx) ) {
			case 1:
				{
				setState(1209);
				schema_name();
				setState(1210);
				match(DOT);
				}
				break;
			}
			setState(1214);
			pragma_name();
			setState(1221);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ASSIGN:
				{
				setState(1215);
				match(ASSIGN);
				setState(1216);
				pragma_value();
				}
				break;
			case OPEN_PAR:
				{
				setState(1217);
				match(OPEN_PAR);
				setState(1218);
				pragma_value();
				setState(1219);
				match(CLOSE_PAR);
				}
				break;
			case EOF:
			case SCOL:
			case ALTER:
			case ANALYZE:
			case ATTACH:
			case BEGIN:
			case COMMIT:
			case CREATE:
			case DEFAULT:
			case DELETE:
			case DETACH:
			case DROP:
			case END:
			case EXPLAIN:
			case INSERT:
			case PRAGMA:
			case REINDEX:
			case RELEASE:
			case REPLACE:
			case ROLLBACK:
			case SAVEPOINT:
			case SELECT:
			case UPDATE:
			case VACUUM:
			case VALUES:
			case WITH:
			case UNEXPECTED_CHAR:
				break;
			default:
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Pragma_valueContext extends ParserRuleContext {
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public Pragma_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pragma_value; }
	}

	public final Pragma_valueContext pragma_value() throws RecognitionException {
		Pragma_valueContext _localctx = new Pragma_valueContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_pragma_value);
		try {
			setState(1226);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,158,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(1223);
				signed_number();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(1224);
				name();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(1225);
				match(STRING_LITERAL);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Reindex_stmtContext extends ParserRuleContext {
		public TerminalNode REINDEX() { return getToken(SQLiteParser.REINDEX, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Reindex_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_reindex_stmt; }
	}

	public final Reindex_stmtContext reindex_stmt() throws RecognitionException {
		Reindex_stmtContext _localctx = new Reindex_stmtContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_reindex_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1228);
			match(REINDEX);
			setState(1239);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,161,_ctx) ) {
			case 1:
				{
				setState(1229);
				collation_name();
				}
				break;
			case 2:
				{
				{
				setState(1233);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,159,_ctx) ) {
				case 1:
					{
					setState(1230);
					schema_name();
					setState(1231);
					match(DOT);
					}
					break;
				}
				setState(1237);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,160,_ctx) ) {
				case 1:
					{
					setState(1235);
					table_name();
					}
					break;
				case 2:
					{
					setState(1236);
					index_name();
					}
					break;
				}
				}
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Select_stmtContext extends ParserRuleContext {
		public List<Select_coreContext> select_core() {
			return getRuleContexts(Select_coreContext.class);
		}
		public Select_coreContext select_core(int i) {
			return getRuleContext(Select_coreContext.class,i);
		}
		public Common_table_stmtContext common_table_stmt() {
			return getRuleContext(Common_table_stmtContext.class,0);
		}
		public List<Compound_operatorContext> compound_operator() {
			return getRuleContexts(Compound_operatorContext.class);
		}
		public Compound_operatorContext compound_operator(int i) {
			return getRuleContext(Compound_operatorContext.class,i);
		}
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Limit_stmtContext limit_stmt() {
			return getRuleContext(Limit_stmtContext.class,0);
		}
		public Select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select_stmt; }
	}

	public final Select_stmtContext select_stmt() throws RecognitionException {
		Select_stmtContext _localctx = new Select_stmtContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_select_stmt);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(1242);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1241);
				common_table_stmt();
				}
			}

			setState(1244);
			select_core();
			setState(1250);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,163,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(1245);
					compound_operator();
					setState(1246);
					select_core();
					}
					} 
				}
				setState(1252);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,163,_ctx);
			}
			setState(1254);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDER) {
				{
				setState(1253);
				order_by_stmt();
				}
			}

			setState(1257);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(1256);
				limit_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Join_clauseContext extends ParserRuleContext {
		public List<Table_or_subqueryContext> table_or_subquery() {
			return getRuleContexts(Table_or_subqueryContext.class);
		}
		public Table_or_subqueryContext table_or_subquery(int i) {
			return getRuleContext(Table_or_subqueryContext.class,i);
		}
		public List<Join_operatorContext> join_operator() {
			return getRuleContexts(Join_operatorContext.class);
		}
		public Join_operatorContext join_operator(int i) {
			return getRuleContext(Join_operatorContext.class,i);
		}
		public List<Join_constraintContext> join_constraint() {
			return getRuleContexts(Join_constraintContext.class);
		}
		public Join_constraintContext join_constraint(int i) {
			return getRuleContext(Join_constraintContext.class,i);
		}
		public Join_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_join_clause; }
	}

	public final Join_clauseContext join_clause() throws RecognitionException {
		Join_clauseContext _localctx = new Join_clauseContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_join_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1259);
			table_or_subquery();
			setState(1267);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA || _la==CROSS || ((((_la - 87)) & ~0x3f) == 0 && ((1L << (_la - 87)) & ((1L << (INNER - 87)) | (1L << (JOIN - 87)) | (1L << (LEFT - 87)) | (1L << (NATURAL - 87)))) != 0)) {
				{
				{
				setState(1260);
				join_operator();
				setState(1261);
				table_or_subquery();
				setState(1263);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,166,_ctx) ) {
				case 1:
					{
					setState(1262);
					join_constraint();
					}
					break;
				}
				}
				}
				setState(1269);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Select_coreContext extends ParserRuleContext {
		public TerminalNode SELECT() { return getToken(SQLiteParser.SELECT, 0); }
		public List<Result_columnContext> result_column() {
			return getRuleContexts(Result_columnContext.class);
		}
		public Result_columnContext result_column(int i) {
			return getRuleContext(Result_columnContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public TerminalNode FROM() { return getToken(SQLiteParser.FROM, 0); }
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode GROUP() { return getToken(SQLiteParser.GROUP, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public TerminalNode WINDOW() { return getToken(SQLiteParser.WINDOW, 0); }
		public List<Window_nameContext> window_name() {
			return getRuleContexts(Window_nameContext.class);
		}
		public Window_nameContext window_name(int i) {
			return getRuleContext(Window_nameContext.class,i);
		}
		public List<TerminalNode> AS() { return getTokens(SQLiteParser.AS); }
		public TerminalNode AS(int i) {
			return getToken(SQLiteParser.AS, i);
		}
		public List<Window_defnContext> window_defn() {
			return getRuleContexts(Window_defnContext.class);
		}
		public Window_defnContext window_defn(int i) {
			return getRuleContext(Window_defnContext.class,i);
		}
		public TerminalNode DISTINCT() { return getToken(SQLiteParser.DISTINCT, 0); }
		public TerminalNode ALL() { return getToken(SQLiteParser.ALL, 0); }
		public List<Table_or_subqueryContext> table_or_subquery() {
			return getRuleContexts(Table_or_subqueryContext.class);
		}
		public Table_or_subqueryContext table_or_subquery(int i) {
			return getRuleContext(Table_or_subqueryContext.class,i);
		}
		public Join_clauseContext join_clause() {
			return getRuleContext(Join_clauseContext.class,0);
		}
		public TerminalNode HAVING() { return getToken(SQLiteParser.HAVING, 0); }
		public TerminalNode VALUES() { return getToken(SQLiteParser.VALUES, 0); }
		public List<TerminalNode> OPEN_PAR() { return getTokens(SQLiteParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(SQLiteParser.OPEN_PAR, i);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(SQLiteParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(SQLiteParser.CLOSE_PAR, i);
		}
		public Select_coreContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select_core; }
	}

	public final Select_coreContext select_core() throws RecognitionException {
		Select_coreContext _localctx = new Select_coreContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_select_core);
		int _la;
		try {
			setState(1360);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SELECT:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1270);
				match(SELECT);
				setState(1272);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,168,_ctx) ) {
				case 1:
					{
					setState(1271);
					_la = _input.LA(1);
					if ( !(_la==ALL || _la==DISTINCT) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
					break;
				}
				setState(1274);
				result_column();
				setState(1279);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1275);
					match(COMMA);
					setState(1276);
					result_column();
					}
					}
					setState(1281);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1294);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==FROM) {
					{
					setState(1282);
					match(FROM);
					setState(1292);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,171,_ctx) ) {
					case 1:
						{
						setState(1283);
						table_or_subquery();
						setState(1288);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==COMMA) {
							{
							{
							setState(1284);
							match(COMMA);
							setState(1285);
							table_or_subquery();
							}
							}
							setState(1290);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						}
						break;
					case 2:
						{
						setState(1291);
						join_clause();
						}
						break;
					}
					}
				}

				setState(1298);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(1296);
					match(WHERE);
					setState(1297);
					expr(0);
					}
				}

				setState(1314);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==GROUP) {
					{
					setState(1300);
					match(GROUP);
					setState(1301);
					match(BY);
					setState(1302);
					expr(0);
					setState(1307);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1303);
						match(COMMA);
						setState(1304);
						expr(0);
						}
						}
						setState(1309);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					setState(1312);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==HAVING) {
						{
						setState(1310);
						match(HAVING);
						setState(1311);
						expr(0);
						}
					}

					}
				}

				setState(1330);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WINDOW) {
					{
					setState(1316);
					match(WINDOW);
					setState(1317);
					window_name();
					setState(1318);
					match(AS);
					setState(1319);
					window_defn();
					setState(1327);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1320);
						match(COMMA);
						setState(1321);
						window_name();
						setState(1322);
						match(AS);
						setState(1323);
						window_defn();
						}
						}
						setState(1329);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				}
				}
				break;
			case VALUES:
				enterOuterAlt(_localctx, 2);
				{
				setState(1332);
				match(VALUES);
				setState(1333);
				match(OPEN_PAR);
				setState(1334);
				expr(0);
				setState(1339);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1335);
					match(COMMA);
					setState(1336);
					expr(0);
					}
					}
					setState(1341);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1342);
				match(CLOSE_PAR);
				setState(1357);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1343);
					match(COMMA);
					setState(1344);
					match(OPEN_PAR);
					setState(1345);
					expr(0);
					setState(1350);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1346);
						match(COMMA);
						setState(1347);
						expr(0);
						}
						}
						setState(1352);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					setState(1353);
					match(CLOSE_PAR);
					}
					}
					setState(1359);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Factored_select_stmtContext extends ParserRuleContext {
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Factored_select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_factored_select_stmt; }
	}

	public final Factored_select_stmtContext factored_select_stmt() throws RecognitionException {
		Factored_select_stmtContext _localctx = new Factored_select_stmtContext(_ctx, getState());
		enterRule(_localctx, 88, RULE_factored_select_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1362);
			select_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Simple_select_stmtContext extends ParserRuleContext {
		public Select_coreContext select_core() {
			return getRuleContext(Select_coreContext.class,0);
		}
		public Common_table_stmtContext common_table_stmt() {
			return getRuleContext(Common_table_stmtContext.class,0);
		}
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Limit_stmtContext limit_stmt() {
			return getRuleContext(Limit_stmtContext.class,0);
		}
		public Simple_select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simple_select_stmt; }
	}

	public final Simple_select_stmtContext simple_select_stmt() throws RecognitionException {
		Simple_select_stmtContext _localctx = new Simple_select_stmtContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_simple_select_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1365);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1364);
				common_table_stmt();
				}
			}

			setState(1367);
			select_core();
			setState(1369);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDER) {
				{
				setState(1368);
				order_by_stmt();
				}
			}

			setState(1372);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(1371);
				limit_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Compound_select_stmtContext extends ParserRuleContext {
		public List<Select_coreContext> select_core() {
			return getRuleContexts(Select_coreContext.class);
		}
		public Select_coreContext select_core(int i) {
			return getRuleContext(Select_coreContext.class,i);
		}
		public Common_table_stmtContext common_table_stmt() {
			return getRuleContext(Common_table_stmtContext.class,0);
		}
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Limit_stmtContext limit_stmt() {
			return getRuleContext(Limit_stmtContext.class,0);
		}
		public List<TerminalNode> INTERSECT() { return getTokens(SQLiteParser.INTERSECT); }
		public TerminalNode INTERSECT(int i) {
			return getToken(SQLiteParser.INTERSECT, i);
		}
		public List<TerminalNode> EXCEPT() { return getTokens(SQLiteParser.EXCEPT); }
		public TerminalNode EXCEPT(int i) {
			return getToken(SQLiteParser.EXCEPT, i);
		}
		public List<TerminalNode> UNION() { return getTokens(SQLiteParser.UNION); }
		public TerminalNode UNION(int i) {
			return getToken(SQLiteParser.UNION, i);
		}
		public List<TerminalNode> ALL() { return getTokens(SQLiteParser.ALL); }
		public TerminalNode ALL(int i) {
			return getToken(SQLiteParser.ALL, i);
		}
		public Compound_select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compound_select_stmt; }
	}

	public final Compound_select_stmtContext compound_select_stmt() throws RecognitionException {
		Compound_select_stmtContext _localctx = new Compound_select_stmtContext(_ctx, getState());
		enterRule(_localctx, 92, RULE_compound_select_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1375);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1374);
				common_table_stmt();
				}
			}

			setState(1377);
			select_core();
			setState(1387); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(1384);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case UNION:
					{
					{
					setState(1378);
					match(UNION);
					setState(1380);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==ALL) {
						{
						setState(1379);
						match(ALL);
						}
					}

					}
					}
					break;
				case INTERSECT:
					{
					setState(1382);
					match(INTERSECT);
					}
					break;
				case EXCEPT:
					{
					setState(1383);
					match(EXCEPT);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(1386);
				select_core();
				}
				}
				setState(1389); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==EXCEPT || _la==INTERSECT || _la==UNION );
			setState(1392);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDER) {
				{
				setState(1391);
				order_by_stmt();
				}
			}

			setState(1395);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(1394);
				limit_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_or_subqueryContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Table_aliasContext table_alias() {
			return getRuleContext(Table_aliasContext.class,0);
		}
		public TerminalNode INDEXED() { return getToken(SQLiteParser.INDEXED, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Table_function_nameContext table_function_name() {
			return getRuleContext(Table_function_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public List<Table_or_subqueryContext> table_or_subquery() {
			return getRuleContexts(Table_or_subqueryContext.class);
		}
		public Table_or_subqueryContext table_or_subquery(int i) {
			return getRuleContext(Table_or_subqueryContext.class,i);
		}
		public Join_clauseContext join_clause() {
			return getRuleContext(Join_clauseContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Table_or_subqueryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_or_subquery; }
	}

	public final Table_or_subqueryContext table_or_subquery() throws RecognitionException {
		Table_or_subqueryContext _localctx = new Table_or_subqueryContext(_ctx, getState());
		enterRule(_localctx, 94, RULE_table_or_subquery);
		int _la;
		try {
			setState(1461);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,204,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1400);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,192,_ctx) ) {
				case 1:
					{
					setState(1397);
					schema_name();
					setState(1398);
					match(DOT);
					}
					break;
				}
				setState(1402);
				table_name();
				setState(1407);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,194,_ctx) ) {
				case 1:
					{
					setState(1404);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,193,_ctx) ) {
					case 1:
						{
						setState(1403);
						match(AS);
						}
						break;
					}
					setState(1406);
					table_alias();
					}
					break;
				}
				setState(1414);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case INDEXED:
					{
					{
					setState(1409);
					match(INDEXED);
					setState(1410);
					match(BY);
					setState(1411);
					index_name();
					}
					}
					break;
				case NOT:
					{
					{
					setState(1412);
					match(NOT);
					setState(1413);
					match(INDEXED);
					}
					}
					break;
				case EOF:
				case SCOL:
				case CLOSE_PAR:
				case COMMA:
				case ALTER:
				case ANALYZE:
				case ATTACH:
				case BEGIN:
				case COMMIT:
				case CREATE:
				case CROSS:
				case DEFAULT:
				case DELETE:
				case DETACH:
				case DROP:
				case END:
				case EXCEPT:
				case EXPLAIN:
				case GROUP:
				case INNER:
				case INSERT:
				case INTERSECT:
				case JOIN:
				case LEFT:
				case LIMIT:
				case NATURAL:
				case ON:
				case ORDER:
				case PRAGMA:
				case REINDEX:
				case RELEASE:
				case REPLACE:
				case ROLLBACK:
				case SAVEPOINT:
				case SELECT:
				case UNION:
				case UPDATE:
				case USING:
				case VACUUM:
				case VALUES:
				case WHERE:
				case WITH:
				case WINDOW:
				case UNEXPECTED_CHAR:
					break;
				default:
					break;
				}
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1419);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,196,_ctx) ) {
				case 1:
					{
					setState(1416);
					schema_name();
					setState(1417);
					match(DOT);
					}
					break;
				}
				setState(1421);
				table_function_name();
				setState(1422);
				match(OPEN_PAR);
				setState(1423);
				expr(0);
				setState(1428);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1424);
					match(COMMA);
					setState(1425);
					expr(0);
					}
					}
					setState(1430);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1431);
				match(CLOSE_PAR);
				setState(1436);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,199,_ctx) ) {
				case 1:
					{
					setState(1433);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,198,_ctx) ) {
					case 1:
						{
						setState(1432);
						match(AS);
						}
						break;
					}
					setState(1435);
					table_alias();
					}
					break;
				}
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(1438);
				match(OPEN_PAR);
				setState(1448);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,201,_ctx) ) {
				case 1:
					{
					setState(1439);
					table_or_subquery();
					setState(1444);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1440);
						match(COMMA);
						setState(1441);
						table_or_subquery();
						}
						}
						setState(1446);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
					break;
				case 2:
					{
					setState(1447);
					join_clause();
					}
					break;
				}
				setState(1450);
				match(CLOSE_PAR);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(1452);
				match(OPEN_PAR);
				setState(1453);
				select_stmt();
				setState(1454);
				match(CLOSE_PAR);
				setState(1459);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,203,_ctx) ) {
				case 1:
					{
					setState(1456);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,202,_ctx) ) {
					case 1:
						{
						setState(1455);
						match(AS);
						}
						break;
					}
					setState(1458);
					table_alias();
					}
					break;
				}
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Result_columnContext extends ParserRuleContext {
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Column_aliasContext column_alias() {
			return getRuleContext(Column_aliasContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Result_columnContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_result_column; }
	}

	public final Result_columnContext result_column() throws RecognitionException {
		Result_columnContext _localctx = new Result_columnContext(_ctx, getState());
		enterRule(_localctx, 96, RULE_result_column);
		int _la;
		try {
			setState(1475);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,207,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(1463);
				match(STAR);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(1464);
				table_name();
				setState(1465);
				match(DOT);
				setState(1466);
				match(STAR);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(1468);
				expr(0);
				setState(1473);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AS || _la==IDENTIFIER || _la==STRING_LITERAL) {
					{
					setState(1470);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==AS) {
						{
						setState(1469);
						match(AS);
						}
					}

					setState(1472);
					column_alias();
					}
				}

				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Join_operatorContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public TerminalNode JOIN() { return getToken(SQLiteParser.JOIN, 0); }
		public TerminalNode NATURAL() { return getToken(SQLiteParser.NATURAL, 0); }
		public TerminalNode INNER() { return getToken(SQLiteParser.INNER, 0); }
		public TerminalNode CROSS() { return getToken(SQLiteParser.CROSS, 0); }
		public TerminalNode LEFT() { return getToken(SQLiteParser.LEFT, 0); }
		public TerminalNode OUTER() { return getToken(SQLiteParser.OUTER, 0); }
		public Join_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_join_operator; }
	}

	public final Join_operatorContext join_operator() throws RecognitionException {
		Join_operatorContext _localctx = new Join_operatorContext(_ctx, getState());
		enterRule(_localctx, 98, RULE_join_operator);
		int _la;
		try {
			setState(1490);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case COMMA:
				enterOuterAlt(_localctx, 1);
				{
				setState(1477);
				match(COMMA);
				}
				break;
			case CROSS:
			case INNER:
			case JOIN:
			case LEFT:
			case NATURAL:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1479);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NATURAL) {
					{
					setState(1478);
					match(NATURAL);
					}
				}

				setState(1487);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case LEFT:
					{
					{
					setState(1481);
					match(LEFT);
					setState(1483);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==OUTER) {
						{
						setState(1482);
						match(OUTER);
						}
					}

					}
					}
					break;
				case INNER:
					{
					setState(1485);
					match(INNER);
					}
					break;
				case CROSS:
					{
					setState(1486);
					match(CROSS);
					}
					break;
				case JOIN:
					break;
				default:
					break;
				}
				setState(1489);
				match(JOIN);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Join_constraintContext extends ParserRuleContext {
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode USING() { return getToken(SQLiteParser.USING, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Join_constraintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_join_constraint; }
	}

	public final Join_constraintContext join_constraint() throws RecognitionException {
		Join_constraintContext _localctx = new Join_constraintContext(_ctx, getState());
		enterRule(_localctx, 100, RULE_join_constraint);
		int _la;
		try {
			setState(1506);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ON:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1492);
				match(ON);
				setState(1493);
				expr(0);
				}
				}
				break;
			case USING:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1494);
				match(USING);
				setState(1495);
				match(OPEN_PAR);
				setState(1496);
				column_name();
				setState(1501);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1497);
					match(COMMA);
					setState(1498);
					column_name();
					}
					}
					setState(1503);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1504);
				match(CLOSE_PAR);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Compound_operatorContext extends ParserRuleContext {
		public TerminalNode UNION() { return getToken(SQLiteParser.UNION, 0); }
		public TerminalNode ALL() { return getToken(SQLiteParser.ALL, 0); }
		public TerminalNode INTERSECT() { return getToken(SQLiteParser.INTERSECT, 0); }
		public TerminalNode EXCEPT() { return getToken(SQLiteParser.EXCEPT, 0); }
		public Compound_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compound_operator; }
	}

	public final Compound_operatorContext compound_operator() throws RecognitionException {
		Compound_operatorContext _localctx = new Compound_operatorContext(_ctx, getState());
		enterRule(_localctx, 102, RULE_compound_operator);
		int _la;
		try {
			setState(1514);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case UNION:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1508);
				match(UNION);
				setState(1510);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ALL) {
					{
					setState(1509);
					match(ALL);
					}
				}

				}
				}
				break;
			case INTERSECT:
				enterOuterAlt(_localctx, 2);
				{
				setState(1512);
				match(INTERSECT);
				}
				break;
			case EXCEPT:
				enterOuterAlt(_localctx, 3);
				{
				setState(1513);
				match(EXCEPT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Update_stmtContext extends ParserRuleContext {
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public Qualified_table_nameContext qualified_table_name() {
			return getRuleContext(Qualified_table_nameContext.class,0);
		}
		public TerminalNode SET() { return getToken(SQLiteParser.SET, 0); }
		public List<TerminalNode> ASSIGN() { return getTokens(SQLiteParser.ASSIGN); }
		public TerminalNode ASSIGN(int i) {
			return getToken(SQLiteParser.ASSIGN, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<Column_name_listContext> column_name_list() {
			return getRuleContexts(Column_name_listContext.class);
		}
		public Column_name_listContext column_name_list(int i) {
			return getRuleContext(Column_name_listContext.class,i);
		}
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public Update_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_update_stmt; }
	}

	public final Update_stmtContext update_stmt() throws RecognitionException {
		Update_stmtContext _localctx = new Update_stmtContext(_ctx, getState());
		enterRule(_localctx, 104, RULE_update_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1517);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1516);
				with_clause();
				}
			}

			setState(1519);
			match(UPDATE);
			setState(1522);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,217,_ctx) ) {
			case 1:
				{
				setState(1520);
				match(OR);
				setState(1521);
				_la = _input.LA(1);
				if ( !(_la==ABORT || ((((_la - 72)) & ~0x3f) == 0 && ((1L << (_la - 72)) & ((1L << (FAIL - 72)) | (1L << (IGNORE - 72)) | (1L << (REPLACE - 72)) | (1L << (ROLLBACK - 72)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			}
			setState(1524);
			qualified_table_name();
			setState(1525);
			match(SET);
			setState(1528);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,218,_ctx) ) {
			case 1:
				{
				setState(1526);
				column_name();
				}
				break;
			case 2:
				{
				setState(1527);
				column_name_list();
				}
				break;
			}
			setState(1530);
			match(ASSIGN);
			setState(1531);
			expr(0);
			setState(1542);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1532);
				match(COMMA);
				setState(1535);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,219,_ctx) ) {
				case 1:
					{
					setState(1533);
					column_name();
					}
					break;
				case 2:
					{
					setState(1534);
					column_name_list();
					}
					break;
				}
				setState(1537);
				match(ASSIGN);
				setState(1538);
				expr(0);
				}
				}
				setState(1544);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(1547);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(1545);
				match(WHERE);
				setState(1546);
				expr(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_name_listContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Column_name_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_name_list; }
	}

	public final Column_name_listContext column_name_list() throws RecognitionException {
		Column_name_listContext _localctx = new Column_name_listContext(_ctx, getState());
		enterRule(_localctx, 106, RULE_column_name_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1549);
			match(OPEN_PAR);
			setState(1550);
			column_name();
			setState(1555);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1551);
				match(COMMA);
				setState(1552);
				column_name();
				}
				}
				setState(1557);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(1558);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Update_stmt_limitedContext extends ParserRuleContext {
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public Qualified_table_nameContext qualified_table_name() {
			return getRuleContext(Qualified_table_nameContext.class,0);
		}
		public TerminalNode SET() { return getToken(SQLiteParser.SET, 0); }
		public List<TerminalNode> ASSIGN() { return getTokens(SQLiteParser.ASSIGN); }
		public TerminalNode ASSIGN(int i) {
			return getToken(SQLiteParser.ASSIGN, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<Column_name_listContext> column_name_list() {
			return getRuleContexts(Column_name_listContext.class);
		}
		public Column_name_listContext column_name_list(int i) {
			return getRuleContext(Column_name_listContext.class,i);
		}
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public Limit_stmtContext limit_stmt() {
			return getRuleContext(Limit_stmtContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Update_stmt_limitedContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_update_stmt_limited; }
	}

	public final Update_stmt_limitedContext update_stmt_limited() throws RecognitionException {
		Update_stmt_limitedContext _localctx = new Update_stmt_limitedContext(_ctx, getState());
		enterRule(_localctx, 108, RULE_update_stmt_limited);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1561);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1560);
				with_clause();
				}
			}

			setState(1563);
			match(UPDATE);
			setState(1566);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,224,_ctx) ) {
			case 1:
				{
				setState(1564);
				match(OR);
				setState(1565);
				_la = _input.LA(1);
				if ( !(_la==ABORT || ((((_la - 72)) & ~0x3f) == 0 && ((1L << (_la - 72)) & ((1L << (FAIL - 72)) | (1L << (IGNORE - 72)) | (1L << (REPLACE - 72)) | (1L << (ROLLBACK - 72)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			}
			setState(1568);
			qualified_table_name();
			setState(1569);
			match(SET);
			setState(1572);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,225,_ctx) ) {
			case 1:
				{
				setState(1570);
				column_name();
				}
				break;
			case 2:
				{
				setState(1571);
				column_name_list();
				}
				break;
			}
			setState(1574);
			match(ASSIGN);
			setState(1575);
			expr(0);
			setState(1586);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1576);
				match(COMMA);
				setState(1579);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,226,_ctx) ) {
				case 1:
					{
					setState(1577);
					column_name();
					}
					break;
				case 2:
					{
					setState(1578);
					column_name_list();
					}
					break;
				}
				setState(1581);
				match(ASSIGN);
				setState(1582);
				expr(0);
				}
				}
				setState(1588);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(1591);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(1589);
				match(WHERE);
				setState(1590);
				expr(0);
				}
			}

			setState(1597);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT || _la==ORDER) {
				{
				setState(1594);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(1593);
					order_by_stmt();
					}
				}

				setState(1596);
				limit_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Qualified_table_nameContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public AliasContext alias() {
			return getRuleContext(AliasContext.class,0);
		}
		public TerminalNode INDEXED() { return getToken(SQLiteParser.INDEXED, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public Qualified_table_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_qualified_table_name; }
	}

	public final Qualified_table_nameContext qualified_table_name() throws RecognitionException {
		Qualified_table_nameContext _localctx = new Qualified_table_nameContext(_ctx, getState());
		enterRule(_localctx, 110, RULE_qualified_table_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1602);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,231,_ctx) ) {
			case 1:
				{
				setState(1599);
				schema_name();
				setState(1600);
				match(DOT);
				}
				break;
			}
			setState(1604);
			table_name();
			setState(1607);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==AS) {
				{
				setState(1605);
				match(AS);
				setState(1606);
				alias();
				}
			}

			setState(1614);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INDEXED:
				{
				{
				setState(1609);
				match(INDEXED);
				setState(1610);
				match(BY);
				setState(1611);
				index_name();
				}
				}
				break;
			case NOT:
				{
				{
				setState(1612);
				match(NOT);
				setState(1613);
				match(INDEXED);
				}
				}
				break;
			case EOF:
			case SCOL:
			case ALTER:
			case ANALYZE:
			case ATTACH:
			case BEGIN:
			case COMMIT:
			case CREATE:
			case DEFAULT:
			case DELETE:
			case DETACH:
			case DROP:
			case END:
			case EXPLAIN:
			case INSERT:
			case LIMIT:
			case ORDER:
			case PRAGMA:
			case REINDEX:
			case RELEASE:
			case REPLACE:
			case ROLLBACK:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case UPDATE:
			case VACUUM:
			case VALUES:
			case WHERE:
			case WITH:
			case UNEXPECTED_CHAR:
				break;
			default:
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Vacuum_stmtContext extends ParserRuleContext {
		public TerminalNode VACUUM() { return getToken(SQLiteParser.VACUUM, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode INTO() { return getToken(SQLiteParser.INTO, 0); }
		public FilenameContext filename() {
			return getRuleContext(FilenameContext.class,0);
		}
		public Vacuum_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_vacuum_stmt; }
	}

	public final Vacuum_stmtContext vacuum_stmt() throws RecognitionException {
		Vacuum_stmtContext _localctx = new Vacuum_stmtContext(_ctx, getState());
		enterRule(_localctx, 112, RULE_vacuum_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1616);
			match(VACUUM);
			setState(1618);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,234,_ctx) ) {
			case 1:
				{
				setState(1617);
				schema_name();
				}
				break;
			}
			setState(1622);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==INTO) {
				{
				setState(1620);
				match(INTO);
				setState(1621);
				filename();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Filter_clauseContext extends ParserRuleContext {
		public TerminalNode FILTER() { return getToken(SQLiteParser.FILTER, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Filter_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_filter_clause; }
	}

	public final Filter_clauseContext filter_clause() throws RecognitionException {
		Filter_clauseContext _localctx = new Filter_clauseContext(_ctx, getState());
		enterRule(_localctx, 114, RULE_filter_clause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1624);
			match(FILTER);
			setState(1625);
			match(OPEN_PAR);
			setState(1626);
			match(WHERE);
			setState(1627);
			expr(0);
			setState(1628);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_defnContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public List<TerminalNode> BY() { return getTokens(SQLiteParser.BY); }
		public TerminalNode BY(int i) {
			return getToken(SQLiteParser.BY, i);
		}
		public List<Ordering_termContext> ordering_term() {
			return getRuleContexts(Ordering_termContext.class);
		}
		public Ordering_termContext ordering_term(int i) {
			return getRuleContext(Ordering_termContext.class,i);
		}
		public Base_window_nameContext base_window_name() {
			return getRuleContext(Base_window_nameContext.class,0);
		}
		public TerminalNode PARTITION() { return getToken(SQLiteParser.PARTITION, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Frame_specContext frame_spec() {
			return getRuleContext(Frame_specContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Window_defnContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_defn; }
	}

	public final Window_defnContext window_defn() throws RecognitionException {
		Window_defnContext _localctx = new Window_defnContext(_ctx, getState());
		enterRule(_localctx, 116, RULE_window_defn);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1630);
			match(OPEN_PAR);
			setState(1632);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,236,_ctx) ) {
			case 1:
				{
				setState(1631);
				base_window_name();
				}
				break;
			}
			setState(1644);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PARTITION) {
				{
				setState(1634);
				match(PARTITION);
				setState(1635);
				match(BY);
				setState(1636);
				expr(0);
				setState(1641);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1637);
					match(COMMA);
					setState(1638);
					expr(0);
					}
					}
					setState(1643);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			{
			setState(1646);
			match(ORDER);
			setState(1647);
			match(BY);
			setState(1648);
			ordering_term();
			setState(1653);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1649);
				match(COMMA);
				setState(1650);
				ordering_term();
				}
				}
				setState(1655);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
			setState(1657);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
				{
				setState(1656);
				frame_spec();
				}
			}

			setState(1659);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Over_clauseContext extends ParserRuleContext {
		public TerminalNode OVER() { return getToken(SQLiteParser.OVER, 0); }
		public Window_nameContext window_name() {
			return getRuleContext(Window_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Base_window_nameContext base_window_name() {
			return getRuleContext(Base_window_nameContext.class,0);
		}
		public TerminalNode PARTITION() { return getToken(SQLiteParser.PARTITION, 0); }
		public List<TerminalNode> BY() { return getTokens(SQLiteParser.BY); }
		public TerminalNode BY(int i) {
			return getToken(SQLiteParser.BY, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public List<Ordering_termContext> ordering_term() {
			return getRuleContexts(Ordering_termContext.class);
		}
		public Ordering_termContext ordering_term(int i) {
			return getRuleContext(Ordering_termContext.class,i);
		}
		public Frame_specContext frame_spec() {
			return getRuleContext(Frame_specContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Over_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_over_clause; }
	}

	public final Over_clauseContext over_clause() throws RecognitionException {
		Over_clauseContext _localctx = new Over_clauseContext(_ctx, getState());
		enterRule(_localctx, 118, RULE_over_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1661);
			match(OVER);
			setState(1695);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,247,_ctx) ) {
			case 1:
				{
				setState(1662);
				window_name();
				}
				break;
			case 2:
				{
				{
				setState(1663);
				match(OPEN_PAR);
				setState(1665);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,241,_ctx) ) {
				case 1:
					{
					setState(1664);
					base_window_name();
					}
					break;
				}
				setState(1677);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1667);
					match(PARTITION);
					setState(1668);
					match(BY);
					setState(1669);
					expr(0);
					setState(1674);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1670);
						match(COMMA);
						setState(1671);
						expr(0);
						}
						}
						setState(1676);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(1689);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(1679);
					match(ORDER);
					setState(1680);
					match(BY);
					setState(1681);
					ordering_term();
					setState(1686);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1682);
						match(COMMA);
						setState(1683);
						ordering_term();
						}
						}
						setState(1688);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(1692);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1691);
					frame_spec();
					}
				}

				setState(1694);
				match(CLOSE_PAR);
				}
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_specContext extends ParserRuleContext {
		public Frame_clauseContext frame_clause() {
			return getRuleContext(Frame_clauseContext.class,0);
		}
		public TerminalNode EXCLUDE() { return getToken(SQLiteParser.EXCLUDE, 0); }
		public TerminalNode GROUP() { return getToken(SQLiteParser.GROUP, 0); }
		public TerminalNode TIES() { return getToken(SQLiteParser.TIES, 0); }
		public TerminalNode NO() { return getToken(SQLiteParser.NO, 0); }
		public TerminalNode OTHERS() { return getToken(SQLiteParser.OTHERS, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public Frame_specContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_spec; }
	}

	public final Frame_specContext frame_spec() throws RecognitionException {
		Frame_specContext _localctx = new Frame_specContext(_ctx, getState());
		enterRule(_localctx, 120, RULE_frame_spec);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1697);
			frame_clause();
			setState(1705);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case EXCLUDE:
				{
				setState(1698);
				match(EXCLUDE);
				{
				setState(1699);
				match(NO);
				setState(1700);
				match(OTHERS);
				}
				}
				break;
			case CURRENT:
				{
				{
				setState(1701);
				match(CURRENT);
				setState(1702);
				match(ROW);
				}
				}
				break;
			case GROUP:
				{
				setState(1703);
				match(GROUP);
				}
				break;
			case TIES:
				{
				setState(1704);
				match(TIES);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_clauseContext extends ParserRuleContext {
		public TerminalNode RANGE() { return getToken(SQLiteParser.RANGE, 0); }
		public TerminalNode ROWS() { return getToken(SQLiteParser.ROWS, 0); }
		public TerminalNode GROUPS() { return getToken(SQLiteParser.GROUPS, 0); }
		public Frame_singleContext frame_single() {
			return getRuleContext(Frame_singleContext.class,0);
		}
		public TerminalNode BETWEEN() { return getToken(SQLiteParser.BETWEEN, 0); }
		public Frame_leftContext frame_left() {
			return getRuleContext(Frame_leftContext.class,0);
		}
		public TerminalNode AND() { return getToken(SQLiteParser.AND, 0); }
		public Frame_rightContext frame_right() {
			return getRuleContext(Frame_rightContext.class,0);
		}
		public Frame_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_clause; }
	}

	public final Frame_clauseContext frame_clause() throws RecognitionException {
		Frame_clauseContext _localctx = new Frame_clauseContext(_ctx, getState());
		enterRule(_localctx, 122, RULE_frame_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1707);
			_la = _input.LA(1);
			if ( !(((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(1714);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,249,_ctx) ) {
			case 1:
				{
				setState(1708);
				frame_single();
				}
				break;
			case 2:
				{
				setState(1709);
				match(BETWEEN);
				setState(1710);
				frame_left();
				setState(1711);
				match(AND);
				setState(1712);
				frame_right();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Simple_function_invocationContext extends ParserRuleContext {
		public Simple_funcContext simple_func() {
			return getRuleContext(Simple_funcContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Simple_function_invocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simple_function_invocation; }
	}

	public final Simple_function_invocationContext simple_function_invocation() throws RecognitionException {
		Simple_function_invocationContext _localctx = new Simple_function_invocationContext(_ctx, getState());
		enterRule(_localctx, 124, RULE_simple_function_invocation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1716);
			simple_func();
			setState(1717);
			match(OPEN_PAR);
			setState(1727);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
			case PLUS:
			case MINUS:
			case TILDE:
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
			case IDENTIFIER:
			case NUMERIC_LITERAL:
			case BIND_PARAMETER:
			case STRING_LITERAL:
			case BLOB_LITERAL:
				{
				{
				setState(1718);
				expr(0);
				setState(1723);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1719);
					match(COMMA);
					setState(1720);
					expr(0);
					}
					}
					setState(1725);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				}
				break;
			case STAR:
				{
				setState(1726);
				match(STAR);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(1729);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Aggregate_function_invocationContext extends ParserRuleContext {
		public Aggregate_funcContext aggregate_func() {
			return getRuleContext(Aggregate_funcContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Filter_clauseContext filter_clause() {
			return getRuleContext(Filter_clauseContext.class,0);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode DISTINCT() { return getToken(SQLiteParser.DISTINCT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Aggregate_function_invocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggregate_function_invocation; }
	}

	public final Aggregate_function_invocationContext aggregate_function_invocation() throws RecognitionException {
		Aggregate_function_invocationContext _localctx = new Aggregate_function_invocationContext(_ctx, getState());
		enterRule(_localctx, 126, RULE_aggregate_function_invocation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1731);
			aggregate_func();
			setState(1732);
			match(OPEN_PAR);
			setState(1745);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
			case PLUS:
			case MINUS:
			case TILDE:
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
			case IDENTIFIER:
			case NUMERIC_LITERAL:
			case BIND_PARAMETER:
			case STRING_LITERAL:
			case BLOB_LITERAL:
				{
				{
				setState(1734);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,252,_ctx) ) {
				case 1:
					{
					setState(1733);
					match(DISTINCT);
					}
					break;
				}
				setState(1736);
				expr(0);
				setState(1741);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1737);
					match(COMMA);
					setState(1738);
					expr(0);
					}
					}
					setState(1743);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				}
				break;
			case STAR:
				{
				setState(1744);
				match(STAR);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			setState(1747);
			match(CLOSE_PAR);
			setState(1749);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==FILTER) {
				{
				setState(1748);
				filter_clause();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_function_invocationContext extends ParserRuleContext {
		public Window_functionContext window_function() {
			return getRuleContext(Window_functionContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode OVER() { return getToken(SQLiteParser.OVER, 0); }
		public Window_defnContext window_defn() {
			return getRuleContext(Window_defnContext.class,0);
		}
		public Window_nameContext window_name() {
			return getRuleContext(Window_nameContext.class,0);
		}
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Filter_clauseContext filter_clause() {
			return getRuleContext(Filter_clauseContext.class,0);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Window_function_invocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_function_invocation; }
	}

	public final Window_function_invocationContext window_function_invocation() throws RecognitionException {
		Window_function_invocationContext _localctx = new Window_function_invocationContext(_ctx, getState());
		enterRule(_localctx, 128, RULE_window_function_invocation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1751);
			window_function();
			setState(1752);
			match(OPEN_PAR);
			setState(1762);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
			case PLUS:
			case MINUS:
			case TILDE:
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
			case IDENTIFIER:
			case NUMERIC_LITERAL:
			case BIND_PARAMETER:
			case STRING_LITERAL:
			case BLOB_LITERAL:
				{
				{
				setState(1753);
				expr(0);
				setState(1758);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1754);
					match(COMMA);
					setState(1755);
					expr(0);
					}
					}
					setState(1760);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				}
				break;
			case STAR:
				{
				setState(1761);
				match(STAR);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			setState(1764);
			match(CLOSE_PAR);
			setState(1766);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==FILTER) {
				{
				setState(1765);
				filter_clause();
				}
			}

			setState(1768);
			match(OVER);
			setState(1771);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,259,_ctx) ) {
			case 1:
				{
				setState(1769);
				window_defn();
				}
				break;
			case 2:
				{
				setState(1770);
				window_name();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Common_table_stmtContext extends ParserRuleContext {
		public TerminalNode WITH() { return getToken(SQLiteParser.WITH, 0); }
		public List<Common_table_expressionContext> common_table_expression() {
			return getRuleContexts(Common_table_expressionContext.class);
		}
		public Common_table_expressionContext common_table_expression(int i) {
			return getRuleContext(Common_table_expressionContext.class,i);
		}
		public TerminalNode RECURSIVE() { return getToken(SQLiteParser.RECURSIVE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Common_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_common_table_stmt; }
	}

	public final Common_table_stmtContext common_table_stmt() throws RecognitionException {
		Common_table_stmtContext _localctx = new Common_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 130, RULE_common_table_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1773);
			match(WITH);
			setState(1775);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,260,_ctx) ) {
			case 1:
				{
				setState(1774);
				match(RECURSIVE);
				}
				break;
			}
			setState(1777);
			common_table_expression();
			setState(1782);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1778);
				match(COMMA);
				setState(1779);
				common_table_expression();
				}
				}
				setState(1784);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Order_by_stmtContext extends ParserRuleContext {
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public List<Ordering_termContext> ordering_term() {
			return getRuleContexts(Ordering_termContext.class);
		}
		public Ordering_termContext ordering_term(int i) {
			return getRuleContext(Ordering_termContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Order_by_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_stmt; }
	}

	public final Order_by_stmtContext order_by_stmt() throws RecognitionException {
		Order_by_stmtContext _localctx = new Order_by_stmtContext(_ctx, getState());
		enterRule(_localctx, 132, RULE_order_by_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1785);
			match(ORDER);
			setState(1786);
			match(BY);
			setState(1787);
			ordering_term();
			setState(1792);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1788);
				match(COMMA);
				setState(1789);
				ordering_term();
				}
				}
				setState(1794);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Limit_stmtContext extends ParserRuleContext {
		public TerminalNode LIMIT() { return getToken(SQLiteParser.LIMIT, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode OFFSET() { return getToken(SQLiteParser.OFFSET, 0); }
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Limit_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_limit_stmt; }
	}

	public final Limit_stmtContext limit_stmt() throws RecognitionException {
		Limit_stmtContext _localctx = new Limit_stmtContext(_ctx, getState());
		enterRule(_localctx, 134, RULE_limit_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1795);
			match(LIMIT);
			setState(1796);
			expr(0);
			setState(1799);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COMMA || _la==OFFSET) {
				{
				setState(1797);
				_la = _input.LA(1);
				if ( !(_la==COMMA || _la==OFFSET) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1798);
				expr(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Ordering_termContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Asc_descContext asc_desc() {
			return getRuleContext(Asc_descContext.class,0);
		}
		public TerminalNode NULLS() { return getToken(SQLiteParser.NULLS, 0); }
		public TerminalNode FIRST() { return getToken(SQLiteParser.FIRST, 0); }
		public TerminalNode LAST() { return getToken(SQLiteParser.LAST, 0); }
		public Ordering_termContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ordering_term; }
	}

	public final Ordering_termContext ordering_term() throws RecognitionException {
		Ordering_termContext _localctx = new Ordering_termContext(_ctx, getState());
		enterRule(_localctx, 136, RULE_ordering_term);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1801);
			expr(0);
			setState(1804);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLLATE) {
				{
				setState(1802);
				match(COLLATE);
				setState(1803);
				collation_name();
				}
			}

			setState(1807);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(1806);
				asc_desc();
				}
			}

			setState(1811);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NULLS) {
				{
				setState(1809);
				match(NULLS);
				setState(1810);
				_la = _input.LA(1);
				if ( !(_la==FIRST || _la==LAST) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Asc_descContext extends ParserRuleContext {
		public TerminalNode ASC() { return getToken(SQLiteParser.ASC, 0); }
		public TerminalNode DESC() { return getToken(SQLiteParser.DESC, 0); }
		public Asc_descContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_asc_desc; }
	}

	public final Asc_descContext asc_desc() throws RecognitionException {
		Asc_descContext _localctx = new Asc_descContext(_ctx, getState());
		enterRule(_localctx, 138, RULE_asc_desc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1813);
			_la = _input.LA(1);
			if ( !(_la==ASC || _la==DESC) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_leftContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode PRECEDING() { return getToken(SQLiteParser.PRECEDING, 0); }
		public TerminalNode FOLLOWING() { return getToken(SQLiteParser.FOLLOWING, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public TerminalNode UNBOUNDED() { return getToken(SQLiteParser.UNBOUNDED, 0); }
		public Frame_leftContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_left; }
	}

	public final Frame_leftContext frame_left() throws RecognitionException {
		Frame_leftContext _localctx = new Frame_leftContext(_ctx, getState());
		enterRule(_localctx, 140, RULE_frame_left);
		try {
			setState(1825);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,267,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1815);
				expr(0);
				setState(1816);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1818);
				expr(0);
				setState(1819);
				match(FOLLOWING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1821);
				match(CURRENT);
				setState(1822);
				match(ROW);
				}
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(1823);
				match(UNBOUNDED);
				setState(1824);
				match(PRECEDING);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_rightContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode PRECEDING() { return getToken(SQLiteParser.PRECEDING, 0); }
		public TerminalNode FOLLOWING() { return getToken(SQLiteParser.FOLLOWING, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public TerminalNode UNBOUNDED() { return getToken(SQLiteParser.UNBOUNDED, 0); }
		public Frame_rightContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_right; }
	}

	public final Frame_rightContext frame_right() throws RecognitionException {
		Frame_rightContext _localctx = new Frame_rightContext(_ctx, getState());
		enterRule(_localctx, 142, RULE_frame_right);
		try {
			setState(1837);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,268,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1827);
				expr(0);
				setState(1828);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1830);
				expr(0);
				setState(1831);
				match(FOLLOWING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1833);
				match(CURRENT);
				setState(1834);
				match(ROW);
				}
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(1835);
				match(UNBOUNDED);
				setState(1836);
				match(FOLLOWING);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_singleContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode PRECEDING() { return getToken(SQLiteParser.PRECEDING, 0); }
		public TerminalNode UNBOUNDED() { return getToken(SQLiteParser.UNBOUNDED, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public Frame_singleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_single; }
	}

	public final Frame_singleContext frame_single() throws RecognitionException {
		Frame_singleContext _localctx = new Frame_singleContext(_ctx, getState());
		enterRule(_localctx, 144, RULE_frame_single);
		try {
			setState(1846);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,269,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1839);
				expr(0);
				setState(1840);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1842);
				match(UNBOUNDED);
				setState(1843);
				match(PRECEDING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1844);
				match(CURRENT);
				setState(1845);
				match(ROW);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_functionContext extends ParserRuleContext {
		public List<TerminalNode> OPEN_PAR() { return getTokens(SQLiteParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(SQLiteParser.OPEN_PAR, i);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(SQLiteParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(SQLiteParser.CLOSE_PAR, i);
		}
		public TerminalNode OVER() { return getToken(SQLiteParser.OVER, 0); }
		public Order_by_expr_asc_descContext order_by_expr_asc_desc() {
			return getRuleContext(Order_by_expr_asc_descContext.class,0);
		}
		public TerminalNode FIRST_VALUE() { return getToken(SQLiteParser.FIRST_VALUE, 0); }
		public TerminalNode LAST_VALUE() { return getToken(SQLiteParser.LAST_VALUE, 0); }
		public Partition_byContext partition_by() {
			return getRuleContext(Partition_byContext.class,0);
		}
		public Frame_clauseContext frame_clause() {
			return getRuleContext(Frame_clauseContext.class,0);
		}
		public TerminalNode CUME_DIST() { return getToken(SQLiteParser.CUME_DIST, 0); }
		public TerminalNode PERCENT_RANK() { return getToken(SQLiteParser.PERCENT_RANK, 0); }
		public Order_by_exprContext order_by_expr() {
			return getRuleContext(Order_by_exprContext.class,0);
		}
		public TerminalNode DENSE_RANK() { return getToken(SQLiteParser.DENSE_RANK, 0); }
		public TerminalNode RANK() { return getToken(SQLiteParser.RANK, 0); }
		public TerminalNode ROW_NUMBER() { return getToken(SQLiteParser.ROW_NUMBER, 0); }
		public TerminalNode LAG() { return getToken(SQLiteParser.LAG, 0); }
		public TerminalNode LEAD() { return getToken(SQLiteParser.LEAD, 0); }
		public OffsetContext offset() {
			return getRuleContext(OffsetContext.class,0);
		}
		public Default_valueContext default_value() {
			return getRuleContext(Default_valueContext.class,0);
		}
		public TerminalNode NTH_VALUE() { return getToken(SQLiteParser.NTH_VALUE, 0); }
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public TerminalNode NTILE() { return getToken(SQLiteParser.NTILE, 0); }
		public Window_functionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_function; }
	}

	public final Window_functionContext window_function() throws RecognitionException {
		Window_functionContext _localctx = new Window_functionContext(_ctx, getState());
		enterRule(_localctx, 146, RULE_window_function);
		int _la;
		try {
			setState(1933);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case FIRST_VALUE:
			case LAST_VALUE:
				enterOuterAlt(_localctx, 1);
				{
				setState(1848);
				_la = _input.LA(1);
				if ( !(_la==FIRST_VALUE || _la==LAST_VALUE) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1849);
				match(OPEN_PAR);
				setState(1850);
				expr(0);
				setState(1851);
				match(CLOSE_PAR);
				setState(1852);
				match(OVER);
				setState(1853);
				match(OPEN_PAR);
				setState(1855);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1854);
					partition_by();
					}
				}

				setState(1857);
				order_by_expr_asc_desc();
				setState(1859);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1858);
					frame_clause();
					}
				}

				setState(1861);
				match(CLOSE_PAR);
				}
				break;
			case CUME_DIST:
			case PERCENT_RANK:
				enterOuterAlt(_localctx, 2);
				{
				setState(1863);
				_la = _input.LA(1);
				if ( !(_la==CUME_DIST || _la==PERCENT_RANK) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1864);
				match(OPEN_PAR);
				setState(1865);
				match(CLOSE_PAR);
				setState(1866);
				match(OVER);
				setState(1867);
				match(OPEN_PAR);
				setState(1869);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1868);
					partition_by();
					}
				}

				setState(1872);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(1871);
					order_by_expr();
					}
				}

				setState(1874);
				match(CLOSE_PAR);
				}
				break;
			case DENSE_RANK:
			case RANK:
			case ROW_NUMBER:
				enterOuterAlt(_localctx, 3);
				{
				setState(1875);
				_la = _input.LA(1);
				if ( !(((((_la - 159)) & ~0x3f) == 0 && ((1L << (_la - 159)) & ((1L << (DENSE_RANK - 159)) | (1L << (RANK - 159)) | (1L << (ROW_NUMBER - 159)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1876);
				match(OPEN_PAR);
				setState(1877);
				match(CLOSE_PAR);
				setState(1878);
				match(OVER);
				setState(1879);
				match(OPEN_PAR);
				setState(1881);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1880);
					partition_by();
					}
				}

				setState(1883);
				order_by_expr_asc_desc();
				setState(1884);
				match(CLOSE_PAR);
				}
				break;
			case LAG:
			case LEAD:
				enterOuterAlt(_localctx, 4);
				{
				setState(1886);
				_la = _input.LA(1);
				if ( !(_la==LAG || _la==LEAD) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1887);
				match(OPEN_PAR);
				setState(1888);
				expr(0);
				setState(1890);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,275,_ctx) ) {
				case 1:
					{
					setState(1889);
					offset();
					}
					break;
				}
				setState(1893);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==COMMA) {
					{
					setState(1892);
					default_value();
					}
				}

				setState(1895);
				match(CLOSE_PAR);
				setState(1896);
				match(OVER);
				setState(1897);
				match(OPEN_PAR);
				setState(1899);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1898);
					partition_by();
					}
				}

				setState(1901);
				order_by_expr_asc_desc();
				setState(1902);
				match(CLOSE_PAR);
				}
				break;
			case NTH_VALUE:
				enterOuterAlt(_localctx, 5);
				{
				setState(1904);
				match(NTH_VALUE);
				setState(1905);
				match(OPEN_PAR);
				setState(1906);
				expr(0);
				setState(1907);
				match(COMMA);
				setState(1908);
				signed_number();
				setState(1909);
				match(CLOSE_PAR);
				setState(1910);
				match(OVER);
				setState(1911);
				match(OPEN_PAR);
				setState(1913);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1912);
					partition_by();
					}
				}

				setState(1915);
				order_by_expr_asc_desc();
				setState(1917);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1916);
					frame_clause();
					}
				}

				setState(1919);
				match(CLOSE_PAR);
				}
				break;
			case NTILE:
				enterOuterAlt(_localctx, 6);
				{
				setState(1921);
				match(NTILE);
				setState(1922);
				match(OPEN_PAR);
				setState(1923);
				expr(0);
				setState(1924);
				match(CLOSE_PAR);
				setState(1925);
				match(OVER);
				setState(1926);
				match(OPEN_PAR);
				setState(1928);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1927);
					partition_by();
					}
				}

				setState(1930);
				order_by_expr_asc_desc();
				setState(1931);
				match(CLOSE_PAR);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OffsetContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public OffsetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_offset; }
	}

	public final OffsetContext offset() throws RecognitionException {
		OffsetContext _localctx = new OffsetContext(_ctx, getState());
		enterRule(_localctx, 148, RULE_offset);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1935);
			match(COMMA);
			setState(1936);
			signed_number();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Default_valueContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public Default_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_default_value; }
	}

	public final Default_valueContext default_value() throws RecognitionException {
		Default_valueContext _localctx = new Default_valueContext(_ctx, getState());
		enterRule(_localctx, 150, RULE_default_value);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1938);
			match(COMMA);
			setState(1939);
			signed_number();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Partition_byContext extends ParserRuleContext {
		public TerminalNode PARTITION() { return getToken(SQLiteParser.PARTITION, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Partition_byContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_partition_by; }
	}

	public final Partition_byContext partition_by() throws RecognitionException {
		Partition_byContext _localctx = new Partition_byContext(_ctx, getState());
		enterRule(_localctx, 152, RULE_partition_by);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(1941);
			match(PARTITION);
			setState(1942);
			match(BY);
			setState(1944); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(1943);
					expr(0);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(1946); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,282,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Order_by_exprContext extends ParserRuleContext {
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Order_by_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_expr; }
	}

	public final Order_by_exprContext order_by_expr() throws RecognitionException {
		Order_by_exprContext _localctx = new Order_by_exprContext(_ctx, getState());
		enterRule(_localctx, 154, RULE_order_by_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1948);
			match(ORDER);
			setState(1949);
			match(BY);
			setState(1951); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(1950);
				expr(0);
				}
				}
				setState(1953); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAR) | (1L << PLUS) | (1L << MINUS) | (1L << TILDE) | (1L << ABORT) | (1L << ACTION) | (1L << ADD) | (1L << AFTER) | (1L << ALL) | (1L << ALTER) | (1L << ANALYZE) | (1L << AND) | (1L << AS) | (1L << ASC) | (1L << ATTACH) | (1L << AUTOINCREMENT) | (1L << BEFORE) | (1L << BEGIN) | (1L << BETWEEN) | (1L << BY) | (1L << CASCADE) | (1L << CASE) | (1L << CAST) | (1L << CHECK) | (1L << COLLATE) | (1L << COLUMN) | (1L << COMMIT) | (1L << CONFLICT) | (1L << CONSTRAINT) | (1L << CREATE) | (1L << CROSS) | (1L << CURRENT_DATE) | (1L << CURRENT_TIME) | (1L << CURRENT_TIMESTAMP) | (1L << DATABASE) | (1L << DEFAULT) | (1L << DEFERRABLE) | (1L << DEFERRED) | (1L << DELETE) | (1L << DESC) | (1L << DETACH) | (1L << DISTINCT) | (1L << DROP))) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (EACH - 64)) | (1L << (ELSE - 64)) | (1L << (END - 64)) | (1L << (ESCAPE - 64)) | (1L << (EXCEPT - 64)) | (1L << (EXCLUSIVE - 64)) | (1L << (EXISTS - 64)) | (1L << (EXPLAIN - 64)) | (1L << (FAIL - 64)) | (1L << (FOR - 64)) | (1L << (FOREIGN - 64)) | (1L << (FROM - 64)) | (1L << (FULL - 64)) | (1L << (GLOB - 64)) | (1L << (GROUP - 64)) | (1L << (HAVING - 64)) | (1L << (IF - 64)) | (1L << (IGNORE - 64)) | (1L << (IMMEDIATE - 64)) | (1L << (IN - 64)) | (1L << (INDEX - 64)) | (1L << (INDEXED - 64)) | (1L << (INITIALLY - 64)) | (1L << (INNER - 64)) | (1L << (INSERT - 64)) | (1L << (INSTEAD - 64)) | (1L << (INTERSECT - 64)) | (1L << (INTO - 64)) | (1L << (IS - 64)) | (1L << (ISNULL - 64)) | (1L << (JOIN - 64)) | (1L << (KEY - 64)) | (1L << (LEFT - 64)) | (1L << (LIKE - 64)) | (1L << (LIMIT - 64)) | (1L << (MATCH - 64)) | (1L << (NATURAL - 64)) | (1L << (NO - 64)) | (1L << (NOT - 64)) | (1L << (NOTNULL - 64)) | (1L << (NULL_ - 64)) | (1L << (OF - 64)) | (1L << (OFFSET - 64)) | (1L << (ON - 64)) | (1L << (OR - 64)) | (1L << (ORDER - 64)) | (1L << (OUTER - 64)) | (1L << (PLAN - 64)) | (1L << (PRAGMA - 64)) | (1L << (PRIMARY - 64)) | (1L << (QUERY - 64)) | (1L << (RAISE - 64)) | (1L << (RECURSIVE - 64)) | (1L << (REFERENCES - 64)) | (1L << (REGEXP - 64)) | (1L << (REINDEX - 64)) | (1L << (RELEASE - 64)) | (1L << (RENAME - 64)) | (1L << (REPLACE - 64)) | (1L << (RESTRICT - 64)) | (1L << (RIGHT - 64)) | (1L << (ROLLBACK - 64)) | (1L << (ROW - 64)) | (1L << (ROWS - 64)))) != 0) || ((((_la - 128)) & ~0x3f) == 0 && ((1L << (_la - 128)) & ((1L << (SAVEPOINT - 128)) | (1L << (SELECT - 128)) | (1L << (SET - 128)) | (1L << (TABLE - 128)) | (1L << (TEMP - 128)) | (1L << (TEMPORARY - 128)) | (1L << (THEN - 128)) | (1L << (TO - 128)) | (1L << (TRANSACTION - 128)) | (1L << (TRIGGER - 128)) | (1L << (UNION - 128)) | (1L << (UNIQUE - 128)) | (1L << (UPDATE - 128)) | (1L << (USING - 128)) | (1L << (VACUUM - 128)) | (1L << (VALUES - 128)) | (1L << (VIEW - 128)) | (1L << (VIRTUAL - 128)) | (1L << (WHEN - 128)) | (1L << (WHERE - 128)) | (1L << (WITH - 128)) | (1L << (WITHOUT - 128)) | (1L << (FIRST_VALUE - 128)) | (1L << (OVER - 128)) | (1L << (PARTITION - 128)) | (1L << (RANGE - 128)) | (1L << (PRECEDING - 128)) | (1L << (UNBOUNDED - 128)) | (1L << (CURRENT - 128)) | (1L << (FOLLOWING - 128)) | (1L << (CUME_DIST - 128)) | (1L << (DENSE_RANK - 128)) | (1L << (LAG - 128)) | (1L << (LAST_VALUE - 128)) | (1L << (LEAD - 128)) | (1L << (NTH_VALUE - 128)) | (1L << (NTILE - 128)) | (1L << (PERCENT_RANK - 128)) | (1L << (RANK - 128)) | (1L << (ROW_NUMBER - 128)) | (1L << (GENERATED - 128)) | (1L << (ALWAYS - 128)) | (1L << (STORED - 128)) | (1L << (TRUE_ - 128)) | (1L << (FALSE_ - 128)) | (1L << (WINDOW - 128)) | (1L << (NULLS - 128)) | (1L << (FIRST - 128)) | (1L << (LAST - 128)) | (1L << (FILTER - 128)) | (1L << (GROUPS - 128)) | (1L << (EXCLUDE - 128)) | (1L << (IDENTIFIER - 128)) | (1L << (NUMERIC_LITERAL - 128)) | (1L << (BIND_PARAMETER - 128)) | (1L << (STRING_LITERAL - 128)) | (1L << (BLOB_LITERAL - 128)))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Order_by_expr_asc_descContext extends ParserRuleContext {
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public Order_by_expr_asc_descContext order_by_expr_asc_desc() {
			return getRuleContext(Order_by_expr_asc_descContext.class,0);
		}
		public Order_by_expr_asc_descContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_expr_asc_desc; }
	}

	public final Order_by_expr_asc_descContext order_by_expr_asc_desc() throws RecognitionException {
		Order_by_expr_asc_descContext _localctx = new Order_by_expr_asc_descContext(_ctx, getState());
		enterRule(_localctx, 156, RULE_order_by_expr_asc_desc);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1955);
			match(ORDER);
			setState(1956);
			match(BY);
			setState(1957);
			order_by_expr_asc_desc();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Expr_asc_descContext extends ParserRuleContext {
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Asc_descContext> asc_desc() {
			return getRuleContexts(Asc_descContext.class);
		}
		public Asc_descContext asc_desc(int i) {
			return getRuleContext(Asc_descContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Expr_asc_descContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr_asc_desc; }
	}

	public final Expr_asc_descContext expr_asc_desc() throws RecognitionException {
		Expr_asc_descContext _localctx = new Expr_asc_descContext(_ctx, getState());
		enterRule(_localctx, 158, RULE_expr_asc_desc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1959);
			expr(0);
			setState(1961);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(1960);
				asc_desc();
				}
			}

			setState(1970);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1963);
				match(COMMA);
				setState(1964);
				expr(0);
				setState(1966);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ASC || _la==DESC) {
					{
					setState(1965);
					asc_desc();
					}
				}

				}
				}
				setState(1972);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Initial_selectContext extends ParserRuleContext {
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Initial_selectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_initial_select; }
	}

	public final Initial_selectContext initial_select() throws RecognitionException {
		Initial_selectContext _localctx = new Initial_selectContext(_ctx, getState());
		enterRule(_localctx, 160, RULE_initial_select);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1973);
			select_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Recursive_selectContext extends ParserRuleContext {
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Recursive_selectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_recursive_select; }
	}

	public final Recursive_selectContext recursive_select() throws RecognitionException {
		Recursive_selectContext _localctx = new Recursive_selectContext(_ctx, getState());
		enterRule(_localctx, 162, RULE_recursive_select);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1975);
			select_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Unary_operatorContext extends ParserRuleContext {
		public TerminalNode MINUS() { return getToken(SQLiteParser.MINUS, 0); }
		public TerminalNode PLUS() { return getToken(SQLiteParser.PLUS, 0); }
		public TerminalNode TILDE() { return getToken(SQLiteParser.TILDE, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public Unary_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_operator; }
	}

	public final Unary_operatorContext unary_operator() throws RecognitionException {
		Unary_operatorContext _localctx = new Unary_operatorContext(_ctx, getState());
		enterRule(_localctx, 164, RULE_unary_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1977);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << PLUS) | (1L << MINUS) | (1L << TILDE))) != 0) || _la==NOT) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Error_messageContext extends ParserRuleContext {
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public Error_messageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_error_message; }
	}

	public final Error_messageContext error_message() throws RecognitionException {
		Error_messageContext _localctx = new Error_messageContext(_ctx, getState());
		enterRule(_localctx, 166, RULE_error_message);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1979);
			match(STRING_LITERAL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Module_argumentContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Column_defContext column_def() {
			return getRuleContext(Column_defContext.class,0);
		}
		public Module_argumentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_module_argument; }
	}

	public final Module_argumentContext module_argument() throws RecognitionException {
		Module_argumentContext _localctx = new Module_argumentContext(_ctx, getState());
		enterRule(_localctx, 168, RULE_module_argument);
		try {
			setState(1983);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,287,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(1981);
				expr(0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(1982);
				column_def();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_aliasContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SQLiteParser.IDENTIFIER, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public Column_aliasContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_alias; }
	}

	public final Column_aliasContext column_alias() throws RecognitionException {
		Column_aliasContext _localctx = new Column_aliasContext(_ctx, getState());
		enterRule(_localctx, 170, RULE_column_alias);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1985);
			_la = _input.LA(1);
			if ( !(_la==IDENTIFIER || _la==STRING_LITERAL) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class KeywordContext extends ParserRuleContext {
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode ACTION() { return getToken(SQLiteParser.ACTION, 0); }
		public TerminalNode ADD() { return getToken(SQLiteParser.ADD, 0); }
		public TerminalNode AFTER() { return getToken(SQLiteParser.AFTER, 0); }
		public TerminalNode ALL() { return getToken(SQLiteParser.ALL, 0); }
		public TerminalNode ALTER() { return getToken(SQLiteParser.ALTER, 0); }
		public TerminalNode ANALYZE() { return getToken(SQLiteParser.ANALYZE, 0); }
		public TerminalNode AND() { return getToken(SQLiteParser.AND, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public TerminalNode ASC() { return getToken(SQLiteParser.ASC, 0); }
		public TerminalNode ATTACH() { return getToken(SQLiteParser.ATTACH, 0); }
		public TerminalNode AUTOINCREMENT() { return getToken(SQLiteParser.AUTOINCREMENT, 0); }
		public TerminalNode BEFORE() { return getToken(SQLiteParser.BEFORE, 0); }
		public TerminalNode BEGIN() { return getToken(SQLiteParser.BEGIN, 0); }
		public TerminalNode BETWEEN() { return getToken(SQLiteParser.BETWEEN, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public TerminalNode CASCADE() { return getToken(SQLiteParser.CASCADE, 0); }
		public TerminalNode CASE() { return getToken(SQLiteParser.CASE, 0); }
		public TerminalNode CAST() { return getToken(SQLiteParser.CAST, 0); }
		public TerminalNode CHECK() { return getToken(SQLiteParser.CHECK, 0); }
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public TerminalNode COLUMN() { return getToken(SQLiteParser.COLUMN, 0); }
		public TerminalNode COMMIT() { return getToken(SQLiteParser.COMMIT, 0); }
		public TerminalNode CONFLICT() { return getToken(SQLiteParser.CONFLICT, 0); }
		public TerminalNode CONSTRAINT() { return getToken(SQLiteParser.CONSTRAINT, 0); }
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode CROSS() { return getToken(SQLiteParser.CROSS, 0); }
		public TerminalNode CURRENT_DATE() { return getToken(SQLiteParser.CURRENT_DATE, 0); }
		public TerminalNode CURRENT_TIME() { return getToken(SQLiteParser.CURRENT_TIME, 0); }
		public TerminalNode CURRENT_TIMESTAMP() { return getToken(SQLiteParser.CURRENT_TIMESTAMP, 0); }
		public TerminalNode DATABASE() { return getToken(SQLiteParser.DATABASE, 0); }
		public TerminalNode DEFAULT() { return getToken(SQLiteParser.DEFAULT, 0); }
		public TerminalNode DEFERRABLE() { return getToken(SQLiteParser.DEFERRABLE, 0); }
		public TerminalNode DEFERRED() { return getToken(SQLiteParser.DEFERRED, 0); }
		public TerminalNode DELETE() { return getToken(SQLiteParser.DELETE, 0); }
		public TerminalNode DESC() { return getToken(SQLiteParser.DESC, 0); }
		public TerminalNode DETACH() { return getToken(SQLiteParser.DETACH, 0); }
		public TerminalNode DISTINCT() { return getToken(SQLiteParser.DISTINCT, 0); }
		public TerminalNode DROP() { return getToken(SQLiteParser.DROP, 0); }
		public TerminalNode EACH() { return getToken(SQLiteParser.EACH, 0); }
		public TerminalNode ELSE() { return getToken(SQLiteParser.ELSE, 0); }
		public TerminalNode END() { return getToken(SQLiteParser.END, 0); }
		public TerminalNode ESCAPE() { return getToken(SQLiteParser.ESCAPE, 0); }
		public TerminalNode EXCEPT() { return getToken(SQLiteParser.EXCEPT, 0); }
		public TerminalNode EXCLUSIVE() { return getToken(SQLiteParser.EXCLUSIVE, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public TerminalNode EXPLAIN() { return getToken(SQLiteParser.EXPLAIN, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode FOR() { return getToken(SQLiteParser.FOR, 0); }
		public TerminalNode FOREIGN() { return getToken(SQLiteParser.FOREIGN, 0); }
		public TerminalNode FROM() { return getToken(SQLiteParser.FROM, 0); }
		public TerminalNode FULL() { return getToken(SQLiteParser.FULL, 0); }
		public TerminalNode GLOB() { return getToken(SQLiteParser.GLOB, 0); }
		public TerminalNode GROUP() { return getToken(SQLiteParser.GROUP, 0); }
		public TerminalNode HAVING() { return getToken(SQLiteParser.HAVING, 0); }
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public TerminalNode IMMEDIATE() { return getToken(SQLiteParser.IMMEDIATE, 0); }
		public TerminalNode IN() { return getToken(SQLiteParser.IN, 0); }
		public TerminalNode INDEX() { return getToken(SQLiteParser.INDEX, 0); }
		public TerminalNode INDEXED() { return getToken(SQLiteParser.INDEXED, 0); }
		public TerminalNode INITIALLY() { return getToken(SQLiteParser.INITIALLY, 0); }
		public TerminalNode INNER() { return getToken(SQLiteParser.INNER, 0); }
		public TerminalNode INSERT() { return getToken(SQLiteParser.INSERT, 0); }
		public TerminalNode INSTEAD() { return getToken(SQLiteParser.INSTEAD, 0); }
		public TerminalNode INTERSECT() { return getToken(SQLiteParser.INTERSECT, 0); }
		public TerminalNode INTO() { return getToken(SQLiteParser.INTO, 0); }
		public TerminalNode IS() { return getToken(SQLiteParser.IS, 0); }
		public TerminalNode ISNULL() { return getToken(SQLiteParser.ISNULL, 0); }
		public TerminalNode JOIN() { return getToken(SQLiteParser.JOIN, 0); }
		public TerminalNode KEY() { return getToken(SQLiteParser.KEY, 0); }
		public TerminalNode LEFT() { return getToken(SQLiteParser.LEFT, 0); }
		public TerminalNode LIKE() { return getToken(SQLiteParser.LIKE, 0); }
		public TerminalNode LIMIT() { return getToken(SQLiteParser.LIMIT, 0); }
		public TerminalNode MATCH() { return getToken(SQLiteParser.MATCH, 0); }
		public TerminalNode NATURAL() { return getToken(SQLiteParser.NATURAL, 0); }
		public TerminalNode NO() { return getToken(SQLiteParser.NO, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode NOTNULL() { return getToken(SQLiteParser.NOTNULL, 0); }
		public TerminalNode NULL_() { return getToken(SQLiteParser.NULL_, 0); }
		public TerminalNode OF() { return getToken(SQLiteParser.OF, 0); }
		public TerminalNode OFFSET() { return getToken(SQLiteParser.OFFSET, 0); }
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public TerminalNode OUTER() { return getToken(SQLiteParser.OUTER, 0); }
		public TerminalNode PLAN() { return getToken(SQLiteParser.PLAN, 0); }
		public TerminalNode PRAGMA() { return getToken(SQLiteParser.PRAGMA, 0); }
		public TerminalNode PRIMARY() { return getToken(SQLiteParser.PRIMARY, 0); }
		public TerminalNode QUERY() { return getToken(SQLiteParser.QUERY, 0); }
		public TerminalNode RAISE() { return getToken(SQLiteParser.RAISE, 0); }
		public TerminalNode RECURSIVE() { return getToken(SQLiteParser.RECURSIVE, 0); }
		public TerminalNode REFERENCES() { return getToken(SQLiteParser.REFERENCES, 0); }
		public TerminalNode REGEXP() { return getToken(SQLiteParser.REGEXP, 0); }
		public TerminalNode REINDEX() { return getToken(SQLiteParser.REINDEX, 0); }
		public TerminalNode RELEASE() { return getToken(SQLiteParser.RELEASE, 0); }
		public TerminalNode RENAME() { return getToken(SQLiteParser.RENAME, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public TerminalNode RESTRICT() { return getToken(SQLiteParser.RESTRICT, 0); }
		public TerminalNode RIGHT() { return getToken(SQLiteParser.RIGHT, 0); }
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public TerminalNode ROWS() { return getToken(SQLiteParser.ROWS, 0); }
		public TerminalNode SAVEPOINT() { return getToken(SQLiteParser.SAVEPOINT, 0); }
		public TerminalNode SELECT() { return getToken(SQLiteParser.SELECT, 0); }
		public TerminalNode SET() { return getToken(SQLiteParser.SET, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public TerminalNode TEMP() { return getToken(SQLiteParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(SQLiteParser.TEMPORARY, 0); }
		public TerminalNode THEN() { return getToken(SQLiteParser.THEN, 0); }
		public TerminalNode TO() { return getToken(SQLiteParser.TO, 0); }
		public TerminalNode TRANSACTION() { return getToken(SQLiteParser.TRANSACTION, 0); }
		public TerminalNode TRIGGER() { return getToken(SQLiteParser.TRIGGER, 0); }
		public TerminalNode UNION() { return getToken(SQLiteParser.UNION, 0); }
		public TerminalNode UNIQUE() { return getToken(SQLiteParser.UNIQUE, 0); }
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public TerminalNode USING() { return getToken(SQLiteParser.USING, 0); }
		public TerminalNode VACUUM() { return getToken(SQLiteParser.VACUUM, 0); }
		public TerminalNode VALUES() { return getToken(SQLiteParser.VALUES, 0); }
		public TerminalNode VIEW() { return getToken(SQLiteParser.VIEW, 0); }
		public TerminalNode VIRTUAL() { return getToken(SQLiteParser.VIRTUAL, 0); }
		public TerminalNode WHEN() { return getToken(SQLiteParser.WHEN, 0); }
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public TerminalNode WITH() { return getToken(SQLiteParser.WITH, 0); }
		public TerminalNode WITHOUT() { return getToken(SQLiteParser.WITHOUT, 0); }
		public TerminalNode FIRST_VALUE() { return getToken(SQLiteParser.FIRST_VALUE, 0); }
		public TerminalNode OVER() { return getToken(SQLiteParser.OVER, 0); }
		public TerminalNode PARTITION() { return getToken(SQLiteParser.PARTITION, 0); }
		public TerminalNode RANGE() { return getToken(SQLiteParser.RANGE, 0); }
		public TerminalNode PRECEDING() { return getToken(SQLiteParser.PRECEDING, 0); }
		public TerminalNode UNBOUNDED() { return getToken(SQLiteParser.UNBOUNDED, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode FOLLOWING() { return getToken(SQLiteParser.FOLLOWING, 0); }
		public TerminalNode CUME_DIST() { return getToken(SQLiteParser.CUME_DIST, 0); }
		public TerminalNode DENSE_RANK() { return getToken(SQLiteParser.DENSE_RANK, 0); }
		public TerminalNode LAG() { return getToken(SQLiteParser.LAG, 0); }
		public TerminalNode LAST_VALUE() { return getToken(SQLiteParser.LAST_VALUE, 0); }
		public TerminalNode LEAD() { return getToken(SQLiteParser.LEAD, 0); }
		public TerminalNode NTH_VALUE() { return getToken(SQLiteParser.NTH_VALUE, 0); }
		public TerminalNode NTILE() { return getToken(SQLiteParser.NTILE, 0); }
		public TerminalNode PERCENT_RANK() { return getToken(SQLiteParser.PERCENT_RANK, 0); }
		public TerminalNode RANK() { return getToken(SQLiteParser.RANK, 0); }
		public TerminalNode ROW_NUMBER() { return getToken(SQLiteParser.ROW_NUMBER, 0); }
		public TerminalNode GENERATED() { return getToken(SQLiteParser.GENERATED, 0); }
		public TerminalNode ALWAYS() { return getToken(SQLiteParser.ALWAYS, 0); }
		public TerminalNode STORED() { return getToken(SQLiteParser.STORED, 0); }
		public TerminalNode TRUE_() { return getToken(SQLiteParser.TRUE_, 0); }
		public TerminalNode FALSE_() { return getToken(SQLiteParser.FALSE_, 0); }
		public TerminalNode WINDOW() { return getToken(SQLiteParser.WINDOW, 0); }
		public TerminalNode NULLS() { return getToken(SQLiteParser.NULLS, 0); }
		public TerminalNode FIRST() { return getToken(SQLiteParser.FIRST, 0); }
		public TerminalNode LAST() { return getToken(SQLiteParser.LAST, 0); }
		public TerminalNode FILTER() { return getToken(SQLiteParser.FILTER, 0); }
		public TerminalNode GROUPS() { return getToken(SQLiteParser.GROUPS, 0); }
		public TerminalNode EXCLUDE() { return getToken(SQLiteParser.EXCLUDE, 0); }
		public KeywordContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_keyword; }
	}

	public final KeywordContext keyword() throws RecognitionException {
		KeywordContext _localctx = new KeywordContext(_ctx, getState());
		enterRule(_localctx, 172, RULE_keyword);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1987);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << ABORT) | (1L << ACTION) | (1L << ADD) | (1L << AFTER) | (1L << ALL) | (1L << ALTER) | (1L << ANALYZE) | (1L << AND) | (1L << AS) | (1L << ASC) | (1L << ATTACH) | (1L << AUTOINCREMENT) | (1L << BEFORE) | (1L << BEGIN) | (1L << BETWEEN) | (1L << BY) | (1L << CASCADE) | (1L << CASE) | (1L << CAST) | (1L << CHECK) | (1L << COLLATE) | (1L << COLUMN) | (1L << COMMIT) | (1L << CONFLICT) | (1L << CONSTRAINT) | (1L << CREATE) | (1L << CROSS) | (1L << CURRENT_DATE) | (1L << CURRENT_TIME) | (1L << CURRENT_TIMESTAMP) | (1L << DATABASE) | (1L << DEFAULT) | (1L << DEFERRABLE) | (1L << DEFERRED) | (1L << DELETE) | (1L << DESC) | (1L << DETACH) | (1L << DISTINCT) | (1L << DROP))) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (EACH - 64)) | (1L << (ELSE - 64)) | (1L << (END - 64)) | (1L << (ESCAPE - 64)) | (1L << (EXCEPT - 64)) | (1L << (EXCLUSIVE - 64)) | (1L << (EXISTS - 64)) | (1L << (EXPLAIN - 64)) | (1L << (FAIL - 64)) | (1L << (FOR - 64)) | (1L << (FOREIGN - 64)) | (1L << (FROM - 64)) | (1L << (FULL - 64)) | (1L << (GLOB - 64)) | (1L << (GROUP - 64)) | (1L << (HAVING - 64)) | (1L << (IF - 64)) | (1L << (IGNORE - 64)) | (1L << (IMMEDIATE - 64)) | (1L << (IN - 64)) | (1L << (INDEX - 64)) | (1L << (INDEXED - 64)) | (1L << (INITIALLY - 64)) | (1L << (INNER - 64)) | (1L << (INSERT - 64)) | (1L << (INSTEAD - 64)) | (1L << (INTERSECT - 64)) | (1L << (INTO - 64)) | (1L << (IS - 64)) | (1L << (ISNULL - 64)) | (1L << (JOIN - 64)) | (1L << (KEY - 64)) | (1L << (LEFT - 64)) | (1L << (LIKE - 64)) | (1L << (LIMIT - 64)) | (1L << (MATCH - 64)) | (1L << (NATURAL - 64)) | (1L << (NO - 64)) | (1L << (NOT - 64)) | (1L << (NOTNULL - 64)) | (1L << (NULL_ - 64)) | (1L << (OF - 64)) | (1L << (OFFSET - 64)) | (1L << (ON - 64)) | (1L << (OR - 64)) | (1L << (ORDER - 64)) | (1L << (OUTER - 64)) | (1L << (PLAN - 64)) | (1L << (PRAGMA - 64)) | (1L << (PRIMARY - 64)) | (1L << (QUERY - 64)) | (1L << (RAISE - 64)) | (1L << (RECURSIVE - 64)) | (1L << (REFERENCES - 64)) | (1L << (REGEXP - 64)) | (1L << (REINDEX - 64)) | (1L << (RELEASE - 64)) | (1L << (RENAME - 64)) | (1L << (REPLACE - 64)) | (1L << (RESTRICT - 64)) | (1L << (RIGHT - 64)) | (1L << (ROLLBACK - 64)) | (1L << (ROW - 64)) | (1L << (ROWS - 64)))) != 0) || ((((_la - 128)) & ~0x3f) == 0 && ((1L << (_la - 128)) & ((1L << (SAVEPOINT - 128)) | (1L << (SELECT - 128)) | (1L << (SET - 128)) | (1L << (TABLE - 128)) | (1L << (TEMP - 128)) | (1L << (TEMPORARY - 128)) | (1L << (THEN - 128)) | (1L << (TO - 128)) | (1L << (TRANSACTION - 128)) | (1L << (TRIGGER - 128)) | (1L << (UNION - 128)) | (1L << (UNIQUE - 128)) | (1L << (UPDATE - 128)) | (1L << (USING - 128)) | (1L << (VACUUM - 128)) | (1L << (VALUES - 128)) | (1L << (VIEW - 128)) | (1L << (VIRTUAL - 128)) | (1L << (WHEN - 128)) | (1L << (WHERE - 128)) | (1L << (WITH - 128)) | (1L << (WITHOUT - 128)) | (1L << (FIRST_VALUE - 128)) | (1L << (OVER - 128)) | (1L << (PARTITION - 128)) | (1L << (RANGE - 128)) | (1L << (PRECEDING - 128)) | (1L << (UNBOUNDED - 128)) | (1L << (CURRENT - 128)) | (1L << (FOLLOWING - 128)) | (1L << (CUME_DIST - 128)) | (1L << (DENSE_RANK - 128)) | (1L << (LAG - 128)) | (1L << (LAST_VALUE - 128)) | (1L << (LEAD - 128)) | (1L << (NTH_VALUE - 128)) | (1L << (NTILE - 128)) | (1L << (PERCENT_RANK - 128)) | (1L << (RANK - 128)) | (1L << (ROW_NUMBER - 128)) | (1L << (GENERATED - 128)) | (1L << (ALWAYS - 128)) | (1L << (STORED - 128)) | (1L << (TRUE_ - 128)) | (1L << (FALSE_ - 128)) | (1L << (WINDOW - 128)) | (1L << (NULLS - 128)) | (1L << (FIRST - 128)) | (1L << (LAST - 128)) | (1L << (FILTER - 128)) | (1L << (GROUPS - 128)) | (1L << (EXCLUDE - 128)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public NameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_name; }
	}

	public final NameContext name() throws RecognitionException {
		NameContext _localctx = new NameContext(_ctx, getState());
		enterRule(_localctx, 174, RULE_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1989);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Function_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Function_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function_name; }
	}

	public final Function_nameContext function_name() throws RecognitionException {
		Function_nameContext _localctx = new Function_nameContext(_ctx, getState());
		enterRule(_localctx, 176, RULE_function_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1991);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Schema_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Schema_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_schema_name; }
	}

	public final Schema_nameContext schema_name() throws RecognitionException {
		Schema_nameContext _localctx = new Schema_nameContext(_ctx, getState());
		enterRule(_localctx, 178, RULE_schema_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1993);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Table_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_name; }
	}

	public final Table_nameContext table_name() throws RecognitionException {
		Table_nameContext _localctx = new Table_nameContext(_ctx, getState());
		enterRule(_localctx, 180, RULE_table_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1995);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_or_index_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Table_or_index_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_or_index_name; }
	}

	public final Table_or_index_nameContext table_or_index_name() throws RecognitionException {
		Table_or_index_nameContext _localctx = new Table_or_index_nameContext(_ctx, getState());
		enterRule(_localctx, 182, RULE_table_or_index_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1997);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class New_table_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public New_table_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_new_table_name; }
	}

	public final New_table_nameContext new_table_name() throws RecognitionException {
		New_table_nameContext _localctx = new New_table_nameContext(_ctx, getState());
		enterRule(_localctx, 184, RULE_new_table_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1999);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Column_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_name; }
	}

	public final Column_nameContext column_name() throws RecognitionException {
		Column_nameContext _localctx = new Column_nameContext(_ctx, getState());
		enterRule(_localctx, 186, RULE_column_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2001);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Collation_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Collation_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_collation_name; }
	}

	public final Collation_nameContext collation_name() throws RecognitionException {
		Collation_nameContext _localctx = new Collation_nameContext(_ctx, getState());
		enterRule(_localctx, 188, RULE_collation_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2003);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Foreign_tableContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Foreign_tableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_foreign_table; }
	}

	public final Foreign_tableContext foreign_table() throws RecognitionException {
		Foreign_tableContext _localctx = new Foreign_tableContext(_ctx, getState());
		enterRule(_localctx, 190, RULE_foreign_table);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2005);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Index_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Index_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_index_name; }
	}

	public final Index_nameContext index_name() throws RecognitionException {
		Index_nameContext _localctx = new Index_nameContext(_ctx, getState());
		enterRule(_localctx, 192, RULE_index_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2007);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Trigger_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Trigger_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_trigger_name; }
	}

	public final Trigger_nameContext trigger_name() throws RecognitionException {
		Trigger_nameContext _localctx = new Trigger_nameContext(_ctx, getState());
		enterRule(_localctx, 194, RULE_trigger_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2009);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class View_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public View_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_view_name; }
	}

	public final View_nameContext view_name() throws RecognitionException {
		View_nameContext _localctx = new View_nameContext(_ctx, getState());
		enterRule(_localctx, 196, RULE_view_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2011);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Module_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Module_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_module_name; }
	}

	public final Module_nameContext module_name() throws RecognitionException {
		Module_nameContext _localctx = new Module_nameContext(_ctx, getState());
		enterRule(_localctx, 198, RULE_module_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2013);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Pragma_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Pragma_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pragma_name; }
	}

	public final Pragma_nameContext pragma_name() throws RecognitionException {
		Pragma_nameContext _localctx = new Pragma_nameContext(_ctx, getState());
		enterRule(_localctx, 200, RULE_pragma_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2015);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Savepoint_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Savepoint_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_savepoint_name; }
	}

	public final Savepoint_nameContext savepoint_name() throws RecognitionException {
		Savepoint_nameContext _localctx = new Savepoint_nameContext(_ctx, getState());
		enterRule(_localctx, 202, RULE_savepoint_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2017);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_aliasContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Table_aliasContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_alias; }
	}

	public final Table_aliasContext table_alias() throws RecognitionException {
		Table_aliasContext _localctx = new Table_aliasContext(_ctx, getState());
		enterRule(_localctx, 204, RULE_table_alias);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2019);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Transaction_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Transaction_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_transaction_name; }
	}

	public final Transaction_nameContext transaction_name() throws RecognitionException {
		Transaction_nameContext _localctx = new Transaction_nameContext(_ctx, getState());
		enterRule(_localctx, 206, RULE_transaction_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2021);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Window_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_name; }
	}

	public final Window_nameContext window_name() throws RecognitionException {
		Window_nameContext _localctx = new Window_nameContext(_ctx, getState());
		enterRule(_localctx, 208, RULE_window_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2023);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AliasContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public AliasContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_alias; }
	}

	public final AliasContext alias() throws RecognitionException {
		AliasContext _localctx = new AliasContext(_ctx, getState());
		enterRule(_localctx, 210, RULE_alias);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2025);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FilenameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public FilenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_filename; }
	}

	public final FilenameContext filename() throws RecognitionException {
		FilenameContext _localctx = new FilenameContext(_ctx, getState());
		enterRule(_localctx, 212, RULE_filename);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2027);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Base_window_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Base_window_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_base_window_name; }
	}

	public final Base_window_nameContext base_window_name() throws RecognitionException {
		Base_window_nameContext _localctx = new Base_window_nameContext(_ctx, getState());
		enterRule(_localctx, 214, RULE_base_window_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2029);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Simple_funcContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Simple_funcContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simple_func; }
	}

	public final Simple_funcContext simple_func() throws RecognitionException {
		Simple_funcContext _localctx = new Simple_funcContext(_ctx, getState());
		enterRule(_localctx, 216, RULE_simple_func);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2031);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Aggregate_funcContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Aggregate_funcContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggregate_func; }
	}

	public final Aggregate_funcContext aggregate_func() throws RecognitionException {
		Aggregate_funcContext _localctx = new Aggregate_funcContext(_ctx, getState());
		enterRule(_localctx, 218, RULE_aggregate_func);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2033);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_function_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Table_function_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_function_name; }
	}

	public final Table_function_nameContext table_function_name() throws RecognitionException {
		Table_function_nameContext _localctx = new Table_function_nameContext(_ctx, getState());
		enterRule(_localctx, 220, RULE_table_function_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2035);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Any_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SQLiteParser.IDENTIFIER, 0); }
		public KeywordContext keyword() {
			return getRuleContext(KeywordContext.class,0);
		}
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Any_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_any_name; }
	}

	public final Any_nameContext any_name() throws RecognitionException {
		Any_nameContext _localctx = new Any_nameContext(_ctx, getState());
		enterRule(_localctx, 222, RULE_any_name);
		try {
			setState(2044);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(2037);
				match(IDENTIFIER);
				}
				break;
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
				enterOuterAlt(_localctx, 2);
				{
				setState(2038);
				keyword();
				}
				break;
			case STRING_LITERAL:
				enterOuterAlt(_localctx, 3);
				{
				setState(2039);
				match(STRING_LITERAL);
				}
				break;
			case OPEN_PAR:
				enterOuterAlt(_localctx, 4);
				{
				setState(2040);
				match(OPEN_PAR);
				setState(2041);
				any_name();
				setState(2042);
				match(CLOSE_PAR);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 33:
			return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 20);
		case 1:
			return precpred(_ctx, 19);
		case 2:
			return precpred(_ctx, 18);
		case 3:
			return precpred(_ctx, 17);
		case 4:
			return precpred(_ctx, 16);
		case 5:
			return precpred(_ctx, 15);
		case 6:
			return precpred(_ctx, 14);
		case 7:
			return precpred(_ctx, 13);
		case 8:
			return precpred(_ctx, 6);
		case 9:
			return precpred(_ctx, 5);
		case 10:
			return precpred(_ctx, 9);
		case 11:
			return precpred(_ctx, 8);
		case 12:
			return precpred(_ctx, 7);
		case 13:
			return precpred(_ctx, 4);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\u00c2\u0801\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t="+
		"\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\4G\tG\4H\tH\4I"+
		"\tI\4J\tJ\4K\tK\4L\tL\4M\tM\4N\tN\4O\tO\4P\tP\4Q\tQ\4R\tR\4S\tS\4T\tT"+
		"\4U\tU\4V\tV\4W\tW\4X\tX\4Y\tY\4Z\tZ\4[\t[\4\\\t\\\4]\t]\4^\t^\4_\t_\4"+
		"`\t`\4a\ta\4b\tb\4c\tc\4d\td\4e\te\4f\tf\4g\tg\4h\th\4i\ti\4j\tj\4k\t"+
		"k\4l\tl\4m\tm\4n\tn\4o\to\4p\tp\4q\tq\3\2\3\2\7\2\u00e5\n\2\f\2\16\2\u00e8"+
		"\13\2\3\2\3\2\3\3\3\3\3\3\3\4\7\4\u00f0\n\4\f\4\16\4\u00f3\13\4\3\4\3"+
		"\4\6\4\u00f7\n\4\r\4\16\4\u00f8\3\4\7\4\u00fc\n\4\f\4\16\4\u00ff\13\4"+
		"\3\4\7\4\u0102\n\4\f\4\16\4\u0105\13\4\3\5\3\5\3\5\5\5\u010a\n\5\5\5\u010c"+
		"\n\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3"+
		"\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\5\5\u0126\n\5\3\6\3\6\3\6\3\6\3\6\5\6\u012d"+
		"\n\6\3\6\3\6\3\6\3\6\3\6\5\6\u0134\n\6\3\6\3\6\3\6\3\6\5\6\u013a\n\6\3"+
		"\6\3\6\5\6\u013e\n\6\3\6\5\6\u0141\n\6\3\7\3\7\3\7\3\7\3\7\5\7\u0148\n"+
		"\7\3\7\5\7\u014b\n\7\3\b\3\b\5\b\u014f\n\b\3\b\3\b\3\b\3\b\3\t\3\t\5\t"+
		"\u0157\n\t\3\t\3\t\5\t\u015b\n\t\5\t\u015d\n\t\3\n\3\n\5\n\u0161\n\n\3"+
		"\13\3\13\5\13\u0165\n\13\3\13\3\13\5\13\u0169\n\13\3\13\5\13\u016c\n\13"+
		"\3\f\3\f\3\f\3\r\3\r\5\r\u0173\n\r\3\r\3\r\3\16\3\16\5\16\u0179\n\16\3"+
		"\16\3\16\3\16\3\16\5\16\u017f\n\16\3\16\3\16\3\16\5\16\u0184\n\16\3\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\16\7\16\u018d\n\16\f\16\16\16\u0190\13\16"+
		"\3\16\3\16\3\16\5\16\u0195\n\16\3\17\3\17\5\17\u0199\n\17\3\17\3\17\5"+
		"\17\u019d\n\17\3\17\5\17\u01a0\n\17\3\20\3\20\5\20\u01a4\n\20\3\20\3\20"+
		"\3\20\3\20\5\20\u01aa\n\20\3\20\3\20\3\20\5\20\u01af\n\20\3\20\3\20\3"+
		"\20\3\20\3\20\7\20\u01b6\n\20\f\20\16\20\u01b9\13\20\3\20\3\20\7\20\u01bd"+
		"\n\20\f\20\16\20\u01c0\13\20\3\20\3\20\3\20\5\20\u01c5\n\20\3\20\3\20"+
		"\5\20\u01c9\n\20\3\21\3\21\5\21\u01cd\n\21\3\21\7\21\u01d0\n\21\f\21\16"+
		"\21\u01d3\13\21\3\22\6\22\u01d6\n\22\r\22\16\22\u01d7\3\22\3\22\3\22\3"+
		"\22\3\22\3\22\3\22\3\22\3\22\3\22\5\22\u01e4\n\22\3\23\3\23\5\23\u01e8"+
		"\n\23\3\23\3\23\3\23\5\23\u01ed\n\23\3\23\5\23\u01f0\n\23\3\23\5\23\u01f3"+
		"\n\23\3\23\3\23\3\23\5\23\u01f8\n\23\3\23\5\23\u01fb\n\23\3\23\3\23\3"+
		"\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u0209\n\23\3\23"+
		"\3\23\3\23\3\23\3\23\5\23\u0210\n\23\3\23\3\23\3\23\3\23\3\23\5\23\u0217"+
		"\n\23\5\23\u0219\n\23\3\24\5\24\u021c\n\24\3\24\3\24\3\25\3\25\5\25\u0222"+
		"\n\25\3\25\3\25\3\25\5\25\u0227\n\25\3\25\3\25\3\25\3\25\7\25\u022d\n"+
		"\25\f\25\16\25\u0230\13\25\3\25\3\25\5\25\u0234\n\25\3\25\3\25\3\25\3"+
		"\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\7\25\u0241\n\25\f\25\16\25\u0244"+
		"\13\25\3\25\3\25\3\25\5\25\u0249\n\25\3\26\3\26\3\26\3\26\3\26\3\26\7"+
		"\26\u0251\n\26\f\26\16\26\u0254\13\26\3\26\3\26\5\26\u0258\n\26\3\26\3"+
		"\26\3\26\3\26\3\26\3\26\3\26\3\26\5\26\u0262\n\26\3\26\3\26\7\26\u0266"+
		"\n\26\f\26\16\26\u0269\13\26\3\26\5\26\u026c\n\26\3\26\3\26\3\26\5\26"+
		"\u0271\n\26\5\26\u0273\n\26\3\27\3\27\3\27\3\27\3\30\3\30\5\30\u027b\n"+
		"\30\3\30\3\30\3\30\3\30\5\30\u0281\n\30\3\30\3\30\3\30\5\30\u0286\n\30"+
		"\3\30\3\30\3\30\3\30\3\30\5\30\u028d\n\30\3\30\3\30\3\30\3\30\3\30\3\30"+
		"\3\30\7\30\u0296\n\30\f\30\16\30\u0299\13\30\5\30\u029b\n\30\5\30\u029d"+
		"\n\30\3\30\3\30\3\30\3\30\3\30\5\30\u02a4\n\30\3\30\3\30\5\30\u02a8\n"+
		"\30\3\30\3\30\3\30\3\30\3\30\5\30\u02af\n\30\3\30\3\30\6\30\u02b3\n\30"+
		"\r\30\16\30\u02b4\3\30\3\30\3\31\3\31\5\31\u02bb\n\31\3\31\3\31\3\31\3"+
		"\31\5\31\u02c1\n\31\3\31\3\31\3\31\5\31\u02c6\n\31\3\31\3\31\3\31\3\31"+
		"\3\31\7\31\u02cd\n\31\f\31\16\31\u02d0\13\31\3\31\3\31\5\31\u02d4\n\31"+
		"\3\31\3\31\3\31\3\32\3\32\3\32\3\32\3\32\3\32\5\32\u02df\n\32\3\32\3\32"+
		"\3\32\5\32\u02e4\n\32\3\32\3\32\3\32\3\32\3\32\3\32\3\32\7\32\u02ed\n"+
		"\32\f\32\16\32\u02f0\13\32\3\32\3\32\5\32\u02f4\n\32\3\33\3\33\5\33\u02f8"+
		"\n\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\7\33"+
		"\u0306\n\33\f\33\16\33\u0309\13\33\3\34\3\34\3\34\3\34\3\34\7\34\u0310"+
		"\n\34\f\34\16\34\u0313\13\34\3\34\3\34\5\34\u0317\n\34\3\35\3\35\3\35"+
		"\3\35\3\35\3\35\5\35\u031f\n\35\3\35\3\35\3\35\3\36\3\36\3\36\3\36\3\36"+
		"\7\36\u0329\n\36\f\36\16\36\u032c\13\36\3\36\3\36\5\36\u0330\n\36\3\36"+
		"\3\36\3\36\3\36\3\36\3\37\5\37\u0338\n\37\3\37\3\37\3\37\3\37\3\37\5\37"+
		"\u033f\n\37\3 \5 \u0342\n \3 \3 \3 \3 \3 \5 \u0349\n \3 \5 \u034c\n \3"+
		" \5 \u034f\n \3!\3!\5!\u0353\n!\3!\3!\3\"\3\"\3\"\3\"\5\"\u035b\n\"\3"+
		"\"\3\"\3\"\5\"\u0360\n\"\3\"\3\"\3#\3#\3#\3#\3#\3#\5#\u036a\n#\3#\3#\3"+
		"#\5#\u036f\n#\3#\3#\3#\3#\3#\3#\3#\5#\u0378\n#\3#\3#\3#\7#\u037d\n#\f"+
		"#\16#\u0380\13#\3#\5#\u0383\n#\3#\3#\5#\u0387\n#\3#\5#\u038a\n#\3#\3#"+
		"\3#\3#\7#\u0390\n#\f#\16#\u0393\13#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\5#\u039f"+
		"\n#\3#\5#\u03a2\n#\3#\3#\3#\3#\3#\3#\5#\u03aa\n#\3#\3#\3#\3#\3#\6#\u03b1"+
		"\n#\r#\16#\u03b2\3#\3#\5#\u03b7\n#\3#\3#\3#\5#\u03bc\n#\3#\3#\3#\3#\3"+
		"#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3"+
		"#\5#\u03da\n#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\5#\u03e6\n#\3#\3#\3#\5#\u03eb"+
		"\n#\3#\3#\3#\3#\3#\3#\3#\3#\3#\3#\5#\u03f7\n#\3#\3#\3#\3#\5#\u03fd\n#"+
		"\3#\3#\3#\3#\3#\5#\u0404\n#\3#\3#\5#\u0408\n#\3#\3#\3#\3#\3#\3#\7#\u0410"+
		"\n#\f#\16#\u0413\13#\5#\u0415\n#\3#\3#\3#\3#\5#\u041b\n#\3#\3#\3#\3#\5"+
		"#\u0421\n#\3#\3#\3#\3#\3#\7#\u0428\n#\f#\16#\u042b\13#\5#\u042d\n#\3#"+
		"\3#\5#\u0431\n#\7#\u0433\n#\f#\16#\u0436\13#\3$\3$\3$\3$\3$\3$\5$\u043e"+
		"\n$\3$\3$\3%\3%\3&\5&\u0445\n&\3&\3&\3&\3&\3&\5&\u044c\n&\3&\3&\3&\3&"+
		"\5&\u0452\n&\3&\3&\3&\5&\u0457\n&\3&\3&\3&\3&\7&\u045d\n&\f&\16&\u0460"+
		"\13&\3&\3&\5&\u0464\n&\3&\3&\3&\3&\3&\7&\u046b\n&\f&\16&\u046e\13&\3&"+
		"\3&\3&\3&\3&\3&\7&\u0476\n&\f&\16&\u0479\13&\3&\3&\7&\u047d\n&\f&\16&"+
		"\u0480\13&\3&\5&\u0483\n&\3&\5&\u0486\n&\3&\3&\5&\u048a\n&\3\'\3\'\3\'"+
		"\3\'\3\'\3\'\7\'\u0492\n\'\f\'\16\'\u0495\13\'\3\'\3\'\3\'\5\'\u049a\n"+
		"\'\5\'\u049c\n\'\3\'\3\'\3\'\3\'\3\'\3\'\5\'\u04a4\n\'\3\'\3\'\3\'\3\'"+
		"\3\'\5\'\u04ab\n\'\3\'\3\'\3\'\7\'\u04b0\n\'\f\'\16\'\u04b3\13\'\3\'\3"+
		"\'\5\'\u04b7\n\'\5\'\u04b9\n\'\3(\3(\3(\3(\5(\u04bf\n(\3(\3(\3(\3(\3("+
		"\3(\3(\5(\u04c8\n(\3)\3)\3)\5)\u04cd\n)\3*\3*\3*\3*\3*\5*\u04d4\n*\3*"+
		"\3*\5*\u04d8\n*\5*\u04da\n*\3+\5+\u04dd\n+\3+\3+\3+\3+\7+\u04e3\n+\f+"+
		"\16+\u04e6\13+\3+\5+\u04e9\n+\3+\5+\u04ec\n+\3,\3,\3,\3,\5,\u04f2\n,\7"+
		",\u04f4\n,\f,\16,\u04f7\13,\3-\3-\5-\u04fb\n-\3-\3-\3-\7-\u0500\n-\f-"+
		"\16-\u0503\13-\3-\3-\3-\3-\7-\u0509\n-\f-\16-\u050c\13-\3-\5-\u050f\n"+
		"-\5-\u0511\n-\3-\3-\5-\u0515\n-\3-\3-\3-\3-\3-\7-\u051c\n-\f-\16-\u051f"+
		"\13-\3-\3-\5-\u0523\n-\5-\u0525\n-\3-\3-\3-\3-\3-\3-\3-\3-\3-\7-\u0530"+
		"\n-\f-\16-\u0533\13-\5-\u0535\n-\3-\3-\3-\3-\3-\7-\u053c\n-\f-\16-\u053f"+
		"\13-\3-\3-\3-\3-\3-\3-\7-\u0547\n-\f-\16-\u054a\13-\3-\3-\7-\u054e\n-"+
		"\f-\16-\u0551\13-\5-\u0553\n-\3.\3.\3/\5/\u0558\n/\3/\3/\5/\u055c\n/\3"+
		"/\5/\u055f\n/\3\60\5\60\u0562\n\60\3\60\3\60\3\60\5\60\u0567\n\60\3\60"+
		"\3\60\5\60\u056b\n\60\3\60\6\60\u056e\n\60\r\60\16\60\u056f\3\60\5\60"+
		"\u0573\n\60\3\60\5\60\u0576\n\60\3\61\3\61\3\61\5\61\u057b\n\61\3\61\3"+
		"\61\5\61\u057f\n\61\3\61\5\61\u0582\n\61\3\61\3\61\3\61\3\61\3\61\5\61"+
		"\u0589\n\61\3\61\3\61\3\61\5\61\u058e\n\61\3\61\3\61\3\61\3\61\3\61\7"+
		"\61\u0595\n\61\f\61\16\61\u0598\13\61\3\61\3\61\5\61\u059c\n\61\3\61\5"+
		"\61\u059f\n\61\3\61\3\61\3\61\3\61\7\61\u05a5\n\61\f\61\16\61\u05a8\13"+
		"\61\3\61\5\61\u05ab\n\61\3\61\3\61\3\61\3\61\3\61\3\61\5\61\u05b3\n\61"+
		"\3\61\5\61\u05b6\n\61\5\61\u05b8\n\61\3\62\3\62\3\62\3\62\3\62\3\62\3"+
		"\62\5\62\u05c1\n\62\3\62\5\62\u05c4\n\62\5\62\u05c6\n\62\3\63\3\63\5\63"+
		"\u05ca\n\63\3\63\3\63\5\63\u05ce\n\63\3\63\3\63\5\63\u05d2\n\63\3\63\5"+
		"\63\u05d5\n\63\3\64\3\64\3\64\3\64\3\64\3\64\3\64\7\64\u05de\n\64\f\64"+
		"\16\64\u05e1\13\64\3\64\3\64\5\64\u05e5\n\64\3\65\3\65\5\65\u05e9\n\65"+
		"\3\65\3\65\5\65\u05ed\n\65\3\66\5\66\u05f0\n\66\3\66\3\66\3\66\5\66\u05f5"+
		"\n\66\3\66\3\66\3\66\3\66\5\66\u05fb\n\66\3\66\3\66\3\66\3\66\3\66\5\66"+
		"\u0602\n\66\3\66\3\66\3\66\7\66\u0607\n\66\f\66\16\66\u060a\13\66\3\66"+
		"\3\66\5\66\u060e\n\66\3\67\3\67\3\67\3\67\7\67\u0614\n\67\f\67\16\67\u0617"+
		"\13\67\3\67\3\67\38\58\u061c\n8\38\38\38\58\u0621\n8\38\38\38\38\58\u0627"+
		"\n8\38\38\38\38\38\58\u062e\n8\38\38\38\78\u0633\n8\f8\168\u0636\138\3"+
		"8\38\58\u063a\n8\38\58\u063d\n8\38\58\u0640\n8\39\39\39\59\u0645\n9\3"+
		"9\39\39\59\u064a\n9\39\39\39\39\39\59\u0651\n9\3:\3:\5:\u0655\n:\3:\3"+
		":\5:\u0659\n:\3;\3;\3;\3;\3;\3;\3<\3<\5<\u0663\n<\3<\3<\3<\3<\3<\7<\u066a"+
		"\n<\f<\16<\u066d\13<\5<\u066f\n<\3<\3<\3<\3<\3<\7<\u0676\n<\f<\16<\u0679"+
		"\13<\3<\5<\u067c\n<\3<\3<\3=\3=\3=\3=\5=\u0684\n=\3=\3=\3=\3=\3=\7=\u068b"+
		"\n=\f=\16=\u068e\13=\5=\u0690\n=\3=\3=\3=\3=\3=\7=\u0697\n=\f=\16=\u069a"+
		"\13=\5=\u069c\n=\3=\5=\u069f\n=\3=\5=\u06a2\n=\3>\3>\3>\3>\3>\3>\3>\3"+
		">\5>\u06ac\n>\3?\3?\3?\3?\3?\3?\3?\5?\u06b5\n?\3@\3@\3@\3@\3@\7@\u06bc"+
		"\n@\f@\16@\u06bf\13@\3@\5@\u06c2\n@\3@\3@\3A\3A\3A\5A\u06c9\nA\3A\3A\3"+
		"A\7A\u06ce\nA\fA\16A\u06d1\13A\3A\5A\u06d4\nA\3A\3A\5A\u06d8\nA\3B\3B"+
		"\3B\3B\3B\7B\u06df\nB\fB\16B\u06e2\13B\3B\5B\u06e5\nB\3B\3B\5B\u06e9\n"+
		"B\3B\3B\3B\5B\u06ee\nB\3C\3C\5C\u06f2\nC\3C\3C\3C\7C\u06f7\nC\fC\16C\u06fa"+
		"\13C\3D\3D\3D\3D\3D\7D\u0701\nD\fD\16D\u0704\13D\3E\3E\3E\3E\5E\u070a"+
		"\nE\3F\3F\3F\5F\u070f\nF\3F\5F\u0712\nF\3F\3F\5F\u0716\nF\3G\3G\3H\3H"+
		"\3H\3H\3H\3H\3H\3H\3H\3H\5H\u0724\nH\3I\3I\3I\3I\3I\3I\3I\3I\3I\3I\5I"+
		"\u0730\nI\3J\3J\3J\3J\3J\3J\3J\5J\u0739\nJ\3K\3K\3K\3K\3K\3K\3K\5K\u0742"+
		"\nK\3K\3K\5K\u0746\nK\3K\3K\3K\3K\3K\3K\3K\3K\5K\u0750\nK\3K\5K\u0753"+
		"\nK\3K\3K\3K\3K\3K\3K\3K\5K\u075c\nK\3K\3K\3K\3K\3K\3K\3K\5K\u0765\nK"+
		"\3K\5K\u0768\nK\3K\3K\3K\3K\5K\u076e\nK\3K\3K\3K\3K\3K\3K\3K\3K\3K\3K"+
		"\3K\3K\5K\u077c\nK\3K\3K\5K\u0780\nK\3K\3K\3K\3K\3K\3K\3K\3K\3K\5K\u078b"+
		"\nK\3K\3K\3K\5K\u0790\nK\3L\3L\3L\3M\3M\3M\3N\3N\3N\6N\u079b\nN\rN\16"+
		"N\u079c\3O\3O\3O\6O\u07a2\nO\rO\16O\u07a3\3P\3P\3P\3P\3Q\3Q\5Q\u07ac\n"+
		"Q\3Q\3Q\3Q\5Q\u07b1\nQ\7Q\u07b3\nQ\fQ\16Q\u07b6\13Q\3R\3R\3S\3S\3T\3T"+
		"\3U\3U\3V\3V\5V\u07c2\nV\3W\3W\3X\3X\3Y\3Y\3Z\3Z\3[\3[\3\\\3\\\3]\3]\3"+
		"^\3^\3_\3_\3`\3`\3a\3a\3b\3b\3c\3c\3d\3d\3e\3e\3f\3f\3g\3g\3h\3h\3i\3"+
		"i\3j\3j\3k\3k\3l\3l\3m\3m\3n\3n\3o\3o\3p\3p\3q\3q\3q\3q\3q\3q\3q\5q\u07ff"+
		"\nq\3q\2\3Dr\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64"+
		"\668:<>@BDFHJLNPRTVXZ\\^`bdfhjlnprtvxz|~\u0080\u0082\u0084\u0086\u0088"+
		"\u008a\u008c\u008e\u0090\u0092\u0094\u0096\u0098\u009a\u009c\u009e\u00a0"+
		"\u00a2\u00a4\u00a6\u00a8\u00aa\u00ac\u00ae\u00b0\u00b2\u00b4\u00b6\u00b8"+
		"\u00ba\u00bc\u00be\u00c0\u00c2\u00c4\u00c6\u00c8\u00ca\u00cc\u00ce\u00d0"+
		"\u00d2\u00d4\u00d6\u00d8\u00da\u00dc\u00de\u00e0\2\36\5\2<<GGTT\4\2\61"+
		"\61DD\3\2\u0086\u0087\4\2\u0093\u0093\u00ac\u00ac\3\2\n\13\4\2==\u008e"+
		"\u008e\4\2::jj\4\2<<TT\7\2\33\33JJSS||\177\177\6\2VV\u0085\u0085\u008b"+
		"\u008b\u0092\u0092\4\2\t\t\16\17\3\2\20\23\3\2\24\27\6\2OOcceexx\5\2\33"+
		"\33JJ\177\177\7\2\668jj\u00ad\u00ae\u00bb\u00bb\u00bd\u00be\4\2\37\37"+
		"@@\5\2\u0081\u0081\u009b\u009b\u00b4\u00b4\4\2\7\7ll\3\2\u00b1\u00b2\4"+
		"\2$$>>\4\2\u0098\u0098\u00a3\u00a3\4\2\u00a0\u00a0\u00a7\u00a7\4\2\u00a1"+
		"\u00a1\u00a8\u00a9\4\2\u00a2\u00a2\u00a4\u00a4\4\2\n\fhh\4\2\u00ba\u00ba"+
		"\u00bd\u00bd\3\2\33\u00b5\2\u0915\2\u00e6\3\2\2\2\4\u00eb\3\2\2\2\6\u00f1"+
		"\3\2\2\2\b\u010b\3\2\2\2\n\u0127\3\2\2\2\f\u0142\3\2\2\2\16\u014c\3\2"+
		"\2\2\20\u0154\3\2\2\2\22\u015e\3\2\2\2\24\u0162\3\2\2\2\26\u016d\3\2\2"+
		"\2\30\u0170\3\2\2\2\32\u0176\3\2\2\2\34\u0198\3\2\2\2\36\u01a1\3\2\2\2"+
		" \u01ca\3\2\2\2\"\u01d5\3\2\2\2$\u01e7\3\2\2\2&\u021b\3\2\2\2(\u0221\3"+
		"\2\2\2*\u024a\3\2\2\2,\u0274\3\2\2\2.\u0278\3\2\2\2\60\u02b8\3\2\2\2\62"+
		"\u02d8\3\2\2\2\64\u02f5\3\2\2\2\66\u030a\3\2\2\28\u0318\3\2\2\2:\u0323"+
		"\3\2\2\2<\u0337\3\2\2\2>\u0341\3\2\2\2@\u0350\3\2\2\2B\u0356\3\2\2\2D"+
		"\u03bb\3\2\2\2F\u0437\3\2\2\2H\u0441\3\2\2\2J\u0489\3\2\2\2L\u048b\3\2"+
		"\2\2N\u04ba\3\2\2\2P\u04cc\3\2\2\2R\u04ce\3\2\2\2T\u04dc\3\2\2\2V\u04ed"+
		"\3\2\2\2X\u0552\3\2\2\2Z\u0554\3\2\2\2\\\u0557\3\2\2\2^\u0561\3\2\2\2"+
		"`\u05b7\3\2\2\2b\u05c5\3\2\2\2d\u05d4\3\2\2\2f\u05e4\3\2\2\2h\u05ec\3"+
		"\2\2\2j\u05ef\3\2\2\2l\u060f\3\2\2\2n\u061b\3\2\2\2p\u0644\3\2\2\2r\u0652"+
		"\3\2\2\2t\u065a\3\2\2\2v\u0660\3\2\2\2x\u067f\3\2\2\2z\u06a3\3\2\2\2|"+
		"\u06ad\3\2\2\2~\u06b6\3\2\2\2\u0080\u06c5\3\2\2\2\u0082\u06d9\3\2\2\2"+
		"\u0084\u06ef\3\2\2\2\u0086\u06fb\3\2\2\2\u0088\u0705\3\2\2\2\u008a\u070b"+
		"\3\2\2\2\u008c\u0717\3\2\2\2\u008e\u0723\3\2\2\2\u0090\u072f\3\2\2\2\u0092"+
		"\u0738\3\2\2\2\u0094\u078f\3\2\2\2\u0096\u0791\3\2\2\2\u0098\u0794\3\2"+
		"\2\2\u009a\u0797\3\2\2\2\u009c\u079e\3\2\2\2\u009e\u07a5\3\2\2\2\u00a0"+
		"\u07a9\3\2\2\2\u00a2\u07b7\3\2\2\2\u00a4\u07b9\3\2\2\2\u00a6\u07bb\3\2"+
		"\2\2\u00a8\u07bd\3\2\2\2\u00aa\u07c1\3\2\2\2\u00ac\u07c3\3\2\2\2\u00ae"+
		"\u07c5\3\2\2\2\u00b0\u07c7\3\2\2\2\u00b2\u07c9\3\2\2\2\u00b4\u07cb\3\2"+
		"\2\2\u00b6\u07cd\3\2\2\2\u00b8\u07cf\3\2\2\2\u00ba\u07d1\3\2\2\2\u00bc"+
		"\u07d3\3\2\2\2\u00be\u07d5\3\2\2\2\u00c0\u07d7\3\2\2\2\u00c2\u07d9\3\2"+
		"\2\2\u00c4\u07db\3\2\2\2\u00c6\u07dd\3\2\2\2\u00c8\u07df\3\2\2\2\u00ca"+
		"\u07e1\3\2\2\2\u00cc\u07e3\3\2\2\2\u00ce\u07e5\3\2\2\2\u00d0\u07e7\3\2"+
		"\2\2\u00d2\u07e9\3\2\2\2\u00d4\u07eb\3\2\2\2\u00d6\u07ed\3\2\2\2\u00d8"+
		"\u07ef\3\2\2\2\u00da\u07f1\3\2\2\2\u00dc\u07f3\3\2\2\2\u00de\u07f5\3\2"+
		"\2\2\u00e0\u07fe\3\2\2\2\u00e2\u00e5\5\6\4\2\u00e3\u00e5\5\4\3\2\u00e4"+
		"\u00e2\3\2\2\2\u00e4\u00e3\3\2\2\2\u00e5\u00e8\3\2\2\2\u00e6\u00e4\3\2"+
		"\2\2\u00e6\u00e7\3\2\2\2\u00e7\u00e9\3\2\2\2\u00e8\u00e6\3\2\2\2\u00e9"+
		"\u00ea\7\2\2\3\u00ea\3\3\2\2\2\u00eb\u00ec\7\u00c2\2\2\u00ec\u00ed\b\3"+
		"\1\2\u00ed\5\3\2\2\2\u00ee\u00f0\7\3\2\2\u00ef\u00ee\3\2\2\2\u00f0\u00f3"+
		"\3\2\2\2\u00f1\u00ef\3\2\2\2\u00f1\u00f2\3\2\2\2\u00f2\u00f4\3\2\2\2\u00f3"+
		"\u00f1\3\2\2\2\u00f4\u00fd\5\b\5\2\u00f5\u00f7\7\3\2\2\u00f6\u00f5\3\2"+
		"\2\2\u00f7\u00f8\3\2\2\2\u00f8\u00f6\3\2\2\2\u00f8\u00f9\3\2\2\2\u00f9"+
		"\u00fa\3\2\2\2\u00fa\u00fc\5\b\5\2\u00fb\u00f6\3\2\2\2\u00fc\u00ff\3\2"+
		"\2\2\u00fd\u00fb\3\2\2\2\u00fd\u00fe\3\2\2\2\u00fe\u0103\3\2\2\2\u00ff"+
		"\u00fd\3\2\2\2\u0100\u0102\7\3\2\2\u0101\u0100\3\2\2\2\u0102\u0105\3\2"+
		"\2\2\u0103\u0101\3\2\2\2\u0103\u0104\3\2\2\2\u0104\7\3\2\2\2\u0105\u0103"+
		"\3\2\2\2\u0106\u0109\7I\2\2\u0107\u0108\7t\2\2\u0108\u010a\7q\2\2\u0109"+
		"\u0107\3\2\2\2\u0109\u010a\3\2\2\2\u010a\u010c\3\2\2\2\u010b\u0106\3\2"+
		"\2\2\u010b\u010c\3\2\2\2\u010c\u0125\3\2\2\2\u010d\u0126\5\n\6\2\u010e"+
		"\u0126\5\f\7\2\u010f\u0126\5\16\b\2\u0110\u0126\5\20\t\2\u0111\u0126\5"+
		"\22\n\2\u0112\u0126\5\32\16\2\u0113\u0126\5\36\20\2\u0114\u0126\5.\30"+
		"\2\u0115\u0126\5\60\31\2\u0116\u0126\5\62\32\2\u0117\u0126\5<\37\2\u0118"+
		"\u0126\5> \2\u0119\u0126\5@!\2\u011a\u0126\5B\"\2\u011b\u0126\5J&\2\u011c"+
		"\u0126\5N(\2\u011d\u0126\5R*\2\u011e\u0126\5\30\r\2\u011f\u0126\5\24\13"+
		"\2\u0120\u0126\5\26\f\2\u0121\u0126\5T+\2\u0122\u0126\5j\66\2\u0123\u0126"+
		"\5n8\2\u0124\u0126\5r:\2\u0125\u010d\3\2\2\2\u0125\u010e\3\2\2\2\u0125"+
		"\u010f\3\2\2\2\u0125\u0110\3\2\2\2\u0125\u0111\3\2\2\2\u0125\u0112\3\2"+
		"\2\2\u0125\u0113\3\2\2\2\u0125\u0114\3\2\2\2\u0125\u0115\3\2\2\2\u0125"+
		"\u0116\3\2\2\2\u0125\u0117\3\2\2\2\u0125\u0118\3\2\2\2\u0125\u0119\3\2"+
		"\2\2\u0125\u011a\3\2\2\2\u0125\u011b\3\2\2\2\u0125\u011c\3\2\2\2\u0125"+
		"\u011d\3\2\2\2\u0125\u011e\3\2\2\2\u0125\u011f\3\2\2\2\u0125\u0120\3\2"+
		"\2\2\u0125\u0121\3\2\2\2\u0125\u0122\3\2\2\2\u0125\u0123\3\2\2\2\u0125"+
		"\u0124\3\2\2\2\u0126\t\3\2\2\2\u0127\u0128\7 \2\2\u0128\u012c\7\u0085"+
		"\2\2\u0129\u012a\5\u00b4[\2\u012a\u012b\7\4\2\2\u012b\u012d\3\2\2\2\u012c"+
		"\u0129\3\2\2\2\u012c\u012d\3\2\2\2\u012d\u012e\3\2\2\2\u012e\u0140\5\u00b6"+
		"\\\2\u012f\u0139\7{\2\2\u0130\u0131\7\u0089\2\2\u0131\u013a\5\u00ba^\2"+
		"\u0132\u0134\7\60\2\2\u0133\u0132\3\2\2\2\u0133\u0134\3\2\2\2\u0134\u0135"+
		"\3\2\2\2\u0135\u0136\5\u00bc_\2\u0136\u0137\7\u0089\2\2\u0137\u0138\5"+
		"\u00bc_\2\u0138\u013a\3\2\2\2\u0139\u0130\3\2\2\2\u0139\u0133\3\2\2\2"+
		"\u013a\u0141\3\2\2\2\u013b\u013d\7\35\2\2\u013c\u013e\7\60\2\2\u013d\u013c"+
		"\3\2\2\2\u013d\u013e\3\2\2\2\u013e\u013f\3\2\2\2\u013f\u0141\5 \21\2\u0140"+
		"\u012f\3\2\2\2\u0140\u013b\3\2\2\2\u0141\13\3\2\2\2\u0142\u014a\7!\2\2"+
		"\u0143\u014b\5\u00b4[\2\u0144\u0145\5\u00b4[\2\u0145\u0146\7\4\2\2\u0146"+
		"\u0148\3\2\2\2\u0147\u0144\3\2\2\2\u0147\u0148\3\2\2\2\u0148\u0149\3\2"+
		"\2\2\u0149\u014b\5\u00b8]\2\u014a\u0143\3\2\2\2\u014a\u0147\3\2\2\2\u014a"+
		"\u014b\3\2\2\2\u014b\r\3\2\2\2\u014c\u014e\7%\2\2\u014d\u014f\79\2\2\u014e"+
		"\u014d\3\2\2\2\u014e\u014f\3\2\2\2\u014f\u0150\3\2\2\2\u0150\u0151\5D"+
		"#\2\u0151\u0152\7#\2\2\u0152\u0153\5\u00b4[\2\u0153\17\3\2\2\2\u0154\u0156"+
		"\7(\2\2\u0155\u0157\t\2\2\2\u0156\u0155\3\2\2\2\u0156\u0157\3\2\2\2\u0157"+
		"\u015c\3\2\2\2\u0158\u015a\7\u008a\2\2\u0159\u015b\5\u00d0i\2\u015a\u0159"+
		"\3\2\2\2\u015a\u015b\3\2\2\2\u015b\u015d\3\2\2\2\u015c\u0158\3\2\2\2\u015c"+
		"\u015d\3\2\2\2\u015d\21\3\2\2\2\u015e\u0160\t\3\2\2\u015f\u0161\7\u008a"+
		"\2\2\u0160\u015f\3\2\2\2\u0160\u0161\3\2\2\2\u0161\23\3\2\2\2\u0162\u0164"+
		"\7\177\2\2\u0163\u0165\7\u008a\2\2\u0164\u0163\3\2\2\2\u0164\u0165\3\2"+
		"\2\2\u0165\u016b\3\2\2\2\u0166\u0168\7\u0089\2\2\u0167\u0169\7\u0082\2"+
		"\2\u0168\u0167\3\2\2\2\u0168\u0169\3\2\2\2\u0169\u016a\3\2\2\2\u016a\u016c"+
		"\5\u00ccg\2\u016b\u0166\3\2\2\2\u016b\u016c\3\2\2\2\u016c\25\3\2\2\2\u016d"+
		"\u016e\7\u0082\2\2\u016e\u016f\5\u00ccg\2\u016f\27\3\2\2\2\u0170\u0172"+
		"\7z\2\2\u0171\u0173\7\u0082\2\2\u0172\u0171\3\2\2\2\u0172\u0173\3\2\2"+
		"\2\u0173\u0174\3\2\2\2\u0174\u0175\5\u00ccg\2\u0175\31\3\2\2\2\u0176\u0178"+
		"\7\64\2\2\u0177\u0179\7\u008d\2\2\u0178\u0177\3\2\2\2\u0178\u0179\3\2"+
		"\2\2\u0179\u017a\3\2\2\2\u017a\u017e\7V\2\2\u017b\u017c\7R\2\2\u017c\u017d"+
		"\7h\2\2\u017d\u017f\7H\2\2\u017e\u017b\3\2\2\2\u017e\u017f\3\2\2\2\u017f"+
		"\u0183\3\2\2\2\u0180\u0181\5\u00b4[\2\u0181\u0182\7\4\2\2\u0182\u0184"+
		"\3\2\2\2\u0183\u0180\3\2\2\2\u0183\u0184\3\2\2\2\u0184\u0185\3\2\2\2\u0185"+
		"\u0186\5\u00c2b\2\u0186\u0187\7m\2\2\u0187\u0188\5\u00b6\\\2\u0188\u0189"+
		"\7\5\2\2\u0189\u018e\5\34\17\2\u018a\u018b\7\7\2\2\u018b\u018d\5\34\17"+
		"\2\u018c\u018a\3\2\2\2\u018d\u0190\3\2\2\2\u018e\u018c\3\2\2\2\u018e\u018f"+
		"\3\2\2\2\u018f\u0191\3\2\2\2\u0190\u018e\3\2\2\2\u0191\u0194\7\6\2\2\u0192"+
		"\u0193\7\u0095\2\2\u0193\u0195\5D#\2\u0194\u0192\3\2\2\2\u0194\u0195\3"+
		"\2\2\2\u0195\33\3\2\2\2\u0196\u0199\5\u00bc_\2\u0197\u0199\5D#\2\u0198"+
		"\u0196\3\2\2\2\u0198\u0197\3\2\2\2\u0199\u019c\3\2\2\2\u019a\u019b\7/"+
		"\2\2\u019b\u019d\5\u00be`\2\u019c\u019a\3\2\2\2\u019c\u019d\3\2\2\2\u019d"+
		"\u019f\3\2\2\2\u019e\u01a0\5\u008cG\2\u019f\u019e\3\2\2\2\u019f\u01a0"+
		"\3\2\2\2\u01a0\35\3\2\2\2\u01a1\u01a3\7\64\2\2\u01a2\u01a4\t\4\2\2\u01a3"+
		"\u01a2\3\2\2\2\u01a3\u01a4\3\2\2\2\u01a4\u01a5\3\2\2\2\u01a5\u01a9\7\u0085"+
		"\2\2\u01a6\u01a7\7R\2\2\u01a7\u01a8\7h\2\2\u01a8\u01aa\7H\2\2\u01a9\u01a6"+
		"\3\2\2\2\u01a9\u01aa\3\2\2\2\u01aa\u01ae\3\2\2\2\u01ab\u01ac\5\u00b4["+
		"\2\u01ac\u01ad\7\4\2\2\u01ad\u01af\3\2\2\2\u01ae\u01ab\3\2\2\2\u01ae\u01af"+
		"\3\2\2\2\u01af\u01b0\3\2\2\2\u01b0\u01c8\5\u00b6\\\2\u01b1\u01b2\7\5\2"+
		"\2\u01b2\u01b7\5 \21\2\u01b3\u01b4\7\7\2\2\u01b4\u01b6\5 \21\2\u01b5\u01b3"+
		"\3\2\2\2\u01b6\u01b9\3\2\2\2\u01b7\u01b5\3\2\2\2\u01b7\u01b8\3\2\2\2\u01b8"+
		"\u01be\3\2\2\2\u01b9\u01b7\3\2\2\2\u01ba\u01bb\7\7\2\2\u01bb\u01bd\5("+
		"\25\2\u01bc\u01ba\3\2\2\2\u01bd\u01c0\3\2\2\2\u01be\u01bc\3\2\2\2\u01be"+
		"\u01bf\3\2\2\2\u01bf\u01c1\3\2\2\2\u01c0\u01be\3\2\2\2\u01c1\u01c4\7\6"+
		"\2\2\u01c2\u01c3\7\u0097\2\2\u01c3\u01c5\7\u00ba\2\2\u01c4\u01c2\3\2\2"+
		"\2\u01c4\u01c5\3\2\2\2\u01c5\u01c9\3\2\2\2\u01c6\u01c7\7#\2\2\u01c7\u01c9"+
		"\5T+\2\u01c8\u01b1\3\2\2\2\u01c8\u01c6\3\2\2\2\u01c9\37\3\2\2\2\u01ca"+
		"\u01cc\5\u00bc_\2\u01cb\u01cd\5\"\22\2\u01cc\u01cb\3\2\2\2\u01cc\u01cd"+
		"\3\2\2\2\u01cd\u01d1\3\2\2\2\u01ce\u01d0\5$\23\2\u01cf\u01ce\3\2\2\2\u01d0"+
		"\u01d3\3\2\2\2\u01d1\u01cf\3\2\2\2\u01d1\u01d2\3\2\2\2\u01d2!\3\2\2\2"+
		"\u01d3\u01d1\3\2\2\2\u01d4\u01d6\5\u00b0Y\2\u01d5\u01d4\3\2\2\2\u01d6"+
		"\u01d7\3\2\2\2\u01d7\u01d5\3\2\2\2\u01d7\u01d8\3\2\2\2\u01d8\u01e3\3\2"+
		"\2\2\u01d9\u01da\7\5\2\2\u01da\u01db\5&\24\2\u01db\u01dc\7\6\2\2\u01dc"+
		"\u01e4\3\2\2\2\u01dd\u01de\7\5\2\2\u01de\u01df\5&\24\2\u01df\u01e0\7\7"+
		"\2\2\u01e0\u01e1\5&\24\2\u01e1\u01e2\7\6\2\2\u01e2\u01e4\3\2\2\2\u01e3"+
		"\u01d9\3\2\2\2\u01e3\u01dd\3\2\2\2\u01e3\u01e4\3\2\2\2\u01e4#\3\2\2\2"+
		"\u01e5\u01e6\7\63\2\2\u01e6\u01e8\5\u00b0Y\2\u01e7\u01e5\3\2\2\2\u01e7"+
		"\u01e8\3\2\2\2\u01e8\u0218\3\2\2\2\u01e9\u01ea\7s\2\2\u01ea\u01ec\7a\2"+
		"\2\u01eb\u01ed\5\u008cG\2\u01ec\u01eb\3\2\2\2\u01ec\u01ed\3\2\2\2\u01ed"+
		"\u01ef\3\2\2\2\u01ee\u01f0\5,\27\2\u01ef\u01ee\3\2\2\2\u01ef\u01f0\3\2"+
		"\2\2\u01f0\u01f2\3\2\2\2\u01f1\u01f3\7&\2\2\u01f2\u01f1\3\2\2\2\u01f2"+
		"\u01f3\3\2\2\2\u01f3\u0219\3\2\2\2\u01f4\u01f5\7h\2\2\u01f5\u01f8\7j\2"+
		"\2\u01f6\u01f8\7\u008d\2\2\u01f7\u01f4\3\2\2\2\u01f7\u01f6\3\2\2\2\u01f8"+
		"\u01fa\3\2\2\2\u01f9\u01fb\5,\27\2\u01fa\u01f9\3\2\2\2\u01fa\u01fb\3\2"+
		"\2\2\u01fb\u0219\3\2\2\2\u01fc\u01fd\7.\2\2\u01fd\u01fe\7\5\2\2\u01fe"+
		"\u01ff\5D#\2\u01ff\u0200\7\6\2\2\u0200\u0219\3\2\2\2\u0201\u0208\7:\2"+
		"\2\u0202\u0209\5&\24\2\u0203\u0209\5H%\2\u0204\u0205\7\5\2\2\u0205\u0206"+
		"\5D#\2\u0206\u0207\7\6\2\2\u0207\u0209\3\2\2\2\u0208\u0202\3\2\2\2\u0208"+
		"\u0203\3\2\2\2\u0208\u0204\3\2\2\2\u0209\u0219\3\2\2\2\u020a\u020b\7/"+
		"\2\2\u020b\u0219\5\u00be`\2\u020c\u0219\5*\26\2\u020d\u020e\7\u00aa\2"+
		"\2\u020e\u0210\7\u00ab\2\2\u020f\u020d\3\2\2\2\u020f\u0210\3\2\2\2\u0210"+
		"\u0211\3\2\2\2\u0211\u0212\7#\2\2\u0212\u0213\7\5\2\2\u0213\u0214\5D#"+
		"\2\u0214\u0216\7\6\2\2\u0215\u0217\t\5\2\2\u0216\u0215\3\2\2\2\u0216\u0217"+
		"\3\2\2\2\u0217\u0219\3\2\2\2\u0218\u01e9\3\2\2\2\u0218\u01f7\3\2\2\2\u0218"+
		"\u01fc\3\2\2\2\u0218\u0201\3\2\2\2\u0218\u020a\3\2\2\2\u0218\u020c\3\2"+
		"\2\2\u0218\u020f\3\2\2\2\u0219%\3\2\2\2\u021a\u021c\t\6\2\2\u021b\u021a"+
		"\3\2\2\2\u021b\u021c\3\2\2\2\u021c\u021d\3\2\2\2\u021d\u021e\7\u00bb\2"+
		"\2\u021e\'\3\2\2\2\u021f\u0220\7\63\2\2\u0220\u0222\5\u00b0Y\2\u0221\u021f"+
		"\3\2\2\2\u0221\u0222\3\2\2\2\u0222\u0248\3\2\2\2\u0223\u0224\7s\2\2\u0224"+
		"\u0227\7a\2\2\u0225\u0227\7\u008d\2\2\u0226\u0223\3\2\2\2\u0226\u0225"+
		"\3\2\2\2\u0227\u0228\3\2\2\2\u0228\u0229\7\5\2\2\u0229\u022e\5\34\17\2"+
		"\u022a\u022b\7\7\2\2\u022b\u022d\5\34\17\2\u022c\u022a\3\2\2\2\u022d\u0230"+
		"\3\2\2\2\u022e\u022c\3\2\2\2\u022e\u022f\3\2\2\2\u022f\u0231\3\2\2\2\u0230"+
		"\u022e\3\2\2\2\u0231\u0233\7\6\2\2\u0232\u0234\5,\27\2\u0233\u0232\3\2"+
		"\2\2\u0233\u0234\3\2\2\2\u0234\u0249\3\2\2\2\u0235\u0236\7.\2\2\u0236"+
		"\u0237\7\5\2\2\u0237\u0238\5D#\2\u0238\u0239\7\6\2\2\u0239\u0249\3\2\2"+
		"\2\u023a\u023b\7L\2\2\u023b\u023c\7a\2\2\u023c\u023d\7\5\2\2\u023d\u0242"+
		"\5\u00bc_\2\u023e\u023f\7\7\2\2\u023f\u0241\5\u00bc_\2\u0240\u023e\3\2"+
		"\2\2\u0241\u0244\3\2\2\2\u0242\u0240\3\2\2\2\u0242\u0243\3\2\2\2\u0243"+
		"\u0245\3\2\2\2\u0244\u0242\3\2\2\2\u0245\u0246\7\6\2\2\u0246\u0247\5*"+
		"\26\2\u0247\u0249\3\2\2\2\u0248\u0226\3\2\2\2\u0248\u0235\3\2\2\2\u0248"+
		"\u023a\3\2\2\2\u0249)\3\2\2\2\u024a\u024b\7w\2\2\u024b\u0257\5\u00c0a"+
		"\2\u024c\u024d\7\5\2\2\u024d\u0252\5\u00bc_\2\u024e\u024f\7\7\2\2\u024f"+
		"\u0251\5\u00bc_\2\u0250\u024e\3\2\2\2\u0251\u0254\3\2\2\2\u0252\u0250"+
		"\3\2\2\2\u0252\u0253\3\2\2\2\u0253\u0255\3\2\2\2\u0254\u0252\3\2\2\2\u0255"+
		"\u0256\7\6\2\2\u0256\u0258\3\2\2\2\u0257\u024c\3\2\2\2\u0257\u0258\3\2"+
		"\2\2\u0258\u0267\3\2\2\2\u0259\u025a\7m\2\2\u025a\u0261\t\7\2\2\u025b"+
		"\u025c\7\u0084\2\2\u025c\u0262\t\b\2\2\u025d\u0262\7+\2\2\u025e\u0262"+
		"\7}\2\2\u025f\u0260\7g\2\2\u0260\u0262\7\34\2\2\u0261\u025b\3\2\2\2\u0261"+
		"\u025d\3\2\2\2\u0261\u025e\3\2\2\2\u0261\u025f\3\2\2\2\u0262\u0266\3\2"+
		"\2\2\u0263\u0264\7e\2\2\u0264\u0266\5\u00b0Y\2\u0265\u0259\3\2\2\2\u0265"+
		"\u0263\3\2\2\2\u0266\u0269\3\2\2\2\u0267\u0265\3\2\2\2\u0267\u0268\3\2"+
		"\2\2\u0268\u0272\3\2\2\2\u0269\u0267\3\2\2\2\u026a\u026c\7h\2\2\u026b"+
		"\u026a\3\2\2\2\u026b\u026c\3\2\2\2\u026c\u026d\3\2\2\2\u026d\u0270\7;"+
		"\2\2\u026e\u026f\7X\2\2\u026f\u0271\t\t\2\2\u0270\u026e\3\2\2\2\u0270"+
		"\u0271\3\2\2\2\u0271\u0273\3\2\2\2\u0272\u026b\3\2\2\2\u0272\u0273\3\2"+
		"\2\2\u0273+\3\2\2\2\u0274\u0275\7m\2\2\u0275\u0276\7\62\2\2\u0276\u0277"+
		"\t\n\2\2\u0277-\3\2\2\2\u0278\u027a\7\64\2\2\u0279\u027b\t\4\2\2\u027a"+
		"\u0279\3\2\2\2\u027a\u027b\3\2\2\2\u027b\u027c\3\2\2\2\u027c\u0280\7\u008b"+
		"\2\2\u027d\u027e\7R\2\2\u027e\u027f\7h\2\2\u027f\u0281\7H\2\2\u0280\u027d"+
		"\3\2\2\2\u0280\u0281\3\2\2\2\u0281\u0285\3\2\2\2\u0282\u0283\5\u00b4["+
		"\2\u0283\u0284\7\4\2\2\u0284\u0286\3\2\2\2\u0285\u0282\3\2\2\2\u0285\u0286"+
		"\3\2\2\2\u0286\u0287\3\2\2\2\u0287\u028c\5\u00c4c\2\u0288\u028d\7\'\2"+
		"\2\u0289\u028d\7\36\2\2\u028a\u028b\7[\2\2\u028b\u028d\7k\2\2\u028c\u0288"+
		"\3\2\2\2\u028c\u0289\3\2\2\2\u028c\u028a\3\2\2\2\u028c\u028d\3\2\2\2\u028d"+
		"\u029c\3\2\2\2\u028e\u029d\7=\2\2\u028f\u029d\7Z\2\2\u0290\u029a\7\u008e"+
		"\2\2\u0291\u0292\7k\2\2\u0292\u0297\5\u00bc_\2\u0293\u0294\7\7\2\2\u0294"+
		"\u0296\5\u00bc_\2\u0295\u0293\3\2\2\2\u0296\u0299\3\2\2\2\u0297\u0295"+
		"\3\2\2\2\u0297\u0298\3\2\2\2\u0298\u029b\3\2\2\2\u0299\u0297\3\2\2\2\u029a"+
		"\u0291\3\2\2\2\u029a\u029b\3\2\2\2\u029b\u029d\3\2\2\2\u029c\u028e\3\2"+
		"\2\2\u029c\u028f\3\2\2\2\u029c\u0290\3\2\2\2\u029d\u029e\3\2\2\2\u029e"+
		"\u029f\7m\2\2\u029f\u02a3\5\u00b6\\\2\u02a0\u02a1\7K\2\2\u02a1\u02a2\7"+
		"B\2\2\u02a2\u02a4\7\u0080\2\2\u02a3\u02a0\3\2\2\2\u02a3\u02a4\3\2\2\2"+
		"\u02a4\u02a7\3\2\2\2\u02a5\u02a6\7\u0094\2\2\u02a6\u02a8\5D#\2\u02a7\u02a5"+
		"\3\2\2\2\u02a7\u02a8\3\2\2\2\u02a8\u02a9\3\2\2\2\u02a9\u02b2\7(\2\2\u02aa"+
		"\u02af\5j\66\2\u02ab\u02af\5J&\2\u02ac\u02af\5<\37\2\u02ad\u02af\5T+\2"+
		"\u02ae\u02aa\3\2\2\2\u02ae\u02ab\3\2\2\2\u02ae\u02ac\3\2\2\2\u02ae\u02ad"+
		"\3\2\2\2\u02af\u02b0\3\2\2\2\u02b0\u02b1\7\3\2\2\u02b1\u02b3\3\2\2\2\u02b2"+
		"\u02ae\3\2\2\2\u02b3\u02b4\3\2\2\2\u02b4\u02b2\3\2\2\2\u02b4\u02b5\3\2"+
		"\2\2\u02b5\u02b6\3\2\2\2\u02b6\u02b7\7D\2\2\u02b7/\3\2\2\2\u02b8\u02ba"+
		"\7\64\2\2\u02b9\u02bb\t\4\2\2\u02ba\u02b9\3\2\2\2\u02ba\u02bb\3\2\2\2"+
		"\u02bb\u02bc\3\2\2\2\u02bc\u02c0\7\u0092\2\2\u02bd\u02be\7R\2\2\u02be"+
		"\u02bf\7h\2\2\u02bf\u02c1\7H\2\2\u02c0\u02bd\3\2\2\2\u02c0\u02c1\3\2\2"+
		"\2\u02c1\u02c5\3\2\2\2\u02c2\u02c3\5\u00b4[\2\u02c3\u02c4\7\4\2\2\u02c4"+
		"\u02c6\3\2\2\2\u02c5\u02c2\3\2\2\2\u02c5\u02c6\3\2\2\2\u02c6\u02c7\3\2"+
		"\2\2\u02c7\u02d3\5\u00c6d\2\u02c8\u02c9\7\5\2\2\u02c9\u02ce\5\u00bc_\2"+
		"\u02ca\u02cb\7\7\2\2\u02cb\u02cd\5\u00bc_\2\u02cc\u02ca\3\2\2\2\u02cd"+
		"\u02d0\3\2\2\2\u02ce\u02cc\3\2\2\2\u02ce\u02cf\3\2\2\2\u02cf\u02d1\3\2"+
		"\2\2\u02d0\u02ce\3\2\2\2\u02d1\u02d2\7\6\2\2\u02d2\u02d4\3\2\2\2\u02d3"+
		"\u02c8\3\2\2\2\u02d3\u02d4\3\2\2\2\u02d4\u02d5\3\2\2\2\u02d5\u02d6\7#"+
		"\2\2\u02d6\u02d7\5T+\2\u02d7\61\3\2\2\2\u02d8\u02d9\7\64\2\2\u02d9\u02da"+
		"\7\u0093\2\2\u02da\u02de\7\u0085\2\2\u02db\u02dc\7R\2\2\u02dc\u02dd\7"+
		"h\2\2\u02dd\u02df\7H\2\2\u02de\u02db\3\2\2\2\u02de\u02df\3\2\2\2\u02df"+
		"\u02e3\3\2\2\2\u02e0\u02e1\5\u00b4[\2\u02e1\u02e2\7\4\2\2\u02e2\u02e4"+
		"\3\2\2\2\u02e3\u02e0\3\2\2\2\u02e3\u02e4\3\2\2\2\u02e4\u02e5\3\2\2\2\u02e5"+
		"\u02e6\5\u00b6\\\2\u02e6\u02e7\7\u008f\2\2\u02e7\u02f3\5\u00c8e\2\u02e8"+
		"\u02e9\7\5\2\2\u02e9\u02ee\5\u00aaV\2\u02ea\u02eb\7\7\2\2\u02eb\u02ed"+
		"\5\u00aaV\2\u02ec\u02ea\3\2\2\2\u02ed\u02f0\3\2\2\2\u02ee\u02ec\3\2\2"+
		"\2\u02ee\u02ef\3\2\2\2\u02ef\u02f1\3\2\2\2\u02f0\u02ee\3\2\2\2\u02f1\u02f2"+
		"\7\6\2\2\u02f2\u02f4\3\2\2\2\u02f3\u02e8\3\2\2\2\u02f3\u02f4\3\2\2\2\u02f4"+
		"\63\3\2\2\2\u02f5\u02f7\7\u0096\2\2\u02f6\u02f8\7v\2\2\u02f7\u02f6\3\2"+
		"\2\2\u02f7\u02f8\3\2\2\2\u02f8\u02f9\3\2\2\2\u02f9\u02fa\5\66\34\2\u02fa"+
		"\u02fb\7#\2\2\u02fb\u02fc\7\5\2\2\u02fc\u02fd\5T+\2\u02fd\u0307\7\6\2"+
		"\2\u02fe\u02ff\7\7\2\2\u02ff\u0300\5\66\34\2\u0300\u0301\7#\2\2\u0301"+
		"\u0302\7\5\2\2\u0302\u0303\5T+\2\u0303\u0304\7\6\2\2\u0304\u0306\3\2\2"+
		"\2\u0305\u02fe\3\2\2\2\u0306\u0309\3\2\2\2\u0307\u0305\3\2\2\2\u0307\u0308"+
		"\3\2\2\2\u0308\65\3\2\2\2\u0309\u0307\3\2\2\2\u030a\u0316\5\u00b6\\\2"+
		"\u030b\u030c\7\5\2\2\u030c\u0311\5\u00bc_\2\u030d\u030e\7\7\2\2\u030e"+
		"\u0310\5\u00bc_\2\u030f\u030d\3\2\2\2\u0310\u0313\3\2\2\2\u0311\u030f"+
		"\3\2\2\2\u0311\u0312\3\2\2\2\u0312\u0314\3\2\2\2\u0313\u0311\3\2\2\2\u0314"+
		"\u0315\7\6\2\2\u0315\u0317\3\2\2\2\u0316\u030b\3\2\2\2\u0316\u0317\3\2"+
		"\2\2\u0317\67\3\2\2\2\u0318\u0319\5\66\34\2\u0319\u031a\7#\2\2\u031a\u031b"+
		"\7\5\2\2\u031b\u031c\5\u00a2R\2\u031c\u031e\7\u008c\2\2\u031d\u031f\7"+
		"\37\2\2\u031e\u031d\3\2\2\2\u031e\u031f\3\2\2\2\u031f\u0320\3\2\2\2\u0320"+
		"\u0321\5\u00a4S\2\u0321\u0322\7\6\2\2\u03229\3\2\2\2\u0323\u032f\5\u00b6"+
		"\\\2\u0324\u0325\7\5\2\2\u0325\u032a\5\u00bc_\2\u0326\u0327\7\7\2\2\u0327"+
		"\u0329\5\u00bc_\2\u0328\u0326\3\2\2\2\u0329\u032c\3\2\2\2\u032a\u0328"+
		"\3\2\2\2\u032a\u032b\3\2\2\2\u032b\u032d\3\2\2\2\u032c\u032a\3\2\2\2\u032d"+
		"\u032e\7\6\2\2\u032e\u0330\3\2\2\2\u032f\u0324\3\2\2\2\u032f\u0330\3\2"+
		"\2\2\u0330\u0331\3\2\2\2\u0331\u0332\7#\2\2\u0332\u0333\7\5\2\2\u0333"+
		"\u0334\5T+\2\u0334\u0335\7\6\2\2\u0335;\3\2\2\2\u0336\u0338\5\64\33\2"+
		"\u0337\u0336\3\2\2\2\u0337\u0338\3\2\2\2\u0338\u0339\3\2\2\2\u0339\u033a"+
		"\7=\2\2\u033a\u033b\7M\2\2\u033b\u033e\5p9\2\u033c\u033d\7\u0095\2\2\u033d"+
		"\u033f\5D#\2\u033e\u033c\3\2\2\2\u033e\u033f\3\2\2\2\u033f=\3\2\2\2\u0340"+
		"\u0342\5\64\33\2\u0341\u0340\3\2\2\2\u0341\u0342\3\2\2\2\u0342\u0343\3"+
		"\2\2\2\u0343\u0344\7=\2\2\u0344\u0345\7M\2\2\u0345\u0348\5p9\2\u0346\u0347"+
		"\7\u0095\2\2\u0347\u0349\5D#\2\u0348\u0346\3\2\2\2\u0348\u0349\3\2\2\2"+
		"\u0349\u034e\3\2\2\2\u034a\u034c\5\u0086D\2\u034b\u034a\3\2\2\2\u034b"+
		"\u034c\3\2\2\2\u034c\u034d\3\2\2\2\u034d\u034f\5\u0088E\2\u034e\u034b"+
		"\3\2\2\2\u034e\u034f\3\2\2\2\u034f?\3\2\2\2\u0350\u0352\7?\2\2\u0351\u0353"+
		"\79\2\2\u0352\u0351\3\2\2\2\u0352\u0353\3\2\2\2\u0353\u0354\3\2\2\2\u0354"+
		"\u0355\5\u00b4[\2\u0355A\3\2\2\2\u0356\u0357\7A\2\2\u0357\u035a\t\13\2"+
		"\2\u0358\u0359\7R\2\2\u0359\u035b\7H\2\2\u035a\u0358\3\2\2\2\u035a\u035b"+
		"\3\2\2\2\u035b\u035f\3\2\2\2\u035c\u035d\5\u00b4[\2\u035d\u035e\7\4\2"+
		"\2\u035e\u0360\3\2\2\2\u035f\u035c\3\2\2\2\u035f\u0360\3\2\2\2\u0360\u0361"+
		"\3\2\2\2\u0361\u0362\5\u00e0q\2\u0362C\3\2\2\2\u0363\u0364\b#\1\2\u0364"+
		"\u03bc\5H%\2\u0365\u03bc\7\u00bc\2\2\u0366\u0367\5\u00b4[\2\u0367\u0368"+
		"\7\4\2\2\u0368\u036a\3\2\2\2\u0369\u0366\3\2\2\2\u0369\u036a\3\2\2\2\u036a"+
		"\u036b\3\2\2\2\u036b\u036c\5\u00b6\\\2\u036c\u036d\7\4\2\2\u036d\u036f"+
		"\3\2\2\2\u036e\u0369\3\2\2\2\u036e\u036f\3\2\2\2\u036f\u0370\3\2\2\2\u0370"+
		"\u03bc\5\u00bc_\2\u0371\u0372\5\u00a6T\2\u0372\u0373\5D#\27\u0373\u03bc"+
		"\3\2\2\2\u0374\u0375\5\u00b2Z\2\u0375\u0382\7\5\2\2\u0376\u0378\7@\2\2"+
		"\u0377\u0376\3\2\2\2\u0377\u0378\3\2\2\2\u0378\u0379\3\2\2\2\u0379\u037e"+
		"\5D#\2\u037a\u037b\7\7\2\2\u037b\u037d\5D#\2\u037c\u037a\3\2\2\2\u037d"+
		"\u0380\3\2\2\2\u037e\u037c\3\2\2\2\u037e\u037f\3\2\2\2\u037f\u0383\3\2"+
		"\2\2\u0380\u037e\3\2\2\2\u0381\u0383\7\t\2\2\u0382\u0377\3\2\2\2\u0382"+
		"\u0381\3\2\2\2\u0382\u0383\3\2\2\2\u0383\u0384\3\2\2\2\u0384\u0386\7\6"+
		"\2\2\u0385\u0387\5t;\2\u0386\u0385\3\2\2\2\u0386\u0387\3\2\2\2\u0387\u0389"+
		"\3\2\2\2\u0388\u038a\5x=\2\u0389\u0388\3\2\2\2\u0389\u038a\3\2\2\2\u038a"+
		"\u03bc\3\2\2\2\u038b\u038c\7\5\2\2\u038c\u0391\5D#\2\u038d\u038e\7\7\2"+
		"\2\u038e\u0390\5D#\2\u038f\u038d\3\2\2\2\u0390\u0393\3\2\2\2\u0391\u038f"+
		"\3\2\2\2\u0391\u0392\3\2\2\2\u0392\u0394\3\2\2\2\u0393\u0391\3\2\2\2\u0394"+
		"\u0395\7\6\2\2\u0395\u03bc\3\2\2\2\u0396\u0397\7-\2\2\u0397\u0398\7\5"+
		"\2\2\u0398\u0399\5D#\2\u0399\u039a\7#\2\2\u039a\u039b\5\"\22\2\u039b\u039c"+
		"\7\6\2\2\u039c\u03bc\3\2\2\2\u039d\u039f\7h\2\2\u039e\u039d\3\2\2\2\u039e"+
		"\u039f\3\2\2\2\u039f\u03a0\3\2\2\2\u03a0\u03a2\7H\2\2\u03a1\u039e\3\2"+
		"\2\2\u03a1\u03a2\3\2\2\2\u03a2\u03a3\3\2\2\2\u03a3\u03a4\7\5\2\2\u03a4"+
		"\u03a5\5T+\2\u03a5\u03a6\7\6\2\2\u03a6\u03bc\3\2\2\2\u03a7\u03a9\7,\2"+
		"\2\u03a8\u03aa\5D#\2\u03a9\u03a8\3\2\2\2\u03a9\u03aa\3\2\2\2\u03aa\u03b0"+
		"\3\2\2\2\u03ab\u03ac\7\u0094\2\2\u03ac\u03ad\5D#\2\u03ad\u03ae\7\u0088"+
		"\2\2\u03ae\u03af\5D#\2\u03af\u03b1\3\2\2\2\u03b0\u03ab\3\2\2\2\u03b1\u03b2"+
		"\3\2\2\2\u03b2\u03b0\3\2\2\2\u03b2\u03b3\3\2\2\2\u03b3\u03b6\3\2\2\2\u03b4"+
		"\u03b5\7C\2\2\u03b5\u03b7\5D#\2\u03b6\u03b4\3\2\2\2\u03b6\u03b7\3\2\2"+
		"\2\u03b7\u03b8\3\2\2\2\u03b8\u03b9\7D\2\2\u03b9\u03bc\3\2\2\2\u03ba\u03bc"+
		"\5F$\2\u03bb\u0363\3\2\2\2\u03bb\u0365\3\2\2\2\u03bb\u036e\3\2\2\2\u03bb"+
		"\u0371\3\2\2\2\u03bb\u0374\3\2\2\2\u03bb\u038b\3\2\2\2\u03bb\u0396\3\2"+
		"\2\2\u03bb\u03a1\3\2\2\2\u03bb\u03a7\3\2\2\2\u03bb\u03ba\3\2\2\2\u03bc"+
		"\u0434\3\2\2\2\u03bd\u03be\f\26\2\2\u03be\u03bf\7\r\2\2\u03bf\u0433\5"+
		"D#\27\u03c0\u03c1\f\25\2\2\u03c1\u03c2\t\f\2\2\u03c2\u0433\5D#\26\u03c3"+
		"\u03c4\f\24\2\2\u03c4\u03c5\t\6\2\2\u03c5\u0433\5D#\25\u03c6\u03c7\f\23"+
		"\2\2\u03c7\u03c8\t\r\2\2\u03c8\u0433\5D#\24\u03c9\u03ca\f\22\2\2\u03ca"+
		"\u03cb\t\16\2\2\u03cb\u0433\5D#\23\u03cc\u03d9\f\21\2\2\u03cd\u03da\7"+
		"\b\2\2\u03ce\u03da\7\30\2\2\u03cf\u03da\7\31\2\2\u03d0\u03da\7\32\2\2"+
		"\u03d1\u03da\7^\2\2\u03d2\u03d3\7^\2\2\u03d3\u03da\7h\2\2\u03d4\u03da"+
		"\7U\2\2\u03d5\u03da\7c\2\2\u03d6\u03da\7O\2\2\u03d7\u03da\7e\2\2\u03d8"+
		"\u03da\7x\2\2\u03d9\u03cd\3\2\2\2\u03d9\u03ce\3\2\2\2\u03d9\u03cf\3\2"+
		"\2\2\u03d9\u03d0\3\2\2\2\u03d9\u03d1\3\2\2\2\u03d9\u03d2\3\2\2\2\u03d9"+
		"\u03d4\3\2\2\2\u03d9\u03d5\3\2\2\2\u03d9\u03d6\3\2\2\2\u03d9\u03d7\3\2"+
		"\2\2\u03d9\u03d8\3\2\2\2\u03da\u03db\3\2\2\2\u03db\u0433\5D#\22\u03dc"+
		"\u03dd\f\20\2\2\u03dd\u03de\7\"\2\2\u03de\u0433\5D#\21\u03df\u03e0\f\17"+
		"\2\2\u03e0\u03e1\7n\2\2\u03e1\u0433\5D#\20\u03e2\u03e3\f\b\2\2\u03e3\u03e5"+
		"\7^\2\2\u03e4\u03e6\7h\2\2\u03e5\u03e4\3\2\2\2\u03e5\u03e6\3\2\2\2\u03e6"+
		"\u03e7\3\2\2\2\u03e7\u0433\5D#\t\u03e8\u03ea\f\7\2\2\u03e9\u03eb\7h\2"+
		"\2\u03ea\u03e9\3\2\2\2\u03ea\u03eb\3\2\2\2\u03eb\u03ec\3\2\2\2\u03ec\u03ed"+
		"\7)\2\2\u03ed\u03ee\5D#\2\u03ee\u03ef\7\"\2\2\u03ef\u03f0\5D#\b\u03f0"+
		"\u0433\3\2\2\2\u03f1\u03f2\f\13\2\2\u03f2\u03f3\7/\2\2\u03f3\u0433\5\u00be"+
		"`\2\u03f4\u03f6\f\n\2\2\u03f5\u03f7\7h\2\2\u03f6\u03f5\3\2\2\2\u03f6\u03f7"+
		"\3\2\2\2\u03f7\u03f8\3\2\2\2\u03f8\u03f9\t\17\2\2\u03f9\u03fc\5D#\2\u03fa"+
		"\u03fb\7E\2\2\u03fb\u03fd\5D#\2\u03fc\u03fa\3\2\2\2\u03fc\u03fd\3\2\2"+
		"\2\u03fd\u0433\3\2\2\2\u03fe\u0403\f\t\2\2\u03ff\u0404\7_\2\2\u0400\u0404"+
		"\7i\2\2\u0401\u0402\7h\2\2\u0402\u0404\7j\2\2\u0403\u03ff\3\2\2\2\u0403"+
		"\u0400\3\2\2\2\u0403\u0401\3\2\2\2\u0404\u0433\3\2\2\2\u0405\u0407\f\6"+
		"\2\2\u0406\u0408\7h\2\2\u0407\u0406\3\2\2\2\u0407\u0408\3\2\2\2\u0408"+
		"\u0409\3\2\2\2\u0409\u0430\7U\2\2\u040a\u0414\7\5\2\2\u040b\u0415\5T+"+
		"\2\u040c\u0411\5D#\2\u040d\u040e\7\7\2\2\u040e\u0410\5D#\2\u040f\u040d"+
		"\3\2\2\2\u0410\u0413\3\2\2\2\u0411\u040f\3\2\2\2\u0411\u0412\3\2\2\2\u0412"+
		"\u0415\3\2\2\2\u0413\u0411\3\2\2\2\u0414\u040b\3\2\2\2\u0414\u040c\3\2"+
		"\2\2\u0414\u0415\3\2\2\2\u0415\u0416\3\2\2\2\u0416\u0431\7\6\2\2\u0417"+
		"\u0418\5\u00b4[\2\u0418\u0419\7\4\2\2\u0419\u041b\3\2\2\2\u041a\u0417"+
		"\3\2\2\2\u041a\u041b\3\2\2\2\u041b\u041c\3\2\2\2\u041c\u0431\5\u00b6\\"+
		"\2\u041d\u041e\5\u00b4[\2\u041e\u041f\7\4\2\2\u041f\u0421\3\2\2\2\u0420"+
		"\u041d\3\2\2\2\u0420\u0421\3\2\2\2\u0421\u0422\3\2\2\2\u0422\u0423\5\u00de"+
		"p\2\u0423\u042c\7\5\2\2\u0424\u0429\5D#\2\u0425\u0426\7\7\2\2\u0426\u0428"+
		"\5D#\2\u0427\u0425\3\2\2\2\u0428\u042b\3\2\2\2\u0429\u0427\3\2\2\2\u0429"+
		"\u042a\3\2\2\2\u042a\u042d\3\2\2\2\u042b\u0429\3\2\2\2\u042c\u0424\3\2"+
		"\2\2\u042c\u042d\3\2\2\2\u042d\u042e\3\2\2\2\u042e\u042f\7\6\2\2\u042f"+
		"\u0431\3\2\2\2\u0430\u040a\3\2\2\2\u0430\u041a\3\2\2\2\u0430\u0420\3\2"+
		"\2\2\u0431\u0433\3\2\2\2\u0432\u03bd\3\2\2\2\u0432\u03c0\3\2\2\2\u0432"+
		"\u03c3\3\2\2\2\u0432\u03c6\3\2\2\2\u0432\u03c9\3\2\2\2\u0432\u03cc\3\2"+
		"\2\2\u0432\u03dc\3\2\2\2\u0432\u03df\3\2\2\2\u0432\u03e2\3\2\2\2\u0432"+
		"\u03e8\3\2\2\2\u0432\u03f1\3\2\2\2\u0432\u03f4\3\2\2\2\u0432\u03fe\3\2"+
		"\2\2\u0432\u0405\3\2\2\2\u0433\u0436\3\2\2\2\u0434\u0432\3\2\2\2\u0434"+
		"\u0435\3\2\2\2\u0435E\3\2\2\2\u0436\u0434\3\2\2\2\u0437\u0438\7u\2\2\u0438"+
		"\u043d\7\5\2\2\u0439\u043e\7S\2\2\u043a\u043b\t\20\2\2\u043b\u043c\7\7"+
		"\2\2\u043c\u043e\5\u00a8U\2\u043d\u0439\3\2\2\2\u043d\u043a\3\2\2\2\u043e"+
		"\u043f\3\2\2\2\u043f\u0440\7\6\2\2\u0440G\3\2\2\2\u0441\u0442\t\21\2\2"+
		"\u0442I\3\2\2\2\u0443\u0445\5\64\33\2\u0444\u0443\3\2\2\2\u0444\u0445"+
		"\3\2\2\2\u0445\u044b\3\2\2\2\u0446\u044c\7Z\2\2\u0447\u044c\7|\2\2\u0448"+
		"\u0449\7Z\2\2\u0449\u044a\7n\2\2\u044a\u044c\t\n\2\2\u044b\u0446\3\2\2"+
		"\2\u044b\u0447\3\2\2\2\u044b\u0448\3\2\2\2\u044c\u044d\3\2\2\2\u044d\u0451"+
		"\7]\2\2\u044e\u044f\5\u00b4[\2\u044f\u0450\7\4\2\2\u0450\u0452\3\2\2\2"+
		"\u0451\u044e\3\2\2\2\u0451\u0452\3\2\2\2\u0452\u0453\3\2\2\2\u0453\u0456"+
		"\5\u00b6\\\2\u0454\u0455\7#\2\2\u0455\u0457\5\u00ceh\2\u0456\u0454\3\2"+
		"\2\2\u0456\u0457\3\2\2\2\u0457\u0463\3\2\2\2\u0458\u0459\7\5\2\2\u0459"+
		"\u045e\5\u00bc_\2\u045a\u045b\7\7\2\2\u045b\u045d\5\u00bc_\2\u045c\u045a"+
		"\3\2\2\2\u045d\u0460\3\2\2\2\u045e\u045c\3\2\2\2\u045e\u045f\3\2\2\2\u045f"+
		"\u0461\3\2\2\2\u0460\u045e\3\2\2\2\u0461\u0462\7\6\2\2\u0462\u0464\3\2"+
		"\2\2\u0463\u0458\3\2\2\2\u0463\u0464\3\2\2\2\u0464\u0482\3\2\2\2\u0465"+
		"\u0466\7\u0091\2\2\u0466\u0467\7\5\2\2\u0467\u046c\5D#\2\u0468\u0469\7"+
		"\7\2\2\u0469\u046b\5D#\2\u046a\u0468\3\2\2\2\u046b\u046e\3\2\2\2\u046c"+
		"\u046a\3\2\2\2\u046c\u046d\3\2\2\2\u046d\u046f\3\2\2\2\u046e\u046c\3\2"+
		"\2\2\u046f\u047e\7\6\2\2\u0470\u0471\7\7\2\2\u0471\u0472\7\5\2\2\u0472"+
		"\u0477\5D#\2\u0473\u0474\7\7\2\2\u0474\u0476\5D#\2\u0475\u0473\3\2\2\2"+
		"\u0476\u0479\3\2\2\2\u0477\u0475\3\2\2\2\u0477\u0478\3\2\2\2\u0478\u047a"+
		"\3\2\2\2\u0479\u0477\3\2\2\2\u047a\u047b\7\6\2\2\u047b\u047d\3\2\2\2\u047c"+
		"\u0470\3\2\2\2\u047d\u0480\3\2\2\2\u047e\u047c\3\2\2\2\u047e\u047f\3\2"+
		"\2\2\u047f\u0483\3\2\2\2\u0480\u047e\3\2\2\2\u0481\u0483\5T+\2\u0482\u0465"+
		"\3\2\2\2\u0482\u0481\3\2\2\2\u0483\u0485\3\2\2\2\u0484\u0486\5L\'\2\u0485"+
		"\u0484\3\2\2\2\u0485\u0486\3\2\2\2\u0486\u048a\3\2\2\2\u0487\u0488\7:"+
		"\2\2\u0488\u048a\7\u0091\2\2\u0489\u0444\3\2\2\2\u0489\u0487\3\2\2\2\u048a"+
		"K\3\2\2\2\u048b\u048c\7m\2\2\u048c\u049b\7\62\2\2\u048d\u048e\7\5\2\2"+
		"\u048e\u0493\5\34\17\2\u048f\u0490\7\7\2\2\u0490\u0492\5\34\17\2\u0491"+
		"\u048f\3\2\2\2\u0492\u0495\3\2\2\2\u0493\u0491\3\2\2\2\u0493\u0494\3\2"+
		"\2\2\u0494\u0496\3\2\2\2\u0495\u0493\3\2\2\2\u0496\u0499\7\6\2\2\u0497"+
		"\u0498\7\u0095\2\2\u0498\u049a\5D#\2\u0499\u0497\3\2\2\2\u0499\u049a\3"+
		"\2\2\2\u049a\u049c\3\2\2\2\u049b\u048d\3\2\2\2\u049b\u049c\3\2\2\2\u049c"+
		"\u049d\3\2\2\2\u049d\u04b8\7\u00b8\2\2\u049e\u04b9\7\u00b9\2\2\u049f\u04a0"+
		"\7\u008e\2\2\u04a0\u04a3\7\u0084\2\2\u04a1\u04a4\5\u00bc_\2\u04a2\u04a4"+
		"\5l\67\2\u04a3\u04a1\3\2\2\2\u04a3\u04a2\3\2\2\2\u04a4\u04a5\3\2\2\2\u04a5"+
		"\u04a6\7\30\2\2\u04a6\u04b1\5D#\2\u04a7\u04aa\7\7\2\2\u04a8\u04ab\5\u00bc"+
		"_\2\u04a9\u04ab\5l\67\2\u04aa\u04a8\3\2\2\2\u04aa\u04a9\3\2\2\2\u04ab"+
		"\u04ac\3\2\2\2\u04ac\u04ad\7\30\2\2\u04ad\u04ae\5D#\2\u04ae\u04b0\3\2"+
		"\2\2\u04af\u04a7\3\2\2\2\u04b0\u04b3\3\2\2\2\u04b1\u04af\3\2\2\2\u04b1"+
		"\u04b2\3\2\2\2\u04b2\u04b6\3\2\2\2\u04b3\u04b1\3\2\2\2\u04b4\u04b5\7\u0095"+
		"\2\2\u04b5\u04b7\5D#\2\u04b6\u04b4\3\2\2\2\u04b6\u04b7\3\2\2\2\u04b7\u04b9"+
		"\3\2\2\2\u04b8\u049e\3\2\2\2\u04b8\u049f\3\2\2\2\u04b9M\3\2\2\2\u04ba"+
		"\u04be\7r\2\2\u04bb\u04bc\5\u00b4[\2\u04bc\u04bd\7\4\2\2\u04bd\u04bf\3"+
		"\2\2\2\u04be\u04bb\3\2\2\2\u04be\u04bf\3\2\2\2\u04bf\u04c0\3\2\2\2\u04c0"+
		"\u04c7\5\u00caf\2\u04c1\u04c2\7\b\2\2\u04c2\u04c8\5P)\2\u04c3\u04c4\7"+
		"\5\2\2\u04c4\u04c5\5P)\2\u04c5\u04c6\7\6\2\2\u04c6\u04c8\3\2\2\2\u04c7"+
		"\u04c1\3\2\2\2\u04c7\u04c3\3\2\2\2\u04c7\u04c8\3\2\2\2\u04c8O\3\2\2\2"+
		"\u04c9\u04cd\5&\24\2\u04ca\u04cd\5\u00b0Y\2\u04cb\u04cd\7\u00bd\2\2\u04cc"+
		"\u04c9\3\2\2\2\u04cc\u04ca\3\2\2\2\u04cc\u04cb\3\2\2\2\u04cdQ\3\2\2\2"+
		"\u04ce\u04d9\7y\2\2\u04cf\u04da\5\u00be`\2\u04d0\u04d1\5\u00b4[\2\u04d1"+
		"\u04d2\7\4\2\2\u04d2\u04d4\3\2\2\2\u04d3\u04d0\3\2\2\2\u04d3\u04d4\3\2"+
		"\2\2\u04d4\u04d7\3\2\2\2\u04d5\u04d8\5\u00b6\\\2\u04d6\u04d8\5\u00c2b"+
		"\2\u04d7\u04d5\3\2\2\2\u04d7\u04d6\3\2\2\2\u04d8\u04da\3\2\2\2\u04d9\u04cf"+
		"\3\2\2\2\u04d9\u04d3\3\2\2\2\u04d9\u04da\3\2\2\2\u04daS\3\2\2\2\u04db"+
		"\u04dd\5\u0084C\2\u04dc\u04db\3\2\2\2\u04dc\u04dd\3\2\2\2\u04dd\u04de"+
		"\3\2\2\2\u04de\u04e4\5X-\2\u04df\u04e0\5h\65\2\u04e0\u04e1\5X-\2\u04e1"+
		"\u04e3\3\2\2\2\u04e2\u04df\3\2\2\2\u04e3\u04e6\3\2\2\2\u04e4\u04e2\3\2"+
		"\2\2\u04e4\u04e5\3\2\2\2\u04e5\u04e8\3\2\2\2\u04e6\u04e4\3\2\2\2\u04e7"+
		"\u04e9\5\u0086D\2\u04e8\u04e7\3\2\2\2\u04e8\u04e9\3\2\2\2\u04e9\u04eb"+
		"\3\2\2\2\u04ea\u04ec\5\u0088E\2\u04eb\u04ea\3\2\2\2\u04eb\u04ec\3\2\2"+
		"\2\u04ecU\3\2\2\2\u04ed\u04f5\5`\61\2\u04ee\u04ef\5d\63\2\u04ef\u04f1"+
		"\5`\61\2\u04f0\u04f2\5f\64\2\u04f1\u04f0\3\2\2\2\u04f1\u04f2\3\2\2\2\u04f2"+
		"\u04f4\3\2\2\2\u04f3\u04ee\3\2\2\2\u04f4\u04f7\3\2\2\2\u04f5\u04f3\3\2"+
		"\2\2\u04f5\u04f6\3\2\2\2\u04f6W\3\2\2\2\u04f7\u04f5\3\2\2\2\u04f8\u04fa"+
		"\7\u0083\2\2\u04f9\u04fb\t\22\2\2\u04fa\u04f9\3\2\2\2\u04fa\u04fb\3\2"+
		"\2\2\u04fb\u04fc\3\2\2\2\u04fc\u0501\5b\62\2\u04fd\u04fe\7\7\2\2\u04fe"+
		"\u0500\5b\62\2\u04ff\u04fd\3\2\2\2\u0500\u0503\3\2\2\2\u0501\u04ff\3\2"+
		"\2\2\u0501\u0502\3\2\2\2\u0502\u0510\3\2\2\2\u0503\u0501\3\2\2\2\u0504"+
		"\u050e\7M\2\2\u0505\u050a\5`\61\2\u0506\u0507\7\7\2\2\u0507\u0509\5`\61"+
		"\2\u0508\u0506\3\2\2\2\u0509\u050c\3\2\2\2\u050a\u0508\3\2\2\2\u050a\u050b"+
		"\3\2\2\2\u050b\u050f\3\2\2\2\u050c\u050a\3\2\2\2\u050d\u050f\5V,\2\u050e"+
		"\u0505\3\2\2\2\u050e\u050d\3\2\2\2\u050f\u0511\3\2\2\2\u0510\u0504\3\2"+
		"\2\2\u0510\u0511\3\2\2\2\u0511\u0514\3\2\2\2\u0512\u0513\7\u0095\2\2\u0513"+
		"\u0515\5D#\2\u0514\u0512\3\2\2\2\u0514\u0515\3\2\2\2\u0515\u0524\3\2\2"+
		"\2\u0516\u0517\7P\2\2\u0517\u0518\7*\2\2\u0518\u051d\5D#\2\u0519\u051a"+
		"\7\7\2\2\u051a\u051c\5D#\2\u051b\u0519\3\2\2\2\u051c\u051f\3\2\2\2\u051d"+
		"\u051b\3\2\2\2\u051d\u051e\3\2\2\2\u051e\u0522\3\2\2\2\u051f\u051d\3\2"+
		"\2\2\u0520\u0521\7Q\2\2\u0521\u0523\5D#\2\u0522\u0520\3\2\2\2\u0522\u0523"+
		"\3\2\2\2\u0523\u0525\3\2\2\2\u0524\u0516\3\2\2\2\u0524\u0525\3\2\2\2\u0525"+
		"\u0534\3\2\2\2\u0526\u0527\7\u00af\2\2\u0527\u0528\5\u00d2j\2\u0528\u0529"+
		"\7#\2\2\u0529\u0531\5v<\2\u052a\u052b\7\7\2\2\u052b\u052c\5\u00d2j\2\u052c"+
		"\u052d\7#\2\2\u052d\u052e\5v<\2\u052e\u0530\3\2\2\2\u052f\u052a\3\2\2"+
		"\2\u0530\u0533\3\2\2\2\u0531\u052f\3\2\2\2\u0531\u0532\3\2\2\2\u0532\u0535"+
		"\3\2\2\2\u0533\u0531\3\2\2\2\u0534\u0526\3\2\2\2\u0534\u0535\3\2\2\2\u0535"+
		"\u0553\3\2\2\2\u0536\u0537\7\u0091\2\2\u0537\u0538\7\5\2\2\u0538\u053d"+
		"\5D#\2\u0539\u053a\7\7\2\2\u053a\u053c\5D#\2\u053b\u0539\3\2\2\2\u053c"+
		"\u053f\3\2\2\2\u053d\u053b\3\2\2\2\u053d\u053e\3\2\2\2\u053e\u0540\3\2"+
		"\2\2\u053f\u053d\3\2\2\2\u0540\u054f\7\6\2\2\u0541\u0542\7\7\2\2\u0542"+
		"\u0543\7\5\2\2\u0543\u0548\5D#\2\u0544\u0545\7\7\2\2\u0545\u0547\5D#\2"+
		"\u0546\u0544\3\2\2\2\u0547\u054a\3\2\2\2\u0548\u0546\3\2\2\2\u0548\u0549"+
		"\3\2\2\2\u0549\u054b\3\2\2\2\u054a\u0548\3\2\2\2\u054b\u054c\7\6\2\2\u054c"+
		"\u054e\3\2\2\2\u054d\u0541\3\2\2\2\u054e\u0551\3\2\2\2\u054f\u054d\3\2"+
		"\2\2\u054f\u0550\3\2\2\2\u0550\u0553\3\2\2\2\u0551\u054f\3\2\2\2\u0552"+
		"\u04f8\3\2\2\2\u0552\u0536\3\2\2\2\u0553Y\3\2\2\2\u0554\u0555\5T+\2\u0555"+
		"[\3\2\2\2\u0556\u0558\5\u0084C\2\u0557\u0556\3\2\2\2\u0557\u0558\3\2\2"+
		"\2\u0558\u0559\3\2\2\2\u0559\u055b\5X-\2\u055a\u055c\5\u0086D\2\u055b"+
		"\u055a\3\2\2\2\u055b\u055c\3\2\2\2\u055c\u055e\3\2\2\2\u055d\u055f\5\u0088"+
		"E\2\u055e\u055d\3\2\2\2\u055e\u055f\3\2\2\2\u055f]\3\2\2\2\u0560\u0562"+
		"\5\u0084C\2\u0561\u0560\3\2\2\2\u0561\u0562\3\2\2\2\u0562\u0563\3\2\2"+
		"\2\u0563\u056d\5X-\2\u0564\u0566\7\u008c\2\2\u0565\u0567\7\37\2\2\u0566"+
		"\u0565\3\2\2\2\u0566\u0567\3\2\2\2\u0567\u056b\3\2\2\2\u0568\u056b\7\\"+
		"\2\2\u0569\u056b\7F\2\2\u056a\u0564\3\2\2\2\u056a\u0568\3\2\2\2\u056a"+
		"\u0569\3\2\2\2\u056b\u056c\3\2\2\2\u056c\u056e\5X-\2\u056d\u056a\3\2\2"+
		"\2\u056e\u056f\3\2\2\2\u056f\u056d\3\2\2\2\u056f\u0570\3\2\2\2\u0570\u0572"+
		"\3\2\2\2\u0571\u0573\5\u0086D\2\u0572\u0571\3\2\2\2\u0572\u0573\3\2\2"+
		"\2\u0573\u0575\3\2\2\2\u0574\u0576\5\u0088E\2\u0575\u0574\3\2\2\2\u0575"+
		"\u0576\3\2\2\2\u0576_\3\2\2\2\u0577\u0578\5\u00b4[\2\u0578\u0579\7\4\2"+
		"\2\u0579\u057b\3\2\2\2\u057a\u0577\3\2\2\2\u057a\u057b\3\2\2\2\u057b\u057c"+
		"\3\2\2\2\u057c\u0581\5\u00b6\\\2\u057d\u057f\7#\2\2\u057e\u057d\3\2\2"+
		"\2\u057e\u057f\3\2\2\2\u057f\u0580\3\2\2\2\u0580\u0582\5\u00ceh\2\u0581"+
		"\u057e\3\2\2\2\u0581\u0582\3\2\2\2\u0582\u0588\3\2\2\2\u0583\u0584\7W"+
		"\2\2\u0584\u0585\7*\2\2\u0585\u0589\5\u00c2b\2\u0586\u0587\7h\2\2\u0587"+
		"\u0589\7W\2\2\u0588\u0583\3\2\2\2\u0588\u0586\3\2\2\2\u0588\u0589\3\2"+
		"\2\2\u0589\u05b8\3\2\2\2\u058a\u058b\5\u00b4[\2\u058b\u058c\7\4\2\2\u058c"+
		"\u058e\3\2\2\2\u058d\u058a\3\2\2\2\u058d\u058e\3\2\2\2\u058e\u058f\3\2"+
		"\2\2\u058f\u0590\5\u00dep\2\u0590\u0591\7\5\2\2\u0591\u0596\5D#\2\u0592"+
		"\u0593\7\7\2\2\u0593\u0595\5D#\2\u0594\u0592\3\2\2\2\u0595\u0598\3\2\2"+
		"\2\u0596\u0594\3\2\2\2\u0596\u0597\3\2\2\2\u0597\u0599\3\2\2\2\u0598\u0596"+
		"\3\2\2\2\u0599\u059e\7\6\2\2\u059a\u059c\7#\2\2\u059b\u059a\3\2\2\2\u059b"+
		"\u059c\3\2\2\2\u059c\u059d\3\2\2\2\u059d\u059f\5\u00ceh\2\u059e\u059b"+
		"\3\2\2\2\u059e\u059f\3\2\2\2\u059f\u05b8\3\2\2\2\u05a0\u05aa\7\5\2\2\u05a1"+
		"\u05a6\5`\61\2\u05a2\u05a3\7\7\2\2\u05a3\u05a5\5`\61\2\u05a4\u05a2\3\2"+
		"\2\2\u05a5\u05a8\3\2\2\2\u05a6\u05a4\3\2\2\2\u05a6\u05a7\3\2\2\2\u05a7"+
		"\u05ab\3\2\2\2\u05a8\u05a6\3\2\2\2\u05a9\u05ab\5V,\2\u05aa\u05a1\3\2\2"+
		"\2\u05aa\u05a9\3\2\2\2\u05ab\u05ac\3\2\2\2\u05ac\u05ad\7\6\2\2\u05ad\u05b8"+
		"\3\2\2\2\u05ae\u05af\7\5\2\2\u05af\u05b0\5T+\2\u05b0\u05b5\7\6\2\2\u05b1"+
		"\u05b3\7#\2\2\u05b2\u05b1\3\2\2\2\u05b2\u05b3\3\2\2\2\u05b3\u05b4\3\2"+
		"\2\2\u05b4\u05b6\5\u00ceh\2\u05b5\u05b2\3\2\2\2\u05b5\u05b6\3\2\2\2\u05b6"+
		"\u05b8\3\2\2\2\u05b7\u057a\3\2\2\2\u05b7\u058d\3\2\2\2\u05b7\u05a0\3\2"+
		"\2\2\u05b7\u05ae\3\2\2\2\u05b8a\3\2\2\2\u05b9\u05c6\7\t\2\2\u05ba\u05bb"+
		"\5\u00b6\\\2\u05bb\u05bc\7\4\2\2\u05bc\u05bd\7\t\2\2\u05bd\u05c6\3\2\2"+
		"\2\u05be\u05c3\5D#\2\u05bf\u05c1\7#\2\2\u05c0\u05bf\3\2\2\2\u05c0\u05c1"+
		"\3\2\2\2\u05c1\u05c2\3\2\2\2\u05c2\u05c4\5\u00acW\2\u05c3\u05c0\3\2\2"+
		"\2\u05c3\u05c4\3\2\2\2\u05c4\u05c6\3\2\2\2\u05c5\u05b9\3\2\2\2\u05c5\u05ba"+
		"\3\2\2\2\u05c5\u05be\3\2\2\2\u05c6c\3\2\2\2\u05c7\u05d5\7\7\2\2\u05c8"+
		"\u05ca\7f\2\2\u05c9\u05c8\3\2\2\2\u05c9\u05ca\3\2\2\2\u05ca\u05d1\3\2"+
		"\2\2\u05cb\u05cd\7b\2\2\u05cc\u05ce\7p\2\2\u05cd\u05cc\3\2\2\2\u05cd\u05ce"+
		"\3\2\2\2\u05ce\u05d2\3\2\2\2\u05cf\u05d2\7Y\2\2\u05d0\u05d2\7\65\2\2\u05d1"+
		"\u05cb\3\2\2\2\u05d1\u05cf\3\2\2\2\u05d1\u05d0\3\2\2\2\u05d1\u05d2\3\2"+
		"\2\2\u05d2\u05d3\3\2\2\2\u05d3\u05d5\7`\2\2\u05d4\u05c7\3\2\2\2\u05d4"+
		"\u05c9\3\2\2\2\u05d5e\3\2\2\2\u05d6\u05d7\7m\2\2\u05d7\u05e5\5D#\2\u05d8"+
		"\u05d9\7\u008f\2\2\u05d9\u05da\7\5\2\2\u05da\u05df\5\u00bc_\2\u05db\u05dc"+
		"\7\7\2\2\u05dc\u05de\5\u00bc_\2\u05dd\u05db\3\2\2\2\u05de\u05e1\3\2\2"+
		"\2\u05df\u05dd\3\2\2\2\u05df\u05e0\3\2\2\2\u05e0\u05e2\3\2\2\2\u05e1\u05df"+
		"\3\2\2\2\u05e2\u05e3\7\6\2\2\u05e3\u05e5\3\2\2\2\u05e4\u05d6\3\2\2\2\u05e4"+
		"\u05d8\3\2\2\2\u05e5g\3\2\2\2\u05e6\u05e8\7\u008c\2\2\u05e7\u05e9\7\37"+
		"\2\2\u05e8\u05e7\3\2\2\2\u05e8\u05e9\3\2\2\2\u05e9\u05ed\3\2\2\2\u05ea"+
		"\u05ed\7\\\2\2\u05eb\u05ed\7F\2\2\u05ec\u05e6\3\2\2\2\u05ec\u05ea\3\2"+
		"\2\2\u05ec\u05eb\3\2\2\2\u05edi\3\2\2\2\u05ee\u05f0\5\64\33\2\u05ef\u05ee"+
		"\3\2\2\2\u05ef\u05f0\3\2\2\2\u05f0\u05f1\3\2\2\2\u05f1\u05f4\7\u008e\2"+
		"\2\u05f2\u05f3\7n\2\2\u05f3\u05f5\t\n\2\2\u05f4\u05f2\3\2\2\2\u05f4\u05f5"+
		"\3\2\2\2\u05f5\u05f6\3\2\2\2\u05f6\u05f7\5p9\2\u05f7\u05fa\7\u0084\2\2"+
		"\u05f8\u05fb\5\u00bc_\2\u05f9\u05fb\5l\67\2\u05fa\u05f8\3\2\2\2\u05fa"+
		"\u05f9\3\2\2\2\u05fb\u05fc\3\2\2\2\u05fc\u05fd\7\b\2\2\u05fd\u0608\5D"+
		"#\2\u05fe\u0601\7\7\2\2\u05ff\u0602\5\u00bc_\2\u0600\u0602\5l\67\2\u0601"+
		"\u05ff\3\2\2\2\u0601\u0600\3\2\2\2\u0602\u0603\3\2\2\2\u0603\u0604\7\b"+
		"\2\2\u0604\u0605\5D#\2\u0605\u0607\3\2\2\2\u0606\u05fe\3\2\2\2\u0607\u060a"+
		"\3\2\2\2\u0608\u0606\3\2\2\2\u0608\u0609\3\2\2\2\u0609\u060d\3\2\2\2\u060a"+
		"\u0608\3\2\2\2\u060b\u060c\7\u0095\2\2\u060c\u060e\5D#\2\u060d\u060b\3"+
		"\2\2\2\u060d\u060e\3\2\2\2\u060ek\3\2\2\2\u060f\u0610\7\5\2\2\u0610\u0615"+
		"\5\u00bc_\2\u0611\u0612\7\7\2\2\u0612\u0614\5\u00bc_\2\u0613\u0611\3\2"+
		"\2\2\u0614\u0617\3\2\2\2\u0615\u0613\3\2\2\2\u0615\u0616\3\2\2\2\u0616"+
		"\u0618\3\2\2\2\u0617\u0615\3\2\2\2\u0618\u0619\7\6\2\2\u0619m\3\2\2\2"+
		"\u061a\u061c\5\64\33\2\u061b\u061a\3\2\2\2\u061b\u061c\3\2\2\2\u061c\u061d"+
		"\3\2\2\2\u061d\u0620\7\u008e\2\2\u061e\u061f\7n\2\2\u061f\u0621\t\n\2"+
		"\2\u0620\u061e\3\2\2\2\u0620\u0621\3\2\2\2\u0621\u0622\3\2\2\2\u0622\u0623"+
		"\5p9\2\u0623\u0626\7\u0084\2\2\u0624\u0627\5\u00bc_\2\u0625\u0627\5l\67"+
		"\2\u0626\u0624\3\2\2\2\u0626\u0625\3\2\2\2\u0627\u0628\3\2\2\2\u0628\u0629"+
		"\7\b\2\2\u0629\u0634\5D#\2\u062a\u062d\7\7\2\2\u062b\u062e\5\u00bc_\2"+
		"\u062c\u062e\5l\67\2\u062d\u062b\3\2\2\2\u062d\u062c\3\2\2\2\u062e\u062f"+
		"\3\2\2\2\u062f\u0630\7\b\2\2\u0630\u0631\5D#\2\u0631\u0633\3\2\2\2\u0632"+
		"\u062a\3\2\2\2\u0633\u0636\3\2\2\2\u0634\u0632\3\2\2\2\u0634\u0635\3\2"+
		"\2\2\u0635\u0639\3\2\2\2\u0636\u0634\3\2\2\2\u0637\u0638\7\u0095\2\2\u0638"+
		"\u063a\5D#\2\u0639\u0637\3\2\2\2\u0639\u063a\3\2\2\2\u063a\u063f\3\2\2"+
		"\2\u063b\u063d\5\u0086D\2\u063c\u063b\3\2\2\2\u063c\u063d\3\2\2\2\u063d"+
		"\u063e\3\2\2\2\u063e\u0640\5\u0088E\2\u063f\u063c\3\2\2\2\u063f\u0640"+
		"\3\2\2\2\u0640o\3\2\2\2\u0641\u0642\5\u00b4[\2\u0642\u0643\7\4\2\2\u0643"+
		"\u0645\3\2\2\2\u0644\u0641\3\2\2\2\u0644\u0645\3\2\2\2\u0645\u0646\3\2"+
		"\2\2\u0646\u0649\5\u00b6\\\2\u0647\u0648\7#\2\2\u0648\u064a\5\u00d4k\2"+
		"\u0649\u0647\3\2\2\2\u0649\u064a\3\2\2\2\u064a\u0650\3\2\2\2\u064b\u064c"+
		"\7W\2\2\u064c\u064d\7*\2\2\u064d\u0651\5\u00c2b\2\u064e\u064f\7h\2\2\u064f"+
		"\u0651\7W\2\2\u0650\u064b\3\2\2\2\u0650\u064e\3\2\2\2\u0650\u0651\3\2"+
		"\2\2\u0651q\3\2\2\2\u0652\u0654\7\u0090\2\2\u0653\u0655\5\u00b4[\2\u0654"+
		"\u0653\3\2\2\2\u0654\u0655\3\2\2\2\u0655\u0658\3\2\2\2\u0656\u0657\7]"+
		"\2\2\u0657\u0659\5\u00d6l\2\u0658\u0656\3\2\2\2\u0658\u0659\3\2\2\2\u0659"+
		"s\3\2\2\2\u065a\u065b\7\u00b3\2\2\u065b\u065c\7\5\2\2\u065c\u065d\7\u0095"+
		"\2\2\u065d\u065e\5D#\2\u065e\u065f\7\6\2\2\u065fu\3\2\2\2\u0660\u0662"+
		"\7\5\2\2\u0661\u0663\5\u00d8m\2\u0662\u0661\3\2\2\2\u0662\u0663\3\2\2"+
		"\2\u0663\u066e\3\2\2\2\u0664\u0665\7\u009a\2\2\u0665\u0666\7*\2\2\u0666"+
		"\u066b\5D#\2\u0667\u0668\7\7\2\2\u0668\u066a\5D#\2\u0669\u0667\3\2\2\2"+
		"\u066a\u066d\3\2\2\2\u066b\u0669\3\2\2\2\u066b\u066c\3\2\2\2\u066c\u066f"+
		"\3\2\2\2\u066d\u066b\3\2\2\2\u066e\u0664\3\2\2\2\u066e\u066f\3\2\2\2\u066f"+
		"\u0670\3\2\2\2\u0670\u0671\7o\2\2\u0671\u0672\7*\2\2\u0672\u0677\5\u008a"+
		"F\2\u0673\u0674\7\7\2\2\u0674\u0676\5\u008aF\2\u0675\u0673\3\2\2\2\u0676"+
		"\u0679\3\2\2\2\u0677\u0675\3\2\2\2\u0677\u0678\3\2\2\2\u0678\u067b\3\2"+
		"\2\2\u0679\u0677\3\2\2\2\u067a\u067c\5z>\2\u067b\u067a\3\2\2\2\u067b\u067c"+
		"\3\2\2\2\u067c\u067d\3\2\2\2\u067d\u067e\7\6\2\2\u067ew\3\2\2\2\u067f"+
		"\u06a1\7\u0099\2\2\u0680\u06a2\5\u00d2j\2\u0681\u0683\7\5\2\2\u0682\u0684"+
		"\5\u00d8m\2\u0683\u0682\3\2\2\2\u0683\u0684\3\2\2\2\u0684\u068f\3\2\2"+
		"\2\u0685\u0686\7\u009a\2\2\u0686\u0687\7*\2\2\u0687\u068c\5D#\2\u0688"+
		"\u0689\7\7\2\2\u0689\u068b\5D#\2\u068a\u0688\3\2\2\2\u068b\u068e\3\2\2"+
		"\2\u068c\u068a\3\2\2\2\u068c\u068d\3\2\2\2\u068d\u0690\3\2\2\2\u068e\u068c"+
		"\3\2\2\2\u068f\u0685\3\2\2\2\u068f\u0690\3\2\2\2\u0690\u069b\3\2\2\2\u0691"+
		"\u0692\7o\2\2\u0692\u0693\7*\2\2\u0693\u0698\5\u008aF\2\u0694\u0695\7"+
		"\7\2\2\u0695\u0697\5\u008aF\2\u0696\u0694\3\2\2\2\u0697\u069a\3\2\2\2"+
		"\u0698\u0696\3\2\2\2\u0698\u0699\3\2\2\2\u0699\u069c\3\2\2\2\u069a\u0698"+
		"\3\2\2\2\u069b\u0691\3\2\2\2\u069b\u069c\3\2\2\2\u069c\u069e\3\2\2\2\u069d"+
		"\u069f\5z>\2\u069e\u069d\3\2\2\2\u069e\u069f\3\2\2\2\u069f\u06a0\3\2\2"+
		"\2\u06a0\u06a2\7\6\2\2\u06a1\u0680\3\2\2\2\u06a1\u0681\3\2\2\2\u06a2y"+
		"\3\2\2\2\u06a3\u06ab\5|?\2\u06a4\u06a5\7\u00b5\2\2\u06a5\u06a6\7g\2\2"+
		"\u06a6\u06ac\7\u00b7\2\2\u06a7\u06a8\7\u009e\2\2\u06a8\u06ac\7\u0080\2"+
		"\2\u06a9\u06ac\7P\2\2\u06aa\u06ac\7\u00b6\2\2\u06ab\u06a4\3\2\2\2\u06ab"+
		"\u06a7\3\2\2\2\u06ab\u06a9\3\2\2\2\u06ab\u06aa\3\2\2\2\u06ab\u06ac\3\2"+
		"\2\2\u06ac{\3\2\2\2\u06ad\u06b4\t\23\2\2\u06ae\u06b5\5\u0092J\2\u06af"+
		"\u06b0\7)\2\2\u06b0\u06b1\5\u008eH\2\u06b1\u06b2\7\"\2\2\u06b2\u06b3\5"+
		"\u0090I\2\u06b3\u06b5\3\2\2\2\u06b4\u06ae\3\2\2\2\u06b4\u06af\3\2\2\2"+
		"\u06b5}\3\2\2\2\u06b6\u06b7\5\u00dan\2\u06b7\u06c1\7\5\2\2\u06b8\u06bd"+
		"\5D#\2\u06b9\u06ba\7\7\2\2\u06ba\u06bc\5D#\2\u06bb\u06b9\3\2\2\2\u06bc"+
		"\u06bf\3\2\2\2\u06bd\u06bb\3\2\2\2\u06bd\u06be\3\2\2\2\u06be\u06c2\3\2"+
		"\2\2\u06bf\u06bd\3\2\2\2\u06c0\u06c2\7\t\2\2\u06c1\u06b8\3\2\2\2\u06c1"+
		"\u06c0\3\2\2\2\u06c2\u06c3\3\2\2\2\u06c3\u06c4\7\6\2\2\u06c4\177\3\2\2"+
		"\2\u06c5\u06c6\5\u00dco\2\u06c6\u06d3\7\5\2\2\u06c7\u06c9\7@\2\2\u06c8"+
		"\u06c7\3\2\2\2\u06c8\u06c9\3\2\2\2\u06c9\u06ca\3\2\2\2\u06ca\u06cf\5D"+
		"#\2\u06cb\u06cc\7\7\2\2\u06cc\u06ce\5D#\2\u06cd\u06cb\3\2\2\2\u06ce\u06d1"+
		"\3\2\2\2\u06cf\u06cd\3\2\2\2\u06cf\u06d0\3\2\2\2\u06d0\u06d4\3\2\2\2\u06d1"+
		"\u06cf\3\2\2\2\u06d2\u06d4\7\t\2\2\u06d3\u06c8\3\2\2\2\u06d3\u06d2\3\2"+
		"\2\2\u06d3\u06d4\3\2\2\2\u06d4\u06d5\3\2\2\2\u06d5\u06d7\7\6\2\2\u06d6"+
		"\u06d8\5t;\2\u06d7\u06d6\3\2\2\2\u06d7\u06d8\3\2\2\2\u06d8\u0081\3\2\2"+
		"\2\u06d9\u06da\5\u0094K\2\u06da\u06e4\7\5\2\2\u06db\u06e0\5D#\2\u06dc"+
		"\u06dd\7\7\2\2\u06dd\u06df\5D#\2\u06de\u06dc\3\2\2\2\u06df\u06e2\3\2\2"+
		"\2\u06e0\u06de\3\2\2\2\u06e0\u06e1\3\2\2\2\u06e1\u06e5\3\2\2\2\u06e2\u06e0"+
		"\3\2\2\2\u06e3\u06e5\7\t\2\2\u06e4\u06db\3\2\2\2\u06e4\u06e3\3\2\2\2\u06e4"+
		"\u06e5\3\2\2\2\u06e5\u06e6\3\2\2\2\u06e6\u06e8\7\6\2\2\u06e7\u06e9\5t"+
		";\2\u06e8\u06e7\3\2\2\2\u06e8\u06e9\3\2\2\2\u06e9\u06ea\3\2\2\2\u06ea"+
		"\u06ed\7\u0099\2\2\u06eb\u06ee\5v<\2\u06ec\u06ee\5\u00d2j\2\u06ed\u06eb"+
		"\3\2\2\2\u06ed\u06ec\3\2\2\2\u06ee\u0083\3\2\2\2\u06ef\u06f1\7\u0096\2"+
		"\2\u06f0\u06f2\7v\2\2\u06f1\u06f0\3\2\2\2\u06f1\u06f2\3\2\2\2\u06f2\u06f3"+
		"\3\2\2\2\u06f3\u06f8\5:\36\2\u06f4\u06f5\7\7\2\2\u06f5\u06f7\5:\36\2\u06f6"+
		"\u06f4\3\2\2\2\u06f7\u06fa\3\2\2\2\u06f8\u06f6\3\2\2\2\u06f8\u06f9\3\2"+
		"\2\2\u06f9\u0085\3\2\2\2\u06fa\u06f8\3\2\2\2\u06fb\u06fc\7o\2\2\u06fc"+
		"\u06fd\7*\2\2\u06fd\u0702\5\u008aF\2\u06fe\u06ff\7\7\2\2\u06ff\u0701\5"+
		"\u008aF\2\u0700\u06fe\3\2\2\2\u0701\u0704\3\2\2\2\u0702\u0700\3\2\2\2"+
		"\u0702\u0703\3\2\2\2\u0703\u0087\3\2\2\2\u0704\u0702\3\2\2\2\u0705\u0706"+
		"\7d\2\2\u0706\u0709\5D#\2\u0707\u0708\t\24\2\2\u0708\u070a\5D#\2\u0709"+
		"\u0707\3\2\2\2\u0709\u070a\3\2\2\2\u070a\u0089\3\2\2\2\u070b\u070e\5D"+
		"#\2\u070c\u070d\7/\2\2\u070d\u070f\5\u00be`\2\u070e\u070c\3\2\2\2\u070e"+
		"\u070f\3\2\2\2\u070f\u0711\3\2\2\2\u0710\u0712\5\u008cG\2\u0711\u0710"+
		"\3\2\2\2\u0711\u0712\3\2\2\2\u0712\u0715\3\2\2\2\u0713\u0714\7\u00b0\2"+
		"\2\u0714\u0716\t\25\2\2\u0715\u0713\3\2\2\2\u0715\u0716\3\2\2\2\u0716"+
		"\u008b\3\2\2\2\u0717\u0718\t\26\2\2\u0718\u008d\3\2\2\2\u0719\u071a\5"+
		"D#\2\u071a\u071b\7\u009c\2\2\u071b\u0724\3\2\2\2\u071c\u071d\5D#\2\u071d"+
		"\u071e\7\u009f\2\2\u071e\u0724\3\2\2\2\u071f\u0720\7\u009e\2\2\u0720\u0724"+
		"\7\u0080\2\2\u0721\u0722\7\u009d\2\2\u0722\u0724\7\u009c\2\2\u0723\u0719"+
		"\3\2\2\2\u0723\u071c\3\2\2\2\u0723\u071f\3\2\2\2\u0723\u0721\3\2\2\2\u0724"+
		"\u008f\3\2\2\2\u0725\u0726\5D#\2\u0726\u0727\7\u009c\2\2\u0727\u0730\3"+
		"\2\2\2\u0728\u0729\5D#\2\u0729\u072a\7\u009f\2\2\u072a\u0730\3\2\2\2\u072b"+
		"\u072c\7\u009e\2\2\u072c\u0730\7\u0080\2\2\u072d\u072e\7\u009d\2\2\u072e"+
		"\u0730\7\u009f\2\2\u072f\u0725\3\2\2\2\u072f\u0728\3\2\2\2\u072f\u072b"+
		"\3\2\2\2\u072f\u072d\3\2\2\2\u0730\u0091\3\2\2\2\u0731\u0732\5D#\2\u0732"+
		"\u0733\7\u009c\2\2\u0733\u0739\3\2\2\2\u0734\u0735\7\u009d\2\2\u0735\u0739"+
		"\7\u009c\2\2\u0736\u0737\7\u009e\2\2\u0737\u0739\7\u0080\2\2\u0738\u0731"+
		"\3\2\2\2\u0738\u0734\3\2\2\2\u0738\u0736\3\2\2\2\u0739\u0093\3\2\2\2\u073a"+
		"\u073b\t\27\2\2\u073b\u073c\7\5\2\2\u073c\u073d\5D#\2\u073d\u073e\7\6"+
		"\2\2\u073e\u073f\7\u0099\2\2\u073f\u0741\7\5\2\2\u0740\u0742\5\u009aN"+
		"\2\u0741\u0740\3\2\2\2\u0741\u0742\3\2\2\2\u0742\u0743\3\2\2\2\u0743\u0745"+
		"\5\u009eP\2\u0744\u0746\5|?\2\u0745\u0744\3\2\2\2\u0745\u0746\3\2\2\2"+
		"\u0746\u0747\3\2\2\2\u0747\u0748\7\6\2\2\u0748\u0790\3\2\2\2\u0749\u074a"+
		"\t\30\2\2\u074a\u074b\7\5\2\2\u074b\u074c\7\6\2\2\u074c\u074d\7\u0099"+
		"\2\2\u074d\u074f\7\5\2\2\u074e\u0750\5\u009aN\2\u074f\u074e\3\2\2\2\u074f"+
		"\u0750\3\2\2\2\u0750\u0752\3\2\2\2\u0751\u0753\5\u009cO\2\u0752\u0751"+
		"\3\2\2\2\u0752\u0753\3\2\2\2\u0753\u0754\3\2\2\2\u0754\u0790\7\6\2\2\u0755"+
		"\u0756\t\31\2\2\u0756\u0757\7\5\2\2\u0757\u0758\7\6\2\2\u0758\u0759\7"+
		"\u0099\2\2\u0759\u075b\7\5\2\2\u075a\u075c\5\u009aN\2\u075b\u075a\3\2"+
		"\2\2\u075b\u075c\3\2\2\2\u075c\u075d\3\2\2\2\u075d\u075e\5\u009eP\2\u075e"+
		"\u075f\7\6\2\2\u075f\u0790\3\2\2\2\u0760\u0761\t\32\2\2\u0761\u0762\7"+
		"\5\2\2\u0762\u0764\5D#\2\u0763\u0765\5\u0096L\2\u0764\u0763\3\2\2\2\u0764"+
		"\u0765\3\2\2\2\u0765\u0767\3\2\2\2\u0766\u0768\5\u0098M\2\u0767\u0766"+
		"\3\2\2\2\u0767\u0768\3\2\2\2\u0768\u0769\3\2\2\2\u0769\u076a\7\6\2\2\u076a"+
		"\u076b\7\u0099\2\2\u076b\u076d\7\5\2\2\u076c\u076e\5\u009aN\2\u076d\u076c"+
		"\3\2\2\2\u076d\u076e\3\2\2\2\u076e\u076f\3\2\2\2\u076f\u0770\5\u009eP"+
		"\2\u0770\u0771\7\6\2\2\u0771\u0790\3\2\2\2\u0772\u0773\7\u00a5\2\2\u0773"+
		"\u0774\7\5\2\2\u0774\u0775\5D#\2\u0775\u0776\7\7\2\2\u0776\u0777\5&\24"+
		"\2\u0777\u0778\7\6\2\2\u0778\u0779\7\u0099\2\2\u0779\u077b\7\5\2\2\u077a"+
		"\u077c\5\u009aN\2\u077b\u077a\3\2\2\2\u077b\u077c\3\2\2\2\u077c\u077d"+
		"\3\2\2\2\u077d\u077f\5\u009eP\2\u077e\u0780\5|?\2\u077f\u077e\3\2\2\2"+
		"\u077f\u0780\3\2\2\2\u0780\u0781\3\2\2\2\u0781\u0782\7\6\2\2\u0782\u0790"+
		"\3\2\2\2\u0783\u0784\7\u00a6\2\2\u0784\u0785\7\5\2\2\u0785\u0786\5D#\2"+
		"\u0786\u0787\7\6\2\2\u0787\u0788\7\u0099\2\2\u0788\u078a\7\5\2\2\u0789"+
		"\u078b\5\u009aN\2\u078a\u0789\3\2\2\2\u078a\u078b\3\2\2\2\u078b\u078c"+
		"\3\2\2\2\u078c\u078d\5\u009eP\2\u078d\u078e\7\6\2\2\u078e\u0790\3\2\2"+
		"\2\u078f\u073a\3\2\2\2\u078f\u0749\3\2\2\2\u078f\u0755\3\2\2\2\u078f\u0760"+
		"\3\2\2\2\u078f\u0772\3\2\2\2\u078f\u0783\3\2\2\2\u0790\u0095\3\2\2\2\u0791"+
		"\u0792\7\7\2\2\u0792\u0793\5&\24\2\u0793\u0097\3\2\2\2\u0794\u0795\7\7"+
		"\2\2\u0795\u0796\5&\24\2\u0796\u0099\3\2\2\2\u0797\u0798\7\u009a\2\2\u0798"+
		"\u079a\7*\2\2\u0799\u079b\5D#\2\u079a\u0799\3\2\2\2\u079b\u079c\3\2\2"+
		"\2\u079c\u079a\3\2\2\2\u079c\u079d\3\2\2\2\u079d\u009b\3\2\2\2\u079e\u079f"+
		"\7o\2\2\u079f\u07a1\7*\2\2\u07a0\u07a2\5D#\2\u07a1\u07a0\3\2\2\2\u07a2"+
		"\u07a3\3\2\2\2\u07a3\u07a1\3\2\2\2\u07a3\u07a4\3\2\2\2\u07a4\u009d\3\2"+
		"\2\2\u07a5\u07a6\7o\2\2\u07a6\u07a7\7*\2\2\u07a7\u07a8\5\u009eP\2\u07a8"+
		"\u009f\3\2\2\2\u07a9\u07ab\5D#\2\u07aa\u07ac\5\u008cG\2\u07ab\u07aa\3"+
		"\2\2\2\u07ab\u07ac\3\2\2\2\u07ac\u07b4\3\2\2\2\u07ad\u07ae\7\7\2\2\u07ae"+
		"\u07b0\5D#\2\u07af\u07b1\5\u008cG\2\u07b0\u07af\3\2\2\2\u07b0\u07b1\3"+
		"\2\2\2\u07b1\u07b3\3\2\2\2\u07b2\u07ad\3\2\2\2\u07b3\u07b6\3\2\2\2\u07b4"+
		"\u07b2\3\2\2\2\u07b4\u07b5\3\2\2\2\u07b5\u00a1\3\2\2\2\u07b6\u07b4\3\2"+
		"\2\2\u07b7\u07b8\5T+\2\u07b8\u00a3\3\2\2\2\u07b9\u07ba\5T+\2\u07ba\u00a5"+
		"\3\2\2\2\u07bb\u07bc\t\33\2\2\u07bc\u00a7\3\2\2\2\u07bd\u07be\7\u00bd"+
		"\2\2\u07be\u00a9\3\2\2\2\u07bf\u07c2\5D#\2\u07c0\u07c2\5 \21\2\u07c1\u07bf"+
		"\3\2\2\2\u07c1\u07c0\3\2\2\2\u07c2\u00ab\3\2\2\2\u07c3\u07c4\t\34\2\2"+
		"\u07c4\u00ad\3\2\2\2\u07c5\u07c6\t\35\2\2\u07c6\u00af\3\2\2\2\u07c7\u07c8"+
		"\5\u00e0q\2\u07c8\u00b1\3\2\2\2\u07c9\u07ca\5\u00e0q\2\u07ca\u00b3\3\2"+
		"\2\2\u07cb\u07cc\5\u00e0q\2\u07cc\u00b5\3\2\2\2\u07cd\u07ce\5\u00e0q\2"+
		"\u07ce\u00b7\3\2\2\2\u07cf\u07d0\5\u00e0q\2\u07d0\u00b9\3\2\2\2\u07d1"+
		"\u07d2\5\u00e0q\2\u07d2\u00bb\3\2\2\2\u07d3\u07d4\5\u00e0q\2\u07d4\u00bd"+
		"\3\2\2\2\u07d5\u07d6\5\u00e0q\2\u07d6\u00bf\3\2\2\2\u07d7\u07d8\5\u00e0"+
		"q\2\u07d8\u00c1\3\2\2\2\u07d9\u07da\5\u00e0q\2\u07da\u00c3\3\2\2\2\u07db"+
		"\u07dc\5\u00e0q\2\u07dc\u00c5\3\2\2\2\u07dd\u07de\5\u00e0q\2\u07de\u00c7"+
		"\3\2\2\2\u07df\u07e0\5\u00e0q\2\u07e0\u00c9\3\2\2\2\u07e1\u07e2\5\u00e0"+
		"q\2\u07e2\u00cb\3\2\2\2\u07e3\u07e4\5\u00e0q\2\u07e4\u00cd\3\2\2\2\u07e5"+
		"\u07e6\5\u00e0q\2\u07e6\u00cf\3\2\2\2\u07e7\u07e8\5\u00e0q\2\u07e8\u00d1"+
		"\3\2\2\2\u07e9\u07ea\5\u00e0q\2\u07ea\u00d3\3\2\2\2\u07eb\u07ec\5\u00e0"+
		"q\2\u07ec\u00d5\3\2\2\2\u07ed\u07ee\5\u00e0q\2\u07ee\u00d7\3\2\2\2\u07ef"+
		"\u07f0\5\u00e0q\2\u07f0\u00d9\3\2\2\2\u07f1\u07f2\5\u00e0q\2\u07f2\u00db"+
		"\3\2\2\2\u07f3\u07f4\5\u00e0q\2\u07f4\u00dd\3\2\2\2\u07f5\u07f6\5\u00e0"+
		"q\2\u07f6\u00df\3\2\2\2\u07f7\u07ff\7\u00ba\2\2\u07f8\u07ff\5\u00aeX\2"+
		"\u07f9\u07ff\7\u00bd\2\2\u07fa\u07fb\7\5\2\2\u07fb\u07fc\5\u00e0q\2\u07fc"+
		"\u07fd\7\6\2\2\u07fd\u07ff\3\2\2\2\u07fe\u07f7\3\2\2\2\u07fe\u07f8\3\2"+
		"\2\2\u07fe\u07f9\3\2\2\2\u07fe\u07fa\3\2\2\2\u07ff\u00e1\3\2\2\2\u0123"+
		"\u00e4\u00e6\u00f1\u00f8\u00fd\u0103\u0109\u010b\u0125\u012c\u0133\u0139"+
		"\u013d\u0140\u0147\u014a\u014e\u0156\u015a\u015c\u0160\u0164\u0168\u016b"+
		"\u0172\u0178\u017e\u0183\u018e\u0194\u0198\u019c\u019f\u01a3\u01a9\u01ae"+
		"\u01b7\u01be\u01c4\u01c8\u01cc\u01d1\u01d7\u01e3\u01e7\u01ec\u01ef\u01f2"+
		"\u01f7\u01fa\u0208\u020f\u0216\u0218\u021b\u0221\u0226\u022e\u0233\u0242"+
		"\u0248\u0252\u0257\u0261\u0265\u0267\u026b\u0270\u0272\u027a\u0280\u0285"+
		"\u028c\u0297\u029a\u029c\u02a3\u02a7\u02ae\u02b4\u02ba\u02c0\u02c5\u02ce"+
		"\u02d3\u02de\u02e3\u02ee\u02f3\u02f7\u0307\u0311\u0316\u031e\u032a\u032f"+
		"\u0337\u033e\u0341\u0348\u034b\u034e\u0352\u035a\u035f\u0369\u036e\u0377"+
		"\u037e\u0382\u0386\u0389\u0391\u039e\u03a1\u03a9\u03b2\u03b6\u03bb\u03d9"+
		"\u03e5\u03ea\u03f6\u03fc\u0403\u0407\u0411\u0414\u041a\u0420\u0429\u042c"+
		"\u0430\u0432\u0434\u043d\u0444\u044b\u0451\u0456\u045e\u0463\u046c\u0477"+
		"\u047e\u0482\u0485\u0489\u0493\u0499\u049b\u04a3\u04aa\u04b1\u04b6\u04b8"+
		"\u04be\u04c7\u04cc\u04d3\u04d7\u04d9\u04dc\u04e4\u04e8\u04eb\u04f1\u04f5"+
		"\u04fa\u0501\u050a\u050e\u0510\u0514\u051d\u0522\u0524\u0531\u0534\u053d"+
		"\u0548\u054f\u0552\u0557\u055b\u055e\u0561\u0566\u056a\u056f\u0572\u0575"+
		"\u057a\u057e\u0581\u0588\u058d\u0596\u059b\u059e\u05a6\u05aa\u05b2\u05b5"+
		"\u05b7\u05c0\u05c3\u05c5\u05c9\u05cd\u05d1\u05d4\u05df\u05e4\u05e8\u05ec"+
		"\u05ef\u05f4\u05fa\u0601\u0608\u060d\u0615\u061b\u0620\u0626\u062d\u0634"+
		"\u0639\u063c\u063f\u0644\u0649\u0650\u0654\u0658\u0662\u066b\u066e\u0677"+
		"\u067b\u0683\u068c\u068f\u0698\u069b\u069e\u06a1\u06ab\u06b4\u06bd\u06c1"+
		"\u06c8\u06cf\u06d3\u06d7\u06e0\u06e4\u06e8\u06ed\u06f1\u06f8\u0702\u0709"+
		"\u070e\u0711\u0715\u0723\u072f\u0738\u0741\u0745\u074f\u0752\u075b\u0764"+
		"\u0767\u076d\u077b\u077f\u078a\u078f\u079c\u07a3\u07ab\u07b0\u07b4\u07c1"+
		"\u07fe";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}