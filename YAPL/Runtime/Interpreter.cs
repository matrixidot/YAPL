namespace YAPL.Runtime;

using Frontend.Errors;
using Frontend.Parsing.Nodes;
using Frontend.Parsing.Nodes.Expressions;
using Frontend.Parsing.Nodes.Statements;
using System.Dynamic;
using Values;

public class Interpreter {


	public static RuntimeValue Evaluate(Statement? node, Environment env) {
		if (node is null)
			return new NullValue();
		switch (node.Type) {
			case NodeType.NUMERIC_LITERAL:
				return new NumberValue((node as NumericLiteral)!.Value);
			case NodeType.IDENTIFIER:
				return EvalIdentifier((node as Identifier)!, env);
			case NodeType.NULL_LITERAL:
				return new NullValue();
			case NodeType.BINARY_EXPR:
				return EvalBinExpr((node as BinaryExpr)!, env);
			case NodeType.PROGRAM:
				return EvalProgram((node as Program)!, env);
			default:
				throw new UnrecognizedNodeError($"The node type of <{node.Type}> has not been defined for interpretation.");
		}
	}

	private static RuntimeValue EvalProgram(Program program, Environment env) {
		RuntimeValue lastEval = new NullValue();

		foreach (Statement? stmt in program.Body) {
			lastEval = Evaluate(stmt, env);
		}
		
		return lastEval;
	}

	private static RuntimeValue EvalBinExpr(BinaryExpr node, Environment env) {
		RuntimeValue lhs = Evaluate(node.Left, env);
		RuntimeValue rhs = Evaluate(node.Right, env);

		if (lhs.Type == ValueTypes.NUMBER && rhs.Type == ValueTypes.NUMBER) {
			return EvalNumericBinExpr((lhs as NumberValue)!, (rhs as NumberValue)!, node.Operator);
		}

		return new NullValue();
	}

	public static RuntimeValue EvalIdentifier(Identifier ident, Environment env) {
		var val = env.LookupVar(ident.Symbol);
		return val;
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