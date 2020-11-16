// Generated from c:\Users\seosal\source\repos\Koralium\new\Koralium\netcore\src\Koralium.SqlParser.ANTLR\ANTLR\KoraliumParser.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class KoraliumParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		SCOL=1, DOT=2, OPEN_PAR=3, CLOSE_PAR=4, COMMA=5, ASSIGN=6, STAR=7, PLUS=8, 
		MINUS=9, TILDE=10, PIPE2=11, DIV=12, MOD=13, LT2=14, GT2=15, AMP=16, PIPE=17, 
		LT=18, LT_EQ=19, GT=20, GT_EQ=21, EQ=22, NOT_EQ1=23, NOT_EQ2=24, NLT=25, 
		NGT=26, XOR=27, EXCLAMATION=28, SELECT=29, DISTINCT=30, FROM=31, AS=32, 
		NULL=33, TRUE=34, FALSE=35, WHERE=36, AND=37, OR=38, IS=39, NOT=40, LIKE=41, 
		GROUP=42, BY=43, HAVING=44, IN=45, ORDER=46, ASC=47, DESC=48, LIMIT=49, 
		OFFSET=50, SET=51, CONTAINS=52, SPACES=53, IDENTIFIER=54, COLUMN_IDENTIFIER=55, 
		STRING_LITERAL=56, VARIABLE_ID=57, NUMERIC_LITERAL=58;
	public static final int
		RULE_parse = 0, RULE_statements_list = 1, RULE_sql_statement = 2, RULE_set_variable_statement = 3, 
		RULE_select_statement = 4, RULE_order_by_clause = 5, RULE_order_by_element = 6, 
		RULE_having_clause = 7, RULE_from_clause = 8, RULE_table_name = 9, RULE_subquery = 10, 
		RULE_orderby_subquery = 11, RULE_group_subquery = 12, RULE_variable_reference = 13, 
		RULE_select_expression = 14, RULE_where_clause = 15, RULE_groupby_clause = 16, 
		RULE_groupby_element = 17, RULE_boolean_expression = 18, RULE_predicate = 19, 
		RULE_is_null_predicate = 20, RULE_search_expression = 21, RULE_in_expression = 22, 
		RULE_like_expression = 23, RULE_in_left_scalar = 24, RULE_boolean_comparison_expression = 25, 
		RULE_boolean_comparison_type = 26, RULE_boolean_binary_type = 27, RULE_column_alias = 28, 
		RULE_scalar_expression2 = 29, RULE_scalar_expression = 30, RULE_error = 31, 
		RULE_binary_expression = 32, RULE_binary_operation_type = 33, RULE_function_call = 34, 
		RULE_column_reference = 35, RULE_literal_value = 36, RULE_column_name = 37, 
		RULE_function_name = 38, RULE_table_alias = 39, RULE_any_name = 40;
	private static String[] makeRuleNames() {
		return new String[] {
			"parse", "statements_list", "sql_statement", "set_variable_statement", 
			"select_statement", "order_by_clause", "order_by_element", "having_clause", 
			"from_clause", "table_name", "subquery", "orderby_subquery", "group_subquery", 
			"variable_reference", "select_expression", "where_clause", "groupby_clause", 
			"groupby_element", "boolean_expression", "predicate", "is_null_predicate", 
			"search_expression", "in_expression", "like_expression", "in_left_scalar", 
			"boolean_comparison_expression", "boolean_comparison_type", "boolean_binary_type", 
			"column_alias", "scalar_expression2", "scalar_expression", "error", "binary_expression", 
			"binary_operation_type", "function_call", "column_reference", "literal_value", 
			"column_name", "function_name", "table_alias", "any_name"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "';'", "'.'", "'('", "')'", "','", "'='", "'*'", "'+'", "'-'", 
			"'~'", "'||'", "'/'", "'%'", "'<<'", "'>>'", "'&'", "'|'", "'<'", "'<='", 
			"'>'", "'>='", "'=='", "'!='", "'<>'", "'!<'", "'!>'", "'^'", "'!'", 
			"'SELECT'", "'DISTINCT'", "'FROM'", "'AS'", "'NULL'", "'TRUE'", "'FALSE'", 
			"'WHERE'", "'AND'", "'OR'", "'IS'", "'NOT'", "'LIKE'", "'GROUP'", "'BY'", 
			"'HAVING'", "'IN'", "'ORDER'", "'ASC'", "'DESC'", "'LIMIT'", "'OFFSET'", 
			"'SET'", "'CONTAINS'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SCOL", "DOT", "OPEN_PAR", "CLOSE_PAR", "COMMA", "ASSIGN", "STAR", 
			"PLUS", "MINUS", "TILDE", "PIPE2", "DIV", "MOD", "LT2", "GT2", "AMP", 
			"PIPE", "LT", "LT_EQ", "GT", "GT_EQ", "EQ", "NOT_EQ1", "NOT_EQ2", "NLT", 
			"NGT", "XOR", "EXCLAMATION", "SELECT", "DISTINCT", "FROM", "AS", "NULL", 
			"TRUE", "FALSE", "WHERE", "AND", "OR", "IS", "NOT", "LIKE", "GROUP", 
			"BY", "HAVING", "IN", "ORDER", "ASC", "DESC", "LIMIT", "OFFSET", "SET", 
			"CONTAINS", "SPACES", "IDENTIFIER", "COLUMN_IDENTIFIER", "STRING_LITERAL", 
			"VARIABLE_ID", "NUMERIC_LITERAL"
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
	public String getGrammarFileName() { return "KoraliumParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public KoraliumParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ParseContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(KoraliumParser.EOF, 0); }
		public List<Statements_listContext> statements_list() {
			return getRuleContexts(Statements_listContext.class);
		}
		public Statements_listContext statements_list(int i) {
			return getRuleContext(Statements_listContext.class,i);
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
			setState(85);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << SCOL) | (1L << SELECT) | (1L << SET))) != 0)) {
				{
				{
				setState(82);
				statements_list();
				}
				}
				setState(87);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(88);
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

	public static class Statements_listContext extends ParserRuleContext {
		public List<Sql_statementContext> sql_statement() {
			return getRuleContexts(Sql_statementContext.class);
		}
		public Sql_statementContext sql_statement(int i) {
			return getRuleContext(Sql_statementContext.class,i);
		}
		public List<TerminalNode> SCOL() { return getTokens(KoraliumParser.SCOL); }
		public TerminalNode SCOL(int i) {
			return getToken(KoraliumParser.SCOL, i);
		}
		public Statements_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statements_list; }
	}

	public final Statements_listContext statements_list() throws RecognitionException {
		Statements_listContext _localctx = new Statements_listContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_statements_list);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(93);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SCOL) {
				{
				{
				setState(90);
				match(SCOL);
				}
				}
				setState(95);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(96);
			sql_statement();
			setState(105);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(98); 
					_errHandler.sync(this);
					_la = _input.LA(1);
					do {
						{
						{
						setState(97);
						match(SCOL);
						}
						}
						setState(100); 
						_errHandler.sync(this);
						_la = _input.LA(1);
					} while ( _la==SCOL );
					setState(102);
					sql_statement();
					}
					} 
				}
				setState(107);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
			}
			setState(111);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(108);
					match(SCOL);
					}
					} 
				}
				setState(113);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
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

	public static class Sql_statementContext extends ParserRuleContext {
		public Set_variable_statementContext set_variable_statement() {
			return getRuleContext(Set_variable_statementContext.class,0);
		}
		public Select_statementContext select_statement() {
			return getRuleContext(Select_statementContext.class,0);
		}
		public Sql_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sql_statement; }
	}

	public final Sql_statementContext sql_statement() throws RecognitionException {
		Sql_statementContext _localctx = new Sql_statementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_sql_statement);
		try {
			setState(116);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SET:
				enterOuterAlt(_localctx, 1);
				{
				setState(114);
				set_variable_statement();
				}
				break;
			case SELECT:
				enterOuterAlt(_localctx, 2);
				{
				setState(115);
				select_statement();
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

	public static class Set_variable_statementContext extends ParserRuleContext {
		public TerminalNode SET() { return getToken(KoraliumParser.SET, 0); }
		public Variable_referenceContext variable_reference() {
			return getRuleContext(Variable_referenceContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(KoraliumParser.ASSIGN, 0); }
		public Scalar_expressionContext scalar_expression() {
			return getRuleContext(Scalar_expressionContext.class,0);
		}
		public Set_variable_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_set_variable_statement; }
	}

	public final Set_variable_statementContext set_variable_statement() throws RecognitionException {
		Set_variable_statementContext _localctx = new Set_variable_statementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_set_variable_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(118);
			match(SET);
			setState(119);
			variable_reference();
			setState(120);
			match(ASSIGN);
			setState(121);
			scalar_expression(0);
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

	public static class Select_statementContext extends ParserRuleContext {
		public Scalar_expressionContext limit;
		public Scalar_expressionContext offset;
		public TerminalNode SELECT() { return getToken(KoraliumParser.SELECT, 0); }
		public List<Select_expressionContext> select_expression() {
			return getRuleContexts(Select_expressionContext.class);
		}
		public Select_expressionContext select_expression(int i) {
			return getRuleContext(Select_expressionContext.class,i);
		}
		public TerminalNode DISTINCT() { return getToken(KoraliumParser.DISTINCT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(KoraliumParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(KoraliumParser.COMMA, i);
		}
		public TerminalNode FROM() { return getToken(KoraliumParser.FROM, 0); }
		public From_clauseContext from_clause() {
			return getRuleContext(From_clauseContext.class,0);
		}
		public TerminalNode ORDER() { return getToken(KoraliumParser.ORDER, 0); }
		public List<TerminalNode> BY() { return getTokens(KoraliumParser.BY); }
		public TerminalNode BY(int i) {
			return getToken(KoraliumParser.BY, i);
		}
		public Order_by_clauseContext order_by_clause() {
			return getRuleContext(Order_by_clauseContext.class,0);
		}
		public TerminalNode LIMIT() { return getToken(KoraliumParser.LIMIT, 0); }
		public TerminalNode OFFSET() { return getToken(KoraliumParser.OFFSET, 0); }
		public List<Scalar_expressionContext> scalar_expression() {
			return getRuleContexts(Scalar_expressionContext.class);
		}
		public Scalar_expressionContext scalar_expression(int i) {
			return getRuleContext(Scalar_expressionContext.class,i);
		}
		public TerminalNode WHERE() { return getToken(KoraliumParser.WHERE, 0); }
		public Where_clauseContext where_clause() {
			return getRuleContext(Where_clauseContext.class,0);
		}
		public TerminalNode GROUP() { return getToken(KoraliumParser.GROUP, 0); }
		public Groupby_clauseContext groupby_clause() {
			return getRuleContext(Groupby_clauseContext.class,0);
		}
		public TerminalNode HAVING() { return getToken(KoraliumParser.HAVING, 0); }
		public Having_clauseContext having_clause() {
			return getRuleContext(Having_clauseContext.class,0);
		}
		public Select_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select_statement; }
	}

	public final Select_statementContext select_statement() throws RecognitionException {
		Select_statementContext _localctx = new Select_statementContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_select_statement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(123);
			match(SELECT);
			setState(125);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==DISTINCT) {
				{
				setState(124);
				match(DISTINCT);
				}
			}

			setState(127);
			select_expression();
			setState(132);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(128);
				match(COMMA);
				setState(129);
				select_expression();
				}
				}
				setState(134);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(150);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==FROM) {
				{
				setState(135);
				match(FROM);
				setState(136);
				from_clause();
				setState(139);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(137);
					match(WHERE);
					setState(138);
					where_clause();
					}
				}

				setState(144);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==GROUP) {
					{
					setState(141);
					match(GROUP);
					setState(142);
					match(BY);
					setState(143);
					groupby_clause();
					}
				}

				setState(148);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==HAVING) {
					{
					setState(146);
					match(HAVING);
					setState(147);
					having_clause();
					}
				}

				}
			}

			setState(155);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDER) {
				{
				setState(152);
				match(ORDER);
				setState(153);
				match(BY);
				setState(154);
				order_by_clause();
				}
			}

			setState(159);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(157);
				match(LIMIT);
				setState(158);
				((Select_statementContext)_localctx).limit = scalar_expression(0);
				}
			}

			setState(163);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OFFSET) {
				{
				setState(161);
				match(OFFSET);
				setState(162);
				((Select_statementContext)_localctx).offset = scalar_expression(0);
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

	public static class Order_by_clauseContext extends ParserRuleContext {
		public List<Order_by_elementContext> order_by_element() {
			return getRuleContexts(Order_by_elementContext.class);
		}
		public Order_by_elementContext order_by_element(int i) {
			return getRuleContext(Order_by_elementContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(KoraliumParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(KoraliumParser.COMMA, i);
		}
		public Order_by_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_clause; }
	}

	public final Order_by_clauseContext order_by_clause() throws RecognitionException {
		Order_by_clauseContext _localctx = new Order_by_clauseContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_order_by_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(165);
			order_by_element();
			setState(170);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(166);
				match(COMMA);
				setState(167);
				order_by_element();
				}
				}
				setState(172);
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

	public static class Order_by_elementContext extends ParserRuleContext {
		public Scalar_expressionContext scalar;
		public Orderby_subqueryContext query;
		public Token order;
		public Scalar_expressionContext scalar_expression() {
			return getRuleContext(Scalar_expressionContext.class,0);
		}
		public Orderby_subqueryContext orderby_subquery() {
			return getRuleContext(Orderby_subqueryContext.class,0);
		}
		public TerminalNode ASC() { return getToken(KoraliumParser.ASC, 0); }
		public TerminalNode DESC() { return getToken(KoraliumParser.DESC, 0); }
		public Order_by_elementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_element; }
	}

	public final Order_by_elementContext order_by_element() throws RecognitionException {
		Order_by_elementContext _localctx = new Order_by_elementContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_order_by_element);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(175);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NULL:
			case TRUE:
			case FALSE:
			case IDENTIFIER:
			case STRING_LITERAL:
			case VARIABLE_ID:
			case NUMERIC_LITERAL:
				{
				setState(173);
				((Order_by_elementContext)_localctx).scalar = scalar_expression(0);
				}
				break;
			case OPEN_PAR:
				{
				setState(174);
				((Order_by_elementContext)_localctx).query = orderby_subquery();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(178);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(177);
				((Order_by_elementContext)_localctx).order = _input.LT(1);
				_la = _input.LA(1);
				if ( !(_la==ASC || _la==DESC) ) {
					((Order_by_elementContext)_localctx).order = (Token)_errHandler.recoverInline(this);
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

	public static class Having_clauseContext extends ParserRuleContext {
		public Boolean_expressionContext boolean_expression() {
			return getRuleContext(Boolean_expressionContext.class,0);
		}
		public Having_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_having_clause; }
	}

	public final Having_clauseContext having_clause() throws RecognitionException {
		Having_clauseContext _localctx = new Having_clauseContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_having_clause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(180);
			boolean_expression(0);
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

	public static class From_clauseContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Table_aliasContext table_alias() {
			return getRuleContext(Table_aliasContext.class,0);
		}
		public TerminalNode AS() { return getToken(KoraliumParser.AS, 0); }
		public SubqueryContext subquery() {
			return getRuleContext(SubqueryContext.class,0);
		}
		public From_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_from_clause; }
	}

	public final From_clauseContext from_clause() throws RecognitionException {
		From_clauseContext _localctx = new From_clauseContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_from_clause);
		int _la;
		try {
			setState(190);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(182);
				table_name();
				setState(187);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAR) | (1L << AS) | (1L << IDENTIFIER) | (1L << STRING_LITERAL))) != 0)) {
					{
					setState(184);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==AS) {
						{
						setState(183);
						match(AS);
						}
					}

					setState(186);
					table_alias();
					}
				}

				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(189);
				subquery();
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
		enterRule(_localctx, 18, RULE_table_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192);
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

	public static class SubqueryContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(KoraliumParser.OPEN_PAR, 0); }
		public Select_statementContext select_statement() {
			return getRuleContext(Select_statementContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(KoraliumParser.CLOSE_PAR, 0); }
		public Table_aliasContext table_alias() {
			return getRuleContext(Table_aliasContext.class,0);
		}
		public TerminalNode AS() { return getToken(KoraliumParser.AS, 0); }
		public SubqueryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subquery; }
	}

	public final SubqueryContext subquery() throws RecognitionException {
		SubqueryContext _localctx = new SubqueryContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_subquery);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(194);
			match(OPEN_PAR);
			setState(195);
			select_statement();
			setState(196);
			match(CLOSE_PAR);
			setState(201);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAR) | (1L << AS) | (1L << IDENTIFIER) | (1L << STRING_LITERAL))) != 0)) {
				{
				setState(198);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AS) {
					{
					setState(197);
					match(AS);
					}
				}

				setState(200);
				table_alias();
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

	public static class Orderby_subqueryContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(KoraliumParser.OPEN_PAR, 0); }
		public Select_statementContext select_statement() {
			return getRuleContext(Select_statementContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(KoraliumParser.CLOSE_PAR, 0); }
		public Orderby_subqueryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_orderby_subquery; }
	}

	public final Orderby_subqueryContext orderby_subquery() throws RecognitionException {
		Orderby_subqueryContext _localctx = new Orderby_subqueryContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_orderby_subquery);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(203);
			match(OPEN_PAR);
			setState(204);
			select_statement();
			setState(205);
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

	public static class Group_subqueryContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(KoraliumParser.OPEN_PAR, 0); }
		public Select_statementContext select_statement() {
			return getRuleContext(Select_statementContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(KoraliumParser.CLOSE_PAR, 0); }
		public Group_subqueryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_group_subquery; }
	}

	public final Group_subqueryContext group_subquery() throws RecognitionException {
		Group_subqueryContext _localctx = new Group_subqueryContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_group_subquery);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(207);
			match(OPEN_PAR);
			setState(208);
			select_statement();
			setState(209);
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

	public static class Variable_referenceContext extends ParserRuleContext {
		public Token variableName;
		public TerminalNode VARIABLE_ID() { return getToken(KoraliumParser.VARIABLE_ID, 0); }
		public Variable_referenceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variable_reference; }
	}

	public final Variable_referenceContext variable_reference() throws RecognitionException {
		Variable_referenceContext _localctx = new Variable_referenceContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_variable_reference);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(211);
			((Variable_referenceContext)_localctx).variableName = match(VARIABLE_ID);
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

	public static class Select_expressionContext extends ParserRuleContext {
		public Table_nameContext tableAlias;
		public TerminalNode STAR() { return getToken(KoraliumParser.STAR, 0); }
		public TerminalNode NULL() { return getToken(KoraliumParser.NULL, 0); }
		public TerminalNode DOT() { return getToken(KoraliumParser.DOT, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Scalar_expressionContext scalar_expression() {
			return getRuleContext(Scalar_expressionContext.class,0);
		}
		public Column_aliasContext column_alias() {
			return getRuleContext(Column_aliasContext.class,0);
		}
		public TerminalNode AS() { return getToken(KoraliumParser.AS, 0); }
		public Select_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select_expression; }
	}

	public final Select_expressionContext select_expression() throws RecognitionException {
		Select_expressionContext _localctx = new Select_expressionContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_select_expression);
		int _la;
		try {
			setState(226);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(213);
				match(STAR);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(214);
				match(NULL);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(215);
				((Select_expressionContext)_localctx).tableAlias = table_name();
				setState(216);
				match(DOT);
				setState(217);
				match(STAR);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(219);
				scalar_expression(0);
				setState(224);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AS || _la==IDENTIFIER) {
					{
					setState(221);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==AS) {
						{
						setState(220);
						match(AS);
						}
					}

					setState(223);
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

	public static class Where_clauseContext extends ParserRuleContext {
		public Boolean_expressionContext boolean_expression() {
			return getRuleContext(Boolean_expressionContext.class,0);
		}
		public Where_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_where_clause; }
	}

	public final Where_clauseContext where_clause() throws RecognitionException {
		Where_clauseContext _localctx = new Where_clauseContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_where_clause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(228);
			boolean_expression(0);
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

	public static class Groupby_clauseContext extends ParserRuleContext {
		public List<Groupby_elementContext> groupby_element() {
			return getRuleContexts(Groupby_elementContext.class);
		}
		public Groupby_elementContext groupby_element(int i) {
			return getRuleContext(Groupby_elementContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(KoraliumParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(KoraliumParser.COMMA, i);
		}
		public Groupby_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_groupby_clause; }
	}

	public final Groupby_clauseContext groupby_clause() throws RecognitionException {
		Groupby_clauseContext _localctx = new Groupby_clauseContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_groupby_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(230);
			groupby_element();
			setState(235);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(231);
				match(COMMA);
				setState(232);
				groupby_element();
				}
				}
				setState(237);
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

	public static class Groupby_elementContext extends ParserRuleContext {
		public Scalar_expressionContext scalar_expression() {
			return getRuleContext(Scalar_expressionContext.class,0);
		}
		public Group_subqueryContext group_subquery() {
			return getRuleContext(Group_subqueryContext.class,0);
		}
		public Groupby_elementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_groupby_element; }
	}

	public final Groupby_elementContext groupby_element() throws RecognitionException {
		Groupby_elementContext _localctx = new Groupby_elementContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_groupby_element);
		try {
			setState(240);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NULL:
			case TRUE:
			case FALSE:
			case IDENTIFIER:
			case STRING_LITERAL:
			case VARIABLE_ID:
			case NUMERIC_LITERAL:
				enterOuterAlt(_localctx, 1);
				{
				setState(238);
				scalar_expression(0);
				}
				break;
			case OPEN_PAR:
				enterOuterAlt(_localctx, 2);
				{
				setState(239);
				group_subquery();
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

	public static class Boolean_expressionContext extends ParserRuleContext {
		public Boolean_expressionContext left;
		public Token isValue;
		public Boolean_expressionContext right;
		public TerminalNode EXCLAMATION() { return getToken(KoraliumParser.EXCLAMATION, 0); }
		public List<Boolean_expressionContext> boolean_expression() {
			return getRuleContexts(Boolean_expressionContext.class);
		}
		public Boolean_expressionContext boolean_expression(int i) {
			return getRuleContext(Boolean_expressionContext.class,i);
		}
		public PredicateContext predicate() {
			return getRuleContext(PredicateContext.class,0);
		}
		public TerminalNode IS() { return getToken(KoraliumParser.IS, 0); }
		public TerminalNode NOT() { return getToken(KoraliumParser.NOT, 0); }
		public TerminalNode TRUE() { return getToken(KoraliumParser.TRUE, 0); }
		public TerminalNode FALSE() { return getToken(KoraliumParser.FALSE, 0); }
		public Boolean_binary_typeContext boolean_binary_type() {
			return getRuleContext(Boolean_binary_typeContext.class,0);
		}
		public Boolean_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean_expression; }
	}

	public final Boolean_expressionContext boolean_expression() throws RecognitionException {
		return boolean_expression(0);
	}

	private Boolean_expressionContext boolean_expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		Boolean_expressionContext _localctx = new Boolean_expressionContext(_ctx, _parentState);
		Boolean_expressionContext _prevctx = _localctx;
		int _startState = 36;
		enterRecursionRule(_localctx, 36, RULE_boolean_expression, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(251);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,28,_ctx) ) {
			case 1:
				{
				setState(243);
				match(EXCLAMATION);
				setState(244);
				boolean_expression(4);
				}
				break;
			case 2:
				{
				setState(245);
				predicate();
				setState(246);
				match(IS);
				setState(247);
				match(NOT);
				setState(248);
				((Boolean_expressionContext)_localctx).isValue = _input.LT(1);
				_la = _input.LA(1);
				if ( !(_la==TRUE || _la==FALSE) ) {
					((Boolean_expressionContext)_localctx).isValue = (Token)_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			case 3:
				{
				setState(250);
				predicate();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(259);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,29,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new Boolean_expressionContext(_parentctx, _parentState);
					_localctx.left = _prevctx;
					_localctx.left = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_boolean_expression);
					setState(253);
					if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
					setState(254);
					boolean_binary_type();
					setState(255);
					((Boolean_expressionContext)_localctx).right = boolean_expression(4);
					}
					} 
				}
				setState(261);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,29,_ctx);
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

	public static class PredicateContext extends ParserRuleContext {
		public Boolean_comparison_expressionContext boolean_comparison_expression() {
			return getRuleContext(Boolean_comparison_expressionContext.class,0);
		}
		public Search_expressionContext search_expression() {
			return getRuleContext(Search_expressionContext.class,0);
		}
		public Function_callContext function_call() {
			return getRuleContext(Function_callContext.class,0);
		}
		public In_expressionContext in_expression() {
			return getRuleContext(In_expressionContext.class,0);
		}
		public Like_expressionContext like_expression() {
			return getRuleContext(Like_expressionContext.class,0);
		}
		public Is_null_predicateContext is_null_predicate() {
			return getRuleContext(Is_null_predicateContext.class,0);
		}
		public PredicateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predicate; }
	}

	public final PredicateContext predicate() throws RecognitionException {
		PredicateContext _localctx = new PredicateContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_predicate);
		try {
			setState(268);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(262);
				boolean_comparison_expression();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(263);
				search_expression();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(264);
				function_call();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(265);
				in_expression();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(266);
				like_expression();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(267);
				is_null_predicate();
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

	public static class Is_null_predicateContext extends ParserRuleContext {
		public Scalar_expressionContext scalar_expression() {
			return getRuleContext(Scalar_expressionContext.class,0);
		}
		public TerminalNode IS() { return getToken(KoraliumParser.IS, 0); }
		public TerminalNode NULL() { return getToken(KoraliumParser.NULL, 0); }
		public TerminalNode NOT() { return getToken(KoraliumParser.NOT, 0); }
		public Is_null_predicateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_is_null_predicate; }
	}

	public final Is_null_predicateContext is_null_predicate() throws RecognitionException {
		Is_null_predicateContext _localctx = new Is_null_predicateContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_is_null_predicate);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(270);
			scalar_expression(0);
			setState(271);
			match(IS);
			setState(273);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NOT) {
				{
				setState(272);
				match(NOT);
				}
			}

			setState(275);
			match(NULL);
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

	public static class Search_expressionContext extends ParserRuleContext {
		public Token wildcard;
		public TerminalNode CONTAINS() { return getToken(KoraliumParser.CONTAINS, 0); }
		public List<TerminalNode> OPEN_PAR() { return getTokens(KoraliumParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(KoraliumParser.OPEN_PAR, i);
		}
		public List<TerminalNode> COMMA() { return getTokens(KoraliumParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(KoraliumParser.COMMA, i);
		}
		public Scalar_expressionContext scalar_expression() {
			return getRuleContext(Scalar_expressionContext.class,0);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(KoraliumParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(KoraliumParser.CLOSE_PAR, i);
		}
		public List<Column_referenceContext> column_reference() {
			return getRuleContexts(Column_referenceContext.class);
		}
		public Column_referenceContext column_reference(int i) {
			return getRuleContext(Column_referenceContext.class,i);
		}
		public TerminalNode STAR() { return getToken(KoraliumParser.STAR, 0); }
		public Search_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_search_expression; }
	}

	public final Search_expressionContext search_expression() throws RecognitionException {
		Search_expressionContext _localctx = new Search_expressionContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_search_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(277);
			match(CONTAINS);
			setState(278);
			match(OPEN_PAR);
			setState(292);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case STAR:
				{
				setState(279);
				((Search_expressionContext)_localctx).wildcard = match(STAR);
				}
				break;
			case OPEN_PAR:
				{
				setState(280);
				match(OPEN_PAR);
				setState(281);
				column_reference();
				setState(286);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(282);
					match(COMMA);
					setState(283);
					column_reference();
					}
					}
					setState(288);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(289);
				match(CLOSE_PAR);
				}
				break;
			case IDENTIFIER:
				{
				setState(291);
				column_reference();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(294);
			match(COMMA);
			setState(295);
			scalar_expression(0);
			setState(296);
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

	public static class In_expressionContext extends ParserRuleContext {
		public In_left_scalarContext element;
		public TerminalNode IN() { return getToken(KoraliumParser.IN, 0); }
		public TerminalNode OPEN_PAR() { return getToken(KoraliumParser.OPEN_PAR, 0); }
		public List<Scalar_expressionContext> scalar_expression() {
			return getRuleContexts(Scalar_expressionContext.class);
		}
		public Scalar_expressionContext scalar_expression(int i) {
			return getRuleContext(Scalar_expressionContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(KoraliumParser.CLOSE_PAR, 0); }
		public In_left_scalarContext in_left_scalar() {
			return getRuleContext(In_left_scalarContext.class,0);
		}
		public TerminalNode NOT() { return getToken(KoraliumParser.NOT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(KoraliumParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(KoraliumParser.COMMA, i);
		}
		public In_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_in_expression; }
	}

	public final In_expressionContext in_expression() throws RecognitionException {
		In_expressionContext _localctx = new In_expressionContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_in_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(298);
			((In_expressionContext)_localctx).element = in_left_scalar();
			setState(300);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NOT) {
				{
				setState(299);
				match(NOT);
				}
			}

			setState(302);
			match(IN);
			setState(303);
			match(OPEN_PAR);
			setState(304);
			scalar_expression(0);
			setState(309);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(305);
				match(COMMA);
				setState(306);
				scalar_expression(0);
				}
				}
				setState(311);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(312);
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

	public static class Like_expressionContext extends ParserRuleContext {
		public In_left_scalarContext element;
		public Scalar_expressionContext right;
		public TerminalNode LIKE() { return getToken(KoraliumParser.LIKE, 0); }
		public In_left_scalarContext in_left_scalar() {
			return getRuleContext(In_left_scalarContext.class,0);
		}
		public Scalar_expressionContext scalar_expression() {
			return getRuleContext(Scalar_expressionContext.class,0);
		}
		public Like_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_like_expression; }
	}

	public final Like_expressionContext like_expression() throws RecognitionException {
		Like_expressionContext _localctx = new Like_expressionContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_like_expression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(314);
			((Like_expressionContext)_localctx).element = in_left_scalar();
			setState(315);
			match(LIKE);
			setState(316);
			((Like_expressionContext)_localctx).right = scalar_expression(0);
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

	public static class In_left_scalarContext extends ParserRuleContext {
		public Scalar_expressionContext scalar_expression() {
			return getRuleContext(Scalar_expressionContext.class,0);
		}
		public In_left_scalarContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_in_left_scalar; }
	}

	public final In_left_scalarContext in_left_scalar() throws RecognitionException {
		In_left_scalarContext _localctx = new In_left_scalarContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_in_left_scalar);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(318);
			scalar_expression(0);
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

	public static class Boolean_comparison_expressionContext extends ParserRuleContext {
		public Scalar_expressionContext left;
		public Scalar_expressionContext right;
		public Boolean_comparison_typeContext boolean_comparison_type() {
			return getRuleContext(Boolean_comparison_typeContext.class,0);
		}
		public List<Scalar_expressionContext> scalar_expression() {
			return getRuleContexts(Scalar_expressionContext.class);
		}
		public Scalar_expressionContext scalar_expression(int i) {
			return getRuleContext(Scalar_expressionContext.class,i);
		}
		public Boolean_comparison_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean_comparison_expression; }
	}

	public final Boolean_comparison_expressionContext boolean_comparison_expression() throws RecognitionException {
		Boolean_comparison_expressionContext _localctx = new Boolean_comparison_expressionContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_boolean_comparison_expression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(320);
			((Boolean_comparison_expressionContext)_localctx).left = scalar_expression(0);
			setState(321);
			boolean_comparison_type();
			setState(322);
			((Boolean_comparison_expressionContext)_localctx).right = scalar_expression(0);
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

	public static class Boolean_comparison_typeContext extends ParserRuleContext {
		public TerminalNode ASSIGN() { return getToken(KoraliumParser.ASSIGN, 0); }
		public TerminalNode GT() { return getToken(KoraliumParser.GT, 0); }
		public TerminalNode LT() { return getToken(KoraliumParser.LT, 0); }
		public TerminalNode GT_EQ() { return getToken(KoraliumParser.GT_EQ, 0); }
		public TerminalNode LT_EQ() { return getToken(KoraliumParser.LT_EQ, 0); }
		public TerminalNode NOT_EQ1() { return getToken(KoraliumParser.NOT_EQ1, 0); }
		public TerminalNode NOT_EQ2() { return getToken(KoraliumParser.NOT_EQ2, 0); }
		public TerminalNode NLT() { return getToken(KoraliumParser.NLT, 0); }
		public TerminalNode NGT() { return getToken(KoraliumParser.NGT, 0); }
		public Boolean_comparison_typeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean_comparison_type; }
	}

	public final Boolean_comparison_typeContext boolean_comparison_type() throws RecognitionException {
		Boolean_comparison_typeContext _localctx = new Boolean_comparison_typeContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_boolean_comparison_type);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(324);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << ASSIGN) | (1L << LT) | (1L << LT_EQ) | (1L << GT) | (1L << GT_EQ) | (1L << NOT_EQ1) | (1L << NOT_EQ2) | (1L << NLT) | (1L << NGT))) != 0)) ) {
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

	public static class Boolean_binary_typeContext extends ParserRuleContext {
		public TerminalNode AND() { return getToken(KoraliumParser.AND, 0); }
		public TerminalNode OR() { return getToken(KoraliumParser.OR, 0); }
		public Boolean_binary_typeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean_binary_type; }
	}

	public final Boolean_binary_typeContext boolean_binary_type() throws RecognitionException {
		Boolean_binary_typeContext _localctx = new Boolean_binary_typeContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_boolean_binary_type);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(326);
			_la = _input.LA(1);
			if ( !(_la==AND || _la==OR) ) {
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

	public static class Column_aliasContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(KoraliumParser.IDENTIFIER, 0); }
		public Column_aliasContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_alias; }
	}

	public final Column_aliasContext column_alias() throws RecognitionException {
		Column_aliasContext _localctx = new Column_aliasContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_column_alias);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(328);
			match(IDENTIFIER);
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

	public static class Scalar_expression2Context extends ParserRuleContext {
		public Scalar_expressionContext left;
		public Scalar_expressionContext right;
		public Column_referenceContext column_reference() {
			return getRuleContext(Column_referenceContext.class,0);
		}
		public Literal_valueContext literal_value() {
			return getRuleContext(Literal_valueContext.class,0);
		}
		public Binary_operation_typeContext binary_operation_type() {
			return getRuleContext(Binary_operation_typeContext.class,0);
		}
		public List<Scalar_expressionContext> scalar_expression() {
			return getRuleContexts(Scalar_expressionContext.class);
		}
		public Scalar_expressionContext scalar_expression(int i) {
			return getRuleContext(Scalar_expressionContext.class,i);
		}
		public Function_callContext function_call() {
			return getRuleContext(Function_callContext.class,0);
		}
		public Variable_referenceContext variable_reference() {
			return getRuleContext(Variable_referenceContext.class,0);
		}
		public Scalar_expression2Context(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scalar_expression2; }
	}

	public final Scalar_expression2Context scalar_expression2() throws RecognitionException {
		Scalar_expression2Context _localctx = new Scalar_expression2Context(_ctx, getState());
		enterRule(_localctx, 58, RULE_scalar_expression2);
		try {
			setState(339);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,36,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(331);
				column_reference();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(332);
				literal_value();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(333);
				((Scalar_expression2Context)_localctx).left = scalar_expression(0);
				setState(334);
				binary_operation_type();
				setState(335);
				((Scalar_expression2Context)_localctx).right = scalar_expression(0);
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(337);
				function_call();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(338);
				variable_reference();
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

	public static class Scalar_expressionContext extends ParserRuleContext {
		public Scalar_expressionContext left;
		public Scalar_expressionContext right;
		public Literal_valueContext literal_value() {
			return getRuleContext(Literal_valueContext.class,0);
		}
		public Column_referenceContext column_reference() {
			return getRuleContext(Column_referenceContext.class,0);
		}
		public Function_callContext function_call() {
			return getRuleContext(Function_callContext.class,0);
		}
		public Variable_referenceContext variable_reference() {
			return getRuleContext(Variable_referenceContext.class,0);
		}
		public Binary_operation_typeContext binary_operation_type() {
			return getRuleContext(Binary_operation_typeContext.class,0);
		}
		public List<Scalar_expressionContext> scalar_expression() {
			return getRuleContexts(Scalar_expressionContext.class);
		}
		public Scalar_expressionContext scalar_expression(int i) {
			return getRuleContext(Scalar_expressionContext.class,i);
		}
		public Scalar_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scalar_expression; }
	}

	public final Scalar_expressionContext scalar_expression() throws RecognitionException {
		return scalar_expression(0);
	}

	private Scalar_expressionContext scalar_expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		Scalar_expressionContext _localctx = new Scalar_expressionContext(_ctx, _parentState);
		Scalar_expressionContext _prevctx = _localctx;
		int _startState = 60;
		enterRecursionRule(_localctx, 60, RULE_scalar_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(346);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
			case 1:
				{
				setState(342);
				literal_value();
				}
				break;
			case 2:
				{
				setState(343);
				column_reference();
				}
				break;
			case 3:
				{
				setState(344);
				function_call();
				}
				break;
			case 4:
				{
				setState(345);
				variable_reference();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(354);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,38,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new Scalar_expressionContext(_parentctx, _parentState);
					_localctx.left = _prevctx;
					_localctx.left = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_scalar_expression);
					setState(348);
					if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
					setState(349);
					binary_operation_type();
					setState(350);
					((Scalar_expressionContext)_localctx).right = scalar_expression(4);
					}
					} 
				}
				setState(356);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,38,_ctx);
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

	public static class ErrorContext extends ParserRuleContext {
		public ErrorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_error; }
	}

	public final ErrorContext error() throws RecognitionException {
		ErrorContext _localctx = new ErrorContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_error);
		try {
			enterOuterAlt(_localctx, 1);
			{
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

	public static class Binary_expressionContext extends ParserRuleContext {
		public List<Scalar_expressionContext> scalar_expression() {
			return getRuleContexts(Scalar_expressionContext.class);
		}
		public Scalar_expressionContext scalar_expression(int i) {
			return getRuleContext(Scalar_expressionContext.class,i);
		}
		public Binary_operation_typeContext binary_operation_type() {
			return getRuleContext(Binary_operation_typeContext.class,0);
		}
		public Binary_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_binary_expression; }
	}

	public final Binary_expressionContext binary_expression() throws RecognitionException {
		Binary_expressionContext _localctx = new Binary_expressionContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_binary_expression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(359);
			scalar_expression(0);
			setState(360);
			binary_operation_type();
			setState(361);
			scalar_expression(0);
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

	public static class Binary_operation_typeContext extends ParserRuleContext {
		public TerminalNode PLUS() { return getToken(KoraliumParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(KoraliumParser.MINUS, 0); }
		public TerminalNode STAR() { return getToken(KoraliumParser.STAR, 0); }
		public TerminalNode DIV() { return getToken(KoraliumParser.DIV, 0); }
		public TerminalNode MOD() { return getToken(KoraliumParser.MOD, 0); }
		public TerminalNode AMP() { return getToken(KoraliumParser.AMP, 0); }
		public TerminalNode PIPE() { return getToken(KoraliumParser.PIPE, 0); }
		public TerminalNode XOR() { return getToken(KoraliumParser.XOR, 0); }
		public Binary_operation_typeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_binary_operation_type; }
	}

	public final Binary_operation_typeContext binary_operation_type() throws RecognitionException {
		Binary_operation_typeContext _localctx = new Binary_operation_typeContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_binary_operation_type);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(363);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << PLUS) | (1L << MINUS) | (1L << DIV) | (1L << MOD) | (1L << AMP) | (1L << PIPE) | (1L << XOR))) != 0)) ) {
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

	public static class Function_callContext extends ParserRuleContext {
		public Function_nameContext function_name() {
			return getRuleContext(Function_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(KoraliumParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(KoraliumParser.CLOSE_PAR, 0); }
		public TerminalNode STAR() { return getToken(KoraliumParser.STAR, 0); }
		public List<Scalar_expressionContext> scalar_expression() {
			return getRuleContexts(Scalar_expressionContext.class);
		}
		public Scalar_expressionContext scalar_expression(int i) {
			return getRuleContext(Scalar_expressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(KoraliumParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(KoraliumParser.COMMA, i);
		}
		public Function_callContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function_call; }
	}

	public final Function_callContext function_call() throws RecognitionException {
		Function_callContext _localctx = new Function_callContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_function_call);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(365);
			function_name();
			setState(366);
			match(OPEN_PAR);
			setState(376);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NULL:
			case TRUE:
			case FALSE:
			case IDENTIFIER:
			case STRING_LITERAL:
			case VARIABLE_ID:
			case NUMERIC_LITERAL:
				{
				{
				setState(367);
				scalar_expression(0);
				setState(372);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(368);
					match(COMMA);
					setState(369);
					scalar_expression(0);
					}
					}
					setState(374);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				}
				break;
			case STAR:
				{
				setState(375);
				match(STAR);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			setState(378);
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

	public static class Column_referenceContext extends ParserRuleContext {
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<TerminalNode> DOT() { return getTokens(KoraliumParser.DOT); }
		public TerminalNode DOT(int i) {
			return getToken(KoraliumParser.DOT, i);
		}
		public Column_referenceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_reference; }
	}

	public final Column_referenceContext column_reference() throws RecognitionException {
		Column_referenceContext _localctx = new Column_referenceContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_column_reference);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(380);
			column_name();
			setState(385);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(381);
					match(DOT);
					setState(382);
					column_name();
					}
					} 
				}
				setState(387);
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

	public static class Literal_valueContext extends ParserRuleContext {
		public TerminalNode NUMERIC_LITERAL() { return getToken(KoraliumParser.NUMERIC_LITERAL, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(KoraliumParser.STRING_LITERAL, 0); }
		public TerminalNode NULL() { return getToken(KoraliumParser.NULL, 0); }
		public TerminalNode TRUE() { return getToken(KoraliumParser.TRUE, 0); }
		public TerminalNode FALSE() { return getToken(KoraliumParser.FALSE, 0); }
		public Literal_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literal_value; }
	}

	public final Literal_valueContext literal_value() throws RecognitionException {
		Literal_valueContext _localctx = new Literal_valueContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_literal_value);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(388);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NULL) | (1L << TRUE) | (1L << FALSE) | (1L << STRING_LITERAL) | (1L << NUMERIC_LITERAL))) != 0)) ) {
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

	public static class Column_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(KoraliumParser.IDENTIFIER, 0); }
		public Column_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_name; }
	}

	public final Column_nameContext column_name() throws RecognitionException {
		Column_nameContext _localctx = new Column_nameContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_column_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(390);
			match(IDENTIFIER);
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
		public TerminalNode IDENTIFIER() { return getToken(KoraliumParser.IDENTIFIER, 0); }
		public Function_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function_name; }
	}

	public final Function_nameContext function_name() throws RecognitionException {
		Function_nameContext _localctx = new Function_nameContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_function_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(392);
			match(IDENTIFIER);
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
		enterRule(_localctx, 78, RULE_table_alias);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(394);
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
		public TerminalNode IDENTIFIER() { return getToken(KoraliumParser.IDENTIFIER, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(KoraliumParser.STRING_LITERAL, 0); }
		public TerminalNode OPEN_PAR() { return getToken(KoraliumParser.OPEN_PAR, 0); }
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(KoraliumParser.CLOSE_PAR, 0); }
		public Any_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_any_name; }
	}

	public final Any_nameContext any_name() throws RecognitionException {
		Any_nameContext _localctx = new Any_nameContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_any_name);
		try {
			setState(402);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(396);
				match(IDENTIFIER);
				}
				break;
			case STRING_LITERAL:
				enterOuterAlt(_localctx, 2);
				{
				setState(397);
				match(STRING_LITERAL);
				}
				break;
			case OPEN_PAR:
				enterOuterAlt(_localctx, 3);
				{
				setState(398);
				match(OPEN_PAR);
				setState(399);
				any_name();
				setState(400);
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
		case 18:
			return boolean_expression_sempred((Boolean_expressionContext)_localctx, predIndex);
		case 30:
			return scalar_expression_sempred((Scalar_expressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean boolean_expression_sempred(Boolean_expressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 3);
		}
		return true;
	}
	private boolean scalar_expression_sempred(Scalar_expressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return precpred(_ctx, 3);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3<\u0197\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\3\2\7\2"+
		"V\n\2\f\2\16\2Y\13\2\3\2\3\2\3\3\7\3^\n\3\f\3\16\3a\13\3\3\3\3\3\6\3e"+
		"\n\3\r\3\16\3f\3\3\7\3j\n\3\f\3\16\3m\13\3\3\3\7\3p\n\3\f\3\16\3s\13\3"+
		"\3\4\3\4\5\4w\n\4\3\5\3\5\3\5\3\5\3\5\3\6\3\6\5\6\u0080\n\6\3\6\3\6\3"+
		"\6\7\6\u0085\n\6\f\6\16\6\u0088\13\6\3\6\3\6\3\6\3\6\5\6\u008e\n\6\3\6"+
		"\3\6\3\6\5\6\u0093\n\6\3\6\3\6\5\6\u0097\n\6\5\6\u0099\n\6\3\6\3\6\3\6"+
		"\5\6\u009e\n\6\3\6\3\6\5\6\u00a2\n\6\3\6\3\6\5\6\u00a6\n\6\3\7\3\7\3\7"+
		"\7\7\u00ab\n\7\f\7\16\7\u00ae\13\7\3\b\3\b\5\b\u00b2\n\b\3\b\5\b\u00b5"+
		"\n\b\3\t\3\t\3\n\3\n\5\n\u00bb\n\n\3\n\5\n\u00be\n\n\3\n\5\n\u00c1\n\n"+
		"\3\13\3\13\3\f\3\f\3\f\3\f\5\f\u00c9\n\f\3\f\5\f\u00cc\n\f\3\r\3\r\3\r"+
		"\3\r\3\16\3\16\3\16\3\16\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\5\20\u00e0\n\20\3\20\5\20\u00e3\n\20\5\20\u00e5\n\20\3\21\3\21\3"+
		"\22\3\22\3\22\7\22\u00ec\n\22\f\22\16\22\u00ef\13\22\3\23\3\23\5\23\u00f3"+
		"\n\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\5\24\u00fe\n\24\3\24"+
		"\3\24\3\24\3\24\7\24\u0104\n\24\f\24\16\24\u0107\13\24\3\25\3\25\3\25"+
		"\3\25\3\25\3\25\5\25\u010f\n\25\3\26\3\26\3\26\5\26\u0114\n\26\3\26\3"+
		"\26\3\27\3\27\3\27\3\27\3\27\3\27\3\27\7\27\u011f\n\27\f\27\16\27\u0122"+
		"\13\27\3\27\3\27\3\27\5\27\u0127\n\27\3\27\3\27\3\27\3\27\3\30\3\30\5"+
		"\30\u012f\n\30\3\30\3\30\3\30\3\30\3\30\7\30\u0136\n\30\f\30\16\30\u0139"+
		"\13\30\3\30\3\30\3\31\3\31\3\31\3\31\3\32\3\32\3\33\3\33\3\33\3\33\3\34"+
		"\3\34\3\35\3\35\3\36\3\36\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37"+
		"\5\37\u0156\n\37\3 \3 \3 \3 \3 \5 \u015d\n \3 \3 \3 \3 \7 \u0163\n \f"+
		" \16 \u0166\13 \3!\3!\3\"\3\"\3\"\3\"\3#\3#\3$\3$\3$\3$\3$\7$\u0175\n"+
		"$\f$\16$\u0178\13$\3$\5$\u017b\n$\3$\3$\3%\3%\3%\7%\u0182\n%\f%\16%\u0185"+
		"\13%\3&\3&\3\'\3\'\3(\3(\3)\3)\3*\3*\3*\3*\3*\3*\5*\u0195\n*\3*\2\4&>"+
		"+\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<>@BDF"+
		"HJLNPR\2\b\3\2\61\62\3\2$%\5\2\b\b\24\27\31\34\3\2\'(\6\2\t\13\16\17\22"+
		"\23\35\35\5\2#%::<<\2\u01a8\2W\3\2\2\2\4_\3\2\2\2\6v\3\2\2\2\bx\3\2\2"+
		"\2\n}\3\2\2\2\f\u00a7\3\2\2\2\16\u00b1\3\2\2\2\20\u00b6\3\2\2\2\22\u00c0"+
		"\3\2\2\2\24\u00c2\3\2\2\2\26\u00c4\3\2\2\2\30\u00cd\3\2\2\2\32\u00d1\3"+
		"\2\2\2\34\u00d5\3\2\2\2\36\u00e4\3\2\2\2 \u00e6\3\2\2\2\"\u00e8\3\2\2"+
		"\2$\u00f2\3\2\2\2&\u00fd\3\2\2\2(\u010e\3\2\2\2*\u0110\3\2\2\2,\u0117"+
		"\3\2\2\2.\u012c\3\2\2\2\60\u013c\3\2\2\2\62\u0140\3\2\2\2\64\u0142\3\2"+
		"\2\2\66\u0146\3\2\2\28\u0148\3\2\2\2:\u014a\3\2\2\2<\u0155\3\2\2\2>\u015c"+
		"\3\2\2\2@\u0167\3\2\2\2B\u0169\3\2\2\2D\u016d\3\2\2\2F\u016f\3\2\2\2H"+
		"\u017e\3\2\2\2J\u0186\3\2\2\2L\u0188\3\2\2\2N\u018a\3\2\2\2P\u018c\3\2"+
		"\2\2R\u0194\3\2\2\2TV\5\4\3\2UT\3\2\2\2VY\3\2\2\2WU\3\2\2\2WX\3\2\2\2"+
		"XZ\3\2\2\2YW\3\2\2\2Z[\7\2\2\3[\3\3\2\2\2\\^\7\3\2\2]\\\3\2\2\2^a\3\2"+
		"\2\2_]\3\2\2\2_`\3\2\2\2`b\3\2\2\2a_\3\2\2\2bk\5\6\4\2ce\7\3\2\2dc\3\2"+
		"\2\2ef\3\2\2\2fd\3\2\2\2fg\3\2\2\2gh\3\2\2\2hj\5\6\4\2id\3\2\2\2jm\3\2"+
		"\2\2ki\3\2\2\2kl\3\2\2\2lq\3\2\2\2mk\3\2\2\2np\7\3\2\2on\3\2\2\2ps\3\2"+
		"\2\2qo\3\2\2\2qr\3\2\2\2r\5\3\2\2\2sq\3\2\2\2tw\5\b\5\2uw\5\n\6\2vt\3"+
		"\2\2\2vu\3\2\2\2w\7\3\2\2\2xy\7\65\2\2yz\5\34\17\2z{\7\b\2\2{|\5> \2|"+
		"\t\3\2\2\2}\177\7\37\2\2~\u0080\7 \2\2\177~\3\2\2\2\177\u0080\3\2\2\2"+
		"\u0080\u0081\3\2\2\2\u0081\u0086\5\36\20\2\u0082\u0083\7\7\2\2\u0083\u0085"+
		"\5\36\20\2\u0084\u0082\3\2\2\2\u0085\u0088\3\2\2\2\u0086\u0084\3\2\2\2"+
		"\u0086\u0087\3\2\2\2\u0087\u0098\3\2\2\2\u0088\u0086\3\2\2\2\u0089\u008a"+
		"\7!\2\2\u008a\u008d\5\22\n\2\u008b\u008c\7&\2\2\u008c\u008e\5 \21\2\u008d"+
		"\u008b\3\2\2\2\u008d\u008e\3\2\2\2\u008e\u0092\3\2\2\2\u008f\u0090\7,"+
		"\2\2\u0090\u0091\7-\2\2\u0091\u0093\5\"\22\2\u0092\u008f\3\2\2\2\u0092"+
		"\u0093\3\2\2\2\u0093\u0096\3\2\2\2\u0094\u0095\7.\2\2\u0095\u0097\5\20"+
		"\t\2\u0096\u0094\3\2\2\2\u0096\u0097\3\2\2\2\u0097\u0099\3\2\2\2\u0098"+
		"\u0089\3\2\2\2\u0098\u0099\3\2\2\2\u0099\u009d\3\2\2\2\u009a\u009b\7\60"+
		"\2\2\u009b\u009c\7-\2\2\u009c\u009e\5\f\7\2\u009d\u009a\3\2\2\2\u009d"+
		"\u009e\3\2\2\2\u009e\u00a1\3\2\2\2\u009f\u00a0\7\63\2\2\u00a0\u00a2\5"+
		"> \2\u00a1\u009f\3\2\2\2\u00a1\u00a2\3\2\2\2\u00a2\u00a5\3\2\2\2\u00a3"+
		"\u00a4\7\64\2\2\u00a4\u00a6\5> \2\u00a5\u00a3\3\2\2\2\u00a5\u00a6\3\2"+
		"\2\2\u00a6\13\3\2\2\2\u00a7\u00ac\5\16\b\2\u00a8\u00a9\7\7\2\2\u00a9\u00ab"+
		"\5\16\b\2\u00aa\u00a8\3\2\2\2\u00ab\u00ae\3\2\2\2\u00ac\u00aa\3\2\2\2"+
		"\u00ac\u00ad\3\2\2\2\u00ad\r\3\2\2\2\u00ae\u00ac\3\2\2\2\u00af\u00b2\5"+
		"> \2\u00b0\u00b2\5\30\r\2\u00b1\u00af\3\2\2\2\u00b1\u00b0\3\2\2\2\u00b2"+
		"\u00b4\3\2\2\2\u00b3\u00b5\t\2\2\2\u00b4\u00b3\3\2\2\2\u00b4\u00b5\3\2"+
		"\2\2\u00b5\17\3\2\2\2\u00b6\u00b7\5&\24\2\u00b7\21\3\2\2\2\u00b8\u00bd"+
		"\5\24\13\2\u00b9\u00bb\7\"\2\2\u00ba\u00b9\3\2\2\2\u00ba\u00bb\3\2\2\2"+
		"\u00bb\u00bc\3\2\2\2\u00bc\u00be\5P)\2\u00bd\u00ba\3\2\2\2\u00bd\u00be"+
		"\3\2\2\2\u00be\u00c1\3\2\2\2\u00bf\u00c1\5\26\f\2\u00c0\u00b8\3\2\2\2"+
		"\u00c0\u00bf\3\2\2\2\u00c1\23\3\2\2\2\u00c2\u00c3\5R*\2\u00c3\25\3\2\2"+
		"\2\u00c4\u00c5\7\5\2\2\u00c5\u00c6\5\n\6\2\u00c6\u00cb\7\6\2\2\u00c7\u00c9"+
		"\7\"\2\2\u00c8\u00c7\3\2\2\2\u00c8\u00c9\3\2\2\2\u00c9\u00ca\3\2\2\2\u00ca"+
		"\u00cc\5P)\2\u00cb\u00c8\3\2\2\2\u00cb\u00cc\3\2\2\2\u00cc\27\3\2\2\2"+
		"\u00cd\u00ce\7\5\2\2\u00ce\u00cf\5\n\6\2\u00cf\u00d0\7\6\2\2\u00d0\31"+
		"\3\2\2\2\u00d1\u00d2\7\5\2\2\u00d2\u00d3\5\n\6\2\u00d3\u00d4\7\6\2\2\u00d4"+
		"\33\3\2\2\2\u00d5\u00d6\7;\2\2\u00d6\35\3\2\2\2\u00d7\u00e5\7\t\2\2\u00d8"+
		"\u00e5\7#\2\2\u00d9\u00da\5\24\13\2\u00da\u00db\7\4\2\2\u00db\u00dc\7"+
		"\t\2\2\u00dc\u00e5\3\2\2\2\u00dd\u00e2\5> \2\u00de\u00e0\7\"\2\2\u00df"+
		"\u00de\3\2\2\2\u00df\u00e0\3\2\2\2\u00e0\u00e1\3\2\2\2\u00e1\u00e3\5:"+
		"\36\2\u00e2\u00df\3\2\2\2\u00e2\u00e3\3\2\2\2\u00e3\u00e5\3\2\2\2\u00e4"+
		"\u00d7\3\2\2\2\u00e4\u00d8\3\2\2\2\u00e4\u00d9\3\2\2\2\u00e4\u00dd\3\2"+
		"\2\2\u00e5\37\3\2\2\2\u00e6\u00e7\5&\24\2\u00e7!\3\2\2\2\u00e8\u00ed\5"+
		"$\23\2\u00e9\u00ea\7\7\2\2\u00ea\u00ec\5$\23\2\u00eb\u00e9\3\2\2\2\u00ec"+
		"\u00ef\3\2\2\2\u00ed\u00eb\3\2\2\2\u00ed\u00ee\3\2\2\2\u00ee#\3\2\2\2"+
		"\u00ef\u00ed\3\2\2\2\u00f0\u00f3\5> \2\u00f1\u00f3\5\32\16\2\u00f2\u00f0"+
		"\3\2\2\2\u00f2\u00f1\3\2\2\2\u00f3%\3\2\2\2\u00f4\u00f5\b\24\1\2\u00f5"+
		"\u00f6\7\36\2\2\u00f6\u00fe\5&\24\6\u00f7\u00f8\5(\25\2\u00f8\u00f9\7"+
		")\2\2\u00f9\u00fa\7*\2\2\u00fa\u00fb\t\3\2\2\u00fb\u00fe\3\2\2\2\u00fc"+
		"\u00fe\5(\25\2\u00fd\u00f4\3\2\2\2\u00fd\u00f7\3\2\2\2\u00fd\u00fc\3\2"+
		"\2\2\u00fe\u0105\3\2\2\2\u00ff\u0100\f\5\2\2\u0100\u0101\58\35\2\u0101"+
		"\u0102\5&\24\6\u0102\u0104\3\2\2\2\u0103\u00ff\3\2\2\2\u0104\u0107\3\2"+
		"\2\2\u0105\u0103\3\2\2\2\u0105\u0106\3\2\2\2\u0106\'\3\2\2\2\u0107\u0105"+
		"\3\2\2\2\u0108\u010f\5\64\33\2\u0109\u010f\5,\27\2\u010a\u010f\5F$\2\u010b"+
		"\u010f\5.\30\2\u010c\u010f\5\60\31\2\u010d\u010f\5*\26\2\u010e\u0108\3"+
		"\2\2\2\u010e\u0109\3\2\2\2\u010e\u010a\3\2\2\2\u010e\u010b\3\2\2\2\u010e"+
		"\u010c\3\2\2\2\u010e\u010d\3\2\2\2\u010f)\3\2\2\2\u0110\u0111\5> \2\u0111"+
		"\u0113\7)\2\2\u0112\u0114\7*\2\2\u0113\u0112\3\2\2\2\u0113\u0114\3\2\2"+
		"\2\u0114\u0115\3\2\2\2\u0115\u0116\7#\2\2\u0116+\3\2\2\2\u0117\u0118\7"+
		"\66\2\2\u0118\u0126\7\5\2\2\u0119\u0127\7\t\2\2\u011a\u011b\7\5\2\2\u011b"+
		"\u0120\5H%\2\u011c\u011d\7\7\2\2\u011d\u011f\5H%\2\u011e\u011c\3\2\2\2"+
		"\u011f\u0122\3\2\2\2\u0120\u011e\3\2\2\2\u0120\u0121\3\2\2\2\u0121\u0123"+
		"\3\2\2\2\u0122\u0120\3\2\2\2\u0123\u0124\7\6\2\2\u0124\u0127\3\2\2\2\u0125"+
		"\u0127\5H%\2\u0126\u0119\3\2\2\2\u0126\u011a\3\2\2\2\u0126\u0125\3\2\2"+
		"\2\u0127\u0128\3\2\2\2\u0128\u0129\7\7\2\2\u0129\u012a\5> \2\u012a\u012b"+
		"\7\6\2\2\u012b-\3\2\2\2\u012c\u012e\5\62\32\2\u012d\u012f\7*\2\2\u012e"+
		"\u012d\3\2\2\2\u012e\u012f\3\2\2\2\u012f\u0130\3\2\2\2\u0130\u0131\7/"+
		"\2\2\u0131\u0132\7\5\2\2\u0132\u0137\5> \2\u0133\u0134\7\7\2\2\u0134\u0136"+
		"\5> \2\u0135\u0133\3\2\2\2\u0136\u0139\3\2\2\2\u0137\u0135\3\2\2\2\u0137"+
		"\u0138\3\2\2\2\u0138\u013a\3\2\2\2\u0139\u0137\3\2\2\2\u013a\u013b\7\6"+
		"\2\2\u013b/\3\2\2\2\u013c\u013d\5\62\32\2\u013d\u013e\7+\2\2\u013e\u013f"+
		"\5> \2\u013f\61\3\2\2\2\u0140\u0141\5> \2\u0141\63\3\2\2\2\u0142\u0143"+
		"\5> \2\u0143\u0144\5\66\34\2\u0144\u0145\5> \2\u0145\65\3\2\2\2\u0146"+
		"\u0147\t\4\2\2\u0147\67\3\2\2\2\u0148\u0149\t\5\2\2\u01499\3\2\2\2\u014a"+
		"\u014b\78\2\2\u014b;\3\2\2\2\u014c\u0156\3\2\2\2\u014d\u0156\5H%\2\u014e"+
		"\u0156\5J&\2\u014f\u0150\5> \2\u0150\u0151\5D#\2\u0151\u0152\5> \2\u0152"+
		"\u0156\3\2\2\2\u0153\u0156\5F$\2\u0154\u0156\5\34\17\2\u0155\u014c\3\2"+
		"\2\2\u0155\u014d\3\2\2\2\u0155\u014e\3\2\2\2\u0155\u014f\3\2\2\2\u0155"+
		"\u0153\3\2\2\2\u0155\u0154\3\2\2\2\u0156=\3\2\2\2\u0157\u0158\b \1\2\u0158"+
		"\u015d\5J&\2\u0159\u015d\5H%\2\u015a\u015d\5F$\2\u015b\u015d\5\34\17\2"+
		"\u015c\u0157\3\2\2\2\u015c\u0159\3\2\2\2\u015c\u015a\3\2\2\2\u015c\u015b"+
		"\3\2\2\2\u015d\u0164\3\2\2\2\u015e\u015f\f\5\2\2\u015f\u0160\5D#\2\u0160"+
		"\u0161\5> \6\u0161\u0163\3\2\2\2\u0162\u015e\3\2\2\2\u0163\u0166\3\2\2"+
		"\2\u0164\u0162\3\2\2\2\u0164\u0165\3\2\2\2\u0165?\3\2\2\2\u0166\u0164"+
		"\3\2\2\2\u0167\u0168\3\2\2\2\u0168A\3\2\2\2\u0169\u016a\5> \2\u016a\u016b"+
		"\5D#\2\u016b\u016c\5> \2\u016cC\3\2\2\2\u016d\u016e\t\6\2\2\u016eE\3\2"+
		"\2\2\u016f\u0170\5N(\2\u0170\u017a\7\5\2\2\u0171\u0176\5> \2\u0172\u0173"+
		"\7\7\2\2\u0173\u0175\5> \2\u0174\u0172\3\2\2\2\u0175\u0178\3\2\2\2\u0176"+
		"\u0174\3\2\2\2\u0176\u0177\3\2\2\2\u0177\u017b\3\2\2\2\u0178\u0176\3\2"+
		"\2\2\u0179\u017b\7\t\2\2\u017a\u0171\3\2\2\2\u017a\u0179\3\2\2\2\u017a"+
		"\u017b\3\2\2\2\u017b\u017c\3\2\2\2\u017c\u017d\7\6\2\2\u017dG\3\2\2\2"+
		"\u017e\u0183\5L\'\2\u017f\u0180\7\4\2\2\u0180\u0182\5L\'\2\u0181\u017f"+
		"\3\2\2\2\u0182\u0185\3\2\2\2\u0183\u0181\3\2\2\2\u0183\u0184\3\2\2\2\u0184"+
		"I\3\2\2\2\u0185\u0183\3\2\2\2\u0186\u0187\t\7\2\2\u0187K\3\2\2\2\u0188"+
		"\u0189\78\2\2\u0189M\3\2\2\2\u018a\u018b\78\2\2\u018bO\3\2\2\2\u018c\u018d"+
		"\5R*\2\u018dQ\3\2\2\2\u018e\u0195\78\2\2\u018f\u0195\7:\2\2\u0190\u0191"+
		"\7\5\2\2\u0191\u0192\5R*\2\u0192\u0193\7\6\2\2\u0193\u0195\3\2\2\2\u0194"+
		"\u018e\3\2\2\2\u0194\u018f\3\2\2\2\u0194\u0190\3\2\2\2\u0195S\3\2\2\2"+
		"-W_fkqv\177\u0086\u008d\u0092\u0096\u0098\u009d\u00a1\u00a5\u00ac\u00b1"+
		"\u00b4\u00ba\u00bd\u00c0\u00c8\u00cb\u00df\u00e2\u00e4\u00ed\u00f2\u00fd"+
		"\u0105\u010e\u0113\u0120\u0126\u012e\u0137\u0155\u015c\u0164\u0176\u017a"+
		"\u0183\u0194";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}