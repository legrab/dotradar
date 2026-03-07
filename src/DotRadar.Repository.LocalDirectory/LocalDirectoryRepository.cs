namespace DotRadar.Repository.LocalDirectory;

public sealed class LocalDirectoryRepository : IRepository
{
    public RepositorySource Source => RepositorySource.LocalDirectory;
}
