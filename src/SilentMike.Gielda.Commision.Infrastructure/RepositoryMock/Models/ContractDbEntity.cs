namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Models;

internal sealed record ContractDbEntity
{
    public decimal Commission { get; init; }
    public required Guid CustomerId { get; init; }
    public required Guid Id { get; init; }
    public required IReadOnlyList<ContractItemDbEntity> Items { get; init; }
    public required string Number { get; init; }
}
