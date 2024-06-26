//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/ondra/OneDrive/Dokumenty/PJP/Project/Project/Grammar.g4 by ANTLR 4.13.1

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
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class GrammarParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, INT_KEYWORD=5, FLOAT_KEYWORD=6, STRING_KEYWORD=7, 
		BOOL_KEYWORD=8, READ=9, WRITE=10, IF=11, ELSE=12, WHILE=13, DO=14, SEMI=15, 
		COMMA=16, DOT=17, MULT=18, DIV=19, MOD=20, PLUS=21, MINUS=22, LESS=23, 
		GREATER=24, NEG=25, ASSIGN=26, EQ=27, NEQ=28, AND=29, OR=30, INT=31, FLOAT=32, 
		BOOL=33, STRING_LITERAL=34, IDENTIFIER=35, WS=36, COMMENT=37, LINE_COMMENT=38;
	public const int
		RULE_program = 0, RULE_statement = 1, RULE_declaration = 2, RULE_block = 3, 
		RULE_expression = 4, RULE_primitiveType = 5;
	public static readonly string[] ruleNames = {
		"program", "statement", "declaration", "block", "expression", "primitiveType"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'{'", "'}'", "'int'", "'float'", "'string'", "'bool'", 
		"'read'", "'write'", "'if'", "'else'", "'while'", "'do'", "';'", "','", 
		"'.'", "'*'", "'/'", "'%'", "'+'", "'-'", "'<'", "'>'", "'!'", "'='", 
		"'=='", "'!='", "'&&'", "'||'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, "INT_KEYWORD", "FLOAT_KEYWORD", "STRING_KEYWORD", 
		"BOOL_KEYWORD", "READ", "WRITE", "IF", "ELSE", "WHILE", "DO", "SEMI", 
		"COMMA", "DOT", "MULT", "DIV", "MOD", "PLUS", "MINUS", "LESS", "GREATER", 
		"NEG", "ASSIGN", "EQ", "NEQ", "AND", "OR", "INT", "FLOAT", "BOOL", "STRING_LITERAL", 
		"IDENTIFIER", "WS", "COMMENT", "LINE_COMMENT"
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

	public override string GrammarFileName { get { return "Grammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static GrammarParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public GrammarParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public GrammarParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgramContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(GrammarParser.Eof, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_program; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.EnterProgram(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.ExitProgram(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProgram(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(Context, State);
		EnterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 13;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 12;
				statement();
				}
				}
				State = 15;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 66609803242L) != 0) );
			State = 17;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMI() { return GetToken(GrammarParser.SEMI, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public DeclarationContext declaration() {
			return GetRuleContext<DeclarationContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode READ() { return GetToken(GrammarParser.READ, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] IDENTIFIER() { return GetTokens(GrammarParser.IDENTIFIER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER(int i) {
			return GetToken(GrammarParser.IDENTIFIER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] COMMA() { return GetTokens(GrammarParser.COMMA); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COMMA(int i) {
			return GetToken(GrammarParser.COMMA, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode WRITE() { return GetToken(GrammarParser.WRITE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IF() { return GetToken(GrammarParser.IF, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ELSE() { return GetToken(GrammarParser.ELSE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode WHILE() { return GetToken(GrammarParser.WHILE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DO() { return GetToken(GrammarParser.DO, 0); }
		public StatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_statement; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.EnterStatement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.ExitStatement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatementContext statement() {
		StatementContext _localctx = new StatementContext(Context, State);
		EnterRule(_localctx, 2, RULE_statement);
		int _la;
		try {
			State = 69;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case SEMI:
				EnterOuterAlt(_localctx, 1);
				{
				State = 19;
				Match(SEMI);
				}
				break;
			case INT_KEYWORD:
			case FLOAT_KEYWORD:
			case STRING_KEYWORD:
			case BOOL_KEYWORD:
				EnterOuterAlt(_localctx, 2);
				{
				State = 20;
				declaration();
				}
				break;
			case T__0:
			case MINUS:
			case NEG:
			case INT:
			case FLOAT:
			case BOOL:
			case STRING_LITERAL:
			case IDENTIFIER:
				EnterOuterAlt(_localctx, 3);
				{
				State = 21;
				expression(0);
				State = 22;
				Match(SEMI);
				}
				break;
			case READ:
				EnterOuterAlt(_localctx, 4);
				{
				State = 24;
				Match(READ);
				State = 25;
				Match(IDENTIFIER);
				State = 30;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==COMMA) {
					{
					{
					State = 26;
					Match(COMMA);
					State = 27;
					Match(IDENTIFIER);
					}
					}
					State = 32;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 33;
				Match(SEMI);
				}
				break;
			case WRITE:
				EnterOuterAlt(_localctx, 5);
				{
				State = 34;
				Match(WRITE);
				State = 35;
				expression(0);
				State = 40;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==COMMA) {
					{
					{
					State = 36;
					Match(COMMA);
					State = 37;
					expression(0);
					}
					}
					State = 42;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 43;
				Match(SEMI);
				}
				break;
			case T__2:
				EnterOuterAlt(_localctx, 6);
				{
				State = 45;
				block();
				}
				break;
			case IF:
				EnterOuterAlt(_localctx, 7);
				{
				State = 46;
				Match(IF);
				State = 47;
				Match(T__0);
				State = 48;
				expression(0);
				State = 49;
				Match(T__1);
				State = 50;
				statement();
				State = 53;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
				case 1:
					{
					State = 51;
					Match(ELSE);
					State = 52;
					statement();
					}
					break;
				}
				}
				break;
			case WHILE:
				EnterOuterAlt(_localctx, 8);
				{
				State = 55;
				Match(WHILE);
				State = 56;
				Match(T__0);
				State = 57;
				expression(0);
				State = 58;
				Match(T__1);
				State = 59;
				statement();
				}
				break;
			case DO:
				EnterOuterAlt(_localctx, 9);
				{
				State = 61;
				Match(DO);
				State = 62;
				statement();
				State = 63;
				Match(WHILE);
				State = 64;
				Match(T__0);
				State = 65;
				expression(0);
				State = 66;
				Match(T__1);
				State = 67;
				Match(SEMI);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DeclarationContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public PrimitiveTypeContext primitiveType() {
			return GetRuleContext<PrimitiveTypeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] IDENTIFIER() { return GetTokens(GrammarParser.IDENTIFIER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER(int i) {
			return GetToken(GrammarParser.IDENTIFIER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMI() { return GetToken(GrammarParser.SEMI, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] COMMA() { return GetTokens(GrammarParser.COMMA); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COMMA(int i) {
			return GetToken(GrammarParser.COMMA, i);
		}
		public DeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_declaration; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.EnterDeclaration(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.ExitDeclaration(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDeclaration(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DeclarationContext declaration() {
		DeclarationContext _localctx = new DeclarationContext(Context, State);
		EnterRule(_localctx, 4, RULE_declaration);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 71;
			primitiveType();
			State = 72;
			Match(IDENTIFIER);
			State = 77;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==COMMA) {
				{
				{
				State = 73;
				Match(COMMA);
				State = 74;
				Match(IDENTIFIER);
				}
				}
				State = 79;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 80;
			Match(SEMI);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_block; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.EnterBlock(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.ExitBlock(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBlock(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BlockContext block() {
		BlockContext _localctx = new BlockContext(Context, State);
		EnterRule(_localctx, 6, RULE_block);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 82;
			Match(T__2);
			State = 86;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 66609803242L) != 0)) {
				{
				{
				State = 83;
				statement();
				}
				}
				State = 88;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 89;
			Match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode BOOL() { return GetToken(GrammarParser.BOOL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(GrammarParser.IDENTIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(GrammarParser.INT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FLOAT() { return GetToken(GrammarParser.FLOAT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING_LITERAL() { return GetToken(GrammarParser.STRING_LITERAL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MINUS() { return GetToken(GrammarParser.MINUS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEG() { return GetToken(GrammarParser.NEG, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MULT() { return GetToken(GrammarParser.MULT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIV() { return GetToken(GrammarParser.DIV, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MOD() { return GetToken(GrammarParser.MOD, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PLUS() { return GetToken(GrammarParser.PLUS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DOT() { return GetToken(GrammarParser.DOT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LESS() { return GetToken(GrammarParser.LESS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode GREATER() { return GetToken(GrammarParser.GREATER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode EQ() { return GetToken(GrammarParser.EQ, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEQ() { return GetToken(GrammarParser.NEQ, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode AND() { return GetToken(GrammarParser.AND, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode OR() { return GetToken(GrammarParser.OR, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ASSIGN() { return GetToken(GrammarParser.ASSIGN, 0); }
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.EnterExpression(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.ExitExpression(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		return expression(0);
	}

	private ExpressionContext expression(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExpressionContext _localctx = new ExpressionContext(Context, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 8;
		EnterRecursionRule(_localctx, 8, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 105;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case BOOL:
				{
				State = 92;
				Match(BOOL);
				}
				break;
			case IDENTIFIER:
				{
				State = 93;
				Match(IDENTIFIER);
				}
				break;
			case INT:
				{
				State = 94;
				Match(INT);
				}
				break;
			case FLOAT:
				{
				State = 95;
				Match(FLOAT);
				}
				break;
			case STRING_LITERAL:
				{
				State = 96;
				Match(STRING_LITERAL);
				}
				break;
			case T__0:
				{
				State = 97;
				Match(T__0);
				State = 98;
				expression(0);
				State = 99;
				Match(T__1);
				}
				break;
			case MINUS:
				{
				State = 101;
				Match(MINUS);
				State = 102;
				expression(9);
				}
				break;
			case NEG:
				{
				State = 103;
				Match(NEG);
				State = 104;
				expression(8);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 130;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,9,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 128;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,8,Context) ) {
					case 1:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 107;
						if (!(Precpred(Context, 7))) throw new FailedPredicateException(this, "Precpred(Context, 7)");
						State = 108;
						_la = TokenStream.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1835008L) != 0)) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 109;
						expression(8);
						}
						break;
					case 2:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 110;
						if (!(Precpred(Context, 6))) throw new FailedPredicateException(this, "Precpred(Context, 6)");
						State = 111;
						_la = TokenStream.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 6422528L) != 0)) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 112;
						expression(7);
						}
						break;
					case 3:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 113;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 114;
						_la = TokenStream.LA(1);
						if ( !(_la==LESS || _la==GREATER) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 115;
						expression(6);
						}
						break;
					case 4:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 116;
						if (!(Precpred(Context, 4))) throw new FailedPredicateException(this, "Precpred(Context, 4)");
						State = 117;
						_la = TokenStream.LA(1);
						if ( !(_la==EQ || _la==NEQ) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 118;
						expression(5);
						}
						break;
					case 5:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 119;
						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
						State = 120;
						Match(AND);
						State = 121;
						expression(4);
						}
						break;
					case 6:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 122;
						if (!(Precpred(Context, 2))) throw new FailedPredicateException(this, "Precpred(Context, 2)");
						State = 123;
						Match(OR);
						State = 124;
						expression(3);
						}
						break;
					case 7:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 125;
						if (!(Precpred(Context, 1))) throw new FailedPredicateException(this, "Precpred(Context, 1)");
						State = 126;
						Match(ASSIGN);
						State = 127;
						expression(2);
						}
						break;
					}
					} 
				}
				State = 132;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,9,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class PrimitiveTypeContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT_KEYWORD() { return GetToken(GrammarParser.INT_KEYWORD, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FLOAT_KEYWORD() { return GetToken(GrammarParser.FLOAT_KEYWORD, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING_KEYWORD() { return GetToken(GrammarParser.STRING_KEYWORD, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode BOOL_KEYWORD() { return GetToken(GrammarParser.BOOL_KEYWORD, 0); }
		public PrimitiveTypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_primitiveType; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.EnterPrimitiveType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IGrammarListener typedListener = listener as IGrammarListener;
			if (typedListener != null) typedListener.ExitPrimitiveType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimitiveType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PrimitiveTypeContext primitiveType() {
		PrimitiveTypeContext _localctx = new PrimitiveTypeContext(Context, State);
		EnterRule(_localctx, 10, RULE_primitiveType);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 133;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 480L) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 4: return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 7);
		case 1: return Precpred(Context, 6);
		case 2: return Precpred(Context, 5);
		case 3: return Precpred(Context, 4);
		case 4: return Precpred(Context, 3);
		case 5: return Precpred(Context, 2);
		case 6: return Precpred(Context, 1);
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,38,136,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,1,0,4,0,14,
		8,0,11,0,12,0,15,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,1,29,8,
		1,10,1,12,1,32,9,1,1,1,1,1,1,1,1,1,1,1,5,1,39,8,1,10,1,12,1,42,9,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,54,8,1,1,1,1,1,1,1,1,1,1,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,70,8,1,1,2,1,2,1,2,1,2,5,2,76,8,2,
		10,2,12,2,79,9,2,1,2,1,2,1,3,1,3,5,3,85,8,3,10,3,12,3,88,9,3,1,3,1,3,1,
		4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,3,4,106,8,4,1,4,
		1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,
		4,1,4,1,4,5,4,129,8,4,10,4,12,4,132,9,4,1,5,1,5,1,5,0,1,8,6,0,2,4,6,8,
		10,0,5,1,0,18,20,2,0,17,17,21,22,1,0,23,24,1,0,27,28,1,0,5,8,157,0,13,
		1,0,0,0,2,69,1,0,0,0,4,71,1,0,0,0,6,82,1,0,0,0,8,105,1,0,0,0,10,133,1,
		0,0,0,12,14,3,2,1,0,13,12,1,0,0,0,14,15,1,0,0,0,15,13,1,0,0,0,15,16,1,
		0,0,0,16,17,1,0,0,0,17,18,5,0,0,1,18,1,1,0,0,0,19,70,5,15,0,0,20,70,3,
		4,2,0,21,22,3,8,4,0,22,23,5,15,0,0,23,70,1,0,0,0,24,25,5,9,0,0,25,30,5,
		35,0,0,26,27,5,16,0,0,27,29,5,35,0,0,28,26,1,0,0,0,29,32,1,0,0,0,30,28,
		1,0,0,0,30,31,1,0,0,0,31,33,1,0,0,0,32,30,1,0,0,0,33,70,5,15,0,0,34,35,
		5,10,0,0,35,40,3,8,4,0,36,37,5,16,0,0,37,39,3,8,4,0,38,36,1,0,0,0,39,42,
		1,0,0,0,40,38,1,0,0,0,40,41,1,0,0,0,41,43,1,0,0,0,42,40,1,0,0,0,43,44,
		5,15,0,0,44,70,1,0,0,0,45,70,3,6,3,0,46,47,5,11,0,0,47,48,5,1,0,0,48,49,
		3,8,4,0,49,50,5,2,0,0,50,53,3,2,1,0,51,52,5,12,0,0,52,54,3,2,1,0,53,51,
		1,0,0,0,53,54,1,0,0,0,54,70,1,0,0,0,55,56,5,13,0,0,56,57,5,1,0,0,57,58,
		3,8,4,0,58,59,5,2,0,0,59,60,3,2,1,0,60,70,1,0,0,0,61,62,5,14,0,0,62,63,
		3,2,1,0,63,64,5,13,0,0,64,65,5,1,0,0,65,66,3,8,4,0,66,67,5,2,0,0,67,68,
		5,15,0,0,68,70,1,0,0,0,69,19,1,0,0,0,69,20,1,0,0,0,69,21,1,0,0,0,69,24,
		1,0,0,0,69,34,1,0,0,0,69,45,1,0,0,0,69,46,1,0,0,0,69,55,1,0,0,0,69,61,
		1,0,0,0,70,3,1,0,0,0,71,72,3,10,5,0,72,77,5,35,0,0,73,74,5,16,0,0,74,76,
		5,35,0,0,75,73,1,0,0,0,76,79,1,0,0,0,77,75,1,0,0,0,77,78,1,0,0,0,78,80,
		1,0,0,0,79,77,1,0,0,0,80,81,5,15,0,0,81,5,1,0,0,0,82,86,5,3,0,0,83,85,
		3,2,1,0,84,83,1,0,0,0,85,88,1,0,0,0,86,84,1,0,0,0,86,87,1,0,0,0,87,89,
		1,0,0,0,88,86,1,0,0,0,89,90,5,4,0,0,90,7,1,0,0,0,91,92,6,4,-1,0,92,106,
		5,33,0,0,93,106,5,35,0,0,94,106,5,31,0,0,95,106,5,32,0,0,96,106,5,34,0,
		0,97,98,5,1,0,0,98,99,3,8,4,0,99,100,5,2,0,0,100,106,1,0,0,0,101,102,5,
		22,0,0,102,106,3,8,4,9,103,104,5,25,0,0,104,106,3,8,4,8,105,91,1,0,0,0,
		105,93,1,0,0,0,105,94,1,0,0,0,105,95,1,0,0,0,105,96,1,0,0,0,105,97,1,0,
		0,0,105,101,1,0,0,0,105,103,1,0,0,0,106,130,1,0,0,0,107,108,10,7,0,0,108,
		109,7,0,0,0,109,129,3,8,4,8,110,111,10,6,0,0,111,112,7,1,0,0,112,129,3,
		8,4,7,113,114,10,5,0,0,114,115,7,2,0,0,115,129,3,8,4,6,116,117,10,4,0,
		0,117,118,7,3,0,0,118,129,3,8,4,5,119,120,10,3,0,0,120,121,5,29,0,0,121,
		129,3,8,4,4,122,123,10,2,0,0,123,124,5,30,0,0,124,129,3,8,4,3,125,126,
		10,1,0,0,126,127,5,26,0,0,127,129,3,8,4,2,128,107,1,0,0,0,128,110,1,0,
		0,0,128,113,1,0,0,0,128,116,1,0,0,0,128,119,1,0,0,0,128,122,1,0,0,0,128,
		125,1,0,0,0,129,132,1,0,0,0,130,128,1,0,0,0,130,131,1,0,0,0,131,9,1,0,
		0,0,132,130,1,0,0,0,133,134,7,4,0,0,134,11,1,0,0,0,10,15,30,40,53,69,77,
		86,105,128,130
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
