public class VariableAlreadyDeclaredError : Exception {
    public VariableAlreadyDeclaredError(string? message, Exception? innerException = null) : base(message, null) { }
    
}