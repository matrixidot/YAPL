namespace YAPL.Frontend.Parsing.Nodes.Expressions;

public class NullLiteral : Expression {
	public override NodeType Type => NodeType.NULL_LITERAL;

	public string Value => "null";

	public override string ToString() {
		return $"{Value}";
	}
}