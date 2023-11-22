namespace YAPL.Nodes;

using CodeAnalysis;
using System.Linq.Expressions;

public class AssignExp : Expression{
	public override TokenType Type => TokenType.ASSIGN_EXP;

	public Expression Asignee { get; }
	public Expression Value { get; }

	public AssignExp(Expression asignee, Expression value) {
		Asignee = asignee;
		Value = value;
	}
	
	public override IEnumerable<Node> GetChildren() {
		yield return Asignee;
		yield return Value;
	}
}