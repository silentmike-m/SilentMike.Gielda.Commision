namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Services;

using Riok.Mapperly.Abstractions;
using SilentMike.Gielda.Commision.Domain.Contracts.Entities;
using SilentMike.Gielda.Commision.Domain.Types;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Models;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Models;

[Mapper]
internal sealed partial class ContractDbMapper : IContractDbMapper
{
    public partial ContractDbEntity ToDbModel(ContractEntity contract);

    [MapProperty(nameof(ContractItemEntity.Value.CustomerValue), nameof(ContractItemDbEntity.CustomerValue))]
    [MapProperty(nameof(ContractItemEntity.Value.Price), nameof(ContractItemDbEntity.Price))]
    public partial ContractItemDbEntity ToDbModel(ContractItemEntity contractItem);

    public partial ContractReadModel ToReadModel(ContractDbEntity contractItem);
    public partial ContractItemReadModel ToReadModel(ContractItemDbEntity contractItem);

    private static Guid ContractIdToGuid(ContractId id) => id.Value;
    private static Guid ContractItemIdToGuid(ContractItemId id) => id.Value;
    private static Guid CustomerIdToGuid(CustomerId id) => id.Value;
}
