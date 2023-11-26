namespace YAPL.Frontend.Parsing.Nodes.Expressions; 

public class NumericLiteral : Expression {
	public override NodeType Type => NodeType.NUMERIC_LITERAL;

	public double Value { get; }

	public NumericLiteral(double value) {
		Value = value;
	}

	public override string ToString() {
		return $"{Value}";
	}
}