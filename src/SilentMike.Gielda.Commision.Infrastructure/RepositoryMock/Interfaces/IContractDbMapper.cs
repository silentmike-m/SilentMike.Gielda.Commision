namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;

using SilentMike.Gielda.Commision.Domain.Contracts.Entities;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Models;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Models;

internal interface IContractDbMapper
{
    ContractDbEntity ToDbModel(ContractEntity contract);
    ContractItemDbEntity ToDbModel(ContractItemEntity contractItem);

    ContractReadModel ToReadModel(ContractDbEntity contractItem);
    ContractItemReadModel ToReadModel(ContractItemDbEntity contractItem);
}
