namespace YAPL.runtime.Values;

using CodeAnalysis;

public class BoolValue : Value {
	public override ValueType Type => ValueType.BOOLEAN;

	public override string Val { get; }

	public BoolValue(bool val = true) {
		Val = val ? "true" : "false";
	}
}