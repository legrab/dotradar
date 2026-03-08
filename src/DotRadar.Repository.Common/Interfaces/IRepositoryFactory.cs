using DotRadar.Common.Results;
using DotRadar.Repository.Common.Enums;

namespace DotRadar.Repository.Common.Interfaces;

public interface IRepositoryFactory
{
    public Result<IRepository?> CreateRepository(RepositorySource source);
}
