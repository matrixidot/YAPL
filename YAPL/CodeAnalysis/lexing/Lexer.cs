namespace YAPL.CodeAnalysis.lexing;

using Exceptions;
using util;

public class Lexer {
	public readonly Dictionary<String, TokenType> KEYWORDS = new()
	{ 
	{ "let", TokenType.LET }, 
	{"null", TokenType.NULL},
	};

	private Token token(string value, TokenType type) {
		return new Token(value, type);
	}

	private Token token(char value, TokenType type) {
		return token(value.ToString(), type);
	}

	public List<Token> tokenize(string sourceCode) {
		StringEnumerator src = sourceCode.getStringEnumerator();
		var tokens = new List<Token>();

		while (src.HasNext()) {
			switch (src.Current()) {
				case '+':
					tokens.Add(token(src.Shift(), TokenType.PLUS));
					break;
				case '-':
					tokens.Add(token(src.Shift(), TokenType.MINUS));
					break;
				case '*':
					tokens.Add(token(src.Shift(), TokenType.STAR));
					break;
				case '/':
					tokens.Add(token(src.Shift(), TokenType.SLASH));
					break;
				case '%':
					tokens.Add(token(src.Shift(), TokenType.MOD));
					break;
				case '=':
					tokens.Add(token(src.Shift(), TokenType.EQUALS));
					break;
				case '(':
					tokens.Add(token(src.Shift(), TokenType.O_PAREN));
					break;
				case ')':
					tokens.Add(token(src.Shift(), TokenType.C_PAREN));
					break;
				default: {
					if (char.IsDigit(src.Current())) {
						string multi = string.Empty;
						while (src.HasNext() && char.IsDigit(src.Current()))
							multi += src.Shift();
						
						tokens.Add(token(multi, TokenType.NUMBER));
					} else if (char.IsLetter(src.Current())) {
						string multi = string.Empty;
						while (src.HasNext() && char.IsLetter(src.Current()))
							multi += src.Shift();

						if (KEYWORDS.TryGetValue(multi, out TokenType value)) {
							tokens.Add(token(multi, value));
						}
						else {
							tokens.Add(token(multi, TokenType.IDENTIFIER));
						}
					} else if (src.Current() is ' ' or '\t' or '\n') {
						src.Step();
					}
					else {
						throw new UnknownCharacterError("Unknown character found in source: " + src.Current());
					}
					break;
				}
			}
		}
		tokens.Add(token("EndOfFile", TokenType.EOF));
		return tokens;
	}
}