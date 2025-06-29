namespace PrepareServiceParams.GitHubAction.Models;

public class ActionOutputs
{
    [Option("env_type",
        Required = true,
        Default = Constants.Constants.Prod,
        HelpText = "Environment type (in lower case)")]
    public string EnvType { get; set; }
    
    [Option("env_type_postfix",
        Required = true,
        HelpText = "Environment tag (in lower case)")]
    public string EnvTypePostfix { get; set; }
    
    [Option("repository_owner",
        Required = true,
        HelpText = "Repository owner (in lower case)")]
    public string RepositoryOwner { get; set; }
    
    [Option("repository_name",
        Required = true,
        HelpText = "Repository name (in lower case)")]
    public string RepositoryName { get; set; }
    
    [Option("branch_name",
        Required = true,
        HelpText = "Branch name (in lower case)")]
    public string BranchName { get; set; }
    
    [Option("image_version",
        Default = Constants.Constants.DefaultImageVersion,
        HelpText = "Image version (in lower case)")]
    public string ImageVersion { get; set; }
    
    [Option("service_network",
        HelpText = "Service network (in lower case)")]
    public string ServiceNetwork { get; set; }
    
    [Option("container_name",
        HelpText = "Container name (in lower case)")]
    public string ContainerName { get; set; }
    
    [Option("container_short_name",
        HelpText = "Container short name (in lower case)")]
    public string ContainerShortName { get; set; }
    
    [Option("server_name",
        HelpText = "Server name (in lower case)")]
    public string ServerName { get; set; }
    
    [Option("server_short_name",
        HelpText = "Server short name (in lower case)")]
    public string ServerShortName { get; set; }
    
    [Option("service_target_folder",
        HelpText = "Service target folder (in lower case)")]
    public string ServiceTargetFolder { get; set; }
    
    [Option("domain_name",
        HelpText = "Service domain name (in lower case)")]
    public string DomainName { get; set; }

    [Option("instance_name",
        HelpText = "Instance name (in lower case)")]
    public string InstanceName { get; set; }

    [Option("instance_name_postfix",
        HelpText = "Instance name (in lower case)")]
    public string InstanceNamePostfix { get; set; }
}