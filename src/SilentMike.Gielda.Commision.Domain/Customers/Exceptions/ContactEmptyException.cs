namespace SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.Constants;

public sealed class ContactEmptyException : DomainException
{
    public override string Code => ErrorCodes.CONTACT_EMPTY;

    public ContactEmptyException(Exception? innerException = null)
        : base("Customer contact e-mail or phone has to be provided", innerException)
    {
    }
}
