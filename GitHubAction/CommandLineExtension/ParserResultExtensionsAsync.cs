namespace PrepareServiceParams.GitHubAction.CommandLineExtension;

public static partial class ParserResultExtensions
{
    public static async Task<ParserResult<T>> WithParsedOutputAsync<T, TO>(this ParserResult<T> result, Func<T, Task<TO>> action, Action<string, string> printEnvAction = null)
    {
        if (result is not Parsed<T> parsed)
        {
            return result;
        }
        
        var outputs = await action(parsed.Value);

        outputs?.PrintEnvironmentVariable(printEnvAction ?? DefaultPrintEnvAction);
        
        return result;
    }
}
