namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock;

using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Models;

internal static class CustomersStore
{
    public static Dictionary<Guid, CustomerDbEntity> Customers { get; } = new();
}
