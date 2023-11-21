namespace YAPL.Nodes;

using CodeAnalysis;

public class Null : Expression {
	public override TokenType Type => TokenType.NULL;

	public string Value { get; }

	public Null(string value) {
		Value = value;
	}

	public override IEnumerable<Node> GetChildren() {
		yield break;
	}
}