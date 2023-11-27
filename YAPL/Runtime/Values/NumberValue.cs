namespace YAPL.Runtime.Values; 

public class NumberValue : RuntimeValue {
	public override ValueTypes Type => ValueTypes.NUMBER;
	public double Value { get; }

	public NumberValue(double value) {
		Value = value;
	}

	public override string ToString() => $"{Value}";
}