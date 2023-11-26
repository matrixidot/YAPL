namespace YAPL;

using Frontend.Parsing;
using Frontend.Parsing.Nodes.Statements;
using Runtime;
using Runtime.Values;

class YAPL {
	public static void Main(string[] args) {
		Parser parser = new();
		while (true) {
			Console.Write("YAPL > ");
			string? line = Console.ReadLine();
			if (line is null or "exit")
				break;

			Program program = parser.produceAST(line);
			//Console.WriteLine(program);

			RuntimeValue result = Interpreter.Evaluate(program);
			Console.WriteLine(result);
		}
	}
}