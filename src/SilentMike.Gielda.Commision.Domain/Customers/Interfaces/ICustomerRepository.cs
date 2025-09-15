namespace SilentMike.Gielda.Commision.Domain.Customers.Interfaces;

using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Types;

public interface ICustomerRepository
{
    Task AddAsync(CustomerEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(CustomerEntity entity, CancellationToken cancellationToken);
    Task<CustomerEntity?> GetAsync(CustomerId customerId, CancellationToken cancellationToken);
    Task UpdateAsync(CustomerEntity entity, CancellationToken cancellationToken);
}
