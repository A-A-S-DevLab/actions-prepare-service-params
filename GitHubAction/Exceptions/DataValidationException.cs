namespace PrepareServiceParams.GitHubAction.Exceptions;

public class DataValidationException : Exception
{
    public DataValidationException(string message) : base(message) { }
    
    public DataValidationException(string message, Exception exception) : base(message, exception) { }
}