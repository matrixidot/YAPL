namespace YAPL.CodeAnalysis.Lexing;

using Errors;
using System.Collections.Specialized;
using util;

public class Lexer {
	private readonly Dictionary<string, TokenType> KEYWORDS = new()
	{ 
	{ "let", TokenType.LET }, 
	};

	public List<Token> tokenize(string sourceCode) {
		StringIterator src = sourceCode.GetIterator();
		List<Token> tokens = new();

		while (src.HasNext()) {
			
			switch (src.At()) {
				case '(':
					tokens.Add(new Token(TokenType.OPAREN, src.Shift()));
					break;
				case ')':
					tokens.Add(new Token(TokenType.CPAREN, src.Shift()));
					break;
				case '+' or '-' or '*' or '/' or '%':
					tokens.Add(new Token(TokenType.BINOP, src.Shift()));
					break;
				case '=':
					tokens.Add(new Token(TokenType.EQUALS, src.Shift()));
					break;
				default: {
					if (IsNum(src.At())) {
						string num = string.Empty;
						while (src.HasNext() && IsNum(src.At())) {
							num += src.Shift();
						}
						tokens.Add(new(TokenType.NUMBER, num));
					} else if (IsLetter(src.At())) {
						string ident = string.Empty;
						while (src.HasNext() && IsLetter(src.At())) {
							ident += src.Shift();
						}
						if (KEYWORDS.ContainsKey(ident))
							tokens.Add(new(KEYWORDS[ident], ident));
						else
							tokens.Add(new(TokenType.IDENTIFIER, ident));
					} else if (IsBlank(src.At())) {
						src.Shift();
					}
					else throw new UnrecognizedCharacterError($"Unrecognized character found while lexing: '{src.At()}'.", null);
					

					break;
				}
			}
		}
		tokens.Add(new Token(TokenType.EOF, "EndOfFile"));
		return tokens;
	}
	
	




	private bool IsLetter(char c) {
		return char.IsLetter(c);
	}

	private bool IsNum(char c) {
		return char.IsDigit(c);
	}

	private bool IsBlank(char c) {
		return c is ' ' or '\n' or '\t' or '\r';
	}
}