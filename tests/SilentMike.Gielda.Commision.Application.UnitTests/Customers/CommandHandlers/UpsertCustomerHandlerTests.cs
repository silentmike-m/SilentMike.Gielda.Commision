namespace SilentMike.Gielda.Commision.Application.UnitTests.Customers.CommandHandlers;

using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using SilentMike.Gielda.Commision.Application.Customers.CommandHandlers;
using SilentMike.Gielda.Commision.Application.Customers.Commands;
using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Customers.Enums;
using SilentMike.Gielda.Commision.Domain.Customers.Interfaces;
using SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;
using SilentMike.Gielda.Commision.Domain.Types;

[TestClass]
public sealed class UpsertCustomerHandlerTests
{
    private readonly Mock<ICustomerRepository> customerRepositoryMock = new();
    private readonly UpsertCustomerHandler handler;
    private readonly NullLogger<UpsertCustomerHandler> logger = new();

    public UpsertCustomerHandlerTests()
        => this.handler = new UpsertCustomerHandler(this.customerRepositoryMock.Object, this.logger);

    [TestMethod]
    public async Task Handle_Should_CreateCustomer_When_NotExists()
    {
        // Arrange
        CustomerEntity? createdCustomer = null;

        var request = new UpsertCustomer
        {
            City = "New York",
            DocumentNumber = "APX345678",
            DocumentType = DocumentType.IdentityCard,
            Email = "user@domain.com",
            FirstName = "John",
            Id = Guid.NewGuid(),
            LastName = "Doe",
            PhoneNumber = "691 874 259",
            Street = "23 Main Street",
            ZipCode = "78-113",
        };

        this.customerRepositoryMock
            .Setup(repository => repository.GetAsync(It.Is<CustomerId>(id => id.Value == request.Id), It.IsAny<CancellationToken>()))
            .ReturnsAsync((CustomerEntity?)null);

        this.customerRepositoryMock
            .Setup(repository => repository.AddAsync(It.IsAny<CustomerEntity>(), It.IsAny<CancellationToken>()))
            .Callback<CustomerEntity, CancellationToken>((customer, _) => createdCustomer = customer);

        // Act
        await this.handler.Handle(request, CancellationToken.None);

        // Assert
        var expectedCustomer = new CustomerEntity(
            request.Id,
            new Address(request.City, request.Street, request.ZipCode),
            new Contact(request.Email, request.PhoneNumber),
            new Document(request.DocumentNumber, request.DocumentType),
            request.FirstName,
            request.LastName
        );

        createdCustomer.Should()
            .NotBeNull()
            .And
            .BeEquivalentTo(expectedCustomer);
    }

    [TestMethod]
    public async Task Handle_Should_UpdateCustomer_When_Exists()
    {
        // Arrange
        var customer = new CustomerEntity(
            new CustomerId(Guid.NewGuid()),
            new Address("Old city", "old street", "old zip code"),
            new Contact("old@domain.com", "old phone"),
            new Document("APX23", DocumentType.DrivingLicense),
            "Old name",
            "Old last name"
        );

        var request = new UpsertCustomer
        {
            City = "New York",
            DocumentNumber = "APX345678",
            DocumentType = DocumentType.IdentityCard,
            Email = "user@domain.com",
            FirstName = "John",
            Id = customer.Id.Value,
            LastName = "Doe",
            PhoneNumber = "691 874 259",
            Street = "23 Main Street",
            ZipCode = "78-113",
        };

        this.customerRepositoryMock
            .Setup(repository => repository.GetAsync(It.Is<CustomerId>(id => id.Value == request.Id), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        // Act
        await this.handler.Handle(request, CancellationToken.None);

        // Assert
        this.customerRepositoryMock
            .Verify(repository => repository.UpdateAsync(customer, It.IsAny<CancellationToken>()), Times.Once);

        var expectedCustomer = new CustomerEntity(
            request.Id,
            new Address(request.City, request.Street, request.ZipCode),
            new Contact(request.Email, request.PhoneNumber),
            new Document(request.DocumentNumber, request.DocumentType),
            request.FirstName,
            request.LastName
        );

        customer.Should()
            .BeEquivalentTo(expectedCustomer);
    }
}
