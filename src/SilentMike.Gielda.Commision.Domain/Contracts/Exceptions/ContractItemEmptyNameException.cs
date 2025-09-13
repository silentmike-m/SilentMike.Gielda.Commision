namespace SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.Constants;

public sealed class ContractItemEmptyNameException : DomainException
{
    public override string Code => ErrorCodes.CONTRACT_ITEM_EMPTY_NAME;

    public ContractItemEmptyNameException(Exception? innerException = null)
        : base("Contract item name can not be empty", innerException)
    {
    }
}
