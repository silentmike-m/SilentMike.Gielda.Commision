namespace SilentMike.Gielda.Commision.Application.Customers.Queries;

using SilentMike.Gielda.Commision.Application.Customers.Models;

public sealed record GetCustomers : IRequest<IReadOnlyList<CustomerDto>>;
