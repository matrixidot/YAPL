namespace YAPL.CodeAnalysis.Exceptions; 

public class FinalReassignError : Exception {
	public FinalReassignError(string? message) : base(message) { }
}