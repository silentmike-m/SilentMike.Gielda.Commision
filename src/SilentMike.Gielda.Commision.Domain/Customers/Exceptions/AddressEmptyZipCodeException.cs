namespace SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.Constants;

public sealed class AddressEmptyZipCodeException : DomainException
{
    public override string Code => ErrorCodes.ADDRESS_EMPTY_ZIP_CODE;

    public AddressEmptyZipCodeException(Exception? innerException = null)
        : base("Customer address zip code can not be empty", innerException)
    {
    }
}
