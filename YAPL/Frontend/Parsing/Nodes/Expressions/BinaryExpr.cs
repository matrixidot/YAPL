namespace YAPL.Frontend.Parsing.Nodes.Expressions; 

public class BinaryExpr : Expression {
	public override NodeType Type => NodeType.BINARY_EXPR;

	public Expression Left { get; }

	public string Operator { get; }

	public Expression Right { get; }

	public BinaryExpr(Expression left, string op, Expression right) {
		Left = left;
		Operator = op;
		Right = right;
	}

	public override string ToString() {
		return $"{Type},\n    ({Left} {Operator} {Right})";
	}
}