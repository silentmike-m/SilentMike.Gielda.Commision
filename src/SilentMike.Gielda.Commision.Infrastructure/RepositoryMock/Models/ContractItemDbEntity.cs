namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Models;

internal sealed record ContractItemDbEntity
{
    public required decimal CustomerValue { get; init; }
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}
