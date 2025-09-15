namespace SilentMike.Gielda.Commision.Infrastructure.Customers.Interfaces;

using SilentMike.Gielda.Commision.Domain.Types;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Models;

internal interface ICustomerReadService
{
    Task<CustomerReadModel?> GetAsync(CustomerId customerId, CancellationToken cancellationToken);
    Task<IReadOnlyList<CustomerReadModel>> GetAsync(CancellationToken cancellationToken);
}
