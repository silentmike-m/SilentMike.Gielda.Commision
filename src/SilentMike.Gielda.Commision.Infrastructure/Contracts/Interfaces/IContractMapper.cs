namespace SilentMike.Gielda.Commision.Infrastructure.Contracts.Interfaces;

using SilentMike.Gielda.Commision.Application.Contracts.Models;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Models;

internal interface IContractMapper
{
    ContractDto ToDto(ContractReadModel customer);
    ContractItemDto ToDto(ContractItemReadModel customer);
}
