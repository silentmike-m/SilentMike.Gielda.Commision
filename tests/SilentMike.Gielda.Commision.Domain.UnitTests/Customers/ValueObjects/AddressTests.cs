namespace SilentMike.Gielda.Commision.Domain.UnitTests.Customers.ValueObjects;

using SilentMike.Gielda.Commision.Domain.Customers.Constants;
using SilentMike.Gielda.Commision.Domain.Customers.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;

[TestClass]
public sealed class AddressTests
{
    [TestMethod]
    public void Should_CreateAddress()
    {
        // Arrange
        const string city = "New York";
        const string street = "123 Main St";
        const string zipCode = "78-113";

        // Act
        var address = new Address(city, street, zipCode);

        // Assert
        address.City.Should()
            .Be(city);

        address.Street.Should()
            .Be(street);

        address.ZipCode.Should()
            .Be(zipCode);
    }

    [TestMethod, DataRow(""), DataRow("  ")]
    public void Should_ThrowAddressEmptyCityException_When_AddressIsEmpty(string city)
    {
        // Arrange
        const string street = "123 Main St";
        const string zipCode = "78-113";

        // Act
        var action = () => new Address(city, street, zipCode);

        // Assert
        action.Should()
            .Throw<AddressEmptyCityException>()
            .Where(exception => exception.Code == ErrorCodes.ADDRESS_EMPTY_CITY);
    }

    [TestMethod, DataRow(""), DataRow("  ")]
    public void Should_ThrowAddressEmptyStreetException_When_AddressIsEmpty(string street)
    {
        // Arrange
        const string city = "New York";
        const string zipCode = "78-113";

        // Act
        var action = () => new Address(city, street, zipCode);

        // Assert
        action.Should()
            .Throw<AddressEmptyStreetException>()
            .Where(exception => exception.Code == ErrorCodes.ADDRESS_EMPTY_STREET);
    }

    [TestMethod, DataRow(""), DataRow("  ")]
    public void Should_ThrowAddressEmptyZipCodeException_When_AddressIsEmpty(string zipCode)
    {
        // Arrange
        const string city = "New York";
        const string street = "123 Main St";

        // Act
        var action = () => new Address(city, street, zipCode);

        // Assert
        action.Should()
            .Throw<AddressEmptyZipCodeException>()
            .Where(exception => exception.Code == ErrorCodes.ADDRESS_EMPTY_ZIP_CODE);
    }
}
