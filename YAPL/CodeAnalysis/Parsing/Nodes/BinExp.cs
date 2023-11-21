namespace YAPL.Nodes;

using CodeAnalysis;
using System.Linq.Expressions;

public class BinExp : Expression{
	public override TokenType Type => TokenType.BIN_EXP;

	public Expression Left { get; }
	public string Op { get; }
	public Expression Right { get; }

	public BinExp(Expression left, string op, Expression right) {
		Left = left;
		Op = op;
		Right = right;
	}
	
	public override IEnumerable<Node> GetChildren() {
		yield return Left;
		yield return Right;
	}
}