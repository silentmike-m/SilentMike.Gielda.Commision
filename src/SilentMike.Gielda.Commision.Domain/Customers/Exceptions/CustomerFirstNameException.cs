namespace SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.Constants;

public sealed class CustomerFirstNameException : DomainException
{
    public override string Code => ErrorCodes.CUSTOMER_EMPTY_FIRST_NAME;

    public CustomerFirstNameException(Exception? innerException = null)
        : base("Customer first name can not be empty", innerException)
    {
    }
}
