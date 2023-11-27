namespace YAPL.Frontend.lexing; 

public class Token {
	
	public TokenType Type { get; }
	public string Value { get; }


	public Token(TokenType type, string value) {
		Type = type;
		Value = value;
	}

	public Token(TokenType type, char value) : this(type, value.ToString()) {
		
	}

	public override string ToString() {
		return $"{{ {Type} : {Value} }}";
	}
}