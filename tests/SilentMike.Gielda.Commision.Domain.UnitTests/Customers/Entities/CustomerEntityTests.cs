namespace SilentMike.Gielda.Commision.Domain.UnitTests.Customers.Entities;

using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Customers.Enums;
using SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;

[TestClass]
public sealed class CustomerEntityTests
{
    [TestMethod, DataRow(""), DataRow("   ")]
    public void Set_LastName_Should_ThrowCustomerLastNameException_When_FirstNameIsEmpty(string lastName)
    {
        // Arrange

        // Act

        // Assert
        true.Should()
            .BeFalse();
    }

    [TestMethod]
    public void SetFirstName_Should_ChangeFirstName()
    {
        // Arrange
        const string firstName = "John";
        const string lastName = "Doe";

        var address = new Address("New York", "123 Main St", "78-113");
        var contact = new Contact("user@domain.com", "691 555 888");
        var document = new Document("APX34553", DocumentType.IdentityCard);
        var id = Guid.NewGuid();

        var customer = new CustomerEntity(id, address, contact, document, "old first name", lastName);

        // Act
        customer.SetFirstName(firstName);

        // Assert
        customer.Address.Should()
            .Be(address);

        customer.Document.Should()
            .Be(document);

        customer.FirstName.Should()
            .Be(firstName);

        customer.Id.Value.Should()
            .Be(id);

        customer.LastName.Should()
            .Be(lastName);

        customer.Contact.Should()
            .Be(contact);
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public void SetFirstName_Should_ThrowCustomerFirstNameException_When_FirstNameIsEmpty(string firstName)
    {
        // Arrange

        // Act

        // Assert
        true.Should()
            .BeFalse();
    }

    [TestMethod]
    public void SetLastName_ShouldChangeLastName()
    {
        // Arrange
        const string firstName = "John";
        const string lastName = "Doe";

        var address = new Address("New York", "123 Main St", "78-113");
        var contact = new Contact("user@domain.com", "691 555 888");
        var document = new Document("APX34553", DocumentType.IdentityCard);
        var id = Guid.NewGuid();

        var customer = new CustomerEntity(id, address, contact, document, firstName, "old last name");

        // Act
        customer.SetLastName(lastName);

        // Assert
        customer.Address.Should()
            .Be(address);

        customer.Document.Should()
            .Be(document);

        customer.FirstName.Should()
            .Be(firstName);

        customer.Id.Value.Should()
            .Be(id);

        customer.LastName.Should()
            .Be(lastName);

        customer.Contact.Should()
            .Be(contact);
    }

    [TestMethod]
    public void Should_CreateCustomer()
    {
        // Arrange
        const string firstName = "John";
        const string lastName = "Doe";

        var address = new Address("New York", "123 Main St", "78-113");
        var contact = new Contact("user@domain.com", "691 555 888");
        var document = new Document("APX34553", DocumentType.IdentityCard);
        var id = Guid.NewGuid();

        // Act
        var customer = new CustomerEntity(id, address, contact, document, firstName, lastName);

        // Assert
        customer.Address.Should()
            .Be(address);

        customer.Document.Should()
            .Be(document);

        customer.FirstName.Should()
            .Be(firstName);

        customer.Id.Value.Should()
            .Be(id);

        customer.LastName.Should()
            .Be(lastName);

        customer.Contact.Should()
            .Be(contact);
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public void Should_ThrowCustomerFirstNameException_When_FirstNameIsEmpty(string firstName)
    {
        // Arrange

        // Act

        // Assert
        true.Should()
            .BeFalse();
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public void Should_ThrowCustomerLastNameException_When_FirstNameIsEmpty(string lastName)
    {
        // Arrange

        // Act

        // Assert
        true.Should()
            .BeFalse();
    }
}
