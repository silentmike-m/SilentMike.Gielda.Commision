namespace SilentMike.Gielda.Commision.WebApi.Models.Customers.Requests;

using SilentMike.Gielda.Commision.Domain.Customers.Enums;

public record UpdateCustomer
{
    public required string City { get; init; }
    public required string DocumentNumber { get; init; }
    public required DocumentType DocumentType { get; init; }
    public string? Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? PhoneNumber { get; init; }
    public required string Street { get; init; }
    public required string ZipCode { get; init; }
}
