namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Services;

using SilentMike.Gielda.Commision.Domain.Contracts.Entities;
using SilentMike.Gielda.Commision.Domain.Contracts.Interfaces;
using SilentMike.Gielda.Commision.Domain.Contracts.ValueObjects;
using SilentMike.Gielda.Commision.Domain.Types;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;

internal sealed class ContractRepositoryMock : IContractRepository
{
    private readonly IContractDbMapper contractDbMapper;

    public ContractRepositoryMock(IContractDbMapper contractDbMapper)
        => this.contractDbMapper = contractDbMapper;

    public Task AddAsync(ContractEntity entity, CancellationToken cancellationToken)
        => ContractsStore.Contracts.TryAdd(entity.Id.Value, this.contractDbMapper.ToDbModel(entity)) is false
            ? throw new Exception()
            : Task.CompletedTask;

    public Task DeleteAsync(ContractEntity entity, CancellationToken cancellationToken)
    {
        ContractsStore.Contracts.Remove(entity.Id.Value);

        return Task.CompletedTask;
    }

    public Task<ContractEntity?> GetAsync(ContractId contractId, CancellationToken cancellationToken)
    {
        if (ContractsStore.Contracts.TryGetValue(contractId.Value, out var contract))
        {
            var result = new ContractEntity(contractId, contract.CustomerId, contract.Commission, contract.Number);

            foreach (var item in contract.Items)
            {
                result.AddItem(new ContractItemEntity(item.Id, item.Name, new ContractItemValue(item.CustomerValue, item.Price)));
            }

            return Task.FromResult<ContractEntity?>(result);
        }

        return Task.FromResult<ContractEntity?>(null);
    }

    public Task UpdateAsync(ContractEntity entity, CancellationToken cancellationToken)
    {
        if (ContractsStore.Contracts.ContainsKey(entity.Id.Value) is false)
        {
            throw new Exception();
        }

        ContractsStore.Contracts[entity.Id.Value] = this.contractDbMapper.ToDbModel(entity);

        return Task.CompletedTask;
    }
}
