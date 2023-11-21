namespace YAPL.CodeAnalysis.Parsing;

using Exceptions;
using lexing;
using Nodes;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Expression = Nodes.Expression;

public class Parser {
	private readonly List<Token> tokens;

	public Parser(string sourceCode) {
		Lexer l = new();
		tokens = l.tokenize(sourceCode);
	}
	
	public SyntaxTree Parse() {
		Node expression = ParseStmt();
		Token endOfFileToken = At();
		return new SyntaxTree(expression, endOfFileToken);
	}

	private Node ParseStmt() {
		switch (At().Type) {
			case TokenType.VAR or TokenType.FINAL:
				return ParseVarDec();
			
			default:
				return ParseExpr();
		}
	}

	// var ident
	// (var / final)  ident = EXPR
	private Node ParseVarDec() {
		bool isFinal = At().Type == TokenType.FINAL;
		string identifier = Expect(TokenType.IDENTIFIER, $"Expected <IDENTIFIER> after <{Eat().Type}> but got ").Value;
		if (At().Type == TokenType.SEMICOLON) {
			if (isFinal) {
				throw new FinalValueUnassignedError("Must assign value to final variable, no value provided");
			}

			Expect(TokenType.SEMICOLON, "Expected <SEMICOLON> to finish var declaration but got ");
			return new VarDec(false, identifier);
		}

		Expect(TokenType.EQUALS, $"Expected <EQUALS> to assign var but got ");
		VarDec declaration = new (isFinal, identifier, ParseExpr());
		Expect(TokenType.SEMICOLON, $"Expected <SEMICOLON> to finish var declaration but got ");
		return declaration;
	}

	private Expression ParseExpr() {
		return ParseAdditiveExpr();
	}

	private Expression ParseAdditiveExpr() {
		Expression left = ParseMultiExpr();

		while (At().Type is TokenType.PLUS or TokenType.MINUS) {
			string op = Eat().Value;
			Expression right = ParseMultiExpr();
			left = new BinExp(left, op, right);
		}

		return left;
	}

	private Expression ParseMultiExpr() {
		Expression left = ParsePrimaryExpr();

		while (At().Type is TokenType.STAR or TokenType.SLASH or TokenType.MOD) {
			string op = Eat().Value;
			Expression right = ParsePrimaryExpr();
			left = new BinExp(left, op, right);
		}

		return left;
	}

	private Expression ParsePrimaryExpr() {
		TokenType tk = At().Type;
		switch (tk) {
			case TokenType.IDENTIFIER:
				return new Identifier(Eat().Value);
			case TokenType.NUMBER:
				return new Number(Eat().Value);
			case TokenType.O_PAREN:
				Eat();
				Expression value = ParseExpr();
				Expect(TokenType.C_PAREN, "Expected: ')', but found: ");
				return value;
			default:
				throw new UnknownTokenError($"Unexpected token found during parsing: {{ {At().Type}, {At().Value} }}");
		}
		
	}

	private Token At() {
		return tokens[0];
	}

	private Token Eat() {
		Token prev = tokens[0];
		tokens.RemoveAt(0);
		return prev;
	}

	private Token Expect(TokenType expected, string errorMessage) {
		Token prev = Eat();
		if (prev == null)
			throw new UnexpectedTokenError("Error while parsing: " + errorMessage + "null instead.");
		if (prev.Type != expected)
			throw new UnexpectedTokenError("Error while parsing: " + errorMessage + prev.Type + " instead");
		return prev;
	}
	
}