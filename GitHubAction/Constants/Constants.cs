namespace PrepareServiceParams.GitHubAction.Constants;

public static class Constants
{
    public const string Prod = "prod";
    public const string Dev = "dev";
    
    public const string ProdSuffix = "";
    public const string DevSuffix = "-dev";
    
    public const string DefaultImageVersion = "latest";

    public static readonly Dictionary<string, string> EnvSuffixes = new()
    {
        { Prod, ProdSuffix },
        { Dev, DevSuffix }
    };
}