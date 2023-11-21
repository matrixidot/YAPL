namespace YAPL.Nodes;

using CodeAnalysis;
using CodeAnalysis.Parsing;

public class SyntaxTree {
	public Expression Root { get; }
	public Token EndOfFileToken { get; }

	public SyntaxTree(Expression root, Token endOfFileToken) {
		Root = root;
		EndOfFileToken = endOfFileToken;
	}

	public static SyntaxTree Parse(string sourceCode) {
		var parser = new Parser(sourceCode);
		return parser.Parse();
	}
}