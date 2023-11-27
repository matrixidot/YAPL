using YAPL.Runtime.Values;

public class BooleanValue : RuntimeValue
{
    public override ValueTypes Type => ValueTypes.BOOLEAN;
    public bool Value { get; }

    public BooleanValue(bool value = false) {
        Value = value;
    }

    public override string ToString() {
        return $"{Value}";
    }
}