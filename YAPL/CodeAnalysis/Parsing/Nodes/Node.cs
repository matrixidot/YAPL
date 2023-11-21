namespace YAPL.Nodes;

using CodeAnalysis;

public abstract class Node {
	public abstract TokenType Type { get; }

	public abstract IEnumerable<Node> GetChildren();

}