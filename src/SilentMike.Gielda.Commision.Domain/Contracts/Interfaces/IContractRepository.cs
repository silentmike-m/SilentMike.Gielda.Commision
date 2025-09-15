namespace SilentMike.Gielda.Commision.Domain.Contracts.Interfaces;

using SilentMike.Gielda.Commision.Domain.Contracts.Entities;
using SilentMike.Gielda.Commision.Domain.Types;

public interface IContractRepository
{
    Task AddAsync(ContractEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(ContractEntity entity, CancellationToken cancellationToken);
    Task<ContractEntity?> GetAsync(ContractId contractId, CancellationToken cancellationToken);
    Task UpdateAsync(ContractEntity entity, CancellationToken cancellationToken);
}
