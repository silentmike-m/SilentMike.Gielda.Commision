namespace SilentMike.Gielda.Commision.Application.Contracts.Models;

public sealed record ContractDto
{
    public decimal Commission { get; init; }
    public required Guid CustomerId { get; init; }
    public required Guid Id { get; init; }
    public required IReadOnlyList<ContractItemDto> Items { get; init; }
    public required string Number { get; init; }
}
