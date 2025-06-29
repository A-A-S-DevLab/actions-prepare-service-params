namespace PrepareServiceParams.GitHubAction.Models;

public class ActionInputs
{
    [Option("env_type",
        Required = false,
        Default = Constants.Constants.Prod,
        HelpText = "Environment type")]
    public string EnvType { get; set; } = null!;
    
    [Option("repository_owner",
        Required = true,
        HelpText = "Repository owner")]
    public string RepositoryOwner { get; set; } = null!;
    
    [Option("repository_name",
        Required = true,
        HelpText = "Repository name")]
    public string RepositoryName { get; set; } = null!;
    
    [Option("branch_name",
        Required = true,
        HelpText = "Branch name")]
    public string BranchName { get; set; } = null!;
    
    [Option("image_version",
        Required = false,
        HelpText = "Image version")]
    public string ImageVersion { get; set; } = null!;
    
    [Option("server_name",
        Required = false,
        HelpText = "Server name")]
    public string ServerName { get; set; } = null!;

    [Option("instance_name",
        Required = false,
        HelpText = "Instance name (in lower case)")]
    public string InstanceName { get; set; } = null;
}
