namespace SilentMike.Gielda.Commision.Domain.UnitTests.Customers.ValueObjects;

using SilentMike.Gielda.Commision.Domain.Customers.Constants;
using SilentMike.Gielda.Commision.Domain.Customers.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;

[TestClass]
public sealed class ContactTests
{
    [TestMethod]
    public void Should_CreateContact()
    {
        // Arrange
        const string email = "user@domain.com";
        const string phoneNumber = "691 555 555";

        // Act
        var contact = new Contact(email, phoneNumber);

        // Assert
        contact.Email.Should()
            .Be(email);

        contact.PhoneNumber.Should()
            .Be(phoneNumber);
    }

    [TestMethod, DataRow("", ""), DataRow("  ", " ")]
    public void Should_ThrowContactEmptyException_When_EmailAndPhoneAreEmpty(string email, string phoneNumber)
    {
        // Arrange

        // Act
        var action = () => new Contact(email, phoneNumber);

        // Assert
        action.Should()
            .Throw<ContactEmptyException>()
            .Where(exception => exception.Code == ErrorCodes.CONTACT_EMPTY);
    }

    [TestMethod, DataRow("userdomain.com"), DataRow("user@domain")]
    public void Should_ThrowContactInvalidEmailFormatException_When_EmailHasWrongFormat(string email)
    {
        // Arrange
        const string phoneNumber = "691 555 555";

        // Act
        var action = () => new Contact(email, phoneNumber);

        // Assert
        action.Should()
            .Throw<ContactInvalidEmailFormatException>()
            .Where(exception => exception.Code == ErrorCodes.CONTACT_INVALID_EMAIL_FORMAT);
    }
}
