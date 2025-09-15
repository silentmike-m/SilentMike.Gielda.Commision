namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock;

using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Models;

internal static class ContractsStore
{
    public static Dictionary<Guid, ContractDbEntity> Contracts { get; } = new();
}
