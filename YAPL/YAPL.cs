namespace YAPL;

using CodeAnalysis.Lexing;
using CodeAnalysis.Parsing;
using CodeAnalysis.Parsing.Nodes;

class YAPL {
	public static void Main(string[] args) {
		Parser parser = new();
		while (true) {
			Console.Write("YAPL > ");
			string? line = Console.ReadLine();
			if (line is null or "exit")
				break;

			Program program = parser.produceAST(line);
			Console.WriteLine(program);
		}
	}
}