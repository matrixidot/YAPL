namespace YAPL.CodeAnalysis; 

public enum TokenType {
	// OPERATORS
	PLUS,
	MINUS,
	STAR,
	SLASH,
	MOD,
	EQUALS,
	O_PAREN,
	C_PAREN,
	
	// KEYWORDS
	LET,
	
	// EXPRESSIONS
	BIN_EXP,
	PAR_EXP,
	
	// OTHER
	NUMBER,
	IDENTIFIER,
	EOF,
	NULL,
	
	
	
}