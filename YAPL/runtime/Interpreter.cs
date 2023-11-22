namespace YAPL.runtime;

using CodeAnalysis;
using CodeAnalysis.Exceptions;
using Nodes;
using System.Globalization;
using Values;

public class Interpreter {
	
	public Value Evaluate(Node Node, Environment env) {
		switch (Node.Type) {
			case TokenType.NUMBER:
				return new NumberValue(((Number)Node).Value);
			case TokenType.IDENTIFIER:
				return EvalIdentifier(((Identifier)Node), env);
			case TokenType.BIN_EXP:
				return EvalBinExp((BinExp) Node, env);
			case TokenType.VAR_DEC:
				return EvalVarDec((VarDec)Node, env);
			case TokenType.ASSIGN_EXP:
				return EvalVarAssignment((AssignExp)Node, env);
			default:
				throw new UnknownNodeError($"Node of type <{Node.Type}> has not yet been defined.");
		}
	}

	private Value EvalVarAssignment(AssignExp expr, Environment env) {
		if (expr.Asignee.Type != TokenType.IDENTIFIER) {
			throw new AssignToNonVarError($"Attempted to assign a value to <{expr.Asignee.Type}> expected <IDENTIFIER>.");
		}
		var varName = ((Identifier)expr.Asignee).Symbol;
		return env.AssignVar(varName, Evaluate(expr.Value, env));
	}

	private Value EvalVarDec(VarDec varDec, Environment env) {
		Value val = varDec.Value != null ? Evaluate(varDec.Value, env) : new NullValue();
		return env.DeclareVar(varDec.Identifier, val, varDec.IsFinal);
	}

	private Value EvalIdentifier(Identifier ident, Environment env) {
		Value val = env.LookupVar(ident.Symbol);
		return val;
	}
	
	 private Value EvalBinExp(BinExp binExp, Environment env) {
		 Value lhs = Evaluate(binExp.Left, env);
		 Value rhs = Evaluate(binExp.Right, env);

		 if (lhs.Type == ValueType.NUMBER && rhs.Type == ValueType.NUMBER) {
			 return EvalNumericBinExp((NumberValue)lhs, (NumberValue)rhs, binExp.Op);
		 }
		 // one or both are null;
		 return new NullValue();
	 }
	 private NumberValue EvalNumericBinExp(NumberValue lhs, NumberValue rhs, string op) {
		 double result = 0;
		 switch (op) {
			 case "+":
				 result = double.Parse(lhs.Val) + double.Parse(rhs.Val);
				 break;
			 case "-":
				 result = double.Parse(lhs.Val) - double.Parse(rhs.Val);
				 break;
			 case "*":
				 result = double.Parse(lhs.Val) * double.Parse(rhs.Val);
				 break;
			 case "/":
				 result = double.Parse(lhs.Val) / double.Parse(rhs.Val);
				 break;
			 case "%":
				 result = double.Parse(lhs.Val) % double.Parse(rhs.Val);
				 break;
		 }
		 return new NumberValue(result.ToString(CultureInfo.InvariantCulture));
	 }

	 
}