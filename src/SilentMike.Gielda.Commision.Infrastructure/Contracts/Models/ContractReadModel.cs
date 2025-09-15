namespace SilentMike.Gielda.Commision.Infrastructure.Contracts.Models;

internal sealed record ContractReadModel
{
    public decimal Commission { get; init; }
    public required Guid CustomerId { get; init; }
    public required Guid Id { get; init; }
    public required IReadOnlyList<ContractItemReadModel> Items { get; init; }
    public required string Number { get; init; }
}
