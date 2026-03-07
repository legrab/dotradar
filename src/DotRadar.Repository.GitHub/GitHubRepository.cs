namespace DotRadar.Repository.GitHub;

[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
    Justification = "Class is instantiated via dependency injection")]
internal sealed class GitHubRepository : IRepository
{
    public RepositorySource Source => RepositorySource.GitHub;
}
