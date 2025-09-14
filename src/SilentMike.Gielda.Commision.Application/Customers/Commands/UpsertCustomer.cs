namespace SilentMike.Gielda.Commision.Application.Customers.Commands;

using SilentMike.Gielda.Commision.Domain.Customers.Enums;

public sealed record UpsertCustomer : IRequest
{
    public required string City { get; init; }
    public required string DocumentNumber { get; init; }
    public required DocumentType DocumentType { get; init; }
    public string Email { get; init; } = string.Empty;
    public required string FirstName { get; init; }
    public required Guid Id { get; init; }
    public required string LastName { get; init; }
    public string PhoneNumber { get; init; } = string.Empty;
    public required string Street { get; init; }
    public required string ZipCode { get; init; }
}
