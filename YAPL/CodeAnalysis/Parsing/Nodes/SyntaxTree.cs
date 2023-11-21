namespace YAPL.Nodes;

using CodeAnalysis;
using CodeAnalysis.Parsing;

public class SyntaxTree {
	public Node Root { get; }
	public Token EndOfFileToken { get; }

	public SyntaxTree(Node root, Token endOfFileToken) {
		Root = root;
		EndOfFileToken = endOfFileToken;
	}

	public static SyntaxTree Parse(string sourceCode) {
		var parser = new Parser(sourceCode);
		return parser.Parse();
	}
}