namespace SilentMike.Gielda.Commision.Application.Customers.Commands;

public sealed record DeleteCustomer : IRequest
{
    public required Guid CustomerId { get; init; }
}
