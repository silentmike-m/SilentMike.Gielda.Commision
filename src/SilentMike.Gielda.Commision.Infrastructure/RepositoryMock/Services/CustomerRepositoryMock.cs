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

    public Task AddAsync(CustomerEntity entity, CancellationToken cancellationToken)
        => CustomersStore.Customers.TryAdd(entity.Id.Value, this.customerDbMapper.ToDbModel(entity)) is false
            ? throw new Exception()
            : Task.CompletedTask;

    public Task DeleteAsync(CustomerEntity entity, CancellationToken cancellationToken)
    {
        CustomersStore.Customers.Remove(entity.Id.Value);

        return Task.CompletedTask;
    }

    public Task<CustomerEntity?> GetAsync(CustomerId customerId, CancellationToken cancellationToken)
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

    public Task UpdateAsync(CustomerEntity entity, CancellationToken cancellationToken)
    {
        if (CustomersStore.Customers.ContainsKey(entity.Id.Value) is false)
        {
            throw new Exception();
        }

        CustomersStore.Customers[entity.Id.Value] = this.customerDbMapper.ToDbModel(entity);

        return Task.CompletedTask;
    }
}
