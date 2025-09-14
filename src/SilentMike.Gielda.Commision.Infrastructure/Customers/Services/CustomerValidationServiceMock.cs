namespace SilentMike.Gielda.Commision.Infrastructure.Customers.Services;

using System.Diagnostics.CodeAnalysis;
using SilentMike.Gielda.Commision.Application.Customers.Interfaces;
using SilentMike.Gielda.Commision.Domain.Types;

[ExcludeFromCodeCoverage]
internal sealed class CustomerValidationServiceMock : ICustomerValidationService
{
    public Task<bool> ContractExistsAsync(CustomerId customerId, CancellationToken cancellationToken)
        => Task.FromResult(false);
}
