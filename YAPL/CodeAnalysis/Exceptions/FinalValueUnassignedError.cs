namespace YAPL.CodeAnalysis.Exceptions; 

public class FinalValueUnassignedError : Exception {
	public FinalValueUnassignedError(string? message) : base(message) { }
}