namespace SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.Constants;

public sealed class AddressEmptyStreetException : DomainException
{
    public override string Code => ErrorCodes.ADDRESS_EMPTY_STREET;

    public AddressEmptyStreetException(Exception? innerException = null)
        : base("Customer address street can not be empty", innerException)
    {
    }
}
