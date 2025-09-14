namespace SilentMike.Gielda.Commision.Infrastructure.Customers.Services;

using System.Diagnostics.CodeAnalysis;
using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Customers.Interfaces;
using SilentMike.Gielda.Commision.Domain.Types;

[ExcludeFromCodeCoverage]
internal sealed class CustomerRepositoryMock : ICustomerRepository
{
    public Task AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken)
        => CustomersStore.Customers.TryAdd(customer.Id, customer) is false
            ? throw new Exception()
            : Task.CompletedTask;

    public Task DeleteCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken)
    {
        CustomersStore.Customers.Remove(customer.Id);

        return Task.CompletedTask;
    }

    public Task<CustomerEntity?> GetCustomerAsync(CustomerId customerId, CancellationToken cancellationToken)
    {
        var _ = CustomersStore.Customers.TryGetValue(customerId, out var customer);

        return Task.FromResult(customer);
    }

    public Task UpdateCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken)
    {
        if (CustomersStore.Customers.ContainsKey(customer.Id) is false)
        {
            throw new Exception();
        }

        CustomersStore.Customers[customer.Id] = customer;

        return Task.CompletedTask;
    }
}
