namespace SilentMike.Gielda.Commision.Domain.Customers.Interfaces;

using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Types;

public interface ICustomerRepository
{
    Task AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken);
    Task DeleteCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken);
    Task<CustomerEntity?> GetCustomerAsync(CustomerId id, CancellationToken cancellationToken);
    Task UpdateCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken);
}
