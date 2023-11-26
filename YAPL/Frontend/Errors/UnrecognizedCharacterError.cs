namespace YAPL.Frontend.Errors; 

public class UnrecognizedCharacterError : Exception {
	public UnrecognizedCharacterError(string? message, Exception? innerException = null ) : base(message, null) { }

}