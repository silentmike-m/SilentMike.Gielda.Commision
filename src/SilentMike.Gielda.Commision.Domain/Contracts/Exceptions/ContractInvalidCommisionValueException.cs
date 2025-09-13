namespace SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.Constants;

public sealed class ContractInvalidCommisionValueException : DomainException
{
    public override string Code => ErrorCodes.CONTRACT_INVALID_COMMISION_VALUE;

    public ContractInvalidCommisionValueException(Exception? innerException = null)
        : base("Contract commission can not be less than zero", innerException)
    {
    }
}
