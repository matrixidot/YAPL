namespace YAPL.Runtime.Values; 

public class NullValue : RuntimeValue {
	public override ValueTypes Type => ValueTypes.NULL;

	public string Value => "null";

	public override string ToString() => "null";
}