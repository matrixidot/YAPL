namespace YAPL.Frontend.lexing;

public enum TokenType {
	// Literal Types
	NUMBER,
	IDENTIFIER,

	// Keywords
	LET,

	// Grouping * Operators
	BINOP,
	EQUALS,
	OPAREN,
	CPAREN,

	// OTHER
	EOF,
	NULL,
}