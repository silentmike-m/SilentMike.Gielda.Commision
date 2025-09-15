namespace SilentMike.Gielda.Commision.Infrastructure.Contracts.Models;

internal sealed record ContractItemReadModel
{
    public required decimal CustomerValue { get; init; }
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}
