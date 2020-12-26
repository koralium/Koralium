//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ./KoraliumLexer.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class KoraliumLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SCOL=1, DOT=2, OPEN_PAR=3, CLOSE_PAR=4, COMMA=5, ASSIGN=6, STAR=7, PLUS=8, 
		MINUS=9, TILDE=10, PIPE2=11, DIV=12, MOD=13, LT2=14, GT2=15, AMP=16, PIPE=17, 
		LT=18, LT_EQ=19, GT=20, GT_EQ=21, EQ=22, NOT_EQ1=23, NOT_EQ2=24, NLT=25, 
		NGT=26, XOR=27, EXCLAMATION=28, SELECT=29, DISTINCT=30, FROM=31, AS=32, 
		NULL=33, TRUE=34, FALSE=35, WHERE=36, AND=37, OR=38, IS=39, NOT=40, LIKE=41, 
		GROUP=42, BY=43, HAVING=44, IN=45, ORDER=46, ASC=47, DESC=48, LIMIT=49, 
		OFFSET=50, SET=51, CONTAINS=52, SPACES=53, IDENTIFIER=54, COMMENT=55, 
		BASE64_LITERAL=56, STRING_LITERAL=57, VARIABLE_ID=58, NUMERIC_LITERAL=59;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"SCOL", "DOT", "OPEN_PAR", "CLOSE_PAR", "COMMA", "ASSIGN", "STAR", "PLUS", 
		"MINUS", "TILDE", "PIPE2", "DIV", "MOD", "LT2", "GT2", "AMP", "PIPE", 
		"LT", "LT_EQ", "GT", "GT_EQ", "EQ", "NOT_EQ1", "NOT_EQ2", "NLT", "NGT", 
		"XOR", "EXCLAMATION", "SELECT", "DISTINCT", "FROM", "AS", "NULL", "TRUE", 
		"FALSE", "WHERE", "AND", "OR", "IS", "NOT", "LIKE", "GROUP", "BY", "HAVING", 
		"IN", "ORDER", "ASC", "DESC", "LIMIT", "OFFSET", "SET", "CONTAINS", "SPACES", 
		"IDENTIFIER", "COMMENT", "BASE64_LITERAL", "STRING_LITERAL", "VARIABLE_ID", 
		"NUMERIC_LITERAL", "DIGIT"
	};


	public KoraliumLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public KoraliumLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "';'", "'.'", "'('", "')'", "','", "'='", "'*'", "'+'", "'-'", "'~'", 
		"'||'", "'/'", "'%'", "'<<'", "'>>'", "'&'", "'|'", "'<'", "'<='", "'>'", 
		"'>='", "'=='", "'!='", "'<>'", "'!<'", "'!>'", "'^'", "'!'", "'SELECT'", 
		"'DISTINCT'", "'FROM'", "'AS'", "'NULL'", "'TRUE'", "'FALSE'", "'WHERE'", 
		"'AND'", "'OR'", "'IS'", "'NOT'", "'LIKE'", "'GROUP'", "'BY'", "'HAVING'", 
		"'IN'", "'ORDER'", "'ASC'", "'DESC'", "'LIMIT'", "'OFFSET'", "'SET'", 
		"'CONTAINS'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SCOL", "DOT", "OPEN_PAR", "CLOSE_PAR", "COMMA", "ASSIGN", "STAR", 
		"PLUS", "MINUS", "TILDE", "PIPE2", "DIV", "MOD", "LT2", "GT2", "AMP", 
		"PIPE", "LT", "LT_EQ", "GT", "GT_EQ", "EQ", "NOT_EQ1", "NOT_EQ2", "NLT", 
		"NGT", "XOR", "EXCLAMATION", "SELECT", "DISTINCT", "FROM", "AS", "NULL", 
		"TRUE", "FALSE", "WHERE", "AND", "OR", "IS", "NOT", "LIKE", "GROUP", "BY", 
		"HAVING", "IN", "ORDER", "ASC", "DESC", "LIMIT", "OFFSET", "SET", "CONTAINS", 
		"SPACES", "IDENTIFIER", "COMMENT", "BASE64_LITERAL", "STRING_LITERAL", 
		"VARIABLE_ID", "NUMERIC_LITERAL"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "KoraliumLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static KoraliumLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '=', '\x1AB', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', '/', '\t', '/', 
		'\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', '\x4', '\x32', 
		'\t', '\x32', '\x4', '\x33', '\t', '\x33', '\x4', '\x34', '\t', '\x34', 
		'\x4', '\x35', '\t', '\x35', '\x4', '\x36', '\t', '\x36', '\x4', '\x37', 
		'\t', '\x37', '\x4', '\x38', '\t', '\x38', '\x4', '\x39', '\t', '\x39', 
		'\x4', ':', '\t', ':', '\x4', ';', '\t', ';', '\x4', '<', '\t', '<', '\x4', 
		'=', '\t', '=', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', 
		'\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', 
		'\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', 
		'\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', 
		'\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', 
		'\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', 
		'\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', 
		'\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', 
		'\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '\"', '\x3', '\"', 
		'\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '#', '\x3', '#', '\x3', 
		'#', '\x3', '#', '\x3', '#', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', 
		'$', '\x3', '$', '\x3', '$', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', 
		'%', '\x3', '%', '\x3', '%', '\x3', '&', '\x3', '&', '\x3', '&', '\x3', 
		'&', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '(', '\x3', '(', '\x3', 
		'(', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', '*', '\x3', 
		'*', '\x3', '*', '\x3', '*', '\x3', '*', '\x3', '+', '\x3', '+', '\x3', 
		'+', '\x3', '+', '\x3', '+', '\x3', '+', '\x3', ',', '\x3', ',', '\x3', 
		',', '\x3', '-', '\x3', '-', '\x3', '-', '\x3', '-', '\x3', '-', '\x3', 
		'-', '\x3', '-', '\x3', '.', '\x3', '.', '\x3', '.', '\x3', '/', '\x3', 
		'/', '\x3', '/', '\x3', '/', '\x3', '/', '\x3', '/', '\x3', '\x30', '\x3', 
		'\x30', '\x3', '\x30', '\x3', '\x30', '\x3', '\x31', '\x3', '\x31', '\x3', 
		'\x31', '\x3', '\x31', '\x3', '\x31', '\x3', '\x32', '\x3', '\x32', '\x3', 
		'\x32', '\x3', '\x32', '\x3', '\x32', '\x3', '\x32', '\x3', '\x33', '\x3', 
		'\x33', '\x3', '\x33', '\x3', '\x33', '\x3', '\x33', '\x3', '\x33', '\x3', 
		'\x33', '\x3', '\x34', '\x3', '\x34', '\x3', '\x34', '\x3', '\x34', '\x3', 
		'\x35', '\x3', '\x35', '\x3', '\x35', '\x3', '\x35', '\x3', '\x35', '\x3', 
		'\x35', '\x3', '\x35', '\x3', '\x35', '\x3', '\x35', '\x3', '\x36', '\x3', 
		'\x36', '\x3', '\x36', '\x3', '\x36', '\x3', '\x37', '\x3', '\x37', '\x3', 
		'\x37', '\x3', '\x37', '\a', '\x37', '\x143', '\n', '\x37', '\f', '\x37', 
		'\xE', '\x37', '\x146', '\v', '\x37', '\x3', '\x37', '\x3', '\x37', '\x3', 
		'\x37', '\x3', '\x37', '\x3', '\x37', '\a', '\x37', '\x14D', '\n', '\x37', 
		'\f', '\x37', '\xE', '\x37', '\x150', '\v', '\x37', '\x3', '\x37', '\x3', 
		'\x37', '\x3', '\x37', '\a', '\x37', '\x155', '\n', '\x37', '\f', '\x37', 
		'\xE', '\x37', '\x158', '\v', '\x37', '\x3', '\x37', '\x3', '\x37', '\x3', 
		'\x37', '\a', '\x37', '\x15D', '\n', '\x37', '\f', '\x37', '\xE', '\x37', 
		'\x160', '\v', '\x37', '\x5', '\x37', '\x162', '\n', '\x37', '\x3', '\x38', 
		'\x3', '\x38', '\x3', '\x38', '\x3', '\x38', '\a', '\x38', '\x168', '\n', 
		'\x38', '\f', '\x38', '\xE', '\x38', '\x16B', '\v', '\x38', '\x3', '\x39', 
		'\x3', '\x39', '\x3', '\x39', '\x3', '\x39', '\x3', '\x39', '\x3', '\x39', 
		'\x3', ':', '\x3', ':', '\x3', ':', '\x3', ':', '\a', ':', '\x177', '\n', 
		':', '\f', ':', '\xE', ':', '\x17A', '\v', ':', '\x3', ':', '\x3', ':', 
		'\x3', ';', '\x3', ';', '\x3', ';', '\a', ';', '\x181', '\n', ';', '\f', 
		';', '\xE', ';', '\x184', '\v', ';', '\x3', '<', '\x5', '<', '\x187', 
		'\n', '<', '\x3', '<', '\x6', '<', '\x18A', '\n', '<', '\r', '<', '\xE', 
		'<', '\x18B', '\x3', '<', '\x3', '<', '\a', '<', '\x190', '\n', '<', '\f', 
		'<', '\xE', '<', '\x193', '\v', '<', '\x5', '<', '\x195', '\n', '<', '\x3', 
		'<', '\x3', '<', '\x6', '<', '\x199', '\n', '<', '\r', '<', '\xE', '<', 
		'\x19A', '\x5', '<', '\x19D', '\n', '<', '\x3', '<', '\x3', '<', '\x5', 
		'<', '\x1A1', '\n', '<', '\x3', '<', '\x6', '<', '\x1A4', '\n', '<', '\r', 
		'<', '\xE', '<', '\x1A5', '\x5', '<', '\x1A8', '\n', '<', '\x3', '=', 
		'\x3', '=', '\x2', '\x2', '>', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', 
		'\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', 
		'\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', 
		'\x10', '\x1F', '\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', 
		')', '\x16', '+', '\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', 
		'\x1B', '\x35', '\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', 
		' ', '?', '!', '\x41', '\"', '\x43', '#', '\x45', '$', 'G', '%', 'I', 
		'&', 'K', '\'', 'M', '(', 'O', ')', 'Q', '*', 'S', '+', 'U', ',', 'W', 
		'-', 'Y', '.', '[', '/', ']', '\x30', '_', '\x31', '\x61', '\x32', '\x63', 
		'\x33', '\x65', '\x34', 'g', '\x35', 'i', '\x36', 'k', '\x37', 'm', '\x38', 
		'o', '\x39', 'q', ':', 's', ';', 'u', '<', 'w', '=', 'y', '\x2', '\x3', 
		'\x2', '\f', '\x5', '\x2', '\v', '\r', '\xF', '\xF', '\"', '\"', '\x3', 
		'\x2', '$', '$', '\x3', '\x2', '\x62', '\x62', '\x3', '\x2', '_', '_', 
		'\x5', '\x2', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x6', '\x2', 
		'\x32', ';', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x4', '\x2', 
		'\f', '\f', '\xF', '\xF', '\x3', '\x2', ')', ')', '\x4', '\x2', '-', '-', 
		'/', '/', '\x3', '\x2', '\x32', ';', '\x2', '\x1BF', '\x2', '\x3', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x2', '\x45', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'G', '\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'K', '\x3', '\x2', '\x2', '\x2', '\x2', 'M', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'Q', '\x3', '\x2', '\x2', '\x2', '\x2', 'S', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'U', '\x3', '\x2', '\x2', '\x2', '\x2', 'W', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'Y', '\x3', '\x2', '\x2', '\x2', '\x2', '[', '\x3', '\x2', 
		'\x2', '\x2', '\x2', ']', '\x3', '\x2', '\x2', '\x2', '\x2', '_', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x61', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x63', '\x3', '\x2', '\x2', '\x2', '\x2', '\x65', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'g', '\x3', '\x2', '\x2', '\x2', '\x2', 'i', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'k', '\x3', '\x2', '\x2', '\x2', '\x2', 'm', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'o', '\x3', '\x2', '\x2', '\x2', '\x2', 'q', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 's', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'u', '\x3', '\x2', '\x2', '\x2', '\x2', 'w', '\x3', '\x2', '\x2', '\x2', 
		'\x3', '{', '\x3', '\x2', '\x2', '\x2', '\x5', '}', '\x3', '\x2', '\x2', 
		'\x2', '\a', '\x7F', '\x3', '\x2', '\x2', '\x2', '\t', '\x81', '\x3', 
		'\x2', '\x2', '\x2', '\v', '\x83', '\x3', '\x2', '\x2', '\x2', '\r', '\x85', 
		'\x3', '\x2', '\x2', '\x2', '\xF', '\x87', '\x3', '\x2', '\x2', '\x2', 
		'\x11', '\x89', '\x3', '\x2', '\x2', '\x2', '\x13', '\x8B', '\x3', '\x2', 
		'\x2', '\x2', '\x15', '\x8D', '\x3', '\x2', '\x2', '\x2', '\x17', '\x8F', 
		'\x3', '\x2', '\x2', '\x2', '\x19', '\x92', '\x3', '\x2', '\x2', '\x2', 
		'\x1B', '\x94', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x96', '\x3', '\x2', 
		'\x2', '\x2', '\x1F', '\x99', '\x3', '\x2', '\x2', '\x2', '!', '\x9C', 
		'\x3', '\x2', '\x2', '\x2', '#', '\x9E', '\x3', '\x2', '\x2', '\x2', '%', 
		'\xA0', '\x3', '\x2', '\x2', '\x2', '\'', '\xA2', '\x3', '\x2', '\x2', 
		'\x2', ')', '\xA5', '\x3', '\x2', '\x2', '\x2', '+', '\xA7', '\x3', '\x2', 
		'\x2', '\x2', '-', '\xAA', '\x3', '\x2', '\x2', '\x2', '/', '\xAD', '\x3', 
		'\x2', '\x2', '\x2', '\x31', '\xB0', '\x3', '\x2', '\x2', '\x2', '\x33', 
		'\xB3', '\x3', '\x2', '\x2', '\x2', '\x35', '\xB6', '\x3', '\x2', '\x2', 
		'\x2', '\x37', '\xB9', '\x3', '\x2', '\x2', '\x2', '\x39', '\xBB', '\x3', 
		'\x2', '\x2', '\x2', ';', '\xBD', '\x3', '\x2', '\x2', '\x2', '=', '\xC4', 
		'\x3', '\x2', '\x2', '\x2', '?', '\xCD', '\x3', '\x2', '\x2', '\x2', '\x41', 
		'\xD2', '\x3', '\x2', '\x2', '\x2', '\x43', '\xD5', '\x3', '\x2', '\x2', 
		'\x2', '\x45', '\xDA', '\x3', '\x2', '\x2', '\x2', 'G', '\xDF', '\x3', 
		'\x2', '\x2', '\x2', 'I', '\xE5', '\x3', '\x2', '\x2', '\x2', 'K', '\xEB', 
		'\x3', '\x2', '\x2', '\x2', 'M', '\xEF', '\x3', '\x2', '\x2', '\x2', 'O', 
		'\xF2', '\x3', '\x2', '\x2', '\x2', 'Q', '\xF5', '\x3', '\x2', '\x2', 
		'\x2', 'S', '\xF9', '\x3', '\x2', '\x2', '\x2', 'U', '\xFE', '\x3', '\x2', 
		'\x2', '\x2', 'W', '\x104', '\x3', '\x2', '\x2', '\x2', 'Y', '\x107', 
		'\x3', '\x2', '\x2', '\x2', '[', '\x10E', '\x3', '\x2', '\x2', '\x2', 
		']', '\x111', '\x3', '\x2', '\x2', '\x2', '_', '\x117', '\x3', '\x2', 
		'\x2', '\x2', '\x61', '\x11B', '\x3', '\x2', '\x2', '\x2', '\x63', '\x120', 
		'\x3', '\x2', '\x2', '\x2', '\x65', '\x126', '\x3', '\x2', '\x2', '\x2', 
		'g', '\x12D', '\x3', '\x2', '\x2', '\x2', 'i', '\x131', '\x3', '\x2', 
		'\x2', '\x2', 'k', '\x13A', '\x3', '\x2', '\x2', '\x2', 'm', '\x161', 
		'\x3', '\x2', '\x2', '\x2', 'o', '\x163', '\x3', '\x2', '\x2', '\x2', 
		'q', '\x16C', '\x3', '\x2', '\x2', '\x2', 's', '\x172', '\x3', '\x2', 
		'\x2', '\x2', 'u', '\x17D', '\x3', '\x2', '\x2', '\x2', 'w', '\x186', 
		'\x3', '\x2', '\x2', '\x2', 'y', '\x1A9', '\x3', '\x2', '\x2', '\x2', 
		'{', '|', '\a', '=', '\x2', '\x2', '|', '\x4', '\x3', '\x2', '\x2', '\x2', 
		'}', '~', '\a', '\x30', '\x2', '\x2', '~', '\x6', '\x3', '\x2', '\x2', 
		'\x2', '\x7F', '\x80', '\a', '*', '\x2', '\x2', '\x80', '\b', '\x3', '\x2', 
		'\x2', '\x2', '\x81', '\x82', '\a', '+', '\x2', '\x2', '\x82', '\n', '\x3', 
		'\x2', '\x2', '\x2', '\x83', '\x84', '\a', '.', '\x2', '\x2', '\x84', 
		'\f', '\x3', '\x2', '\x2', '\x2', '\x85', '\x86', '\a', '?', '\x2', '\x2', 
		'\x86', '\xE', '\x3', '\x2', '\x2', '\x2', '\x87', '\x88', '\a', ',', 
		'\x2', '\x2', '\x88', '\x10', '\x3', '\x2', '\x2', '\x2', '\x89', '\x8A', 
		'\a', '-', '\x2', '\x2', '\x8A', '\x12', '\x3', '\x2', '\x2', '\x2', '\x8B', 
		'\x8C', '\a', '/', '\x2', '\x2', '\x8C', '\x14', '\x3', '\x2', '\x2', 
		'\x2', '\x8D', '\x8E', '\a', '\x80', '\x2', '\x2', '\x8E', '\x16', '\x3', 
		'\x2', '\x2', '\x2', '\x8F', '\x90', '\a', '~', '\x2', '\x2', '\x90', 
		'\x91', '\a', '~', '\x2', '\x2', '\x91', '\x18', '\x3', '\x2', '\x2', 
		'\x2', '\x92', '\x93', '\a', '\x31', '\x2', '\x2', '\x93', '\x1A', '\x3', 
		'\x2', '\x2', '\x2', '\x94', '\x95', '\a', '\'', '\x2', '\x2', '\x95', 
		'\x1C', '\x3', '\x2', '\x2', '\x2', '\x96', '\x97', '\a', '>', '\x2', 
		'\x2', '\x97', '\x98', '\a', '>', '\x2', '\x2', '\x98', '\x1E', '\x3', 
		'\x2', '\x2', '\x2', '\x99', '\x9A', '\a', '@', '\x2', '\x2', '\x9A', 
		'\x9B', '\a', '@', '\x2', '\x2', '\x9B', ' ', '\x3', '\x2', '\x2', '\x2', 
		'\x9C', '\x9D', '\a', '(', '\x2', '\x2', '\x9D', '\"', '\x3', '\x2', '\x2', 
		'\x2', '\x9E', '\x9F', '\a', '~', '\x2', '\x2', '\x9F', '$', '\x3', '\x2', 
		'\x2', '\x2', '\xA0', '\xA1', '\a', '>', '\x2', '\x2', '\xA1', '&', '\x3', 
		'\x2', '\x2', '\x2', '\xA2', '\xA3', '\a', '>', '\x2', '\x2', '\xA3', 
		'\xA4', '\a', '?', '\x2', '\x2', '\xA4', '(', '\x3', '\x2', '\x2', '\x2', 
		'\xA5', '\xA6', '\a', '@', '\x2', '\x2', '\xA6', '*', '\x3', '\x2', '\x2', 
		'\x2', '\xA7', '\xA8', '\a', '@', '\x2', '\x2', '\xA8', '\xA9', '\a', 
		'?', '\x2', '\x2', '\xA9', ',', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xAB', 
		'\a', '?', '\x2', '\x2', '\xAB', '\xAC', '\a', '?', '\x2', '\x2', '\xAC', 
		'.', '\x3', '\x2', '\x2', '\x2', '\xAD', '\xAE', '\a', '#', '\x2', '\x2', 
		'\xAE', '\xAF', '\a', '?', '\x2', '\x2', '\xAF', '\x30', '\x3', '\x2', 
		'\x2', '\x2', '\xB0', '\xB1', '\a', '>', '\x2', '\x2', '\xB1', '\xB2', 
		'\a', '@', '\x2', '\x2', '\xB2', '\x32', '\x3', '\x2', '\x2', '\x2', '\xB3', 
		'\xB4', '\a', '#', '\x2', '\x2', '\xB4', '\xB5', '\a', '>', '\x2', '\x2', 
		'\xB5', '\x34', '\x3', '\x2', '\x2', '\x2', '\xB6', '\xB7', '\a', '#', 
		'\x2', '\x2', '\xB7', '\xB8', '\a', '@', '\x2', '\x2', '\xB8', '\x36', 
		'\x3', '\x2', '\x2', '\x2', '\xB9', '\xBA', '\a', '`', '\x2', '\x2', '\xBA', 
		'\x38', '\x3', '\x2', '\x2', '\x2', '\xBB', '\xBC', '\a', '#', '\x2', 
		'\x2', '\xBC', ':', '\x3', '\x2', '\x2', '\x2', '\xBD', '\xBE', '\a', 
		'U', '\x2', '\x2', '\xBE', '\xBF', '\a', 'G', '\x2', '\x2', '\xBF', '\xC0', 
		'\a', 'N', '\x2', '\x2', '\xC0', '\xC1', '\a', 'G', '\x2', '\x2', '\xC1', 
		'\xC2', '\a', '\x45', '\x2', '\x2', '\xC2', '\xC3', '\a', 'V', '\x2', 
		'\x2', '\xC3', '<', '\x3', '\x2', '\x2', '\x2', '\xC4', '\xC5', '\a', 
		'\x46', '\x2', '\x2', '\xC5', '\xC6', '\a', 'K', '\x2', '\x2', '\xC6', 
		'\xC7', '\a', 'U', '\x2', '\x2', '\xC7', '\xC8', '\a', 'V', '\x2', '\x2', 
		'\xC8', '\xC9', '\a', 'K', '\x2', '\x2', '\xC9', '\xCA', '\a', 'P', '\x2', 
		'\x2', '\xCA', '\xCB', '\a', '\x45', '\x2', '\x2', '\xCB', '\xCC', '\a', 
		'V', '\x2', '\x2', '\xCC', '>', '\x3', '\x2', '\x2', '\x2', '\xCD', '\xCE', 
		'\a', 'H', '\x2', '\x2', '\xCE', '\xCF', '\a', 'T', '\x2', '\x2', '\xCF', 
		'\xD0', '\a', 'Q', '\x2', '\x2', '\xD0', '\xD1', '\a', 'O', '\x2', '\x2', 
		'\xD1', '@', '\x3', '\x2', '\x2', '\x2', '\xD2', '\xD3', '\a', '\x43', 
		'\x2', '\x2', '\xD3', '\xD4', '\a', 'U', '\x2', '\x2', '\xD4', '\x42', 
		'\x3', '\x2', '\x2', '\x2', '\xD5', '\xD6', '\a', 'P', '\x2', '\x2', '\xD6', 
		'\xD7', '\a', 'W', '\x2', '\x2', '\xD7', '\xD8', '\a', 'N', '\x2', '\x2', 
		'\xD8', '\xD9', '\a', 'N', '\x2', '\x2', '\xD9', '\x44', '\x3', '\x2', 
		'\x2', '\x2', '\xDA', '\xDB', '\a', 'V', '\x2', '\x2', '\xDB', '\xDC', 
		'\a', 'T', '\x2', '\x2', '\xDC', '\xDD', '\a', 'W', '\x2', '\x2', '\xDD', 
		'\xDE', '\a', 'G', '\x2', '\x2', '\xDE', '\x46', '\x3', '\x2', '\x2', 
		'\x2', '\xDF', '\xE0', '\a', 'H', '\x2', '\x2', '\xE0', '\xE1', '\a', 
		'\x43', '\x2', '\x2', '\xE1', '\xE2', '\a', 'N', '\x2', '\x2', '\xE2', 
		'\xE3', '\a', 'U', '\x2', '\x2', '\xE3', '\xE4', '\a', 'G', '\x2', '\x2', 
		'\xE4', 'H', '\x3', '\x2', '\x2', '\x2', '\xE5', '\xE6', '\a', 'Y', '\x2', 
		'\x2', '\xE6', '\xE7', '\a', 'J', '\x2', '\x2', '\xE7', '\xE8', '\a', 
		'G', '\x2', '\x2', '\xE8', '\xE9', '\a', 'T', '\x2', '\x2', '\xE9', '\xEA', 
		'\a', 'G', '\x2', '\x2', '\xEA', 'J', '\x3', '\x2', '\x2', '\x2', '\xEB', 
		'\xEC', '\a', '\x43', '\x2', '\x2', '\xEC', '\xED', '\a', 'P', '\x2', 
		'\x2', '\xED', '\xEE', '\a', '\x46', '\x2', '\x2', '\xEE', 'L', '\x3', 
		'\x2', '\x2', '\x2', '\xEF', '\xF0', '\a', 'Q', '\x2', '\x2', '\xF0', 
		'\xF1', '\a', 'T', '\x2', '\x2', '\xF1', 'N', '\x3', '\x2', '\x2', '\x2', 
		'\xF2', '\xF3', '\a', 'K', '\x2', '\x2', '\xF3', '\xF4', '\a', 'U', '\x2', 
		'\x2', '\xF4', 'P', '\x3', '\x2', '\x2', '\x2', '\xF5', '\xF6', '\a', 
		'P', '\x2', '\x2', '\xF6', '\xF7', '\a', 'Q', '\x2', '\x2', '\xF7', '\xF8', 
		'\a', 'V', '\x2', '\x2', '\xF8', 'R', '\x3', '\x2', '\x2', '\x2', '\xF9', 
		'\xFA', '\a', 'N', '\x2', '\x2', '\xFA', '\xFB', '\a', 'K', '\x2', '\x2', 
		'\xFB', '\xFC', '\a', 'M', '\x2', '\x2', '\xFC', '\xFD', '\a', 'G', '\x2', 
		'\x2', '\xFD', 'T', '\x3', '\x2', '\x2', '\x2', '\xFE', '\xFF', '\a', 
		'I', '\x2', '\x2', '\xFF', '\x100', '\a', 'T', '\x2', '\x2', '\x100', 
		'\x101', '\a', 'Q', '\x2', '\x2', '\x101', '\x102', '\a', 'W', '\x2', 
		'\x2', '\x102', '\x103', '\a', 'R', '\x2', '\x2', '\x103', 'V', '\x3', 
		'\x2', '\x2', '\x2', '\x104', '\x105', '\a', '\x44', '\x2', '\x2', '\x105', 
		'\x106', '\a', '[', '\x2', '\x2', '\x106', 'X', '\x3', '\x2', '\x2', '\x2', 
		'\x107', '\x108', '\a', 'J', '\x2', '\x2', '\x108', '\x109', '\a', '\x43', 
		'\x2', '\x2', '\x109', '\x10A', '\a', 'X', '\x2', '\x2', '\x10A', '\x10B', 
		'\a', 'K', '\x2', '\x2', '\x10B', '\x10C', '\a', 'P', '\x2', '\x2', '\x10C', 
		'\x10D', '\a', 'I', '\x2', '\x2', '\x10D', 'Z', '\x3', '\x2', '\x2', '\x2', 
		'\x10E', '\x10F', '\a', 'K', '\x2', '\x2', '\x10F', '\x110', '\a', 'P', 
		'\x2', '\x2', '\x110', '\\', '\x3', '\x2', '\x2', '\x2', '\x111', '\x112', 
		'\a', 'Q', '\x2', '\x2', '\x112', '\x113', '\a', 'T', '\x2', '\x2', '\x113', 
		'\x114', '\a', '\x46', '\x2', '\x2', '\x114', '\x115', '\a', 'G', '\x2', 
		'\x2', '\x115', '\x116', '\a', 'T', '\x2', '\x2', '\x116', '^', '\x3', 
		'\x2', '\x2', '\x2', '\x117', '\x118', '\a', '\x43', '\x2', '\x2', '\x118', 
		'\x119', '\a', 'U', '\x2', '\x2', '\x119', '\x11A', '\a', '\x45', '\x2', 
		'\x2', '\x11A', '`', '\x3', '\x2', '\x2', '\x2', '\x11B', '\x11C', '\a', 
		'\x46', '\x2', '\x2', '\x11C', '\x11D', '\a', 'G', '\x2', '\x2', '\x11D', 
		'\x11E', '\a', 'U', '\x2', '\x2', '\x11E', '\x11F', '\a', '\x45', '\x2', 
		'\x2', '\x11F', '\x62', '\x3', '\x2', '\x2', '\x2', '\x120', '\x121', 
		'\a', 'N', '\x2', '\x2', '\x121', '\x122', '\a', 'K', '\x2', '\x2', '\x122', 
		'\x123', '\a', 'O', '\x2', '\x2', '\x123', '\x124', '\a', 'K', '\x2', 
		'\x2', '\x124', '\x125', '\a', 'V', '\x2', '\x2', '\x125', '\x64', '\x3', 
		'\x2', '\x2', '\x2', '\x126', '\x127', '\a', 'Q', '\x2', '\x2', '\x127', 
		'\x128', '\a', 'H', '\x2', '\x2', '\x128', '\x129', '\a', 'H', '\x2', 
		'\x2', '\x129', '\x12A', '\a', 'U', '\x2', '\x2', '\x12A', '\x12B', '\a', 
		'G', '\x2', '\x2', '\x12B', '\x12C', '\a', 'V', '\x2', '\x2', '\x12C', 
		'\x66', '\x3', '\x2', '\x2', '\x2', '\x12D', '\x12E', '\a', 'U', '\x2', 
		'\x2', '\x12E', '\x12F', '\a', 'G', '\x2', '\x2', '\x12F', '\x130', '\a', 
		'V', '\x2', '\x2', '\x130', 'h', '\x3', '\x2', '\x2', '\x2', '\x131', 
		'\x132', '\a', '\x45', '\x2', '\x2', '\x132', '\x133', '\a', 'Q', '\x2', 
		'\x2', '\x133', '\x134', '\a', 'P', '\x2', '\x2', '\x134', '\x135', '\a', 
		'V', '\x2', '\x2', '\x135', '\x136', '\a', '\x43', '\x2', '\x2', '\x136', 
		'\x137', '\a', 'K', '\x2', '\x2', '\x137', '\x138', '\a', 'P', '\x2', 
		'\x2', '\x138', '\x139', '\a', 'U', '\x2', '\x2', '\x139', 'j', '\x3', 
		'\x2', '\x2', '\x2', '\x13A', '\x13B', '\t', '\x2', '\x2', '\x2', '\x13B', 
		'\x13C', '\x3', '\x2', '\x2', '\x2', '\x13C', '\x13D', '\b', '\x36', '\x2', 
		'\x2', '\x13D', 'l', '\x3', '\x2', '\x2', '\x2', '\x13E', '\x144', '\a', 
		'$', '\x2', '\x2', '\x13F', '\x143', '\n', '\x3', '\x2', '\x2', '\x140', 
		'\x141', '\a', '$', '\x2', '\x2', '\x141', '\x143', '\a', '$', '\x2', 
		'\x2', '\x142', '\x13F', '\x3', '\x2', '\x2', '\x2', '\x142', '\x140', 
		'\x3', '\x2', '\x2', '\x2', '\x143', '\x146', '\x3', '\x2', '\x2', '\x2', 
		'\x144', '\x142', '\x3', '\x2', '\x2', '\x2', '\x144', '\x145', '\x3', 
		'\x2', '\x2', '\x2', '\x145', '\x147', '\x3', '\x2', '\x2', '\x2', '\x146', 
		'\x144', '\x3', '\x2', '\x2', '\x2', '\x147', '\x162', '\a', '$', '\x2', 
		'\x2', '\x148', '\x14E', '\a', '\x62', '\x2', '\x2', '\x149', '\x14D', 
		'\n', '\x4', '\x2', '\x2', '\x14A', '\x14B', '\a', '\x62', '\x2', '\x2', 
		'\x14B', '\x14D', '\a', '\x62', '\x2', '\x2', '\x14C', '\x149', '\x3', 
		'\x2', '\x2', '\x2', '\x14C', '\x14A', '\x3', '\x2', '\x2', '\x2', '\x14D', 
		'\x150', '\x3', '\x2', '\x2', '\x2', '\x14E', '\x14C', '\x3', '\x2', '\x2', 
		'\x2', '\x14E', '\x14F', '\x3', '\x2', '\x2', '\x2', '\x14F', '\x151', 
		'\x3', '\x2', '\x2', '\x2', '\x150', '\x14E', '\x3', '\x2', '\x2', '\x2', 
		'\x151', '\x162', '\a', '\x62', '\x2', '\x2', '\x152', '\x156', '\a', 
		']', '\x2', '\x2', '\x153', '\x155', '\n', '\x5', '\x2', '\x2', '\x154', 
		'\x153', '\x3', '\x2', '\x2', '\x2', '\x155', '\x158', '\x3', '\x2', '\x2', 
		'\x2', '\x156', '\x154', '\x3', '\x2', '\x2', '\x2', '\x156', '\x157', 
		'\x3', '\x2', '\x2', '\x2', '\x157', '\x159', '\x3', '\x2', '\x2', '\x2', 
		'\x158', '\x156', '\x3', '\x2', '\x2', '\x2', '\x159', '\x162', '\a', 
		'_', '\x2', '\x2', '\x15A', '\x15E', '\t', '\x6', '\x2', '\x2', '\x15B', 
		'\x15D', '\t', '\a', '\x2', '\x2', '\x15C', '\x15B', '\x3', '\x2', '\x2', 
		'\x2', '\x15D', '\x160', '\x3', '\x2', '\x2', '\x2', '\x15E', '\x15C', 
		'\x3', '\x2', '\x2', '\x2', '\x15E', '\x15F', '\x3', '\x2', '\x2', '\x2', 
		'\x15F', '\x162', '\x3', '\x2', '\x2', '\x2', '\x160', '\x15E', '\x3', 
		'\x2', '\x2', '\x2', '\x161', '\x13E', '\x3', '\x2', '\x2', '\x2', '\x161', 
		'\x148', '\x3', '\x2', '\x2', '\x2', '\x161', '\x152', '\x3', '\x2', '\x2', 
		'\x2', '\x161', '\x15A', '\x3', '\x2', '\x2', '\x2', '\x162', 'n', '\x3', 
		'\x2', '\x2', '\x2', '\x163', '\x164', '\a', '/', '\x2', '\x2', '\x164', 
		'\x165', '\a', '/', '\x2', '\x2', '\x165', '\x169', '\x3', '\x2', '\x2', 
		'\x2', '\x166', '\x168', '\n', '\b', '\x2', '\x2', '\x167', '\x166', '\x3', 
		'\x2', '\x2', '\x2', '\x168', '\x16B', '\x3', '\x2', '\x2', '\x2', '\x169', 
		'\x167', '\x3', '\x2', '\x2', '\x2', '\x169', '\x16A', '\x3', '\x2', '\x2', 
		'\x2', '\x16A', 'p', '\x3', '\x2', '\x2', '\x2', '\x16B', '\x169', '\x3', 
		'\x2', '\x2', '\x2', '\x16C', '\x16D', '\a', '\x44', '\x2', '\x2', '\x16D', 
		'\x16E', '\a', '\x38', '\x2', '\x2', '\x16E', '\x16F', '\a', '\x36', '\x2', 
		'\x2', '\x16F', '\x170', '\x3', '\x2', '\x2', '\x2', '\x170', '\x171', 
		'\x5', 's', ':', '\x2', '\x171', 'r', '\x3', '\x2', '\x2', '\x2', '\x172', 
		'\x178', '\a', ')', '\x2', '\x2', '\x173', '\x177', '\n', '\t', '\x2', 
		'\x2', '\x174', '\x175', '\a', ')', '\x2', '\x2', '\x175', '\x177', '\a', 
		')', '\x2', '\x2', '\x176', '\x173', '\x3', '\x2', '\x2', '\x2', '\x176', 
		'\x174', '\x3', '\x2', '\x2', '\x2', '\x177', '\x17A', '\x3', '\x2', '\x2', 
		'\x2', '\x178', '\x176', '\x3', '\x2', '\x2', '\x2', '\x178', '\x179', 
		'\x3', '\x2', '\x2', '\x2', '\x179', '\x17B', '\x3', '\x2', '\x2', '\x2', 
		'\x17A', '\x178', '\x3', '\x2', '\x2', '\x2', '\x17B', '\x17C', '\a', 
		')', '\x2', '\x2', '\x17C', 't', '\x3', '\x2', '\x2', '\x2', '\x17D', 
		'\x17E', '\a', '\x42', '\x2', '\x2', '\x17E', '\x182', '\t', '\x6', '\x2', 
		'\x2', '\x17F', '\x181', '\t', '\a', '\x2', '\x2', '\x180', '\x17F', '\x3', 
		'\x2', '\x2', '\x2', '\x181', '\x184', '\x3', '\x2', '\x2', '\x2', '\x182', 
		'\x180', '\x3', '\x2', '\x2', '\x2', '\x182', '\x183', '\x3', '\x2', '\x2', 
		'\x2', '\x183', 'v', '\x3', '\x2', '\x2', '\x2', '\x184', '\x182', '\x3', 
		'\x2', '\x2', '\x2', '\x185', '\x187', '\a', '/', '\x2', '\x2', '\x186', 
		'\x185', '\x3', '\x2', '\x2', '\x2', '\x186', '\x187', '\x3', '\x2', '\x2', 
		'\x2', '\x187', '\x19C', '\x3', '\x2', '\x2', '\x2', '\x188', '\x18A', 
		'\x5', 'y', '=', '\x2', '\x189', '\x188', '\x3', '\x2', '\x2', '\x2', 
		'\x18A', '\x18B', '\x3', '\x2', '\x2', '\x2', '\x18B', '\x189', '\x3', 
		'\x2', '\x2', '\x2', '\x18B', '\x18C', '\x3', '\x2', '\x2', '\x2', '\x18C', 
		'\x194', '\x3', '\x2', '\x2', '\x2', '\x18D', '\x191', '\a', '\x30', '\x2', 
		'\x2', '\x18E', '\x190', '\x5', 'y', '=', '\x2', '\x18F', '\x18E', '\x3', 
		'\x2', '\x2', '\x2', '\x190', '\x193', '\x3', '\x2', '\x2', '\x2', '\x191', 
		'\x18F', '\x3', '\x2', '\x2', '\x2', '\x191', '\x192', '\x3', '\x2', '\x2', 
		'\x2', '\x192', '\x195', '\x3', '\x2', '\x2', '\x2', '\x193', '\x191', 
		'\x3', '\x2', '\x2', '\x2', '\x194', '\x18D', '\x3', '\x2', '\x2', '\x2', 
		'\x194', '\x195', '\x3', '\x2', '\x2', '\x2', '\x195', '\x19D', '\x3', 
		'\x2', '\x2', '\x2', '\x196', '\x198', '\a', '\x30', '\x2', '\x2', '\x197', 
		'\x199', '\x5', 'y', '=', '\x2', '\x198', '\x197', '\x3', '\x2', '\x2', 
		'\x2', '\x199', '\x19A', '\x3', '\x2', '\x2', '\x2', '\x19A', '\x198', 
		'\x3', '\x2', '\x2', '\x2', '\x19A', '\x19B', '\x3', '\x2', '\x2', '\x2', 
		'\x19B', '\x19D', '\x3', '\x2', '\x2', '\x2', '\x19C', '\x189', '\x3', 
		'\x2', '\x2', '\x2', '\x19C', '\x196', '\x3', '\x2', '\x2', '\x2', '\x19D', 
		'\x1A7', '\x3', '\x2', '\x2', '\x2', '\x19E', '\x1A0', '\a', 'G', '\x2', 
		'\x2', '\x19F', '\x1A1', '\t', '\n', '\x2', '\x2', '\x1A0', '\x19F', '\x3', 
		'\x2', '\x2', '\x2', '\x1A0', '\x1A1', '\x3', '\x2', '\x2', '\x2', '\x1A1', 
		'\x1A3', '\x3', '\x2', '\x2', '\x2', '\x1A2', '\x1A4', '\x5', 'y', '=', 
		'\x2', '\x1A3', '\x1A2', '\x3', '\x2', '\x2', '\x2', '\x1A4', '\x1A5', 
		'\x3', '\x2', '\x2', '\x2', '\x1A5', '\x1A3', '\x3', '\x2', '\x2', '\x2', 
		'\x1A5', '\x1A6', '\x3', '\x2', '\x2', '\x2', '\x1A6', '\x1A8', '\x3', 
		'\x2', '\x2', '\x2', '\x1A7', '\x19E', '\x3', '\x2', '\x2', '\x2', '\x1A7', 
		'\x1A8', '\x3', '\x2', '\x2', '\x2', '\x1A8', 'x', '\x3', '\x2', '\x2', 
		'\x2', '\x1A9', '\x1AA', '\t', '\v', '\x2', '\x2', '\x1AA', 'z', '\x3', 
		'\x2', '\x2', '\x2', '\x17', '\x2', '\x142', '\x144', '\x14C', '\x14E', 
		'\x156', '\x15E', '\x161', '\x169', '\x176', '\x178', '\x182', '\x186', 
		'\x18B', '\x191', '\x194', '\x19A', '\x19C', '\x1A0', '\x1A5', '\x1A7', 
		'\x3', '\x2', '\x3', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
