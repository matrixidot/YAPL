namespace YAPL.CodeAnalysis.Exceptions; 

public class UnknownNodeError : Exception {
	public UnknownNodeError(string? message) : base(message) { }
}