namespace YAPL.Nodes;

using CodeAnalysis;
using System.Linq.Expressions;

public class VarDec : Node {
	public override TokenType Type => TokenType.VAR_DEC;

	public bool IsFinal { get; }

	public string Identifier { get; }
	public Expression? Value { get; }

	public VarDec(bool isFinal, string identifier, Expression? value = null) {
		IsFinal = isFinal;
		Identifier = identifier;
		Value = value;
	}
	
	public override IEnumerable<Node> GetChildren() {
		yield return Value;
	}
}