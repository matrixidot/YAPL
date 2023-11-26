namespace YAPL.CodeAnalysis.Parsing.Nodes; 

public class Identifier : Expression {
	public override NodeType Type => NodeType.IDENTIFIER;

	private string Symbol { get; }

	public Identifier(string symbol) {
		Symbol = symbol;
	}

	public override string ToString() {
		return Symbol;
	}
}