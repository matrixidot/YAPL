namespace YAPL.CodeAnalysis.Lexing;

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
}