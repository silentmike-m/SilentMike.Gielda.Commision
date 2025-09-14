namespace SilentMike.Gielda.Commision.WebApi.Models.Customers.Requests;

public sealed record AddCustomer : UpdateCustomer
{
    public required Guid Id { get; init; }
}
