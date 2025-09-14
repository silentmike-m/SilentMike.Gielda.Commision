namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Services;

using System.Diagnostics.CodeAnalysis;
using SilentMike.Gielda.Commision.Domain.Types;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Models;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;

[ExcludeFromCodeCoverage]
internal sealed class CustomerReadServiceMock : ICustomerReadService
{
    private readonly ICustomerDbMapper customerDbMapper;

    public CustomerReadServiceMock(ICustomerDbMapper customerDbMapper)
        => this.customerDbMapper = customerDbMapper;

    public Task<CustomerReadModel?> GetCustomerAsync(CustomerId customerId, CancellationToken cancellationToken)
    {
        var result = CustomersStore.Customers.TryGetValue(customerId.Value, out var customer)
            ? this.customerDbMapper.ToReadModel(customer)
            : null;

        return Task.FromResult(result);
    }

    public Task<IReadOnlyList<CustomerReadModel>> GetCustomersAsync(CancellationToken cancellationToken)
    {
        var customers = CustomersStore.Customers.Values
            .Select(customer => this.customerDbMapper.ToReadModel(customer))
            .ToList();

        return Task.FromResult<IReadOnlyList<CustomerReadModel>>(customers);
    }
}
