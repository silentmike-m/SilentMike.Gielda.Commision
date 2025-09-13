namespace SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.Constants;

public sealed class CustomerLastNameException : DomainException
{
    public override string Code => ErrorCodes.CUSTOMER_EMPTY_LAST_NAME;

    public CustomerLastNameException(Exception? innerException = null)
        : base("Customer last name can not be empty", innerException)
    {
    }
}
