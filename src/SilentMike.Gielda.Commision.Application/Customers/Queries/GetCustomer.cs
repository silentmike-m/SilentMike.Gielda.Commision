namespace SilentMike.Gielda.Commision.Application.Customers.Queries;

using SilentMike.Gielda.Commision.Application.Customers.Models;

public sealed record GetCustomer : IRequest<CustomerDto?>
{
    public required Guid CustomerId { get; init; }
}
