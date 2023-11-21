namespace YAPL.Nodes;

using CodeAnalysis;

public class Number : Expression {
	public override TokenType Type => TokenType.NUMBER;

	public string Value { get; }

	public Number(string value) {
		Value = value;
	}

	public override IEnumerable<Node> GetChildren() {
		yield break;
	}
}