namespace SilentMike.Gielda.Commision.Application.Customers.Interfaces;

using SilentMike.Gielda.Commision.Domain.Types;

public interface ICustomerValidationService
{
    Task<bool> ContractExistsAsync(CustomerId customerId, CancellationToken cancellationToken);
}
