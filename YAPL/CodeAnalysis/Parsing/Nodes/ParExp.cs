namespace YAPL.Nodes;

using CodeAnalysis;
using System.Linq.Expressions;

public class ParExp : Expression {
	public override TokenType Type => TokenType.PAR_EXP;
	public Token OpenParen { get; }
	public Expression Expr { get; }
	public Token CloseParen { get; }

	public ParExp(Token openParen, Expression expr, Token closeParen) {
		OpenParen = openParen;
		Expr = expr;
		CloseParen = closeParen;
	}

	public override IEnumerable<Node> GetChildren() {
		yield return OpenParen;
		yield return Expr;
		yield return CloseParen;
	}
}