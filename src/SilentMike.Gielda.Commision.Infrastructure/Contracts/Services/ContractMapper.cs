namespace SilentMike.Gielda.Commision.Infrastructure.Contracts.Services;

using Riok.Mapperly.Abstractions;
using SilentMike.Gielda.Commision.Application.Contracts.Models;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Models;

[Mapper]
internal sealed partial class ContractMapper : IContractMapper
{
    public partial ContractDto ToDto(ContractReadModel customer);
    public partial ContractItemDto ToDto(ContractItemReadModel customer);
}
