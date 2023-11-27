namespace YAPL.Frontend.Parsing.Nodes.Expressions; 

public class Identifier : Expression {
	public override NodeType Type => NodeType.IDENTIFIER;

	public string Symbol { get; }

	public Identifier(string symbol) {
		Symbol = symbol;
	}

	public override string ToString() {
		return Symbol;
	}
}