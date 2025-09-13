namespace SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

using SilentMike.Gielda.Commision.Domain.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.Constants;

public sealed class DocumentEmptyNumberException : DomainException
{
    public override string Code => ErrorCodes.DOCUMENT_EMPTY_NUMBER;

    public DocumentEmptyNumberException(Exception? innerException = null)
        : base("Customer document number can not be empty", innerException)
    {
    }
}
