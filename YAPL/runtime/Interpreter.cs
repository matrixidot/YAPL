namespace YAPL.runtime;

using CodeAnalysis;
using CodeAnalysis.Exceptions;
using Nodes;
using System.Globalization;
using System.Security.AccessControl;
using Values;

public class Interpreter {
	
	public Value Evaluate(Node Node) {
		switch (Node.Type) {
			case TokenType.NUMBER:
				return new NumberValue(((Number)Node).Value);
			case TokenType.NULL:
				return new NullValue(((Null)Node).Value);
			case TokenType.BIN_EXP:
				return EvalBinExp((BinExp) Node);
			default:
				throw new UnknownNodeError($"Node of type <{Node.Type}> has not yet been defined.");
		}
	}

	 private Value EvalBinExp(BinExp binExp) {
		 Value lhs = Evaluate(binExp.Left);
		 Value rhs = Evaluate(binExp.Right);

		 if (lhs.Type == ValueType.NUMBER && rhs.Type == ValueType.NUMBER) {
			 return EvalNumericBinExp((NumberValue)lhs, (NumberValue)rhs, binExp.Op);
		 }
		 // one or both are null;
		 return new NullValue("null");
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