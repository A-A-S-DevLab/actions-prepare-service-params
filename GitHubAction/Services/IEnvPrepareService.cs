namespace PrepareServiceParams.GitHubAction.Services;

public interface IEnvPrepareService
{
    ActionOutputs PrepareEnvs(ActionInputs actionInputs);
}