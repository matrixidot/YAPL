namespace YAPL.Runtime;

using Frontend.Errors;
using Frontend.Parsing.Nodes;
using Frontend.Parsing.Nodes.Expressions;
using Frontend.Parsing.Nodes.Statements;
using System.Dynamic;
using Values;

public class Interpreter {


	public static RuntimeValue Evaluate(Statement? node) {
		if (node is null)
			return new NullValue();
		switch (node.Type) {
			case NodeType.NUMERIC_LITERAL:
				return new NumberValue((node as NumericLiteral)!.Value);
			case NodeType.NULL_LITERAL:
				return new NullValue();
			case NodeType.BINARY_EXPR:
				return EvalBinExpr((node as BinaryExpr)!);
			case NodeType.PROGRAM:
				return EvalProgram((node as Program)!);
			default:
				throw new UnrecognizedNodeError($"The node type of <{node.Type}> has not been defined for interpretation.");
		}
	}

	private static RuntimeValue EvalProgram(Program program) {
		RuntimeValue lastEval = new NullValue();

		foreach (Statement? stmt in program.Body) {
			lastEval = Evaluate(stmt);
		}
		
		return lastEval;
	}

	private static RuntimeValue EvalBinExpr(BinaryExpr node) {
		RuntimeValue lhs = Evaluate(node.Left);
		RuntimeValue rhs = Evaluate(node.Right);

		if (lhs.Type == ValueType.NUMBER && rhs.Type == ValueType.NUMBER) {
			return EvalNumericBinExpr((lhs as NumberValue)!, (rhs as NumberValue)!, node.Operator);
		}

		return new NullValue();
	}

	private static NumberValue EvalNumericBinExpr(NumberValue lhs, NumberValue rhs, string op) {
		return op switch {
			"+" => new NumberValue(lhs.Value + rhs.Value),
			"-" => new NumberValue(lhs.Value - rhs.Value),
			"*" => new NumberValue(lhs.Value * rhs.Value),
			"/" => new NumberValue(lhs.Value / rhs.Value),
			"%" => new NumberValue(lhs.Value % rhs.Value),
		};
	}
}