namespace SilentMike.Gielda.Commision.Application.UnitTests.Customers.Validators;

using Moq;
using SilentMike.Gielda.Commision.Application.Customers.Commands;
using SilentMike.Gielda.Commision.Application.Customers.Constants;
using SilentMike.Gielda.Commision.Application.Customers.Interfaces;
using SilentMike.Gielda.Commision.Application.Customers.Validators;
using SilentMike.Gielda.Commision.Domain.Types;

[TestClass]
public sealed class DeleteCustomerValidatorTests
{
    private readonly Mock<ICustomerValidationService> validationServiceMock = new();
    private readonly DeleteCustomerValidator validator;

    public DeleteCustomerValidatorTests()
        => this.validator = new DeleteCustomerValidator(this.validationServiceMock.Object);

    [TestMethod]
    public async Task Validation_Should_Fail_When_CustomerContractExists()
    {
        // Arrange
        var request = new DeleteCustomer
        {
            CustomerId = Guid.NewGuid(),
        };

        this.validationServiceMock
            .Setup(service => service.ContractExistsAsync(It.Is<CustomerId>(customerId => customerId.Value == request.CustomerId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(DeleteCustomer.CustomerId)
                && error.ErrorCode == ValidationErrorCodes.DELETE_CUSTOMER_WITH_EXISTSING_CONTRACT
                && error.ErrorMessage == ValidationErrorCodes.DELETE_CUSTOMER_WITH_EXISTSING_CONTRACT_MESSAGE
            );
    }

    [TestMethod]
    public async Task Validation_Should_Fail_When_CustomerIdIsEmpty()
    {
        // Arrange
        var request = new DeleteCustomer
        {
            CustomerId = Guid.Empty,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(DeleteCustomer.CustomerId)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_ID
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_ID_MESSAGE
            );
    }

    [TestMethod]
    public async Task Validation_Should_Pass()
    {
        // Arrange
        var request = new DeleteCustomer
        {
            CustomerId = Guid.NewGuid(),
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeTrue();
    }
}
