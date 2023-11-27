public class CannotResolveVarError : Exception {
    public CannotResolveVarError(string? message, Exception? innerException = null) : base(message, null) { }
    
}