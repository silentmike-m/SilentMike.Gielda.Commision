namespace SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.Constants;

public sealed class ContractItemInvalidPriceException : DomainException
{
    public override string Code => ErrorCodes.CONTRACT_ITEM_INVALID_PRICE;

    public ContractItemInvalidPriceException(Exception? innerException = null)
        : base("Contract item price can not be less than value for customer", innerException)
    {
    }
}
