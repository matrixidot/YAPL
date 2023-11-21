namespace YAPL.Nodes;

using CodeAnalysis;

public class Identifier : Expression {
	public override TokenType Type => TokenType.IDENTIFIER;
	public Token Symbol { get; }

	public Identifier(Token symbol) {
		Symbol = symbol;
	}

	public override IEnumerable<Node> GetChildren() {
		yield return Symbol;
	}
}