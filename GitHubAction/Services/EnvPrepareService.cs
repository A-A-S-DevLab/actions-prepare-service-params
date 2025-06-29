using PrepareServiceParams.GitHubAction.Exceptions;

namespace PrepareServiceParams.GitHubAction.Services;

public class EnvPrepareService : IEnvPrepareService
{
    public ActionOutputs PrepareEnvs(ActionInputs actionInputs)
    {
        ValidateInputs(actionInputs);
        
        var actionOutputs = new ActionOutputs();
        
        actionOutputs.EnvType = actionInputs.EnvType.Clear() ?? Constants.Constants.Prod;
        actionOutputs.EnvTypePostfix = Constants.Constants.EnvSuffixes[actionOutputs.EnvType];
        
        actionOutputs.InstanceName = actionInputs.InstanceName.Clear() ?? string.Empty;
        actionOutputs.InstanceNamePostfix = $"-{actionOutputs.InstanceName}";
        
        actionOutputs.RepositoryName = actionInputs.RepositoryName.Clear();
        actionOutputs.RepositoryOwner = actionInputs.RepositoryOwner.Clear();
        actionOutputs.BranchName = actionInputs.BranchName.Clear();
        
        actionOutputs.ImageVersion = actionInputs.ImageVersion.Clear();
        
        actionOutputs.ServiceNetwork = $"{actionOutputs.RepositoryName}-network{actionOutputs.EnvTypePostfix}{actionOutputs.InstanceNamePostfix}";
        
        actionOutputs.ContainerName = $"{actionOutputs.RepositoryName}{actionOutputs.EnvTypePostfix}{actionOutputs.InstanceNamePostfix}";
        actionOutputs.ContainerShortName = actionOutputs.ContainerName.KebabCaseDeleteFirstWord();

        actionOutputs.ServerName = actionInputs.ServerName.Clear();
        actionOutputs.ServerShortName = actionOutputs.ServerName.KebabCaseSecondWord();
        
        actionOutputs.ServiceTargetFolder = $"~/projects/{actionOutputs.ContainerName}";
        
        actionOutputs.DomainName = $"{actionOutputs.ContainerShortName}.{actionOutputs.ServerShortName}.aas";

        return actionOutputs;
    }
    private void ValidateInputs(ActionInputs actionInputs)
    {
        if (actionInputs.EnvType != null
            && !Constants.Constants.EnvSuffixes.ContainsKey(actionInputs.EnvType))
        {
            throw new DataValidationException($"Invalid environment type property value: '{actionInputs.EnvType}'.");
        }
    }
}