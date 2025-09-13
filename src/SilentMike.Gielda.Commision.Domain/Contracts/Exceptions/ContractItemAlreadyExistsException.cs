namespace SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.Constants;
using SilentMike.Gielda.Commision.Domain.Types;

public sealed class ContractItemAlreadyExistsException : DomainException
{
    public override string Code => ErrorCodes.CONTRACT_ITEM_ALREADY_EXISTS;

    public ContractItemAlreadyExistsException(ContractItemId itemId, Exception? innerException = null)
        : base($"Contract item with id '{itemId.Value}' already exists", innerException)
    {
    }
}
