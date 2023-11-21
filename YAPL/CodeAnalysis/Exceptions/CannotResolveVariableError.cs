namespace YAPL.CodeAnalysis.Exceptions; 

public class CannotResolveVariableError : Exception {
	public CannotResolveVariableError(string? message) : base(message) { }
}