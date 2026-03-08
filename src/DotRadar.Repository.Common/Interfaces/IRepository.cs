using DotRadar.Repository.Common.Enums;

namespace DotRadar.Repository.Common.Interfaces;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public interface IRepository
{
    public RepositorySource Source { get; }
}
