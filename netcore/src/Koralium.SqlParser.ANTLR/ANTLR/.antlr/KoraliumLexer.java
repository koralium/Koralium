// Generated from c:\Users\seosal\source\repos\Koralium\new\Koralium\netcore\src\Koralium.SqlParser.ANTLR\ANTLR\KoraliumLexer.g4 by ANTLR 4.8
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class KoraliumLexer extends Lexer {
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
		OFFSET=50, SET=51, CONTAINS=52, SPACES=53, IDENTIFIER=54, STRING_LITERAL=55, 
		VARIABLE_ID=56, NUMERIC_LITERAL=57;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"SCOL", "DOT", "OPEN_PAR", "CLOSE_PAR", "COMMA", "ASSIGN", "STAR", "PLUS", 
			"MINUS", "TILDE", "PIPE2", "DIV", "MOD", "LT2", "GT2", "AMP", "PIPE", 
			"LT", "LT_EQ", "GT", "GT_EQ", "EQ", "NOT_EQ1", "NOT_EQ2", "NLT", "NGT", 
			"XOR", "EXCLAMATION", "SELECT", "DISTINCT", "FROM", "AS", "NULL", "TRUE", 
			"FALSE", "WHERE", "AND", "OR", "IS", "NOT", "LIKE", "GROUP", "BY", "HAVING", 
			"IN", "ORDER", "ASC", "DESC", "LIMIT", "OFFSET", "SET", "CONTAINS", "SPACES", 
			"IDENTIFIER", "STRING_LITERAL", "VARIABLE_ID", "NUMERIC_LITERAL", "DIGIT"
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
			"CONTAINS", "SPACES", "IDENTIFIER", "STRING_LITERAL", "VARIABLE_ID", 
			"NUMERIC_LITERAL"
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


	public KoraliumLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "KoraliumLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2;\u0195\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\3\2\3\2\3\3"+
		"\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\t\3\t\3\n\3\n\3\13\3\13"+
		"\3\f\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\17\3\20\3\20\3\20\3\21\3\21"+
		"\3\22\3\22\3\23\3\23\3\24\3\24\3\24\3\25\3\25\3\26\3\26\3\26\3\27\3\27"+
		"\3\27\3\30\3\30\3\30\3\31\3\31\3\31\3\32\3\32\3\32\3\33\3\33\3\33\3\34"+
		"\3\34\3\35\3\35\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\37\3\37\3\37\3\37"+
		"\3\37\3\37\3\37\3\37\3\37\3 \3 \3 \3 \3 \3!\3!\3!\3\"\3\"\3\"\3\"\3\""+
		"\3#\3#\3#\3#\3#\3$\3$\3$\3$\3$\3$\3%\3%\3%\3%\3%\3%\3&\3&\3&\3&\3\'\3"+
		"\'\3\'\3(\3(\3(\3)\3)\3)\3)\3*\3*\3*\3*\3*\3+\3+\3+\3+\3+\3+\3,\3,\3,"+
		"\3-\3-\3-\3-\3-\3-\3-\3.\3.\3.\3/\3/\3/\3/\3/\3/\3\60\3\60\3\60\3\60\3"+
		"\61\3\61\3\61\3\61\3\61\3\62\3\62\3\62\3\62\3\62\3\62\3\63\3\63\3\63\3"+
		"\63\3\63\3\63\3\63\3\64\3\64\3\64\3\64\3\65\3\65\3\65\3\65\3\65\3\65\3"+
		"\65\3\65\3\65\3\66\3\66\3\66\3\66\3\67\3\67\3\67\3\67\7\67\u013f\n\67"+
		"\f\67\16\67\u0142\13\67\3\67\3\67\3\67\3\67\3\67\7\67\u0149\n\67\f\67"+
		"\16\67\u014c\13\67\3\67\3\67\3\67\7\67\u0151\n\67\f\67\16\67\u0154\13"+
		"\67\3\67\3\67\3\67\7\67\u0159\n\67\f\67\16\67\u015c\13\67\5\67\u015e\n"+
		"\67\38\38\38\38\78\u0164\n8\f8\168\u0167\138\38\38\39\39\39\79\u016e\n"+
		"9\f9\169\u0171\139\3:\6:\u0174\n:\r:\16:\u0175\3:\3:\7:\u017a\n:\f:\16"+
		":\u017d\13:\5:\u017f\n:\3:\3:\6:\u0183\n:\r:\16:\u0184\5:\u0187\n:\3:"+
		"\3:\5:\u018b\n:\3:\6:\u018e\n:\r:\16:\u018f\5:\u0192\n:\3;\3;\2\2<\3\3"+
		"\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21"+
		"!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\36;\37= ?!"+
		"A\"C#E$G%I&K\'M(O)Q*S+U,W-Y.[/]\60_\61a\62c\63e\64g\65i\66k\67m8o9q:s"+
		";u\2\3\2\13\5\2\13\r\17\17\"\"\3\2$$\3\2bb\3\2__\5\2C\\aac|\6\2\62;C\\"+
		"aac|\3\2))\4\2--//\3\2\62;\2\u01a7\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2"+
		"\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3"+
		"\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2"+
		"\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2"+
		"\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2"+
		"\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2"+
		"\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2"+
		"O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2U\3\2\2\2\2W\3\2\2\2\2Y\3\2\2\2\2[\3"+
		"\2\2\2\2]\3\2\2\2\2_\3\2\2\2\2a\3\2\2\2\2c\3\2\2\2\2e\3\2\2\2\2g\3\2\2"+
		"\2\2i\3\2\2\2\2k\3\2\2\2\2m\3\2\2\2\2o\3\2\2\2\2q\3\2\2\2\2s\3\2\2\2\3"+
		"w\3\2\2\2\5y\3\2\2\2\7{\3\2\2\2\t}\3\2\2\2\13\177\3\2\2\2\r\u0081\3\2"+
		"\2\2\17\u0083\3\2\2\2\21\u0085\3\2\2\2\23\u0087\3\2\2\2\25\u0089\3\2\2"+
		"\2\27\u008b\3\2\2\2\31\u008e\3\2\2\2\33\u0090\3\2\2\2\35\u0092\3\2\2\2"+
		"\37\u0095\3\2\2\2!\u0098\3\2\2\2#\u009a\3\2\2\2%\u009c\3\2\2\2\'\u009e"+
		"\3\2\2\2)\u00a1\3\2\2\2+\u00a3\3\2\2\2-\u00a6\3\2\2\2/\u00a9\3\2\2\2\61"+
		"\u00ac\3\2\2\2\63\u00af\3\2\2\2\65\u00b2\3\2\2\2\67\u00b5\3\2\2\29\u00b7"+
		"\3\2\2\2;\u00b9\3\2\2\2=\u00c0\3\2\2\2?\u00c9\3\2\2\2A\u00ce\3\2\2\2C"+
		"\u00d1\3\2\2\2E\u00d6\3\2\2\2G\u00db\3\2\2\2I\u00e1\3\2\2\2K\u00e7\3\2"+
		"\2\2M\u00eb\3\2\2\2O\u00ee\3\2\2\2Q\u00f1\3\2\2\2S\u00f5\3\2\2\2U\u00fa"+
		"\3\2\2\2W\u0100\3\2\2\2Y\u0103\3\2\2\2[\u010a\3\2\2\2]\u010d\3\2\2\2_"+
		"\u0113\3\2\2\2a\u0117\3\2\2\2c\u011c\3\2\2\2e\u0122\3\2\2\2g\u0129\3\2"+
		"\2\2i\u012d\3\2\2\2k\u0136\3\2\2\2m\u015d\3\2\2\2o\u015f\3\2\2\2q\u016a"+
		"\3\2\2\2s\u0186\3\2\2\2u\u0193\3\2\2\2wx\7=\2\2x\4\3\2\2\2yz\7\60\2\2"+
		"z\6\3\2\2\2{|\7*\2\2|\b\3\2\2\2}~\7+\2\2~\n\3\2\2\2\177\u0080\7.\2\2\u0080"+
		"\f\3\2\2\2\u0081\u0082\7?\2\2\u0082\16\3\2\2\2\u0083\u0084\7,\2\2\u0084"+
		"\20\3\2\2\2\u0085\u0086\7-\2\2\u0086\22\3\2\2\2\u0087\u0088\7/\2\2\u0088"+
		"\24\3\2\2\2\u0089\u008a\7\u0080\2\2\u008a\26\3\2\2\2\u008b\u008c\7~\2"+
		"\2\u008c\u008d\7~\2\2\u008d\30\3\2\2\2\u008e\u008f\7\61\2\2\u008f\32\3"+
		"\2\2\2\u0090\u0091\7\'\2\2\u0091\34\3\2\2\2\u0092\u0093\7>\2\2\u0093\u0094"+
		"\7>\2\2\u0094\36\3\2\2\2\u0095\u0096\7@\2\2\u0096\u0097\7@\2\2\u0097 "+
		"\3\2\2\2\u0098\u0099\7(\2\2\u0099\"\3\2\2\2\u009a\u009b\7~\2\2\u009b$"+
		"\3\2\2\2\u009c\u009d\7>\2\2\u009d&\3\2\2\2\u009e\u009f\7>\2\2\u009f\u00a0"+
		"\7?\2\2\u00a0(\3\2\2\2\u00a1\u00a2\7@\2\2\u00a2*\3\2\2\2\u00a3\u00a4\7"+
		"@\2\2\u00a4\u00a5\7?\2\2\u00a5,\3\2\2\2\u00a6\u00a7\7?\2\2\u00a7\u00a8"+
		"\7?\2\2\u00a8.\3\2\2\2\u00a9\u00aa\7#\2\2\u00aa\u00ab\7?\2\2\u00ab\60"+
		"\3\2\2\2\u00ac\u00ad\7>\2\2\u00ad\u00ae\7@\2\2\u00ae\62\3\2\2\2\u00af"+
		"\u00b0\7#\2\2\u00b0\u00b1\7>\2\2\u00b1\64\3\2\2\2\u00b2\u00b3\7#\2\2\u00b3"+
		"\u00b4\7@\2\2\u00b4\66\3\2\2\2\u00b5\u00b6\7`\2\2\u00b68\3\2\2\2\u00b7"+
		"\u00b8\7#\2\2\u00b8:\3\2\2\2\u00b9\u00ba\7U\2\2\u00ba\u00bb\7G\2\2\u00bb"+
		"\u00bc\7N\2\2\u00bc\u00bd\7G\2\2\u00bd\u00be\7E\2\2\u00be\u00bf\7V\2\2"+
		"\u00bf<\3\2\2\2\u00c0\u00c1\7F\2\2\u00c1\u00c2\7K\2\2\u00c2\u00c3\7U\2"+
		"\2\u00c3\u00c4\7V\2\2\u00c4\u00c5\7K\2\2\u00c5\u00c6\7P\2\2\u00c6\u00c7"+
		"\7E\2\2\u00c7\u00c8\7V\2\2\u00c8>\3\2\2\2\u00c9\u00ca\7H\2\2\u00ca\u00cb"+
		"\7T\2\2\u00cb\u00cc\7Q\2\2\u00cc\u00cd\7O\2\2\u00cd@\3\2\2\2\u00ce\u00cf"+
		"\7C\2\2\u00cf\u00d0\7U\2\2\u00d0B\3\2\2\2\u00d1\u00d2\7P\2\2\u00d2\u00d3"+
		"\7W\2\2\u00d3\u00d4\7N\2\2\u00d4\u00d5\7N\2\2\u00d5D\3\2\2\2\u00d6\u00d7"+
		"\7V\2\2\u00d7\u00d8\7T\2\2\u00d8\u00d9\7W\2\2\u00d9\u00da\7G\2\2\u00da"+
		"F\3\2\2\2\u00db\u00dc\7H\2\2\u00dc\u00dd\7C\2\2\u00dd\u00de\7N\2\2\u00de"+
		"\u00df\7U\2\2\u00df\u00e0\7G\2\2\u00e0H\3\2\2\2\u00e1\u00e2\7Y\2\2\u00e2"+
		"\u00e3\7J\2\2\u00e3\u00e4\7G\2\2\u00e4\u00e5\7T\2\2\u00e5\u00e6\7G\2\2"+
		"\u00e6J\3\2\2\2\u00e7\u00e8\7C\2\2\u00e8\u00e9\7P\2\2\u00e9\u00ea\7F\2"+
		"\2\u00eaL\3\2\2\2\u00eb\u00ec\7Q\2\2\u00ec\u00ed\7T\2\2\u00edN\3\2\2\2"+
		"\u00ee\u00ef\7K\2\2\u00ef\u00f0\7U\2\2\u00f0P\3\2\2\2\u00f1\u00f2\7P\2"+
		"\2\u00f2\u00f3\7Q\2\2\u00f3\u00f4\7V\2\2\u00f4R\3\2\2\2\u00f5\u00f6\7"+
		"N\2\2\u00f6\u00f7\7K\2\2\u00f7\u00f8\7M\2\2\u00f8\u00f9\7G\2\2\u00f9T"+
		"\3\2\2\2\u00fa\u00fb\7I\2\2\u00fb\u00fc\7T\2\2\u00fc\u00fd\7Q\2\2\u00fd"+
		"\u00fe\7W\2\2\u00fe\u00ff\7R\2\2\u00ffV\3\2\2\2\u0100\u0101\7D\2\2\u0101"+
		"\u0102\7[\2\2\u0102X\3\2\2\2\u0103\u0104\7J\2\2\u0104\u0105\7C\2\2\u0105"+
		"\u0106\7X\2\2\u0106\u0107\7K\2\2\u0107\u0108\7P\2\2\u0108\u0109\7I\2\2"+
		"\u0109Z\3\2\2\2\u010a\u010b\7K\2\2\u010b\u010c\7P\2\2\u010c\\\3\2\2\2"+
		"\u010d\u010e\7Q\2\2\u010e\u010f\7T\2\2\u010f\u0110\7F\2\2\u0110\u0111"+
		"\7G\2\2\u0111\u0112\7T\2\2\u0112^\3\2\2\2\u0113\u0114\7C\2\2\u0114\u0115"+
		"\7U\2\2\u0115\u0116\7E\2\2\u0116`\3\2\2\2\u0117\u0118\7F\2\2\u0118\u0119"+
		"\7G\2\2\u0119\u011a\7U\2\2\u011a\u011b\7E\2\2\u011bb\3\2\2\2\u011c\u011d"+
		"\7N\2\2\u011d\u011e\7K\2\2\u011e\u011f\7O\2\2\u011f\u0120\7K\2\2\u0120"+
		"\u0121\7V\2\2\u0121d\3\2\2\2\u0122\u0123\7Q\2\2\u0123\u0124\7H\2\2\u0124"+
		"\u0125\7H\2\2\u0125\u0126\7U\2\2\u0126\u0127\7G\2\2\u0127\u0128\7V\2\2"+
		"\u0128f\3\2\2\2\u0129\u012a\7U\2\2\u012a\u012b\7G\2\2\u012b\u012c\7V\2"+
		"\2\u012ch\3\2\2\2\u012d\u012e\7E\2\2\u012e\u012f\7Q\2\2\u012f\u0130\7"+
		"P\2\2\u0130\u0131\7V\2\2\u0131\u0132\7C\2\2\u0132\u0133\7K\2\2\u0133\u0134"+
		"\7P\2\2\u0134\u0135\7U\2\2\u0135j\3\2\2\2\u0136\u0137\t\2\2\2\u0137\u0138"+
		"\3\2\2\2\u0138\u0139\b\66\2\2\u0139l\3\2\2\2\u013a\u0140\7$\2\2\u013b"+
		"\u013f\n\3\2\2\u013c\u013d\7$\2\2\u013d\u013f\7$\2\2\u013e\u013b\3\2\2"+
		"\2\u013e\u013c\3\2\2\2\u013f\u0142\3\2\2\2\u0140\u013e\3\2\2\2\u0140\u0141"+
		"\3\2\2\2\u0141\u0143\3\2\2\2\u0142\u0140\3\2\2\2\u0143\u015e\7$\2\2\u0144"+
		"\u014a\7b\2\2\u0145\u0149\n\4\2\2\u0146\u0147\7b\2\2\u0147\u0149\7b\2"+
		"\2\u0148\u0145\3\2\2\2\u0148\u0146\3\2\2\2\u0149\u014c\3\2\2\2\u014a\u0148"+
		"\3\2\2\2\u014a\u014b\3\2\2\2\u014b\u014d\3\2\2\2\u014c\u014a\3\2\2\2\u014d"+
		"\u015e\7b\2\2\u014e\u0152\7]\2\2\u014f\u0151\n\5\2\2\u0150\u014f\3\2\2"+
		"\2\u0151\u0154\3\2\2\2\u0152\u0150\3\2\2\2\u0152\u0153\3\2\2\2\u0153\u0155"+
		"\3\2\2\2\u0154\u0152\3\2\2\2\u0155\u015e\7_\2\2\u0156\u015a\t\6\2\2\u0157"+
		"\u0159\t\7\2\2\u0158\u0157\3\2\2\2\u0159\u015c\3\2\2\2\u015a\u0158\3\2"+
		"\2\2\u015a\u015b\3\2\2\2\u015b\u015e\3\2\2\2\u015c\u015a\3\2\2\2\u015d"+
		"\u013a\3\2\2\2\u015d\u0144\3\2\2\2\u015d\u014e\3\2\2\2\u015d\u0156\3\2"+
		"\2\2\u015en\3\2\2\2\u015f\u0165\7)\2\2\u0160\u0164\n\b\2\2\u0161\u0162"+
		"\7)\2\2\u0162\u0164\7)\2\2\u0163\u0160\3\2\2\2\u0163\u0161\3\2\2\2\u0164"+
		"\u0167\3\2\2\2\u0165\u0163\3\2\2\2\u0165\u0166\3\2\2\2\u0166\u0168\3\2"+
		"\2\2\u0167\u0165\3\2\2\2\u0168\u0169\7)\2\2\u0169p\3\2\2\2\u016a\u016b"+
		"\7B\2\2\u016b\u016f\t\6\2\2\u016c\u016e\t\7\2\2\u016d\u016c\3\2\2\2\u016e"+
		"\u0171\3\2\2\2\u016f\u016d\3\2\2\2\u016f\u0170\3\2\2\2\u0170r\3\2\2\2"+
		"\u0171\u016f\3\2\2\2\u0172\u0174\5u;\2\u0173\u0172\3\2\2\2\u0174\u0175"+
		"\3\2\2\2\u0175\u0173\3\2\2\2\u0175\u0176\3\2\2\2\u0176\u017e\3\2\2\2\u0177"+
		"\u017b\7\60\2\2\u0178\u017a\5u;\2\u0179\u0178\3\2\2\2\u017a\u017d\3\2"+
		"\2\2\u017b\u0179\3\2\2\2\u017b\u017c\3\2\2\2\u017c\u017f\3\2\2\2\u017d"+
		"\u017b\3\2\2\2\u017e\u0177\3\2\2\2\u017e\u017f\3\2\2\2\u017f\u0187\3\2"+
		"\2\2\u0180\u0182\7\60\2\2\u0181\u0183\5u;\2\u0182\u0181\3\2\2\2\u0183"+
		"\u0184\3\2\2\2\u0184\u0182\3\2\2\2\u0184\u0185\3\2\2\2\u0185\u0187\3\2"+
		"\2\2\u0186\u0173\3\2\2\2\u0186\u0180\3\2\2\2\u0187\u0191\3\2\2\2\u0188"+
		"\u018a\7G\2\2\u0189\u018b\t\t\2\2\u018a\u0189\3\2\2\2\u018a\u018b\3\2"+
		"\2\2\u018b\u018d\3\2\2\2\u018c\u018e\5u;\2\u018d\u018c\3\2\2\2\u018e\u018f"+
		"\3\2\2\2\u018f\u018d\3\2\2\2\u018f\u0190\3\2\2\2\u0190\u0192\3\2\2\2\u0191"+
		"\u0188\3\2\2\2\u0191\u0192\3\2\2\2\u0192t\3\2\2\2\u0193\u0194\t\n\2\2"+
		"\u0194v\3\2\2\2\25\2\u013e\u0140\u0148\u014a\u0152\u015a\u015d\u0163\u0165"+
		"\u016f\u0175\u017b\u017e\u0184\u0186\u018a\u018f\u0191\3\2\3\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}