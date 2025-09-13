namespace SilentMike.Gielda.Commision.Domain.UnitTests.Customers.ValueObjects;

using SilentMike.Gielda.Commision.Domain.Customers.Constants;
using SilentMike.Gielda.Commision.Domain.Customers.Enums;
using SilentMike.Gielda.Commision.Domain.Customers.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;

[TestClass]
public sealed class DocumentTests
{
    [TestMethod]
    public void Should_CreateDocument()
    {
        // Arrange
        const string documentNumber = "AOX2345";

        // Act
        var document = new Document(documentNumber, DocumentType.IdentityCard);

        // Assert
        document.DocumentNumber.Should()
            .Be(documentNumber);

        document.DocumentType.Should()
            .Be(DocumentType.IdentityCard);
    }

    [TestMethod, DataRow(""), DataRow("  ")]
    public void Should_ThrowDocumentEmptyNumberException_When_DocumentNumberIsEmpty(string documentNumber)
    {
        // Arrange

        // Act
        var action = () => new Document(documentNumber, DocumentType.IdentityCard);

        // Assert
        action.Should()
            .Throw<DocumentEmptyNumberException>()
            .Where(exception => exception.Code == ErrorCodes.DOCUMENT_EMPTY_NUMBER);
    }
}
