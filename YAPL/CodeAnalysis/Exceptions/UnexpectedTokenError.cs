namespace YAPL.CodeAnalysis.Exceptions; 

public class UnexpectedTokenError : Exception {
	public UnexpectedTokenError(string? message) : base(message) { }
}