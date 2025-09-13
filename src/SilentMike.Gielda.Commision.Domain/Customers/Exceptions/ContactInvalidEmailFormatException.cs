namespace SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.Constants;

public sealed class ContactInvalidEmailFormatException : DomainException
{
    public override string Code => ErrorCodes.CONTACT_INVALID_EMAIL_FORMAT;

    public ContactInvalidEmailFormatException(string email, Exception? innerException = null)
        : base("Customer contact e-mail 'email' has invalid format", innerException)
    {
    }
}
