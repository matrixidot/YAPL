namespace YAPL;

using CodeAnalysis;
using Nodes;
using runtime;
using runtime.Values;

class Program {
	public static void Main(string[] args) {
		bool showTree = false;
		Interpreter interpreter = new();
		Environment env = new(null);
		env.DeclareVar("true", new BoolValue(true), true);
		env.DeclareVar("false", new BoolValue(false), true);
		env.DeclareVar("null", new NullValue(), true);
		while (true) {
			Console.Write("> ");
			string? line = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(line)) return;
			switch (line) {
				case "#st":
					showTree = !showTree;
					Console.WriteLine(showTree ? "Showing parse trees." : "Not showing parse trees.");
					continue;
				case "#cls":
					Console.Clear();
					continue;
			}

			SyntaxTree tree = SyntaxTree.Parse(line);
			if (showTree) {
				PrettyPrint(tree.Root);
			}
			Value result = interpreter.Evaluate(tree.Root, env);
			Console.WriteLine(result.Val);
		}
	}

	public static void PrettyPrint(Node node, string indent = "", bool isLast = true) {
		var marker = isLast ? "└──" : "├──";
        
		Console.Write(indent);
		Console.Write(marker);
		Console.Write(node.Type);
		
		if (node.Type == TokenType.NUMBER) {
			Console.Write($" : {((Number)node).Value}");
		}

		if (node.Type == TokenType.BIN_EXP) {
			string toAdd = isLast ? "    " : "│   ";
			Console.Write($"\n{indent + toAdd}├── {((BinExp)node).Op}");
		}

		if (node.Type == TokenType.IDENTIFIER) {
			Console.Write($" : {((Identifier)node).Symbol}");
		}
		
		if (node is Token t && t.Value is not null)
			Console.Write(" " + t.Value);
			
		
		Console.WriteLine();
		indent += isLast ? "    " : "│   ";
		
		Node? lastChild = node.GetChildren().LastOrDefault();
		foreach (Node child in node.GetChildren())
			PrettyPrint(child, indent, child == lastChild);
	}
}