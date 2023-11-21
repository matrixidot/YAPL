namespace YAPL.Nodes;

using CodeAnalysis;

public class Identifier : Expression {
	public override TokenType Type => TokenType.IDENTIFIER;
	public string Symbol { get; }

	public Identifier(string symbol) {
		Symbol = symbol;
	}

	public override IEnumerable<Node> GetChildren() {
		yield break;
	}
}