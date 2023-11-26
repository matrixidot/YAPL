namespace YAPL.Frontend.Errors; 

public class UnrecognizedNodeError : Exception {
	public UnrecognizedNodeError(string? message, Exception? innerException = null) : base(message, null) { }
}