namespace YAPL.Frontend.Parsing;

using Errors;
using lexing;
using Nodes.Expressions;
using Nodes.Statements;

public class Parser {
	private List<Token> tokens = new();

	public Program produceAST(string sourceCode) {
		Lexer lexer = new();
		tokens = lexer.tokenize(sourceCode);
		
		List<Statement> body = new();
		
		while (NotEof()) {
			body.Add(ParseStmt());
		}
		return new Program(body);
	}

	private Statement ParseStmt() {
		return ParseExpr();
	}

	private Expression ParseExpr() {
		return ParseAdditiveExpr();
	}

	private Expression ParseAdditiveExpr() {
		Expression left = ParseMultiplyExpr();

		while (At().Value is "+" or "-") {
			string op = Eat().Value;
			Expression right = ParseMultiplyExpr();
			left = new BinaryExpr(left, op, right);
			
		}

		return left;
	}
	
	private Expression ParseMultiplyExpr() {
		Expression left = ParsePrimaryExpr();

		while (At().Value is "*" or "/" or "%") {
			string op = Eat().Value;
			Expression right = ParsePrimaryExpr();
			left = new BinaryExpr(left, op, right);
			
		}

		return left;
	}
	
	private Expression ParsePrimaryExpr() {
		TokenType tk = At().Type;

		switch (tk) { 
		case TokenType.NULL:
			Eat();
			return new NullLiteral();
		case TokenType.IDENTIFIER :
			return new Identifier(Eat().Value);
		case TokenType.NUMBER :
			return new NumericLiteral(double.Parse(Eat().Value));
		case TokenType.OPAREN :
			Eat();
			Expression value = ParseExpr();
			Expect(TokenType.CPAREN, "parenthetical expr");
			return value;
		default :
			throw new UnexpectedTokenError($"Unexpected token found during parsing: <{At()}>.");
		}
	}


	private Token Eat() {
		Token prev = At();
		tokens.RemoveAt(0);
		return prev;
	}
	
	private Token At() {
		return tokens[0];
	}
	
	private Token Expect(TokenType expected, string exprType) {
		Token prev = Eat();
		if (prev == null)
			throw new UnexpectedTokenError($"Error while parsing: expected <{expected}> in a {exprType} but got <NULL> instead.");
		if (prev.Type != expected)
			throw new UnexpectedTokenError($"Error while parsing: expected <{expected}> in a {exprType} but got <{prev}> instead.");
		return prev;
	}
	
	private bool NotEof() {
		return tokens[0].Type != TokenType.EOF;
	}
}