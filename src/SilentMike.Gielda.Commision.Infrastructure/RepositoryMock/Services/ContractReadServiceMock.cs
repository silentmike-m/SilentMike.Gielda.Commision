namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Services;

using SilentMike.Gielda.Commision.Domain.Types;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Models;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;

internal sealed class ContractReadServiceMock : IContractReadService
{
    private readonly IContractDbMapper contractDbMapper;

    public ContractReadServiceMock(IContractDbMapper contractDbMapper)
        => this.contractDbMapper = contractDbMapper;

    public Task<ContractReadModel?> GetAsync(ContractNumber contractNumber, CancellationToken cancellationToken)
    {
        var contract = ContractsStore.Contracts.Values
            .SingleOrDefault(contract => contract.Number == contractNumber.Value);

        var result = contract is null
            ? null
            : this.contractDbMapper.ToReadModel(contract);

        return Task.FromResult(result);
    }

    public Task<ContractReadModel?> GetAsync(ContractId contractId, CancellationToken cancellationToken)
    {
        var result = ContractsStore.Contracts.TryGetValue(contractId.Value, out var contract)
            ? this.contractDbMapper.ToReadModel(contract)
            : null;

        return Task.FromResult(result);
    }

    public Task<IReadOnlyList<ContractReadModel>> GetAsync(CustomerId customerId, CancellationToken cancellationToken)
    {
        var result = ContractsStore.Contracts.Values
            .Where(contract => contract.CustomerId == customerId)
            .Select(contract => this.contractDbMapper.ToReadModel(contract))
            .ToList();

        return Task.FromResult<IReadOnlyList<ContractReadModel>>(result);
    }
}
