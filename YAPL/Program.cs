﻿namespace YAPL;

using CodeAnalysis;
using Nodes;
using runtime;
using runtime.Values;

class Program {
	public static void Main(string[] args) {
		bool showTree = false;
		while (true) {
			Console.Write("> ");
			string line = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(line)) return;
			if (line == "#st") {
				showTree = !showTree;
				Console.WriteLine(showTree ? "Showing parse trees." : "Not showing parse trees.");
				continue;
			}
			if (line == "#cls")
			{
				Console.Clear();
				continue;
			}

			SyntaxTree tree = SyntaxTree.Parse(line);
			if (showTree) {
				PrettyPrint(tree.Root);
			}

			Interpreter interpreter = new Interpreter();
			Value result = interpreter.Evaluate(tree.Root);
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
			Console.Write($"\n{indent + "    "}├── {((BinExp)node).Op}");
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