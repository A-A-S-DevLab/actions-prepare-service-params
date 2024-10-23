using System.Reflection;
using System.Text;

namespace PrepareServiceParams.GitHubAction.CommandLineExtension;

public static partial class ParserResultExtensions
{
    private static readonly Action<string, string> DefaultPrintEnvAction = (envName, envValue) =>
    {
        // https://docs.github.com/actions/reference/workflow-commands-for-github-actions#setting-an-output-parameter
        // ::set-output deprecated as mentioned in https://github.blog/changelog/2022-10-11-github-actions-deprecating-save-state-and-set-output-commands/
        var githubOutputFile = Environment.GetEnvironmentVariable("GITHUB_OUTPUT", EnvironmentVariableTarget.Process);
        if (!string.IsNullOrWhiteSpace(githubOutputFile))
        {
            using var textWriter = new StreamWriter(githubOutputFile!, true, Encoding.UTF8);
            textWriter.WriteLine($"{envName}={envValue}");
        }
        else
        {
            Console.WriteLine($"::set-output name={envName}::{envValue}");
        }
    };

    public static ParserResult<T> WithParsedOutput<T, TO>(this ParserResult<T> result, Func<T, TO> action, Action<string, string> printEnvAction = null)
    {
        if (result is not Parsed<T> parsed)
        {
            return result;
        }
        
        var outputs = action(parsed.Value);

        outputs?.PrintEnvironmentVariable(printEnvAction ?? DefaultPrintEnvAction);
        
        return result;
    }
    
    private static void PrintEnvironmentVariable<TO>(this TO outputs, Action<string, string> printEnvAction)
    {
        foreach (var propertyInfo in outputs.GetType().GetProperties())
        {
            var description = propertyInfo.GetCustomAttribute<OptionAttribute>();
            if (description == null)
            {
                continue;
            }

            PrintEnvironmentVariable(description.LongName, propertyInfo.GetValue(outputs)?.ToString(), description.Default?.ToString(), description.Required, printEnvAction);
        }
    }
    
    private static void PrintEnvironmentVariable(string envName, string envValue, string envDefaultValue, bool envRequired, Action<string, string> printEnvAction)
    {
        if (string.IsNullOrWhiteSpace(envName))
        {
            throw new ArgumentNullException($"Env variable name of {nameof(envName)} property is empty");
        }
    
        if (envRequired && envValue == null)
        {
            throw new ArgumentNullException($"Env variable value of {nameof(envName)} property is empty");
        }
        
        envName = envName.ToUpper();
        
        envValue ??= envDefaultValue ?? string.Empty;
        
        printEnvAction.Invoke(envName, envValue);
    }
}
