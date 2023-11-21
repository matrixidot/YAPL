namespace YAPL.CodeAnalysis.Exceptions; 

public class VariableAleadyDefinedError : Exception {
	public VariableAleadyDefinedError(string? message) : base(message) { }
}