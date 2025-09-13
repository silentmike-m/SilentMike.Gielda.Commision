namespace SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;

using SilentMike.Gielda.Commision.Domain.Customers.Enums;
using SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

public sealed record Document
{
    public string DocumentNumber { get; }
    public DocumentType DocumentType { get; }

    public Document(string documentNumber, DocumentType documentType)
    {
        if (string.IsNullOrWhiteSpace(documentNumber))
        {
            throw new DocumentEmptyNumberException();
        }

        this.DocumentNumber = documentNumber;
        this.DocumentType = documentType;
    }
}
