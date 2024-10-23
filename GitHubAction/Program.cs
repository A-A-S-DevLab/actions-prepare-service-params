using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => services.AddGitHubActionServices())
    .Build();

static TService Get<TService>(IHost host)
    where TService : notnull =>
    host.Services.GetRequiredService<TService>();

var parser = Default.ParseArguments(() => new ActionInputs(), args);

parser.WithNotParsed(errors =>
{
    Get<ILoggerFactory>(host)
        .CreateLogger("GitHubAction.Program")
        .LogError(string.Join(Environment.NewLine, errors.Select(error => error.ToString())));

    Environment.Exit(2);
});

parser.WithParsedOutput(inputs =>
{
    try
    {
        return Action(inputs, host);
    }
    catch (Exception e)
    {
        Get<ILoggerFactory>(host)
            .CreateLogger("GitHubAction.Program")
            .LogError(e.Message);
        
        Environment.Exit(2);
    }

    return null;
});

Environment.Exit(0);

static ActionOutputs Action(ActionInputs inputs, IHost host)
{
    using CancellationTokenSource tokenSource = new();

    Console.CancelKeyPress += delegate
    {
        tokenSource.Cancel();
    };
    
    var service = Get<IEnvPrepareService>(host);
    
    return service.PrepareEnvs(inputs);
}