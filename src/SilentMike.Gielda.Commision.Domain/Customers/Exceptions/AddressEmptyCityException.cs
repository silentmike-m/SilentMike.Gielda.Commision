namespace SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.Constants;

public sealed class AddressEmptyCityException : DomainException
{
    public override string Code => ErrorCodes.ADDRESS_EMPTY_CITY;

    public AddressEmptyCityException(Exception? innerException = null)
        : base("Customer address city can not be empty", innerException)
    {
    }
}
