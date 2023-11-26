namespace YAPL.Runtime.Values; 

public class NullValue : RuntimeValue {
	public override ValueType Type => ValueType.NULL;

	public string Value => "null";

	public override string ToString() => "null";
}