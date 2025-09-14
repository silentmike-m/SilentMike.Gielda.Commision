namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Services;

using System.Diagnostics.CodeAnalysis;
using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Customers.Enums;
using SilentMike.Gielda.Commision.Domain.Customers.Interfaces;
using SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;
using SilentMike.Gielda.Commision.Domain.Types;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;

[ExcludeFromCodeCoverage]
internal sealed class CustomerRepositoryMock : ICustomerRepository
{
    private readonly ICustomerDbMapper customerDbMapper;

    public CustomerRepositoryMock(ICustomerDbMapper customerDbMapper)
        => this.customerDbMapper = customerDbMapper;

    public Task AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken)
        => CustomersStore.Customers.TryAdd(customer.Id.Value, this.customerDbMapper.ToDbModel(customer)) is false
            ? throw new Exception()
            : Task.CompletedTask;

    public Task DeleteCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken)
    {
        CustomersStore.Customers.Remove(customer.Id.Value);

        return Task.CompletedTask;
    }

    public Task<CustomerEntity?> GetCustomerAsync(CustomerId customerId, CancellationToken cancellationToken)
    {
        var result = CustomersStore.Customers.TryGetValue(customerId.Value, out var customer)
            ? new CustomerEntity(
                customerId,
                new Address(customer.City, customer.Street, customer.ZipCode),
                new Contact(customer.Email, customer.PhoneNumber),
                new Document(customer.DocumentNumber, (DocumentType)customer.DocumentType),
                customer.FirstName,
                customer.LastName
            )
            : null;

        return Task.FromResult(result);
    }

    public Task UpdateCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken)
    {
        if (CustomersStore.Customers.ContainsKey(customer.Id.Value) is false)
        {
            throw new Exception();
        }

        CustomersStore.Customers[customer.Id.Value] = this.customerDbMapper.ToDbModel(customer);

        return Task.CompletedTask;
    }
}
