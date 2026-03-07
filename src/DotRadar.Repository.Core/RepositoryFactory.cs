namespace DotRadar.Repository.Core;

[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
    Justification = "Class is instantiated via dependency injection")]
internal sealed class RepositoryFactory(Func<IEnumerable<IRepository>> repositoryFunc) : IRepositoryFactory
{
    public Result<IRepository?> CreateRepository(RepositorySource source)
    {
        IRepository? repository = repositoryFunc().FirstOrDefault(r => r.Source == source);
        if (repository != null)
        {
            return repository.AsSuccess();
        }

        return new ResultException($"Repository with source {source} not found.").AsFailure<IRepository>();
    }
}
