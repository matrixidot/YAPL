namespace YAPL.Runtime.Values; 

public class NumberValue : RuntimeValue {
	public override ValueType Type => ValueType.NUMBER;
	public double Value { get; }

	public NumberValue(double value) {
		Value = value;
	}

	public override string ToString() => $"{Value}";
}