namespace YAPL.Frontend.Parsing.Nodes.Statements; 

public class Program : Statement {
	public override NodeType Type => NodeType.PROGRAM;
	public List<Statement> Body { get; }

	public Program(List<Statement> body) {
		Body = body;
	}

	public override string ToString() {
		string toRet = "{\n" +
		               "  Type: Program,\n" +
		               "  Body: [\n";
		foreach (Statement stmt in Body) {
			toRet += "    " + stmt + ",\n";
		}
		toRet += "  ]\n}";
		return toRet;
	}
}