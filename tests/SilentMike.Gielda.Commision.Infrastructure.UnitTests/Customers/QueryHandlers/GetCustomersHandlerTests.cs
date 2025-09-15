﻿namespace SilentMike.Gielda.Commision.Infrastructure.UnitTests.Customers.QueryHandlers;

using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using SilentMike.Gielda.Commision.Application.Customers.Models;
using SilentMike.Gielda.Commision.Application.Customers.Queries;
using SilentMike.Gielda.Commision.Domain.Customers.Enums;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Models;
using SilentMike.Gielda.Commision.Infrastructure.Customers.QueryHandlers;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Services;

[TestClass]
public sealed class GetCustomersHandlerTests
{
    private static readonly CustomerReadModel READ_MODEL = new()
    {
        City = "New York",
        DocumentNumber = "APX23455",
        DocumentType = DocumentType.Other,
        Email = "user@domain.com",
        FirstName = "John",
        Id = Guid.NewGuid(),
        LastName = "Doe",
        PhoneNumber = "691 55 23 58",
        Street = "23 Main Street",
        ZipCode = "12345",
    };

    private static readonly CustomerDto EXPECTED_DTO = new()
    {
        City = READ_MODEL.City,
        DocumentNumber = READ_MODEL.DocumentNumber,
        DocumentType = READ_MODEL.DocumentType,
        Email = READ_MODEL.Email,
        FirstName = READ_MODEL.FirstName,
        Id = READ_MODEL.Id,
        LastName = READ_MODEL.LastName,
        PhoneNumber = READ_MODEL.PhoneNumber,
        Street = READ_MODEL.Street,
        ZipCode = READ_MODEL.ZipCode,
    };

    private readonly ICustomerMapper customerMapper = new CustomerMapper();
    private readonly Mock<ICustomerReadService> customerReadServiceMock = new();
    private readonly GetCustomersHandler handler;
    private readonly NullLogger<GetCustomerHandler> logger = new();

    public GetCustomersHandlerTests()
        => this.handler = new GetCustomersHandler(this.customerMapper, this.customerReadServiceMock.Object, this.logger);

    [TestMethod]
    public async Task Handle_Should_ReturnCustomersDto()
    {
        // Arrange
        var request = new GetCustomers();

        this.customerReadServiceMock
            .Setup(service => service.GetAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync([READ_MODEL]);

        // Act
        var result = await this.handler.Handle(request, CancellationToken.None);

        // assert
        result.Should()
            .HaveCount(1)
            .And
            .ContainEquivalentOf(EXPECTED_DTO);
    }

    [TestMethod]
    public async Task Handle_Should_ReturnEmptyList_When_MissingCustomers()
    {
        // Arrange
        var request = new GetCustomers();

        this.customerReadServiceMock
            .Setup(service => service.GetAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        // Act
        var result = await this.handler.Handle(request, CancellationToken.None);

        // assert
        result.Should()
            .BeEmpty();
    }
}
