namespace YAPL.CodeAnalysis.Errors; 

public class UnrecognizedCharacterError : Exception {
	public UnrecognizedCharacterError(string? message, Exception? innerException) : base(message, null) { }

}