namespace YAPL.CodeAnalysis;

using Nodes;

public class Token : Node {
	public override TokenType Type { get; }
	public string Value { get; }
	
	public Token(string value, TokenType type) {
		Value = value;
		Type = type;
	}
	
	public override IEnumerable<Node> GetChildren() => Enumerable.Empty<Node>();

}