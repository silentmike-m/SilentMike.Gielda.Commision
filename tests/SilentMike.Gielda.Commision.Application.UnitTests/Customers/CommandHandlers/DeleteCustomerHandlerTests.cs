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
public sealed class DeleteCustomerHandlerTests
{
    private readonly Mock<ICustomerRepository> customerRepositoryMock = new();
    private readonly DeleteCustomerHandler handler;
    private readonly NullLogger<DeleteCustomerHandler> logger = new();

    public DeleteCustomerHandlerTests()
        => this.handler = new DeleteCustomerHandler(this.customerRepositoryMock.Object, this.logger);

    [TestMethod]
    public async Task Handle_Should_DeleteCustomer()
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

        var request = new DeleteCustomer
        {
            CustomerId = customer.Id.Value,
        };

        this.customerRepositoryMock
            .Setup(repository => repository.GetAsync(It.Is<CustomerId>(id => id.Value == customer.Id.Value), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        // Act
        await this.handler.Handle(request, CancellationToken.None);

        // Assert
        this.customerRepositoryMock
            .Verify(repository => repository.DeleteAsync(customer, It.IsAny<CancellationToken>()), Times.Once);
    }

    [TestMethod]
    public async Task Handle_Should_NotThrowException_When_CustomerNotExists()
    {
        // Arrange
        var request = new DeleteCustomer
        {
            CustomerId = Guid.NewGuid(),
        };

        this.customerRepositoryMock
            .Setup(repository => repository.GetAsync(It.IsAny<CustomerId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((CustomerEntity?)null);

        // Act
        await this.handler.Handle(request, CancellationToken.None);

        // Assert
        this.customerRepositoryMock
            .Verify(repository => repository.DeleteAsync(It.IsAny<CustomerEntity>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}
