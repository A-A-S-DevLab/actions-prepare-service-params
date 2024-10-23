namespace PrepareServiceParams.GitHubAction.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddGitHubActionServices(this IServiceCollection services) =>
        services.AddTransient<IEnvPrepareService, EnvPrepareService>();
}
