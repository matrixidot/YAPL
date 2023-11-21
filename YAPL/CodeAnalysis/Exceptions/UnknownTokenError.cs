namespace YAPL.CodeAnalysis.Exceptions; 

public class UnknownTokenError : Exception{
	public UnknownTokenError(string? message) : base(message) { }
}