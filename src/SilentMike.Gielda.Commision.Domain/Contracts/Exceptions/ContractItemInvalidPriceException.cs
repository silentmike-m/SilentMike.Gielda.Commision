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

public sealed class ContractEmptyNumberException : DomainException
{
    public override string Code => ErrorCodes.CONTRACT_EMPTY_NUMBER;

    public ContractEmptyNumberException(Exception? innerException = null)
        : base("Contract number can not be empty", innerException)
    {
    }
}
