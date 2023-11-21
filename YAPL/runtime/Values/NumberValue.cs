namespace YAPL.runtime.Values;

using CodeAnalysis;

public class NumberValue : Value {
	public override ValueType Type => ValueType.NUMBER;

	public override string Val { get; }

	public NumberValue(string numberVal) {
		Val = numberVal;
	}
	
}