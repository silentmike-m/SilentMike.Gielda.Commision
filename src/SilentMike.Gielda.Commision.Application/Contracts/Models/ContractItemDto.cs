namespace SilentMike.Gielda.Commision.Application.Contracts.Models;

public sealed record ContractItemDto
{
    public required decimal CustomerValue { get; init; }
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}
