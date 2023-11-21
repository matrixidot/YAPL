namespace YAPL.CodeAnalysis.Exceptions; 

public class UnknownCharacterError : Exception {
	public UnknownCharacterError(string? message) : base(message) { }
}