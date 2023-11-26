namespace YAPL.Frontend.Errors; 

public class UnexpectedTokenError : Exception {
	public UnexpectedTokenError(string? message, Exception? innerException = null) : base(message, null) { }
}