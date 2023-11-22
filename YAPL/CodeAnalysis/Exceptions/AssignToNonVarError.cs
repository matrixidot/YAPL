namespace YAPL.CodeAnalysis.Exceptions; 

public class AssignToNonVarError : Exception {
	public AssignToNonVarError(string? message) : base(message) { }
}