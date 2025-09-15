namespace SilentMike.Gielda.Commision.Infrastructure.Contracts.Interfaces;

using SilentMike.Gielda.Commision.Domain.Types;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Models;

internal interface IContractReadService
{
    Task<ContractReadModel?> GetAsync(ContractNumber contractNumber, CancellationToken cancellationToken);
    Task<ContractReadModel?> GetAsync(ContractId contractId, CancellationToken cancellationToken);
    Task<IReadOnlyList<ContractReadModel>> GetAsync(CustomerId customerId, CancellationToken cancellationToken);
}
