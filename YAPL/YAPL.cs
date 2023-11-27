namespace YAPL;

using Frontend.Parsing;
using Frontend.Parsing.Nodes.Statements;
using Runtime;
using Runtime.Values;

class YAPL {
	public static void Main(string[] args) {
		
		Parser parser = new();
		Environment global = new();

		InitGlobalVars(global);

		while (true) {
			Console.Write("YAPL > ");
			string? line = Console.ReadLine();
			if (line is null or "exit")
				break;

			Program program = parser.produceAST(line);
			//Console.WriteLine(program);

			RuntimeValue result = Interpreter.Evaluate(program, global);
			Console.WriteLine(result);
		}
	}

	private static void InitGlobalVars(Environment global) {
		global.DeclareVar("x", new NumberValue(100));
		global.DeclareVar("true", new BooleanValue(true));
		global.DeclareVar("false", new BooleanValue());
		global.DeclareVar("null", new NullValue());
	}
}