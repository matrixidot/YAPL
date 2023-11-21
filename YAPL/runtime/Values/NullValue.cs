namespace YAPL.runtime.Values;

using CodeAnalysis;

public class NullValue : Value {
	public override ValueType Type => ValueType.NULL;

	public override string Val { get; }

	public NullValue(string nullVal) {
		Val = nullVal;
	}
}